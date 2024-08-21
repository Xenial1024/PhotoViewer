namespace PhotoViewer
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            this.pbDisplay = new System.Windows.Forms.PictureBox();
            this.btnOpenImage = new System.Windows.Forms.Button();
            this.btnStopViewingImage = new System.Windows.Forms.Button();
            this.ofdOpenImage = new System.Windows.Forms.OpenFileDialog();
            this.btnManual = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnNextImage = new System.Windows.Forms.Button();
            this.btnPreviousImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // pbDisplay
            // 
            this.pbDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbDisplay.Location = new System.Drawing.Point(12, 51);
            this.pbDisplay.Name = "pbDisplay";
            this.pbDisplay.Size = new System.Drawing.Size(776, 387);
            this.pbDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbDisplay.TabIndex = 0;
            this.pbDisplay.TabStop = false;
            // 
            // btnOpenImage
            // 
            this.btnOpenImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnOpenImage.Location = new System.Drawing.Point(12, 12);
            this.btnOpenImage.Name = "btnOpenImage";
            this.btnOpenImage.Size = new System.Drawing.Size(101, 32);
            this.btnOpenImage.TabIndex = 1;
            this.btnOpenImage.Text = "Wybierz";
            this.btnOpenImage.UseVisualStyleBackColor = true;
            this.btnOpenImage.Click += new System.EventHandler(this.BtnOpenImage_Click);
            // 
            // btnStopViewingImage
            // 
            this.btnStopViewingImage.Enabled = false;
            this.btnStopViewingImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnStopViewingImage.Location = new System.Drawing.Point(334, 12);
            this.btnStopViewingImage.Name = "btnStopViewingImage";
            this.btnStopViewingImage.Size = new System.Drawing.Size(105, 32);
            this.btnStopViewingImage.TabIndex = 2;
            this.btnStopViewingImage.Text = "Wyczyść";
            this.btnStopViewingImage.UseVisualStyleBackColor = true;
            this.btnStopViewingImage.Click += new System.EventHandler(this.BtnStopViewingImage_Click);
            // 
            // ofdOpenImage
            // 
            this.ofdOpenImage.FileName = "ImagePath";
            // 
            // btnManual
            // 
            this.btnManual.Image = global::PhotoViewer.Properties.Resources.info_icon_32;
            this.btnManual.Location = new System.Drawing.Point(445, 12);
            this.btnManual.Name = "btnManual";
            this.btnManual.Size = new System.Drawing.Size(32, 32);
            this.btnManual.TabIndex = 3;
            this.toolTip1.SetToolTip(this.btnManual, "instrukcja obsługi");
            this.btnManual.UseVisualStyleBackColor = true;
            this.btnManual.Click += new System.EventHandler(this.BtnManual_Click);
            // 
            // btnNextImage
            // 
            this.btnNextImage.Enabled = false;
            this.btnNextImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnNextImage.Location = new System.Drawing.Point(237, 12);
            this.btnNextImage.Name = "btnNextImage";
            this.btnNextImage.Size = new System.Drawing.Size(91, 32);
            this.btnNextImage.TabIndex = 2;
            this.btnNextImage.Text = "Kolejny";
            this.btnNextImage.UseVisualStyleBackColor = true;
            this.btnNextImage.Click += new System.EventHandler(this.BtnNextImage_Click);
            // 
            // btnPreviousImage
            // 
            this.btnPreviousImage.Enabled = false;
            this.btnPreviousImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnPreviousImage.Location = new System.Drawing.Point(119, 12);
            this.btnPreviousImage.Name = "btnPreviousImage";
            this.btnPreviousImage.Size = new System.Drawing.Size(112, 32);
            this.btnPreviousImage.TabIndex = 2;
            this.btnPreviousImage.Text = "Poprzedni";
            this.btnPreviousImage.UseVisualStyleBackColor = true;
            this.btnPreviousImage.Click += new System.EventHandler(this.BtnPreviousImage_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnManual);
            this.Controls.Add(this.btnPreviousImage);
            this.Controls.Add(this.btnNextImage);
            this.Controls.Add(this.btnStopViewingImage);
            this.Controls.Add(this.btnOpenImage);
            this.Controls.Add(this.pbDisplay);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pbDisplay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbDisplay;
        private System.Windows.Forms.Button btnOpenImage;
        private System.Windows.Forms.Button btnStopViewingImage;
        private System.Windows.Forms.OpenFileDialog ofdOpenImage;
        private System.Windows.Forms.Button btnManual;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnNextImage;
        private System.Windows.Forms.Button btnPreviousImage;
    }
}

