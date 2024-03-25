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
            apriToolStripMenuItem = new ToolStripMenuItem();
            nuovoToolStripMenuItem = new ToolStripMenuItem();
            salvaToolStripMenuItem = new ToolStripMenuItem();
            salvaComeToolStripMenuItem = new ToolStripMenuItem();
            esciToolStripMenuItem = new ToolStripMenuItem();
            cOMToolStripMenuItem = new ToolStripMenuItem();
            spedisciTCPToolStripMenuItem = new ToolStripMenuItem();
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
            lblDispositivo = new Label();
            radioButtonMaster = new RadioButton();
            radioButtonSlave = new RadioButton();
            numericUpDownIndirizzoMaster = new NumericUpDown();
            label1 = new Label();
            label6 = new Label();
            textBoxMatricola = new TextBox();
            groupBox1 = new GroupBox();
            label3 = new Label();
            label2 = new Label();
            lblVersione = new Label();
            btnSet = new Button();
            groupBox2 = new GroupBox();
            chkMatricola = new CheckBox();
            chkModbus = new CheckBox();
            chkNetlist = new CheckBox();
            chkParametri = new CheckBox();
            btnReset = new Button();
            timerVerifica = new System.Windows.Forms.Timer(components);
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxConnected).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownIndirizzoMaster).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, cOMToolStripMenuItem, lingiaToolStripMenuItem, toolStripMenuItem1 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 2, 0, 2);
            menuStrip1.Size = new Size(719, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { apriToolStripMenuItem, nuovoToolStripMenuItem, salvaToolStripMenuItem, salvaComeToolStripMenuItem, esciToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // apriToolStripMenuItem
            // 
            apriToolStripMenuItem.Name = "apriToolStripMenuItem";
            apriToolStripMenuItem.Size = new Size(146, 22);
            apriToolStripMenuItem.Text = "Apri";
            // 
            // nuovoToolStripMenuItem
            // 
            nuovoToolStripMenuItem.Name = "nuovoToolStripMenuItem";
            nuovoToolStripMenuItem.Size = new Size(146, 22);
            nuovoToolStripMenuItem.Text = "Nuovo";
            // 
            // salvaToolStripMenuItem
            // 
            salvaToolStripMenuItem.Name = "salvaToolStripMenuItem";
            salvaToolStripMenuItem.Size = new Size(146, 22);
            salvaToolStripMenuItem.Text = "Salva";
            // 
            // salvaComeToolStripMenuItem
            // 
            salvaComeToolStripMenuItem.Name = "salvaComeToolStripMenuItem";
            salvaComeToolStripMenuItem.Size = new Size(146, 22);
            salvaComeToolStripMenuItem.Text = "Salva come ...";
            // 
            // esciToolStripMenuItem
            // 
            esciToolStripMenuItem.Name = "esciToolStripMenuItem";
            esciToolStripMenuItem.Size = new Size(146, 22);
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
            pictureBox1.Location = new Point(618, 396);
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
            labelConnected.Location = new Point(74, 396);
            labelConnected.Margin = new Padding(4, 0, 4, 0);
            labelConnected.Name = "labelConnected";
            labelConnected.Size = new Size(38, 15);
            labelConnected.TabIndex = 2;
            labelConnected.Text = "label1";
            labelConnected.Click += labelConnected_Click;
            // 
            // pictureBoxConnected
            // 
            pictureBoxConnected.ErrorImage = configuratoreSerial6._0.Resource1.roccheggianiSplash;
            pictureBoxConnected.InitialImage = null;
            pictureBoxConnected.Location = new Point(32, 396);
            pictureBoxConnected.Margin = new Padding(4, 3, 4, 3);
            pictureBoxConnected.Name = "pictureBoxConnected";
            pictureBoxConnected.Size = new Size(15, 15);
            pictureBoxConnected.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxConnected.TabIndex = 3;
            pictureBoxConnected.TabStop = false;
            pictureBoxConnected.Click += pictureBoxConnected_Click;
            // 
            // timerRicezione
            // 
            timerRicezione.Enabled = true;
            timerRicezione.Interval = 1;
            timerRicezione.Tick += timerRicezione_Tick;
            // 
            // timerDisconnetti
            // 
            timerDisconnetti.Interval = 2000;
            timerDisconnetti.Tick += timerDisconnetti_Tick;
            // 
            // lblDispositivo
            // 
            lblDispositivo.AutoSize = true;
            lblDispositivo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblDispositivo.Location = new Point(140, 119);
            lblDispositivo.Margin = new Padding(4, 0, 4, 0);
            lblDispositivo.Name = "lblDispositivo";
            lblDispositivo.Size = new Size(87, 21);
            lblDispositivo.TabIndex = 4;
            lblDispositivo.Text = "Dispositivo";
            lblDispositivo.Click += lblDispositivo_Click;
            // 
            // radioButtonMaster
            // 
            radioButtonMaster.AutoSize = true;
            radioButtonMaster.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            radioButtonMaster.Location = new Point(41, 39);
            radioButtonMaster.Name = "radioButtonMaster";
            radioButtonMaster.Size = new Size(87, 25);
            radioButtonMaster.TabIndex = 6;
            radioButtonMaster.TabStop = true;
            radioButtonMaster.Text = "MASTER";
            radioButtonMaster.UseVisualStyleBackColor = true;
            radioButtonMaster.CheckedChanged += radioButtonMaster_CheckedChanged;
            // 
            // radioButtonSlave
            // 
            radioButtonSlave.AutoSize = true;
            radioButtonSlave.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            radioButtonSlave.Location = new Point(155, 39);
            radioButtonSlave.Name = "radioButtonSlave";
            radioButtonSlave.Size = new Size(72, 25);
            radioButtonSlave.TabIndex = 7;
            radioButtonSlave.TabStop = true;
            radioButtonSlave.Text = "SLAVE";
            radioButtonSlave.UseVisualStyleBackColor = true;
            radioButtonSlave.CheckedChanged += radioButtonSlave_CheckedChanged;
            // 
            // numericUpDownIndirizzoMaster
            // 
            numericUpDownIndirizzoMaster.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            numericUpDownIndirizzoMaster.Location = new Point(564, 75);
            numericUpDownIndirizzoMaster.Maximum = new decimal(new int[] { 254, 0, 0, 0 });
            numericUpDownIndirizzoMaster.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownIndirizzoMaster.Name = "numericUpDownIndirizzoMaster";
            numericUpDownIndirizzoMaster.Size = new Size(53, 29);
            numericUpDownIndirizzoMaster.TabIndex = 8;
            numericUpDownIndirizzoMaster.TextAlign = HorizontalAlignment.Right;
            numericUpDownIndirizzoMaster.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(368, 75);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(69, 21);
            label1.TabIndex = 9;
            label1.Text = "Indirizzo";
            label1.Click += label1_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(368, 39);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(75, 21);
            label6.TabIndex = 16;
            label6.Text = "Matricola";
            // 
            // textBoxMatricola
            // 
            textBoxMatricola.Location = new Point(460, 36);
            textBoxMatricola.Name = "textBoxMatricola";
            textBoxMatricola.Size = new Size(164, 23);
            textBoxMatricola.TabIndex = 17;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(lblVersione);
            groupBox1.Controls.Add(btnSet);
            groupBox1.Controls.Add(textBoxMatricola);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(radioButtonSlave);
            groupBox1.Controls.Add(lblDispositivo);
            groupBox1.Controls.Add(radioButtonMaster);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(numericUpDownIndirizzoMaster);
            groupBox1.Location = new Point(32, 56);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(640, 193);
            groupBox1.TabIndex = 18;
            groupBox1.TabStop = false;
            groupBox1.Text = "PARAMETRI";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Silver;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(42, 119);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(87, 21);
            label3.TabIndex = 21;
            label3.Text = "Dispositivo";
            label3.Click += label3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Silver;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(42, 164);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(73, 21);
            label2.TabIndex = 20;
            label2.Text = "Versione:";
            // 
            // lblVersione
            // 
            lblVersione.AutoSize = true;
            lblVersione.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblVersione.Location = new Point(140, 164);
            lblVersione.Margin = new Padding(4, 0, 4, 0);
            lblVersione.Name = "lblVersione";
            lblVersione.Size = new Size(87, 21);
            lblVersione.TabIndex = 19;
            lblVersione.Text = "Dispositivo";
            // 
            // btnSet
            // 
            btnSet.Location = new Point(542, 134);
            btnSet.Name = "btnSet";
            btnSet.Size = new Size(75, 23);
            btnSet.TabIndex = 18;
            btnSet.Text = "Set";
            btnSet.UseVisualStyleBackColor = true;
            btnSet.Click += btnSet_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(chkMatricola);
            groupBox2.Controls.Add(chkModbus);
            groupBox2.Controls.Add(chkNetlist);
            groupBox2.Controls.Add(chkParametri);
            groupBox2.Controls.Add(btnReset);
            groupBox2.Location = new Point(32, 274);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(640, 116);
            groupBox2.TabIndex = 20;
            groupBox2.TabStop = false;
            groupBox2.Text = "RESET";
            // 
            // chkMatricola
            // 
            chkMatricola.AutoSize = true;
            chkMatricola.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            chkMatricola.Location = new Point(241, 81);
            chkMatricola.Name = "chkMatricola";
            chkMatricola.Size = new Size(136, 25);
            chkMatricola.TabIndex = 26;
            chkMatricola.Text = "Reset matricola";
            chkMatricola.UseVisualStyleBackColor = true;
            chkMatricola.CheckedChanged += chkMatricola_CheckedChanged;
            // 
            // chkModbus
            // 
            chkModbus.AutoSize = true;
            chkModbus.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            chkModbus.Location = new Point(241, 43);
            chkModbus.Name = "chkModbus";
            chkModbus.Size = new Size(137, 25);
            chkModbus.TabIndex = 25;
            chkModbus.Text = "Reset MODBUS";
            chkModbus.UseVisualStyleBackColor = true;
            chkModbus.CheckedChanged += chkModbus_CheckedChanged;
            // 
            // chkNetlist
            // 
            chkNetlist.AutoSize = true;
            chkNetlist.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            chkNetlist.Location = new Point(41, 77);
            chkNetlist.Name = "chkNetlist";
            chkNetlist.Size = new Size(113, 25);
            chkNetlist.TabIndex = 24;
            chkNetlist.Text = "Reset netlist";
            chkNetlist.UseVisualStyleBackColor = true;
            chkNetlist.CheckedChanged += chkNetlist_CheckedChanged;
            // 
            // chkParametri
            // 
            chkParametri.AutoSize = true;
            chkParametri.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            chkParametri.Location = new Point(41, 39);
            chkParametri.Name = "chkParametri";
            chkParametri.Size = new Size(139, 25);
            chkParametri.TabIndex = 23;
            chkParametri.Text = "Reset parametri";
            chkParametri.UseVisualStyleBackColor = true;
            chkParametri.CheckedChanged += chkParametri_CheckedChanged;
            // 
            // btnReset
            // 
            btnReset.Enabled = false;
            btnReset.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnReset.Location = new Point(430, 58);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(134, 32);
            btnReset.TabIndex = 20;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // timerVerifica
            // 
            timerVerifica.Interval = 500;
            timerVerifica.Tick += timerVerifica_Tick;
            // 
            // frmStartUp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(719, 467);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
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
            ((System.ComponentModel.ISupportInitialize)numericUpDownIndirizzoMaster).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem apriToolStripMenuItem;
        private ToolStripMenuItem nuovoToolStripMenuItem;
        private ToolStripMenuItem salvaToolStripMenuItem;
        private ToolStripMenuItem salvaComeToolStripMenuItem;
        private ToolStripMenuItem esciToolStripMenuItem;
        private ToolStripMenuItem cOMToolStripMenuItem;
        private ToolStripMenuItem lingiaToolStripMenuItem;
        private ToolStripMenuItem italianoToolStripMenuItem;
        private ToolStripMenuItem engllishToolStripMenuItem;
        private PictureBox pictureBox1;
        private ToolStripMenuItem spedisciTCPToolStripMenuItem;
        private System.Windows.Forms.Timer timerConnessione;
        private Label labelConnected;
        private PictureBox pictureBoxConnected;
        private System.Windows.Forms.Timer timerRicezione;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.Timer timerDisconnetti;
        private Label lblDispositivo;
        private RadioButton radioButtonMaster;
        private RadioButton radioButtonSlave;
        private NumericUpDown numericUpDownIndirizzoMaster;
        private Label label1;
        private Label label6;
        private TextBox textBoxMatricola;
        private GroupBox groupBox1;
        private Button btnSet;
        private GroupBox groupBox2;
        private Button btnReset;
        private Label lblVersione;
        private Label label2;
        private Label label3;
        private System.Windows.Forms.Timer timerVerifica;
        private CheckBox chkMatricola;
        private CheckBox chkModbus;
        private CheckBox chkNetlist;
        private CheckBox chkParametri;
    }
}

