namespace configuratore
{
    partial class frmStartUp
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            esciToolStripMenuItem = new ToolStripMenuItem();
            cOMToolStripMenuItem = new ToolStripMenuItem();
            spedisciTCPToolStripMenuItem = new ToolStripMenuItem();
            deviceToolStripMenuItem = new ToolStripMenuItem();
            cASSETTEToolStripMenuItem = new ToolStripMenuItem();
            fANCOILToolStripMenuItem = new ToolStripMenuItem();
            tERMOSTATOANALOGICOToolStripMenuItem = new ToolStripMenuItem();
            tERMOSTATOTOUCHCONTROLToolStripMenuItem = new ToolStripMenuItem();
            tERMOSTATOTFTToolStripMenuItem = new ToolStripMenuItem();
            lingiaToolStripMenuItem = new ToolStripMenuItem();
            italianoToolStripMenuItem = new ToolStripMenuItem();
            engllishToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            infoToolStripMenuItem = new ToolStripMenuItem();
            pictureBox1 = new PictureBox();
            timerConnessione = new System.Windows.Forms.Timer(components);
            labelConnected = new Label();
            pictureBoxConnected = new PictureBox();
            timerRicezione = new System.Windows.Forms.Timer(components);
            timerDisconnetti = new System.Windows.Forms.Timer(components);
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxConnected).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, cOMToolStripMenuItem, deviceToolStripMenuItem, lingiaToolStripMenuItem, toolStripMenuItem1 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 2, 0, 2);
            menuStrip1.Size = new Size(548, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { esciToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // esciToolStripMenuItem
            // 
            esciToolStripMenuItem.Name = "esciToolStripMenuItem";
            esciToolStripMenuItem.Size = new Size(94, 22);
            esciToolStripMenuItem.Text = "Esci";
            esciToolStripMenuItem.Click += esciToolStripMenuItem_Click;
            // 
            // cOMToolStripMenuItem
            // 
            cOMToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { spedisciTCPToolStripMenuItem });
            cOMToolStripMenuItem.Name = "cOMToolStripMenuItem";
            cOMToolStripMenuItem.Size = new Size(47, 20);
            cOMToolStripMenuItem.Text = "COM";
            cOMToolStripMenuItem.Click += cOMToolStripMenuItem_Click;
            // 
            // spedisciTCPToolStripMenuItem
            // 
            spedisciTCPToolStripMenuItem.Name = "spedisciTCPToolStripMenuItem";
            spedisciTCPToolStripMenuItem.Size = new Size(120, 22);
            spedisciTCPToolStripMenuItem.Text = "Connetti";
            spedisciTCPToolStripMenuItem.Click += spedisciTCPToolStripMenuItem_Click;
            // 
            // deviceToolStripMenuItem
            // 
            deviceToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cASSETTEToolStripMenuItem, fANCOILToolStripMenuItem, tERMOSTATOANALOGICOToolStripMenuItem, tERMOSTATOTOUCHCONTROLToolStripMenuItem, tERMOSTATOTFTToolStripMenuItem });
            deviceToolStripMenuItem.Name = "deviceToolStripMenuItem";
            deviceToolStripMenuItem.Size = new Size(54, 20);
            deviceToolStripMenuItem.Text = "Device";
            // 
            // cASSETTEToolStripMenuItem
            // 
            cASSETTEToolStripMenuItem.Name = "cASSETTEToolStripMenuItem";
            cASSETTEToolStripMenuItem.Size = new Size(244, 22);
            cASSETTEToolStripMenuItem.Text = "CASSETTE";
            cASSETTEToolStripMenuItem.Click += cASSETTEToolStripMenuItem_Click;
            // 
            // fANCOILToolStripMenuItem
            // 
            fANCOILToolStripMenuItem.Name = "fANCOILToolStripMenuItem";
            fANCOILToolStripMenuItem.Size = new Size(244, 22);
            fANCOILToolStripMenuItem.Text = "FANCOIL";
            fANCOILToolStripMenuItem.Click += fANCOILToolStripMenuItem_Click;
            // 
            // tERMOSTATOANALOGICOToolStripMenuItem
            // 
            tERMOSTATOANALOGICOToolStripMenuItem.Name = "tERMOSTATOANALOGICOToolStripMenuItem";
            tERMOSTATOANALOGICOToolStripMenuItem.Size = new Size(244, 22);
            tERMOSTATOANALOGICOToolStripMenuItem.Text = "TERMOSTATO ANALOGICO";
            tERMOSTATOANALOGICOToolStripMenuItem.Click += tERMOSTATOANALOGICOToolStripMenuItem_Click;
            // 
            // tERMOSTATOTOUCHCONTROLToolStripMenuItem
            // 
            tERMOSTATOTOUCHCONTROLToolStripMenuItem.Name = "tERMOSTATOTOUCHCONTROLToolStripMenuItem";
            tERMOSTATOTOUCHCONTROLToolStripMenuItem.Size = new Size(244, 22);
            tERMOSTATOTOUCHCONTROLToolStripMenuItem.Text = "TERMOSTATO TOUCH CONTROL";
            // 
            // tERMOSTATOTFTToolStripMenuItem
            // 
            tERMOSTATOTFTToolStripMenuItem.Name = "tERMOSTATOTFTToolStripMenuItem";
            tERMOSTATOTFTToolStripMenuItem.Size = new Size(244, 22);
            tERMOSTATOTFTToolStripMenuItem.Text = "TERMOSTATO TFT";
            tERMOSTATOTFTToolStripMenuItem.Click += tERMOSTATOTFTToolStripMenuItem_Click;
            // 
            // lingiaToolStripMenuItem
            // 
            lingiaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { italianoToolStripMenuItem, engllishToolStripMenuItem });
            lingiaToolStripMenuItem.Name = "lingiaToolStripMenuItem";
            lingiaToolStripMenuItem.Size = new Size(55, 20);
            lingiaToolStripMenuItem.Text = "Lingua";
            // 
            // italianoToolStripMenuItem
            // 
            italianoToolStripMenuItem.Name = "italianoToolStripMenuItem";
            italianoToolStripMenuItem.Size = new Size(115, 22);
            italianoToolStripMenuItem.Text = "Italiano";
            italianoToolStripMenuItem.Click += italianoToolStripMenuItem_Click;
            // 
            // engllishToolStripMenuItem
            // 
            engllishToolStripMenuItem.Name = "engllishToolStripMenuItem";
            engllishToolStripMenuItem.Size = new Size(115, 22);
            engllishToolStripMenuItem.Text = "Engllish";
            engllishToolStripMenuItem.Click += engllishToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { infoToolStripMenuItem });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(24, 20);
            toolStripMenuItem1.Text = "?";
            // 
            // infoToolStripMenuItem
            // 
            infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            infoToolStripMenuItem.Size = new Size(95, 22);
            infoToolStripMenuItem.Text = "Info";
            infoToolStripMenuItem.Click += infoToolStripMenuItem_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.ErrorImage = configuratoreSerial6._0.Resource1.roccheggianiSplash;
            pictureBox1.InitialImage = null;
            pictureBox1.Location = new Point(481, 257);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(54, 33);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // timerConnessione
            // 
            timerConnessione.Interval = 1000;
            timerConnessione.Tick += timerConnessione_Tick;
            // 
            // labelConnected
            // 
            labelConnected.AutoSize = true;
            labelConnected.Location = new Point(33, 257);
            labelConnected.Margin = new Padding(4, 0, 4, 0);
            labelConnected.Name = "labelConnected";
            labelConnected.Size = new Size(38, 15);
            labelConnected.TabIndex = 2;
            labelConnected.Text = "label1";
            // 
            // pictureBoxConnected
            // 
            pictureBoxConnected.ErrorImage = configuratoreSerial6._0.Resource1.roccheggianiSplash;
            pictureBoxConnected.InitialImage = null;
            pictureBoxConnected.Location = new Point(14, 257);
            pictureBoxConnected.Margin = new Padding(4, 3, 4, 3);
            pictureBoxConnected.Name = "pictureBoxConnected";
            pictureBoxConnected.Size = new Size(15, 15);
            pictureBoxConnected.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxConnected.TabIndex = 3;
            pictureBoxConnected.TabStop = false;
            // 
            // timerRicezione
            // 
            timerRicezione.Enabled = true;
            timerRicezione.Tick += timerRicezione_Tick;
            // 
            // timerDisconnetti
            // 
            timerDisconnetti.Interval = 2000;
            timerDisconnetti.Tick += timerDisconnetti_Tick;
            // 
            // frmStartUp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = configuratoreSerial6._0.Resource1.roccheggianiSplash;
            ClientSize = new Size(548, 305);
            Controls.Add(pictureBoxConnected);
            Controls.Add(labelConnected);
            Controls.Add(pictureBox1);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmStartUp";
            Text = "Roccheggiani";
            FormClosing += frmStartUp_FormClosing;
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxConnected).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem esciToolStripMenuItem;
        private ToolStripMenuItem cOMToolStripMenuItem;
        private ToolStripMenuItem deviceToolStripMenuItem;
        private ToolStripMenuItem lingiaToolStripMenuItem;
        private ToolStripMenuItem italianoToolStripMenuItem;
        private ToolStripMenuItem engllishToolStripMenuItem;
        private PictureBox pictureBox1;
        private ToolStripMenuItem cASSETTEToolStripMenuItem;
        private ToolStripMenuItem fANCOILToolStripMenuItem;
        private ToolStripMenuItem spedisciTCPToolStripMenuItem;
        private System.Windows.Forms.Timer timerConnessione;
        private Label labelConnected;
        private PictureBox pictureBoxConnected;
        private System.Windows.Forms.Timer timerRicezione;
        private ToolStripMenuItem tERMOSTATOANALOGICOToolStripMenuItem;
        private ToolStripMenuItem tERMOSTATOTOUCHCONTROLToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.Timer timerDisconnetti;
        private ToolStripMenuItem tERMOSTATOTFTToolStripMenuItem;
    }
}

