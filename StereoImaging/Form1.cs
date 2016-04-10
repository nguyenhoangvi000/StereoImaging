using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//Extra
using System.Threading;

//EMGU
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.Util;

//DiresctShow
using DirectShowLib;


namespace StereoImaging
{
    public partial class Form1 : Form
    {
        #region Devices
        Capture _Capture1;
        Capture _Capture2;
        #endregion
        
        #region Image Processing

        //Frames
        Image<Bgr, Byte> frame_S1;
        Image<Gray, Byte> Gray_frame_S1;
        Image<Bgr, Byte> frame_S2;
        Image<Gray, Byte> Gray_frame_S2;

        //Chessboard detection
        const int width = 9;//9 //width of chessboard no. squares in width - 1
        const int height = 6;//6 // heght of chess board no. squares in heigth - 1
        Size patternSize = new Size(width, height); //size of chess board to be detected
        Bgr[] line_colour_array = new Bgr[width * height]; // just for displaying coloured lines of detected chessboard
        PointF[] corners_Left;
        PointF[] corners_Right;
        bool start_Flag = true; //start straight away

        //buffers
        static int buffer_length = 100; //define the aquasition length of the buffer 
        int buffer_savepoint = 0; //tracks the filled partition of the buffer
        MCvPoint3D32f[][] corners_object_Points = new MCvPoint3D32f[buffer_length][]; //stores the calculated size for the chessboard
        PointF[][] corners_points_Left = new PointF[buffer_length][];//stores the calculated points from chessboard detection Camera 1
        PointF[][] corners_points_Right = new PointF[buffer_length][];//stores the calculated points from chessboard detection Camera 2

        //Calibration parmeters
        IntrinsicCameraParameters IntrinsicCam1 = new IntrinsicCameraParameters(); //Camera 1
        IntrinsicCameraParameters IntrinsicCam2 = new IntrinsicCameraParameters(); //Camera 2
        ExtrinsicCameraParameters EX_Param; //Output of Extrinsics for Camera 1 & 2
        Matrix<double> fundamental; //fundemental output matrix for StereoCalibrate
        Matrix<double> essential; //essential output matrix for StereoCalibrate
        Rectangle Rec1 = new Rectangle(); //Rectangle Calibrated in camera 1
        Rectangle Rec2 = new Rectangle(); //Rectangle Caliubrated in camera 2
        Matrix<double> Q = new Matrix<double>(4, 4); //This is what were interested in the disparity-to-depth mapping matrix
        Matrix<double> R1 = new Matrix<double>(3, 3); //rectification transforms (rotation matrices) for Camera 1.
        Matrix<double> R2 = new Matrix<double>(3, 3); //rectification transforms (rotation matrices) for Camera 1.
        Matrix<double> P1 = new Matrix<double>(3, 4); //projection matrices in the new (rectified) coordinate systems for Camera 1.
        Matrix<double> P2 = new Matrix<double>(3, 4); //projection matrices in the new (rectified) coordinate systems for Camera 2.
        private MCvPoint3D32f[] _points; //Computer3DPointsFromStereoPair
        #endregion
        
        #region Current mode variables
        public enum Mode
        {
            Caluculating_Stereo_Intrinsics,
            Calibrated,
            SavingFrames
        }
        Mode currentMode = Mode.SavingFrames;
        #endregion
        public Form1()
        {
            InitializeComponent();

            //set up chessboard drawing array
            Random R = new Random();
            for (int i = 0; i < line_colour_array.Length; i++)
            {
                line_colour_array[i] = new Bgr(R.Next(0, 255), R.Next(0, 255), R.Next(0, 255));
            }

            //Set up the capture method 

            //-> Find systems cameras with DirectShow.Net dll
            //thanks to carles lloret
            DsDevice[] _SystemCamereas = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);
            Video_Device[] WebCams = new Video_Device[_SystemCamereas.Length];
            for (int i = 0; i < _SystemCamereas.Length; i++) WebCams[i] = new Video_Device(i, _SystemCamereas[i].Name, _SystemCamereas[i].ClassID);
            
