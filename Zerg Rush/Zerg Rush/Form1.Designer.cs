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
            this.runTicker = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.spaceship = new System.Windows.Forms.PictureBox();
            this.defaultalienPicture = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.spaceship)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.defaultalienPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // runTicker
            // 
            this.runTicker.Interval = 10;
            this.runTicker.Tick += new System.EventHandler(this.runTicker_Tick);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(299, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 23);
            this.label1.TabIndex = 1;
            // 
            // spaceship
            // 
            this.spaceship.BackColor = System.Drawing.Color.Transparent;
            this.spaceship.Image = global::Zerg_Rush.Properties.Resources.spaceship;
            this.spaceship.InitialImage = null;
            this.spaceship.Location = new System.Drawing.Point(253, 110);
            this.spaceship.Name = "spaceship";
            this.spaceship.Size = new System.Drawing.Size(41, 34);
            this.spaceship.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.spaceship.TabIndex = 2;
            this.spaceship.TabStop = false;
            this.spaceship.Click += new System.EventHandler(this.spaceship_Click);
            // 
            // defaultalienPicture
            // 
            this.defaultalienPicture.BackColor = System.Drawing.Color.Transparent;
            this.defaultalienPicture.Image = global::Zerg_Rush.Properties.Resources.space_invader;
            this.defaultalienPicture.Location = new System.Drawing.Point(125, 151);
            this.defaultalienPicture.Name = "defaultalienPicture";
            this.defaultalienPicture.Size = new System.Drawing.Size(36, 34);
            this.defaultalienPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.defaultalienPicture.TabIndex = 0;
            this.defaultalienPicture.TabStop = false;
            this.defaultalienPicture.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(302, 151);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(252, 132);
            this.button1.TabIndex = 3;
            this.button1.Text = "Play";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(924, 481);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.spaceship);
            this.Controls.Add(this.defaultalienPicture);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyUp);
            ((System.ComponentModel.ISupportInitialize)(this.spaceship)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.defaultalienPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox defaultalienPicture;
        private System.Windows.Forms.Timer runTicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox spaceship;
        private System.Windows.Forms.Button button1;
    }
}

