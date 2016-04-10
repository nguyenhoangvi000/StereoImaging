namespace StereoImaging
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Video_Source2 = new System.Windows.Forms.PictureBox();
            this.Video_Source1 = new System.Windows.Forms.PictureBox();
            this.DisparityMap = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.fullDP_State = new System.Windows.Forms.Button();
            this.specklerange = new System.Windows.Forms.TrackBar();
            this.label9 = new System.Windows.Forms.Label();
            this.uniquenessRatio = new System.Windows.Forms.TrackBar();
            this.label8 = new System.Windows.Forms.Label();
            this.pre_filter_cap = new System.Windows.Forms.TrackBar();
            this.label7 = new System.Windows.Forms.Label();
            this.Speckle_Window = new System.Windows.Forms.TrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.SAD_Window = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Disp12MaxDiff = new System.Windows.Forms.TrackBar();
            this.Num_Disparities = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Min_Disparities = new System.Windows.Forms.TrackBar();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Video_Source2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Video_Source1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisparityMap)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.specklerange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uniquenessRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pre_filter_cap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Speckle_Window)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SAD_Window)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Disp12MaxDiff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_Disparities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Min_Disparities)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.Video_Source2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.Video_Source1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.DisparityMap, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(973, 717);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Video_Source2
            // 
            this.Video_Source2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Video_Source2.Location = new System.Drawing.Point(489, 3);
            this.Video_Source2.Name = "Video_Source2";
            this.Video_Source2.Size = new System.Drawing.Size(481, 352);
            this.Video_Source2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Video_Source2.TabIndex = 1;
            this.Video_Source2.TabStop = false;
            // 
            // Video_Source1
            // 
            this.Video_Source1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Video_Source1.Location = new System.Drawing.Point(3, 3);
            this.Video_Source1.Name = "Video_Source1";
            this.Video_Source1.Size = new System.Drawing.Size(480, 352);
            this.Video_Source1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Video_Source1.TabIndex = 0;
            this.Video_Source1.TabStop = false;
            // 
            // DisparityMap
            // 
            this.DisparityMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DisparityMap.Location = new System.Drawing.Point(489, 361);
            this.DisparityMap.Name = "DisparityMap";
            this.DisparityMap.Size = new System.Drawing.Size(481, 353);
            this.DisparityMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.DisparityMap.TabIndex = 2;
            this.DisparityMap.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.fullDP_State);
            this.panel1.Controls.Add(this.specklerange);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.uniquenessRatio);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.pre_filter_cap);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.Speckle_Window);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.SAD_Window);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.Disp12MaxDiff);
            this.panel1.Controls.Add(this.Num_Disparities);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Min_Disparities);
            this.panel1.Location = new System.Drawing.Point(3, 361);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(480, 353);
            this.panel1.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(72, 466);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 16);
            this.label10.TabIndex = 21;
            this.label10.Text = "FullDP:";
            // 
            // fullDP_State
            // 
            this.fullDP_State.Location = new System.Drawing.Point(136, 459);
            this.fullDP_State.Name = "fullDP_State";
            this.fullDP_State.Size = new System.Drawing.Size(313, 30);
            this.fullDP_State.TabIndex = 20;
            this.fullDP_State.Text = "False";
            this.fullDP_State.UseVisualStyleBackColor = true;
            this.fullDP_State.Click += new System.EventHandler(this.fullDP_State_Click);
            // 
            // specklerange
            // 
            this.specklerange.Location = new System.Drawing.Point(136, 415);
            this.specklerange.Maximum = 160;
            this.specklerange.Name = "specklerange";
            this.specklerange.Size = new System.Drawing.Size(313, 45);
            this.specklerange.TabIndex = 19;
            this.specklerange.TickFrequency = 16;
            this.specklerange.Scroll += new System.EventHandler(this.specklerange_Scroll);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(11, 415);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(119, 16);
            this.label9.TabIndex = 18;
            this.label9.Text = "Speckle Range:";
            // 
            // uniquenessRatio
            // 
            this.uniquenessRatio.Location = new System.Drawing.Point(136, 316);
            this.uniquenessRatio.Maximum = 30;
            this.uniquenessRatio.Name = "uniquenessRatio";
            this.uniquenessRatio.Size = new System.Drawing.Size(313, 45);
            this.uniquenessRatio.TabIndex = 17;
            this.uniquenessRatio.TickFrequency = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(43, 316);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 16);
            this.label8.TabIndex = 16;
            this.label8.Text = "Uniqueness:";
            // 
            // pre_filter_cap
            // 
            this.pre_filter_cap.Location = new System.Drawing.Point(136, 265);
            this.pre_filter_cap.Maximum = 1000;
            this.pre_filter_cap.Name = "pre_filter_cap";
            this.pre_filter_cap.Size = new System.Drawing.Size(313, 45);
            this.pre_filter_cap.TabIndex = 15;
            this.pre_filter_cap.TickFrequency = 100;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(55, 265);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 16);
            this.label7.TabIndex = 14;
            this.label7.Text = "Pre Filter:";
            // 
            // Speckle_Window
            // 
            this.Speckle_Window.Location = new System.Drawing.Point(136, 364);
            this.Speckle_Window.Maximum = 64;
            this.Speckle_Window.Name = "Speckle_Window";
            this.Speckle_Window.Size = new System.Drawing.Size(313, 45);
            this.Speckle_Window.TabIndex = 13;
            this.Speckle_Window.TickFrequency = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 364);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Speckle Window:";
            // 
            // SAD_Window
            // 
            this.SAD_Window.Location = new System.Drawing.Point(136, 163);
            this.SAD_Window.Maximum = 19;
            this.SAD_Window.Minimum = 1;
            this.SAD_Window.Name = "SAD_Window";
            this.SAD_Window.Size = new System.Drawing.Size(313, 45);
            this.SAD_Window.SmallChange = 2;
            this.SAD_Window.TabIndex = 11;
            this.SAD_Window.TickFrequency = 2;
            this.SAD_Window.Value = 1;
            this.SAD_Window.Scroll += new System.EventHandler(this.SAD_Window_Scroll);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(29, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "SAD Window:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(59, 214);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Max Diff :";
            // 
            // Disp12MaxDiff
            // 
            this.Disp12MaxDiff.Location = new System.Drawing.Point(136, 214);
            this.Disp12MaxDiff.Maximum = 100;
            this.Disp12MaxDiff.Minimum = -1;
            this.Disp12MaxDiff.Name = "Disp12MaxDiff";
            this.Disp12MaxDiff.Size = new System.Drawing.Size(313, 45);
            this.Disp12MaxDiff.TabIndex = 8;
            this.Disp12MaxDiff.TickFrequency = 10;
            this.Disp12MaxDiff.Value = -1;
            // 
            // Num_Disparities
            // 
            this.Num_Disparities.Location = new System.Drawing.Point(136, 61);
            this.Num_Disparities.Maximum = 160;
            this.Num_Disparities.Minimum = 16;
            this.Num_Disparities.Name = "Num_Disparities";
            this.Num_Disparities.Size = new System.Drawing.Size(313, 45);
            this.Num_Disparities.TabIndex = 7;
            this.Num_Disparities.TickFrequency = 16;
            this.Num_Disparities.Value = 64;
            this.Num_Disparities.Scroll += new System.EventHandler(this.Num_Disparities_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(43, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Disparities:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Min Disparities:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(180, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Calibration";
            // 
            // Min_Disparities
            // 
            this.Min_Disparities.Location = new System.Drawing.Point(136, 112);
            this.Min_Disparities.Maximum = 159;
            this.Min_Disparities.Name = "Min_Disparities";
            this.Min_Disparities.Size = new System.Drawing.Size(313, 45);
            this.Min_Disparities.TabIndex = 0;
            this.Min_Disparities.TickFrequency = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 741);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Video_Source2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Video_Source1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisparityMap)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.specklerange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uniquenessRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pre_filter_cap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Speckle_Window)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SAD_Window)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Disp12MaxDiff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_Disparities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Min_Disparities)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox Video_Source2;
        private System.Windows.Forms.PictureBox Video_Source1;
        private System.Windows.Forms.PictureBox DisparityMap;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar Min_Disparities;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar Num_Disparities;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar Disp12MaxDiff;
        private System.Windows.Forms.TrackBar SAD_Window;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar Speckle_Window;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar pre_filter_cap;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TrackBar uniquenessRatio;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TrackBar specklerange;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button fullDP_State;
    }
}

