namespace Zerg_Rush
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
            this.components = new System.ComponentModel.Container();
            this.defaultalienPicture = new System.Windows.Forms.PictureBox();
            this.runTicker = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.defaultalienPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // defaultalienPicture
            // 
            this.defaultalienPicture.Image = global::Zerg_Rush.Properties.Resources.f3b38e0625012600f8c71693e75443dc526c1;
            this.defaultalienPicture.Location = new System.Drawing.Point(62, 30);
            this.defaultalienPicture.Name = "defaultalienPicture";
            this.defaultalienPicture.Size = new System.Drawing.Size(30, 25);
            this.defaultalienPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.defaultalienPicture.TabIndex = 0;
            this.defaultalienPicture.TabStop = false;
            this.defaultalienPicture.Visible = false;
            this.defaultalienPicture.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // runTicker
            // 
            this.runTicker.Tick += new System.EventHandler(this.runTicker_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(924, 481);
            this.Controls.Add(this.defaultalienPicture);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.defaultalienPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox defaultalienPicture;
        private System.Windows.Forms.Timer runTicker;
    }
}