            //check to see what video inputs we have available
            if (WebCams.Length < 2)
            {
                if (WebCams.Length == 0) throw new InvalidOperationException("A camera device was not detected");
                MessageBox.Show("Only 1 camera detected. Stero Imaging can not be emulated");
            }
            else if (WebCams.Length >= 2)
            {
                if (WebCams.Length > 2) MessageBox.Show("More than 2 cameras detected. Stero Imaging will be performed using " + WebCams[0].Device_Name + " and " + WebCams[1].Device_Name);
                _Capture1 = new Capture(WebCams[0].Device_ID);
                _Capture2 = new Capture(WebCams[1].Device_ID);
                //We will only use 1 frame ready event this is not really safe but it fits the purpose
                _Capture1.ImageGrabbed += ProcessFrame;
                //_Capture2.Start(); //We make sure we start Capture device 2 first
                _Capture1.Start();
            }
        }

        /// <summary>
        /// Is called to process frame from camera
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void ProcessFrame(object sender, EventArgs arg)
        {
            #region Frame Aquasition
            //Aquire the frames or calculate two frames from one camera
            frame_S1 = _Capture1.RetrieveBgrFrame();
            Gray_frame_S1 = frame_S1.Convert<Gray,Byte>();
            frame_S2 = _Capture2.RetrieveBgrFrame();
            Gray_frame_S2 = frame_S2.Convert<Gray,Byte>();
            #endregion

            #region Saving Chessboard Corners in Buffer
            if (currentMode == Mode.SavingFrames)
            {
                //Find the chessboard in bothe images
                corners_Left = CameraCalibration.FindChessboardCorners(Gray_frame_S1, patternSize, Emgu.CV.CvEnum.CALIB_CB_TYPE.ADAPTIVE_THRESH);
                corners_Right = CameraCalibration.FindChessboardCorners(Gray_frame_S2, patternSize, Emgu.CV.CvEnum.CALIB_CB_TYPE.ADAPTIVE_THRESH);

                //we use this loop so we can show a colour image rather than a gray: //CameraCalibration.DrawChessboardCorners(Gray_Frame, patternSize, corners);
                //we we only do this is the chessboard is present in both images
                if (corners_Left != null && corners_Right != null) //chess board found in one of the frames?
                {
                    //make mesurments more accurate by using FindCornerSubPixel
                    Gray_frame_S1.FindCornerSubPix(new PointF[1][] { corners_Left }, new Size(11, 11), new Size(-1, -1), new MCvTermCriteria(30, 0.01));
                    Gray_frame_S2.FindCornerSubPix(new PointF[1][] { corners_Right }, new Size(11, 11), new Size(-1, -1), new MCvTermCriteria(30, 0.01));

                    //if go button has been pressed start aquiring frames else we will just display the points
                    if (start_Flag)
                    {
                        //save the calculated points into an array
                        corners_points_Left[buffer_savepoint] = corners_Left;
                        corners_points_Right[buffer_savepoint] = corners_Right;
                        buffer_savepoint++;//increase buffer positon

                        //check the state of buffer
                        if (buffer_savepoint == buffer_length) currentMode = Mode.Caluculating_Stereo_Intrinsics; //buffer full

                        //Show state of Buffer
                        UpdateTitle("Form1: Buffer " + buffer_savepoint.ToString() + " of " + buffer_length.ToString());
                    }

                    //draw the results
                    frame_S1.Draw(new CircleF(corners_Left[0], 3), new Bgr(Color.Yellow), 1);
                    frame_S2.Draw(new CircleF(corners_Right[0], 3), new Bgr(Color.Yellow), 1);
                    for(int i = 1; i<corners_Left.Length; i++)
                    {
                        //left
                        frame_S1.Draw(new LineSegment2DF(corners_Left[i - 1], corners_Left[i]), line_colour_array[i], 2);
                        frame_S1.Draw(new CircleF(corners_Left[i], 3), new Bgr(Color.Yellow), 1);
                        //right
                        frame_S2.Draw(new LineSegment2DF(corners_Right[i - 1], corners_Right[i]), line_colour_array[i], 2);
                        frame_S2.Draw(new CircleF(corners_Right[i], 3), new Bgr(Color.Yellow), 1);
                    }
                    //calibrate the delay bassed on size of buffer
                    //if buffer small you want a big delay if big small delay
                    Thread.Sleep(100);//allow the user to move the board to a different position
                }
                corners_Left = null;
                corners_Right = null;
            }
            #endregion
            #region Calculating Stereo Cameras Relationship
            if (currentMode == Mode.Caluculating_Stereo_Intrinsics)
            {
                //fill the MCvPoint3D32f with correct mesurments
                for (int k = 0; k < buffer_length; k++)
                {
                    //Fill our objects list with the real world mesurments for the intrinsic calculations
                    List<MCvPoint3D32f> object_list = new List<MCvPoint3D32f>();
                    for (int i = 0; i < height; i++)
                    {
                        for (int j = 0; j < width; j++)
                        {
                            object_list.Add(new MCvPoint3D32f(j * 20.0F, i * 20.0F, 0.0F));
                        }
                    }
                    corners_object_Points[k] = object_list.ToArray();
                }
                //If Emgu.CV.CvEnum.CALIB_TYPE == CV_CALIB_USE_INTRINSIC_GUESS and/or CV_CALIB_FIX_ASPECT_RATIO are specified, some or all of fx, fy, cx, cy must be initialized before calling the function
                //if you use FIX_ASPECT_RATIO and FIX_FOCAL_LEGNTH options, these values needs to be set in the intrinsic parameters before the CalibrateCamera function is called. Otherwise 0 values are used as default.
                CameraCalibration.StereoCalibrate(corners_object_Points, corners_points_Left, corners_points_Right, IntrinsicCam1, IntrinsicCam2, frame_S1.Size,
                                                                 Emgu.CV.CvEnum.CALIB_TYPE.DEFAULT, new MCvTermCriteria(0.1e5), 
                                                                 out EX_Param, out fundamental, out essential);
                MessageBox.Show("Intrinsic Calculation Complete"); //display that the mothod has been succesful
                //currentMode = Mode.Calibrated;

                //Computes rectification transforms for each head of a calibrated stereo camera.
                CvInvoke.cvStereoRectify(IntrinsicCam1.IntrinsicMatrix, IntrinsicCam2.IntrinsicMatrix,
                                         IntrinsicCam1.DistortionCoeffs, IntrinsicCam2.DistortionCoeffs,
                                         frame_S1.Size,
                                         EX_Param.RotationVector.RotationMatrix, EX_Param.TranslationVector,
                                         R1, R2, P1, P2, Q,
                                         Emgu.CV.CvEnum.STEREO_RECTIFY_TYPE.DEFAULT, 0,
                                         frame_S1.Size, ref Rec1, ref Rec2);

                //This will Show us the usable area from each camera
                MessageBox.Show("Left: " + Rec1.ToString() +  " \nRight: " + Rec2.ToString());
                currentMode = Mode.Calibrated;

            }
            #endregion
            #region Caluclating disparity map after calibration
            if (currentMode == Mode.Calibrated)
            {
                Image<Gray, short> disparityMap;

                Computer3DPointsFromStereoPair(Gray_frame_S1, Gray_frame_S2, out disparityMap, out _points);

                //Display the disparity map
                DisparityMap.Image = disparityMap.ToBitmap();
                //Draw the accurate area
                frame_S1.Draw(Rec1, new Bgr(Color.LimeGreen), 1);
                frame_S2.Draw(Rec2, new Bgr(Color.LimeGreen), 1);
            }
            #endregion
            //display image
            Video_Source1.Image = frame_S1.ToBitmap();
            Video_Source2.Image = frame_S2.ToBitmap();


        }

