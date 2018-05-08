namespace Pushy
{
    partial class LevelEditor
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
            this.lbMauer = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbKasten = new System.Windows.Forms.Label();
            this.lbKnopf = new System.Windows.Forms.Label();
            this.lbKugel = new System.Windows.Forms.Label();
            this.lbKugelZiel = new System.Windows.Forms.Label();
            this.lbHaus = new System.Windows.Forms.Label();
            this.lbBarrier = new System.Windows.Forms.Label();
            this.cBoxFarbe = new System.Windows.Forms.ComboBox();
            this.lbTeleporter = new System.Windows.Forms.Label();
            this.numIndex = new System.Windows.Forms.NumericUpDown();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSpeichern = new System.Windows.Forms.Button();
            this.btnClearen = new System.Windows.Forms.Button();
            this.lbPlayer = new System.Windows.Forms.Label();
            this.txBName = new System.Windows.Forms.TextBox();
            this.numHohe = new System.Windows.Forms.NumericUpDown();
            this.numBreite = new System.Windows.Forms.NumericUpDown();
            this.lbFarbklecks = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.lbBombe = new System.Windows.Forms.Label();
            this.lbLoch = new System.Windows.Forms.Label();
            this.lbEis = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHohe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBreite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbMauer
            // 
            this.lbMauer.AutoSize = true;
            this.lbMauer.Location = new System.Drawing.Point(38, 425);
            this.lbMauer.Name = "lbMauer";
            this.lbMauer.Size = new System.Drawing.Size(37, 13);
            this.lbMauer.TabIndex = 0;
            this.lbMauer.Tag = "";
            this.lbMauer.Text = "Mauer";
            this.lbMauer.Click += new System.EventHandler(this.label_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::Pushy.Properties.Resources.Boden;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(175, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 400);
            this.panel1.TabIndex = 1;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // lbKasten
            // 
            this.lbKasten.AutoSize = true;
            this.lbKasten.Location = new System.Drawing.Point(38, 400);
            this.lbKasten.Name = "lbKasten";
            this.lbKasten.Size = new System.Drawing.Size(40, 13);
            this.lbKasten.TabIndex = 2;
            this.lbKasten.Text = "Kasten";
            this.lbKasten.Click += new System.EventHandler(this.label_Click);
            // 
            // lbKnopf
            // 
            this.lbKnopf.AutoSize = true;
            this.lbKnopf.Location = new System.Drawing.Point(38, 375);
            this.lbKnopf.Name = "lbKnopf";
            this.lbKnopf.Size = new System.Drawing.Size(35, 13);
            this.lbKnopf.TabIndex = 3;
            this.lbKnopf.Text = "Knopf";
            this.lbKnopf.Click += new System.EventHandler(this.label_Click);
            // 
            // lbKugel
            // 
            this.lbKugel.AutoSize = true;
            this.lbKugel.Location = new System.Drawing.Point(38, 353);
            this.lbKugel.Name = "lbKugel";
            this.lbKugel.Size = new System.Drawing.Size(34, 13);
            this.lbKugel.TabIndex = 4;
            this.lbKugel.Text = "Kugel";
            this.lbKugel.Click += new System.EventHandler(this.label_Click);
            // 
            // lbKugelZiel
            // 
            this.lbKugelZiel.AutoSize = true;
            this.lbKugelZiel.Location = new System.Drawing.Point(38, 329);
            this.lbKugelZiel.Name = "lbKugelZiel";
            this.lbKugelZiel.Size = new System.Drawing.Size(49, 13);
            this.lbKugelZiel.TabIndex = 5;
            this.lbKugelZiel.Text = "Kugelziel";
            this.lbKugelZiel.Click += new System.EventHandler(this.label_Click);
            // 
            // lbHaus
            // 
            this.lbHaus.AutoSize = true;
            this.lbHaus.Location = new System.Drawing.Point(38, 307);
            this.lbHaus.Name = "lbHaus";
            this.lbHaus.Size = new System.Drawing.Size(32, 13);
            this.lbHaus.TabIndex = 6;
            this.lbHaus.Text = "Haus";
            this.lbHaus.Click += new System.EventHandler(this.label_Click);
            // 
            // lbBarrier
            // 
            this.lbBarrier.AutoSize = true;
            this.lbBarrier.Location = new System.Drawing.Point(38, 285);
            this.lbBarrier.Name = "lbBarrier";
            this.lbBarrier.Size = new System.Drawing.Size(43, 13);
            this.lbBarrier.TabIndex = 7;
            this.lbBarrier.Text = "Barriere";
            this.lbBarrier.Click += new System.EventHandler(this.label_Click);
            // 
            // cBoxFarbe
            // 
            this.cBoxFarbe.FormattingEnabled = true;
            this.cBoxFarbe.Items.AddRange(new object[] {
            "blau",
            "rot",
            "grün",
            "gelb"});
            this.cBoxFarbe.Location = new System.Drawing.Point(630, 132);
            this.cBoxFarbe.Name = "cBoxFarbe";
            this.cBoxFarbe.Size = new System.Drawing.Size(121, 21);
            this.cBoxFarbe.TabIndex = 8;
            this.cBoxFarbe.Visible = false;
            this.cBoxFarbe.SelectedIndexChanged += new System.EventHandler(this.cBoxFarbe_SelectedIndexChanged);
            // 
            // lbTeleporter
            // 
            this.lbTeleporter.AutoSize = true;
            this.lbTeleporter.Location = new System.Drawing.Point(38, 250);
            this.lbTeleporter.Name = "lbTeleporter";
            this.lbTeleporter.Size = new System.Drawing.Size(55, 13);
            this.lbTeleporter.TabIndex = 11;
            this.lbTeleporter.Text = "Teleporter";
            this.lbTeleporter.Click += new System.EventHandler(this.label_Click);
            // 
            // numIndex
            // 
            this.numIndex.Location = new System.Drawing.Point(630, 159);
            this.numIndex.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numIndex.Name = "numIndex";
            this.numIndex.Size = new System.Drawing.Size(78, 20);
            this.numIndex.TabIndex = 12;
            this.numIndex.Visible = false;
            this.numIndex.ValueChanged += new System.EventHandler(this.numIndex_ValueChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(630, 195);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "Löschen";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSpeichern
            // 
            this.btnSpeichern.Location = new System.Drawing.Point(690, 343);
            this.btnSpeichern.Name = "btnSpeichern";
            this.btnSpeichern.Size = new System.Drawing.Size(75, 23);
            this.btnSpeichern.TabIndex = 15;
            this.btnSpeichern.Text = "Speichern";
            this.btnSpeichern.UseVisualStyleBackColor = true;
            this.btnSpeichern.Click += new System.EventHandler(this.btnSpeichern_Click);
            // 
            // btnClearen
            // 
            this.btnClearen.Location = new System.Drawing.Point(13, 4);
            this.btnClearen.Name = "btnClearen";
            this.btnClearen.Size = new System.Drawing.Size(75, 23);
            this.btnClearen.TabIndex = 16;
            this.btnClearen.Text = "Clearen";
            this.btnClearen.UseVisualStyleBackColor = true;
            this.btnClearen.Click += new System.EventHandler(this.btnClearen_Click);
            // 
            // lbPlayer
            // 
            this.lbPlayer.AutoSize = true;
            this.lbPlayer.Location = new System.Drawing.Point(39, 227);
            this.lbPlayer.Name = "lbPlayer";
            this.lbPlayer.Size = new System.Drawing.Size(36, 13);
            this.lbPlayer.TabIndex = 17;
            this.lbPlayer.Text = "Player";
            this.lbPlayer.Click += new System.EventHandler(this.label_Click);
            // 
            // txBName
            // 
            this.txBName.Location = new System.Drawing.Point(584, 346);
            this.txBName.Name = "txBName";
            this.txBName.Size = new System.Drawing.Size(100, 20);
            this.txBName.TabIndex = 20;
            // 
            // numHohe
            // 
            this.numHohe.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numHohe.Location = new System.Drawing.Point(672, 283);
            this.numHohe.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numHohe.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numHohe.Name = "numHohe";
            this.numHohe.Size = new System.Drawing.Size(36, 20);
            this.numHohe.TabIndex = 21;
            this.numHohe.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numHohe.ValueChanged += new System.EventHandler(this.numHohe_ValueChanged);
            // 
            // numBreite
            // 
            this.numBreite.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numBreite.Location = new System.Drawing.Point(633, 283);
            this.numBreite.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numBreite.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numBreite.Name = "numBreite";
            this.numBreite.Size = new System.Drawing.Size(36, 20);
            this.numBreite.TabIndex = 22;
            this.numBreite.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numBreite.ValueChanged += new System.EventHandler(this.numBreite_ValueChanged);
            // 
            // lbFarbklecks
            // 
            this.lbFarbklecks.AutoSize = true;
            this.lbFarbklecks.Location = new System.Drawing.Point(42, 205);
            this.lbFarbklecks.Name = "lbFarbklecks";
            this.lbFarbklecks.Size = new System.Drawing.Size(59, 13);
            this.lbFarbklecks.TabIndex = 23;
            this.lbFarbklecks.Text = "Farbklecks";
            this.lbFarbklecks.Click += new System.EventHandler(this.label_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(584, 401);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(181, 23);
            this.button1.TabIndex = 24;
            this.button1.Text = "Extern Speichern";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(13, 25);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(124, 23);
            this.button2.TabIndex = 25;
            this.button2.Text = "Level löschen";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(613, 43);
            this.trackBar1.Maximum = 2;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(138, 45);
            this.trackBar1.TabIndex = 26;
            this.trackBar1.Visible = false;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(630, 225);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(92, 17);
            this.checkBox1.TabIndex = 27;
            this.checkBox1.Text = "Bombenknopf";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // lbBombe
            // 
            this.lbBombe.AutoSize = true;
            this.lbBombe.Location = new System.Drawing.Point(42, 192);
            this.lbBombe.Name = "lbBombe";
            this.lbBombe.Size = new System.Drawing.Size(40, 13);
            this.lbBombe.TabIndex = 28;
            this.lbBombe.Text = "Bombe";
            this.lbBombe.Click += new System.EventHandler(this.label_Click);
            // 
            // lbLoch
            // 
            this.lbLoch.AutoSize = true;
            this.lbLoch.Location = new System.Drawing.Point(44, 166);
            this.lbLoch.Name = "lbLoch";
            this.lbLoch.Size = new System.Drawing.Size(31, 13);
            this.lbLoch.TabIndex = 29;
            this.lbLoch.Text = "Loch";
            this.lbLoch.Click += new System.EventHandler(this.label_Click);
            // 
            // lbEis
            // 
            this.lbEis.AutoSize = true;
            this.lbEis.Location = new System.Drawing.Point(44, 140);
            this.lbEis.Name = "lbEis";
            this.lbEis.Size = new System.Drawing.Size(21, 13);
            this.lbEis.TabIndex = 30;
            this.lbEis.Text = "Eis";
            this.lbEis.Click += new System.EventHandler(this.label_Click);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(41, 70);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(117, 17);
            this.checkBox2.TabIndex = 31;
            this.checkBox2.Text = "Nur Player Teleport";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // LevelEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 450);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.lbEis);
            this.Controls.Add(this.lbLoch);
            this.Controls.Add(this.lbBombe);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbFarbklecks);
            this.Controls.Add(this.numBreite);
            this.Controls.Add(this.numHohe);
            this.Controls.Add(this.txBName);
            this.Controls.Add(this.lbPlayer);
            this.Controls.Add(this.btnClearen);
            this.Controls.Add(this.btnSpeichern);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.numIndex);
            this.Controls.Add(this.lbTeleporter);
            this.Controls.Add(this.cBoxFarbe);
            this.Controls.Add(this.lbBarrier);
            this.Controls.Add(this.lbHaus);
            this.Controls.Add(this.lbKugelZiel);
            this.Controls.Add(this.lbKugel);
            this.Controls.Add(this.lbKnopf);
            this.Controls.Add(this.lbKasten);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbMauer);
            this.MinimumSize = new System.Drawing.Size(789, 489);
            this.Name = "LevelEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LevelEditor";
            ((System.ComponentModel.ISupportInitialize)(this.numIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHohe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBreite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbMauer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbKasten;
        private System.Windows.Forms.Label lbKnopf;
        private System.Windows.Forms.Label lbKugel;
        private System.Windows.Forms.Label lbKugelZiel;
        private System.Windows.Forms.Label lbHaus;
        private System.Windows.Forms.Label lbBarrier;
        private System.Windows.Forms.ComboBox cBoxFarbe;
        private System.Windows.Forms.Label lbTeleporter;
        private System.Windows.Forms.NumericUpDown numIndex;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSpeichern;
        private System.Windows.Forms.Button btnClearen;
        private System.Windows.Forms.Label lbPlayer;
        private System.Windows.Forms.TextBox txBName;
        private System.Windows.Forms.NumericUpDown numHohe;
        private System.Windows.Forms.NumericUpDown numBreite;
        private System.Windows.Forms.Label lbFarbklecks;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label lbBombe;
        private System.Windows.Forms.Label lbLoch;
        private System.Windows.Forms.Label lbEis;
        private System.Windows.Forms.CheckBox checkBox2;
    }
}