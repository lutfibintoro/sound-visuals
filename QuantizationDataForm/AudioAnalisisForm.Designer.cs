namespace QuantizationDataForm
{
    partial class AudioAnalisisForm
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
            this._viewSampleWAV = new System.Windows.Forms.Button();
            this._browseWAVButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this._pathWAVText = new System.Windows.Forms.TextBox();
            this._apply = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.visualPanel = new System.Windows.Forms.Panel();
            this.resetApplication = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _viewSampleWAV
            // 
            this._viewSampleWAV.Location = new System.Drawing.Point(16, 65);
            this._viewSampleWAV.Name = "_viewSampleWAV";
            this._viewSampleWAV.Size = new System.Drawing.Size(129, 52);
            this._viewSampleWAV.TabIndex = 0;
            this._viewSampleWAV.Text = "View WAV";
            this._viewSampleWAV.UseVisualStyleBackColor = true;
            this._viewSampleWAV.Click += new System.EventHandler(this.View_Click);
            // 
            // _browseWAVButton
            // 
            this._browseWAVButton.Location = new System.Drawing.Point(410, 31);
            this._browseWAVButton.Name = "_browseWAVButton";
            this._browseWAVButton.Size = new System.Drawing.Size(95, 35);
            this._browseWAVButton.TabIndex = 1;
            this._browseWAVButton.Text = "Browse";
            this._browseWAVButton.UseVisualStyleBackColor = true;
            this._browseWAVButton.Click += new System.EventHandler(this.Browse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "enter WAV path file";
            // 
            // _pathWAVText
            // 
            this._pathWAVText.Location = new System.Drawing.Point(16, 33);
            this._pathWAVText.Name = "_pathWAVText";
            this._pathWAVText.Size = new System.Drawing.Size(388, 26);
            this._pathWAVText.TabIndex = 3;
            // 
            // _apply
            // 
            this._apply.Location = new System.Drawing.Point(6, 270);
            this._apply.Name = "_apply";
            this._apply.Size = new System.Drawing.Size(95, 39);
            this._apply.TabIndex = 4;
            this._apply.Text = "Apply Style";
            this._apply.UseVisualStyleBackColor = true;
            this._apply.Click += new System.EventHandler(this.Apply_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkedListBox1);
            this.groupBox1.Controls.Add(this._apply);
            this.groupBox1.Location = new System.Drawing.Point(16, 123);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 315);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Plot Sytle";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "Signal Plot",
            "Marker Plot",
            "Lines Plot",
            "Filled Plot",
            "Line Axis",
            "Floating Axis",
            "Horizontal Step",
            "Vertikal Step",
            "Mouse Coordinates",
            "Background Navy"});
            this.checkedListBox1.Location = new System.Drawing.Point(6, 25);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(260, 257);
            this.checkedListBox1.TabIndex = 5;
            // 
            // visualPanel
            // 
            this.visualPanel.Location = new System.Drawing.Point(294, 96);
            this.visualPanel.Name = "visualPanel";
            this.visualPanel.Size = new System.Drawing.Size(494, 336);
            this.visualPanel.TabIndex = 6;
            // 
            // resetApplication
            // 
            this.resetApplication.Location = new System.Drawing.Point(151, 65);
            this.resetApplication.Name = "resetApplication";
            this.resetApplication.Size = new System.Drawing.Size(129, 52);
            this.resetApplication.TabIndex = 7;
            this.resetApplication.Text = "Restart App";
            this.resetApplication.UseVisualStyleBackColor = true;
            this.resetApplication.Click += new System.EventHandler(this.ResetApplication_Click);
            // 
            // AudioAnalisisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.resetApplication);
            this.Controls.Add(this.visualPanel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this._pathWAVText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._browseWAVButton);
            this.Controls.Add(this._viewSampleWAV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AudioAnalisisForm";
            this.Text = "AudioAnalisisForm";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _viewSampleWAV;
        private System.Windows.Forms.Button _browseWAVButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _pathWAVText;
        private System.Windows.Forms.Button _apply;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Panel visualPanel;
        private System.Windows.Forms.Button resetApplication;
    }
}