        /// <summary>
        /// Given the left and right image, computer the disparity map and the 3D point cloud.
        /// </summary>
        /// <param name="left">The left image</param>
        /// <param name="right">The right image</param>
        /// <param name="disparityMap">The left disparity map</param>
        /// <param name="points">The 3D point cloud within a [-0.5, 0.5] cube</param>
        private void Computer3DPointsFromStereoPair(Image<Gray, Byte> left, Image<Gray, Byte> right, out Image<Gray, short> disparityMap, out MCvPoint3D32f[] points)
        {
            Size size = left.Size;

            disparityMap = new Image<Gray, short>(size);
            //thread safe calibration values


            /*This is maximum disparity minus minimum disparity. Always greater than 0. In the current implementation this parameter must be divisible by 16.*/
            int numDisparities = GetSliderValue(Num_Disparities);

            /*The minimum possible disparity value. Normally it is 0, but sometimes rectification algorithms can shift images, so this parameter needs to be adjusted accordingly*/
            int minDispatities = GetSliderValue(Min_Disparities);

            /*The matched block size. Must be an odd number >=1 . Normally, it should be somewhere in 3..11 range*/
            int SAD = GetSliderValue(SAD_Window);

            /*P1, P2 – Parameters that control disparity smoothness. The larger the values, the smoother the disparity. 
             * P1 is the penalty on the disparity change by plus or minus 1 between neighbor pixels. 
             * P2 is the penalty on the disparity change by more than 1 between neighbor pixels. 
             * The algorithm requires P2 > P1 . 
             * See stereo_match.cpp sample where some reasonably good P1 and P2 values are shown 
             * (like 8*number_of_image_channels*SADWindowSize*SADWindowSize and 32*number_of_image_channels*SADWindowSize*SADWindowSize , respectively).*/

            int P1 = 8 * 1 * SAD * SAD;//GetSliderValue(P1_Slider);
            int P2 = 32 * 1 * SAD * SAD;//GetSliderValue(P2_Slider);

            /* Maximum allowed difference (in integer pixel units) in the left-right disparity check. Set it to non-positive value to disable the check.*/
            int disp12MaxDiff = GetSliderValue(Disp12MaxDiff);

            /*Truncation value for the prefiltered image pixels. 
             * The algorithm first computes x-derivative at each pixel and clips its value by [-preFilterCap, preFilterCap] interval. 
             * The result values are passed to the Birchfield-Tomasi pixel cost function.*/
            int PreFilterCap = GetSliderValue(pre_filter_cap);

            /*The margin in percents by which the best (minimum) computed cost function value should “win” the second best value to consider the found match correct. 
             * Normally, some value within 5-15 range is good enough*/
            int UniquenessRatio = GetSliderValue(uniquenessRatio);

            /*Maximum disparity variation within each connected component. 
             * If you do speckle filtering, set it to some positive value, multiple of 16. 
             * Normally, 16 or 32 is good enough*/
            int Speckle = GetSliderValue(Speckle_Window);

            /*Maximum disparity variation within each connected component. If you do speckle filtering, set it to some positive value, multiple of 16. Normally, 16 or 32 is good enough.*/
            int SpeckleRange = GetSliderValue(specklerange);

            /*Set it to true to run full-scale 2-pass dynamic programming algorithm. It will consume O(W*H*numDisparities) bytes, 
             * which is large for 640x480 stereo and huge for HD-size pictures. By default this is usually false*/
            //Set globally for ease
            //bool fullDP = true;

            using (StereoSGBM stereoSolver = new StereoSGBM(minDispatities, numDisparities, SAD, P1, P2, disp12MaxDiff, PreFilterCap, UniquenessRatio, Speckle, SpeckleRange, fullDP))
            //using (StereoBM stereoSolver = new StereoBM(Emgu.CV.CvEnum.STEREO_BM_TYPE.BASIC, 0))
            {
                stereoSolver.FindStereoCorrespondence(left, right, disparityMap);//Computes the disparity map using: 
                /*GC: graph cut-based algorithm
                  BM: block matching algorithm
                  SGBM: modified H. Hirschmuller algorithm HH08*/
                points = PointCollection.ReprojectImageTo3D(disparityMap, Q); //Reprojects disparity image to 3D space.
            }
        }


