namespace Pushy
{
    partial class Level
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Level));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pcBReset = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pcBReset)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Location = new System.Drawing.Point(32, 29);
            this.panel1.MinimumSize = new System.Drawing.Size(400, 400);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 400);
            this.panel1.TabIndex = 0;
            // 
            // pcBReset
            // 
            this.pcBReset.BackColor = System.Drawing.Color.Silver;
            this.pcBReset.Location = new System.Drawing.Point(513, 104);
            this.pcBReset.Name = "pcBReset";
            this.pcBReset.Size = new System.Drawing.Size(100, 50);
            this.pcBReset.TabIndex = 6;
            this.pcBReset.TabStop = false;
            this.pcBReset.Click += new System.EventHandler(this.pcBReset_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(466, 429);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "0";
            // 
            // Level
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 459);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pcBReset);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(658, 498);
            this.Name = "Level";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Level";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Level_FormClosing);
            this.SizeChanged += new System.EventHandler(this.Level_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pcBReset)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pcBReset;
        private System.Windows.Forms.Label label1;
    }
}