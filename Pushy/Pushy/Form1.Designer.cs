namespace Pushy
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLevelEditor = new System.Windows.Forms.Button();
            this.btnStarten = new System.Windows.Forms.Button();
            this.comBox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // btnLevelEditor
            // 
            this.btnLevelEditor.Location = new System.Drawing.Point(12, 43);
            this.btnLevelEditor.Name = "btnLevelEditor";
            this.btnLevelEditor.Size = new System.Drawing.Size(75, 23);
            this.btnLevelEditor.TabIndex = 15;
            this.btnLevelEditor.Text = "Level-Editor";
            this.btnLevelEditor.UseVisualStyleBackColor = true;
            this.btnLevelEditor.Click += new System.EventHandler(this.btnLevelEditor_Click);
            // 
            // btnStarten
            // 
            this.btnStarten.Location = new System.Drawing.Point(106, 42);
            this.btnStarten.Name = "btnStarten";
            this.btnStarten.Size = new System.Drawing.Size(75, 23);
            this.btnStarten.TabIndex = 16;
            this.btnStarten.Text = "Starten";
            this.btnStarten.UseVisualStyleBackColor = true;
            this.btnStarten.Click += new System.EventHandler(this.btnStarten_Click);
            // 
            // comBox
            // 
            this.comBox.FormattingEnabled = true;
            this.comBox.Location = new System.Drawing.Point(12, 77);
            this.comBox.Name = "comBox";
            this.comBox.Size = new System.Drawing.Size(169, 21);
            this.comBox.TabIndex = 17;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(168, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "Externes laden";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(189, 106);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comBox);
            this.Controls.Add(this.btnStarten);
            this.Controls.Add(this.btnLevelEditor);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnLevelEditor;
        private System.Windows.Forms.Button btnStarten;
        private System.Windows.Forms.ComboBox comBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