        #region Window/Form Control
        /// <summary>
        /// Thread safe method to get a slider value from form
        /// </summary>
        /// <param name="Control"></param>
        /// <returns></returns>
        private delegate int GetSlideValueDelgate(TrackBar Control);
        private int GetSliderValue(TrackBar Control)
        {
            if (Control.InvokeRequired)
            {
                try
                {
                    return (int)Control.Invoke(new Func<int>(() => GetSliderValue(Control)));
                }
                catch(Exception ex)
                {
                    return 0;
                }
            }
            else
            {
                return Control.Value;
            }
        }

        private delegate void UpateTitleDelgate(String Text);
        private void UpdateTitle(String Text)
        {
            if (this.InvokeRequired)
            {
                try
                {
                    // update title asynchronously
                    UpateTitleDelgate ut = new UpateTitleDelgate(UpdateTitle); 
                    //if (this.IsHandleCreated && !this.IsDisposed)
                    this.BeginInvoke(ut, new object[] { Text });
                }
                catch (Exception ex)
                {
                }
            }
            else
            {
                this.Text = Text;
            }
        }

        /// <summary>
        /// The matched block size. Must be an odd number >=1 . Normally, it should be somewhere in 3..11 range
        /// Each time the slider moves the value is checked and made odd if even
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SAD_Window_Scroll(object sender, EventArgs e)
        {
            /*The matched block size. Must be an odd number >=1 . Normally, it should be somewhere in 3..11 range*/
            //This ensures only odd numbers are allowed from slider value
            if (SAD_Window.Value % 2 == 0)
            {
                if (SAD_Window.Value == SAD_Window.Maximum) SAD_Window.Value = SAD_Window.Maximum - 2;
                else SAD_Window.Value++;
            } 
        }

        /// <summary>
        /// This is maximum disparity minus minimum disparity. Always greater than 0. In the current implementation this parameter must be divisible by 16.
        /// Each time the slider moves the value is checked and made a factor of 16
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Num_Disparities_Scroll(object sender, EventArgs e)
        {

            if (Num_Disparities.Value % 16 != 0)
            {
                //value must be divisable by 16
                if (Num_Disparities.Value >= 152) Num_Disparities.Value = 160;
                else if (Num_Disparities.Value >= 136) Num_Disparities.Value = 144;
                else if (Num_Disparities.Value >= 120) Num_Disparities.Value = 128;
                else if (Num_Disparities.Value >= 104) Num_Disparities.Value = 112;
                else if (Num_Disparities.Value >= 88) Num_Disparities.Value = 96;
                else if (Num_Disparities.Value >= 72) Num_Disparities.Value = 80;
                else if (Num_Disparities.Value >= 56) Num_Disparities.Value = 64;
                else if (Num_Disparities.Value >= 40) Num_Disparities.Value = 48;
                else if (Num_Disparities.Value >= 24) Num_Disparities.Value = 32;
                else Num_Disparities.Value = 16;
            }
        }

        /// <summary>
        /// Maximum disparity variation within each connected component. If you do speckle filtering, set it to some positive value, multiple of 16. Normally, 16 or 32 is good enough.
        /// Each time the slider moves the value is checked and made a factor of 16
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void specklerange_Scroll(object sender, EventArgs e)
        {
            if (specklerange.Value % 16 != 0)
            {
                //value must be divisable by 16
                //TODO: we can do this in a loop
                if (specklerange.Value >= 152) specklerange.Value = 160;
                else if (specklerange.Value >= 136) specklerange.Value = 144;
                else if (specklerange.Value >= 120) specklerange.Value = 128;
                else if (specklerange.Value >= 104) specklerange.Value = 112;
                else if (specklerange.Value >= 88) specklerange.Value = 96;
                else if (specklerange.Value >= 72) specklerange.Value = 80;
                else if (specklerange.Value >= 56) specklerange.Value = 64;
                else if (specklerange.Value >= 40) specklerange.Value = 48;
                else if (specklerange.Value >= 24) specklerange.Value = 32;
                else if (specklerange.Value >= 8) specklerange.Value = 16;
                else specklerange.Value = 0;
            }
        }

        /// <summary>
        /// Sets the state of fulldp in the StereoSGBM algorithm allowing full-scale 2-pass dynamic programming algorithm. 
        /// It will consume O(W*H*numDisparities) bytes, which is large for 640x480 stereo and huge for HD-size pictures. By default this is false
        /// </summary>
        bool fullDP = false;
        private void fullDP_State_Click(object sender, EventArgs e)
        {
            if (fullDP_State.Text == "True")
            {
                fullDP = false;
                fullDP_State.Text = "False";
            }
            else
            {
                fullDP = true;
                fullDP_State.Text = "True";
            }
        }

        /// <summary>
        /// Overide form closing event to release cameras
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosing(CancelEventArgs e)
        {
            if (_Capture1 != null) _Capture1.Dispose();
            if (_Capture2 != null) _Capture2.Dispose();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            OnClosing(null);
        }
        #endregion
    }
}

/// <summary>
/// Structure to Store Information about Video Devices
/// </summary>
struct Video_Device
{
    public string Device_Name;
    public int Device_ID;
    public Guid Identifier;

    public Video_Device(int ID, string Name, Guid Identity = new Guid())
    {
        Device_ID = ID;
        Device_Name = Name;
        Identifier = Identity;
    }

    // <summary>
    /// Represent the Device as a String
    /// </summary>H:\Live Mesh\Visual Studio 2010\Projects\Examples\EMGU x64\Emgu.CV.Example\CameraCapture V2.0\Structures.cs
    /// <returns>The string representation of this color</returns>
    public override string ToString()
    {
        return String.Format("[{0} {1}:{2}]", Device_ID, Device_Name, Identifier);
    }
}