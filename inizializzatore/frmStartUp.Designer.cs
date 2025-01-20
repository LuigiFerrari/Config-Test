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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStartUp));
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
            timerConnessione = new System.Windows.Forms.Timer(components);
            timerRicezione = new System.Windows.Forms.Timer(components);
            timerDisconnetti = new System.Windows.Forms.Timer(components);
            timerVerifica = new System.Windows.Forms.Timer(components);
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            groupBox2 = new GroupBox();
            chkMatricola = new CheckBox();
            chkModbus = new CheckBox();
            chkNetlist = new CheckBox();
            chkParametri = new CheckBox();
            btnReset = new Button();
            groupBox1 = new GroupBox();
            msgErr = new Label();
            label3 = new Label();
            label2 = new Label();
            lblVersione = new Label();
            btnSet = new Button();
            textBoxMatricola = new TextBox();
            label6 = new Label();
            radioButtonSlave = new RadioButton();
            lblDispositivo = new Label();
            radioButtonMaster = new RadioButton();
            labelIndirizzo = new Label();
            numericUpDownIndirizzoMaster = new NumericUpDown();
            tabPage2 = new TabPage();
            CassetteFancoilGrp = new GroupBox();
            groupBox3 = new GroupBox();
            label1 = new Label();
            btnAutotest = new Button();
            btLEDSOK = new PictureBox();
            pbLED5 = new PictureBox();
            btnLED5 = new Button();
            pbLED4 = new PictureBox();
            btnLED4 = new Button();
            pbLED3 = new PictureBox();
            btnLED3 = new Button();
            pbLED2 = new PictureBox();
            btnLED2 = new Button();
            pbLED1 = new PictureBox();
            btnLED1 = new Button();
            pbLED0 = new PictureBox();
            btnLED0 = new Button();
            groupBox11 = new GroupBox();
            pbLEDPRESSOK = new PictureBox();
            lblPressSensFrg = new Label();
            lblPressSensBck = new Label();
            pictureBox3 = new PictureBox();
            groupBox4 = new GroupBox();
            pbLEDADCDAC2OK = new PictureBox();
            pbLEDADCDAC1OK = new PictureBox();
            lblADC2 = new Label();
            lblADC1 = new Label();
            lblADC2bkg = new Label();
            DAC1 = new TrackBar();
            DAC2 = new TrackBar();
            lblADC1bkg = new Label();
            groupBox10 = new GroupBox();
            pbLEDTRIACOK = new PictureBox();
            btnTriac2 = new Button();
            btnTriac1 = new Button();
            pictureBox2 = new PictureBox();
            groupBox5 = new GroupBox();
            pbLEDDIOK = new PictureBox();
            label18 = new Label();
            label19 = new Label();
            label15 = new Label();
            label16 = new Label();
            label17 = new Label();
            pbLEDDI5 = new PictureBox();
            pbLEDDI4 = new PictureBox();
            pbLEDDI3 = new PictureBox();
            pbLEDDI2 = new PictureBox();
            pbLEDDI1 = new PictureBox();
            groupBox9 = new GroupBox();
            label4 = new Label();
            pbLED_RS4852PLC = new PictureBox();
            label11 = new Label();
            pbLED_RS4851PLC = new PictureBox();
            groupBox6 = new GroupBox();
            groupBox8 = new GroupBox();
            pbLEDNTC2 = new PictureBox();
            lblNTC2 = new Label();
            groupBox7 = new GroupBox();
            pbLEDNTC1 = new PictureBox();
            lblNTC1 = new Label();
            TermostatoAnalogicoGrp = new GroupBox();
            pictureBox5 = new PictureBox();
            pictureBox4 = new PictureBox();
            groupBoxBEEP = new GroupBox();
            pbLEDBEEPOK = new PictureBox();
            pictureBox8 = new PictureBox();
            groupBox17 = new GroupBox();
            pbLEDPOTOK = new PictureBox();
            forgroundKnob = new Label();
            sliderBck = new Label();
            groupBoxSWT = new GroupBox();
            pbLEDTOUCHOK = new PictureBox();
            pictureBoxOnOff = new PictureBox();
            LEDOnOff = new PictureBox();
            groupBoxLEDS = new GroupBox();
            groupBox15 = new GroupBox();
            PBLEDBLUOK = new PictureBox();
            rbB0 = new RadioButton();
            rbB50 = new RadioButton();
            rbB100 = new RadioButton();
            LEDBluPower = new PictureBox();
            groupBox14 = new GroupBox();
            PBLEDVERDEOK = new PictureBox();
            rbG0 = new RadioButton();
            rbG50 = new RadioButton();
            rbG100 = new RadioButton();
            LEDVerdePower = new PictureBox();
            groupBox12 = new GroupBox();
            pbLEDROSSOOK = new PictureBox();
            rbR0 = new RadioButton();
            rbR50 = new RadioButton();
            rbR100 = new RadioButton();
            LEDRossoPower = new PictureBox();
            groupBox18 = new GroupBox();
            groupBox24 = new GroupBox();
            pbLED_RS4853T = new PictureBox();
            pbLED_RS48513T = new PictureBox();
            label5 = new Label();
            label7 = new Label();
            groupBox23 = new GroupBox();
            pbLED_RS4852T = new PictureBox();
            pbLED_RS48512T = new PictureBox();
            label25 = new Label();
            label26 = new Label();
            groupBox19 = new GroupBox();
            groupBox20 = new GroupBox();
            ledNTC2Anal = new PictureBox();
            lblNTC2val = new Label();
            groupBox21 = new GroupBox();
            ledNTC1Anal = new PictureBox();
            lblNTC1val = new Label();
            pictureBoxConnected = new PictureBox();
            labelConnected = new Label();
            pictureBox1 = new PictureBox();
            timerTest = new System.Windows.Forms.Timer(components);
            timerPowerOn = new System.Windows.Forms.Timer(components);
            sysTimer = new System.Windows.Forms.Timer(components);
            timerAutoClick = new System.Windows.Forms.Timer(components);
            menuStrip1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownIndirizzoMaster).BeginInit();
            tabPage2.SuspendLayout();
            CassetteFancoilGrp.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btLEDSOK).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbLED5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbLED4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbLED3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbLED2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbLED1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbLED0).BeginInit();
            groupBox11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbLEDPRESSOK).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbLEDADCDAC2OK).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbLEDADCDAC1OK).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DAC1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DAC2).BeginInit();
            groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbLEDTRIACOK).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbLEDDIOK).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbLEDDI5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbLEDDI4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbLEDDI3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbLEDDI2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbLEDDI1).BeginInit();
            groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbLED_RS4852PLC).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbLED_RS4851PLC).BeginInit();
            groupBox6.SuspendLayout();
            groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbLEDNTC2).BeginInit();
            groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbLEDNTC1).BeginInit();
            TermostatoAnalogicoGrp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            groupBoxBEEP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbLEDBEEPOK).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            groupBox17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbLEDPOTOK).BeginInit();
            groupBoxSWT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbLEDTOUCHOK).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxOnOff).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LEDOnOff).BeginInit();
            groupBoxLEDS.SuspendLayout();
            groupBox15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PBLEDBLUOK).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LEDBluPower).BeginInit();
            groupBox14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PBLEDVERDEOK).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LEDVerdePower).BeginInit();
            groupBox12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbLEDROSSOOK).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LEDRossoPower).BeginInit();
            groupBox18.SuspendLayout();
            groupBox24.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbLED_RS4853T).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbLED_RS48513T).BeginInit();
            groupBox23.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbLED_RS4852T).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbLED_RS48512T).BeginInit();
            groupBox19.SuspendLayout();
            groupBox20.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ledNTC2Anal).BeginInit();
            groupBox21.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ledNTC1Anal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxConnected).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, cOMToolStripMenuItem, lingiaToolStripMenuItem, toolStripMenuItem1 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 2, 0, 2);
            menuStrip1.Size = new Size(1010, 24);
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
            // timerConnessione
            // 
            timerConnessione.Interval = 1000;
            timerConnessione.Tick += timerConnessione_Tick;
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
            // timerVerifica
            // 
            timerVerifica.Interval = 500;
            timerVerifica.Tick += timerVerifica_Tick;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(47, 27);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(919, 512);
            tabControl1.TabIndex = 21;
            tabControl1.Selecting += tabControl1_Selecting;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(groupBox2);
            tabPage1.Controls.Add(groupBox1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(911, 484);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "INIZIALIZZAZIONE";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(chkMatricola);
            groupBox2.Controls.Add(chkModbus);
            groupBox2.Controls.Add(chkNetlist);
            groupBox2.Controls.Add(chkParametri);
            groupBox2.Controls.Add(btnReset);
            groupBox2.Location = new Point(122, 274);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(640, 116);
            groupBox2.TabIndex = 25;
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
            // groupBox1
            // 
            groupBox1.Controls.Add(msgErr);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(lblVersione);
            groupBox1.Controls.Add(btnSet);
            groupBox1.Controls.Add(textBoxMatricola);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(radioButtonSlave);
            groupBox1.Controls.Add(lblDispositivo);
            groupBox1.Controls.Add(radioButtonMaster);
            groupBox1.Controls.Add(labelIndirizzo);
            groupBox1.Controls.Add(numericUpDownIndirizzoMaster);
            groupBox1.Location = new Point(122, 56);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(640, 193);
            groupBox1.TabIndex = 24;
            groupBox1.TabStop = false;
            groupBox1.Text = "PARAMETRI";
            // 
            // msgErr
            // 
            msgErr.AutoSize = true;
            msgErr.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            msgErr.Location = new Point(460, 75);
            msgErr.Margin = new Padding(4, 0, 4, 0);
            msgErr.Name = "msgErr";
            msgErr.Size = new Size(0, 15);
            msgErr.TabIndex = 22;
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
            lblVersione.Size = new Size(28, 21);
            lblVersione.TabIndex = 19;
            lblVersione.Text = "---";
            // 
            // btnSet
            // 
            btnSet.Location = new Point(549, 162);
            btnSet.Name = "btnSet";
            btnSet.Size = new Size(75, 23);
            btnSet.TabIndex = 18;
            btnSet.Text = "Set";
            btnSet.UseVisualStyleBackColor = true;
            btnSet.Click += btnSet_Click;
            // 
            // textBoxMatricola
            // 
            textBoxMatricola.Location = new Point(460, 36);
            textBoxMatricola.Name = "textBoxMatricola";
            textBoxMatricola.Size = new Size(164, 23);
            textBoxMatricola.TabIndex = 17;
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
            radioButtonSlave.CheckedChanged += radioButtonSlave_CheckedChanged_1;
            // 
            // lblDispositivo
            // 
            lblDispositivo.AutoSize = true;
            lblDispositivo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblDispositivo.Location = new Point(140, 119);
            lblDispositivo.Margin = new Padding(4, 0, 4, 0);
            lblDispositivo.Name = "lblDispositivo";
            lblDispositivo.Size = new Size(28, 21);
            lblDispositivo.TabIndex = 4;
            lblDispositivo.Text = "---";
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
            // 
            // labelIndirizzo
            // 
            labelIndirizzo.AutoSize = true;
            labelIndirizzo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelIndirizzo.Location = new Point(374, 111);
            labelIndirizzo.Margin = new Padding(4, 0, 4, 0);
            labelIndirizzo.Name = "labelIndirizzo";
            labelIndirizzo.Size = new Size(69, 21);
            labelIndirizzo.TabIndex = 9;
            labelIndirizzo.Text = "Indirizzo";
            // 
            // numericUpDownIndirizzoMaster
            // 
            numericUpDownIndirizzoMaster.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            numericUpDownIndirizzoMaster.Location = new Point(571, 111);
            numericUpDownIndirizzoMaster.Maximum = new decimal(new int[] { 254, 0, 0, 0 });
            numericUpDownIndirizzoMaster.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownIndirizzoMaster.Name = "numericUpDownIndirizzoMaster";
            numericUpDownIndirizzoMaster.Size = new Size(53, 29);
            numericUpDownIndirizzoMaster.TabIndex = 8;
            numericUpDownIndirizzoMaster.TextAlign = HorizontalAlignment.Right;
            numericUpDownIndirizzoMaster.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(CassetteFancoilGrp);
            tabPage2.Controls.Add(TermostatoAnalogicoGrp);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(911, 484);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "TEST";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // CassetteFancoilGrp
            // 
            CassetteFancoilGrp.Controls.Add(groupBox3);
            CassetteFancoilGrp.Controls.Add(groupBox11);
            CassetteFancoilGrp.Controls.Add(groupBox4);
            CassetteFancoilGrp.Controls.Add(groupBox10);
            CassetteFancoilGrp.Controls.Add(groupBox5);
            CassetteFancoilGrp.Controls.Add(groupBox9);
            CassetteFancoilGrp.Controls.Add(groupBox6);
            CassetteFancoilGrp.Location = new Point(18, 23);
            CassetteFancoilGrp.Name = "CassetteFancoilGrp";
            CassetteFancoilGrp.Size = new Size(855, 458);
            CassetteFancoilGrp.TabIndex = 11;
            CassetteFancoilGrp.TabStop = false;
            CassetteFancoilGrp.Text = "CASSETTE/FANCOIL";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label1);
            groupBox3.Controls.Add(btnAutotest);
            groupBox3.Controls.Add(btLEDSOK);
            groupBox3.Controls.Add(pbLED5);
            groupBox3.Controls.Add(btnLED5);
            groupBox3.Controls.Add(pbLED4);
            groupBox3.Controls.Add(btnLED4);
            groupBox3.Controls.Add(pbLED3);
            groupBox3.Controls.Add(btnLED3);
            groupBox3.Controls.Add(pbLED2);
            groupBox3.Controls.Add(btnLED2);
            groupBox3.Controls.Add(pbLED1);
            groupBox3.Controls.Add(btnLED1);
            groupBox3.Controls.Add(pbLED0);
            groupBox3.Controls.Add(btnLED0);
            groupBox3.Location = new Point(23, 33);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(399, 203);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            groupBox3.Text = "LED";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(332, 40);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 16;
            label1.Text = "AUTOTEST";
            // 
            // btnAutotest
            // 
            btnAutotest.FlatStyle = FlatStyle.Flat;
            btnAutotest.Image = configuratoreSerial6._0.Resource1.autotestOFF;
            btnAutotest.Location = new Point(340, 68);
            btnAutotest.Name = "btnAutotest";
            btnAutotest.Size = new Size(45, 73);
            btnAutotest.TabIndex = 15;
            btnAutotest.UseVisualStyleBackColor = true;
            btnAutotest.Click += btnAutotest_Click;
            // 
            // btLEDSOK
            // 
            btLEDSOK.Image = configuratoreSerial6._0.Resource1.LedVerdeOFF;
            btLEDSOK.Location = new Point(254, 22);
            btLEDSOK.Name = "btLEDSOK";
            btLEDSOK.Size = new Size(39, 43);
            btLEDSOK.SizeMode = PictureBoxSizeMode.StretchImage;
            btLEDSOK.TabIndex = 14;
            btLEDSOK.TabStop = false;
            // 
            // pbLED5
            // 
            pbLED5.Image = configuratoreSerial6._0.Resource1.LedVerdeOFF;
            pbLED5.Location = new Point(177, 108);
            pbLED5.Name = "pbLED5";
            pbLED5.Size = new Size(39, 43);
            pbLED5.SizeMode = PictureBoxSizeMode.StretchImage;
            pbLED5.TabIndex = 11;
            pbLED5.TabStop = false;
            // 
            // btnLED5
            // 
            btnLED5.Cursor = Cursors.Hand;
            btnLED5.FlatAppearance.BorderSize = 0;
            btnLED5.FlatStyle = FlatStyle.Flat;
            btnLED5.Image = configuratoreSerial6._0.Resource1.OFFSWT;
            btnLED5.Location = new Point(161, 150);
            btnLED5.Name = "btnLED5";
            btnLED5.Size = new Size(71, 43);
            btnLED5.TabIndex = 10;
            btnLED5.UseVisualStyleBackColor = true;
            // 
            // pbLED4
            // 
            pbLED4.Image = configuratoreSerial6._0.Resource1.LedVerdeOFF;
            pbLED4.Location = new Point(255, 107);
            pbLED4.Name = "pbLED4";
            pbLED4.Size = new Size(39, 43);
            pbLED4.SizeMode = PictureBoxSizeMode.StretchImage;
            pbLED4.TabIndex = 9;
            pbLED4.TabStop = false;
            // 
            // btnLED4
            // 
            btnLED4.Cursor = Cursors.Hand;
            btnLED4.FlatAppearance.BorderSize = 0;
            btnLED4.FlatStyle = FlatStyle.Flat;
            btnLED4.Image = configuratoreSerial6._0.Resource1.OFFSWT;
            btnLED4.Location = new Point(239, 149);
            btnLED4.Name = "btnLED4";
            btnLED4.Size = new Size(71, 43);
            btnLED4.TabIndex = 8;
            btnLED4.UseVisualStyleBackColor = true;
            // 
            // pbLED3
            // 
            pbLED3.Image = configuratoreSerial6._0.Resource1.LedVerdeOFF;
            pbLED3.Location = new Point(22, 109);
            pbLED3.Name = "pbLED3";
            pbLED3.Size = new Size(39, 43);
            pbLED3.SizeMode = PictureBoxSizeMode.StretchImage;
            pbLED3.TabIndex = 7;
            pbLED3.TabStop = false;
            // 
            // btnLED3
            // 
            btnLED3.Cursor = Cursors.Hand;
            btnLED3.FlatAppearance.BorderSize = 0;
            btnLED3.FlatStyle = FlatStyle.Flat;
            btnLED3.Image = configuratoreSerial6._0.Resource1.OFFSWT;
            btnLED3.Location = new Point(6, 151);
            btnLED3.Name = "btnLED3";
            btnLED3.Size = new Size(71, 43);
            btnLED3.TabIndex = 6;
            btnLED3.UseVisualStyleBackColor = true;
            // 
            // pbLED2
            // 
            pbLED2.Image = configuratoreSerial6._0.Resource1.LedVerdeOFF;
            pbLED2.Location = new Point(99, 109);
            pbLED2.Name = "pbLED2";
            pbLED2.Size = new Size(39, 43);
            pbLED2.SizeMode = PictureBoxSizeMode.StretchImage;
            pbLED2.TabIndex = 5;
            pbLED2.TabStop = false;
            // 
            // btnLED2
            // 
            btnLED2.Cursor = Cursors.Hand;
            btnLED2.FlatAppearance.BorderSize = 0;
            btnLED2.FlatStyle = FlatStyle.Flat;
            btnLED2.Image = configuratoreSerial6._0.Resource1.OFFSWT;
            btnLED2.Location = new Point(83, 151);
            btnLED2.Name = "btnLED2";
            btnLED2.Size = new Size(71, 43);
            btnLED2.TabIndex = 4;
            btnLED2.UseVisualStyleBackColor = true;
            // 
            // pbLED1
            // 
            pbLED1.Image = configuratoreSerial6._0.Resource1.LedRossoOFF;
            pbLED1.Location = new Point(22, 17);
            pbLED1.Name = "pbLED1";
            pbLED1.Size = new Size(39, 43);
            pbLED1.SizeMode = PictureBoxSizeMode.StretchImage;
            pbLED1.TabIndex = 3;
            pbLED1.TabStop = false;
            // 
            // btnLED1
            // 
            btnLED1.Cursor = Cursors.Hand;
            btnLED1.FlatAppearance.BorderSize = 0;
            btnLED1.FlatStyle = FlatStyle.Flat;
            btnLED1.Image = configuratoreSerial6._0.Resource1.OFF;
            btnLED1.Location = new Point(6, 60);
            btnLED1.Name = "btnLED1";
            btnLED1.Size = new Size(71, 43);
            btnLED1.TabIndex = 2;
            btnLED1.UseVisualStyleBackColor = true;
            // 
            // pbLED0
            // 
            pbLED0.Image = configuratoreSerial6._0.Resource1.LedRossoOFF;
            pbLED0.Location = new Point(99, 17);
            pbLED0.Name = "pbLED0";
            pbLED0.Size = new Size(39, 43);
            pbLED0.SizeMode = PictureBoxSizeMode.StretchImage;
            pbLED0.TabIndex = 1;
            pbLED0.TabStop = false;
            // 
            // btnLED0
            // 
            btnLED0.Cursor = Cursors.Hand;
            btnLED0.FlatAppearance.BorderSize = 0;
            btnLED0.FlatStyle = FlatStyle.Flat;
            btnLED0.Image = configuratoreSerial6._0.Resource1.OFFSWT;
            btnLED0.Location = new Point(83, 60);
            btnLED0.Name = "btnLED0";
            btnLED0.Size = new Size(71, 43);
            btnLED0.TabIndex = 0;
            btnLED0.UseVisualStyleBackColor = true;
            // 
            // groupBox11
            // 
            groupBox11.Controls.Add(pbLEDPRESSOK);
            groupBox11.Controls.Add(lblPressSensFrg);
            groupBox11.Controls.Add(lblPressSensBck);
            groupBox11.Controls.Add(pictureBox3);
            groupBox11.Location = new Point(670, 355);
            groupBox11.Name = "groupBox11";
            groupBox11.Size = new Size(161, 88);
            groupBox11.TabIndex = 10;
            groupBox11.TabStop = false;
            groupBox11.Text = "PRESSURE SENSOR";
            // 
            // pbLEDPRESSOK
            // 
            pbLEDPRESSOK.Image = configuratoreSerial6._0.Resource1.LedVerdeOFF;
            pbLEDPRESSOK.Location = new Point(114, 26);
            pbLEDPRESSOK.Name = "pbLEDPRESSOK";
            pbLEDPRESSOK.Size = new Size(39, 43);
            pbLEDPRESSOK.SizeMode = PictureBoxSizeMode.StretchImage;
            pbLEDPRESSOK.TabIndex = 16;
            pbLEDPRESSOK.TabStop = false;
            // 
            // lblPressSensFrg
            // 
            lblPressSensFrg.BackColor = Color.Red;
            lblPressSensFrg.Location = new Point(65, 15);
            lblPressSensFrg.Name = "lblPressSensFrg";
            lblPressSensFrg.Size = new Size(41, 29);
            lblPressSensFrg.TabIndex = 7;
            // 
            // lblPressSensBck
            // 
            lblPressSensBck.BackColor = Color.SpringGreen;
            lblPressSensBck.Location = new Point(65, 15);
            lblPressSensBck.Name = "lblPressSensBck";
            lblPressSensBck.Size = new Size(41, 67);
            lblPressSensBck.TabIndex = 6;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = configuratoreSerial6._0.Resource1.sensorePress;
            pictureBox3.Location = new Point(6, 15);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(53, 55);
            pictureBox3.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox3.TabIndex = 2;
            pictureBox3.TabStop = false;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(pbLEDADCDAC2OK);
            groupBox4.Controls.Add(pbLEDADCDAC1OK);
            groupBox4.Controls.Add(lblADC2);
            groupBox4.Controls.Add(lblADC1);
            groupBox4.Controls.Add(lblADC2bkg);
            groupBox4.Controls.Add(DAC1);
            groupBox4.Controls.Add(DAC2);
            groupBox4.Controls.Add(lblADC1bkg);
            groupBox4.Location = new Point(434, 43);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(397, 193);
            groupBox4.TabIndex = 5;
            groupBox4.TabStop = false;
            groupBox4.Text = "ADC / DAC";
            // 
            // pbLEDADCDAC2OK
            // 
            pbLEDADCDAC2OK.Image = configuratoreSerial6._0.Resource1.LedVerdeOFF;
            pbLEDADCDAC2OK.Location = new Point(350, 50);
            pbLEDADCDAC2OK.Name = "pbLEDADCDAC2OK";
            pbLEDADCDAC2OK.Size = new Size(39, 43);
            pbLEDADCDAC2OK.SizeMode = PictureBoxSizeMode.StretchImage;
            pbLEDADCDAC2OK.TabIndex = 26;
            pbLEDADCDAC2OK.TabStop = false;
            // 
            // pbLEDADCDAC1OK
            // 
            pbLEDADCDAC1OK.Image = configuratoreSerial6._0.Resource1.LedVerdeOFF;
            pbLEDADCDAC1OK.Location = new Point(350, 134);
            pbLEDADCDAC1OK.Name = "pbLEDADCDAC1OK";
            pbLEDADCDAC1OK.Size = new Size(39, 43);
            pbLEDADCDAC1OK.SizeMode = PictureBoxSizeMode.StretchImage;
            pbLEDADCDAC1OK.TabIndex = 25;
            pbLEDADCDAC1OK.TabStop = false;
            // 
            // lblADC2
            // 
            lblADC2.BackColor = Color.Red;
            lblADC2.Location = new Point(27, 161);
            lblADC2.Name = "lblADC2";
            lblADC2.Size = new Size(158, 16);
            lblADC2.TabIndex = 7;
            // 
            // lblADC1
            // 
            lblADC1.BackColor = Color.Red;
            lblADC1.Location = new Point(27, 74);
            lblADC1.Name = "lblADC1";
            lblADC1.Size = new Size(158, 16);
            lblADC1.TabIndex = 6;
            // 
            // lblADC2bkg
            // 
            lblADC2bkg.BackColor = Color.SpringGreen;
            lblADC2bkg.Location = new Point(27, 161);
            lblADC2bkg.Name = "lblADC2bkg";
            lblADC2bkg.Size = new Size(291, 16);
            lblADC2bkg.TabIndex = 5;
            // 
            // DAC1
            // 
            DAC1.Cursor = Cursors.Hand;
            DAC1.Location = new Point(29, 113);
            DAC1.Maximum = 1023;
            DAC1.Name = "DAC1";
            DAC1.Size = new Size(291, 45);
            DAC1.TabIndex = 2;
            DAC1.TickFrequency = 10;
            // 
            // DAC2
            // 
            DAC2.Cursor = Cursors.Hand;
            DAC2.Location = new Point(27, 26);
            DAC2.Maximum = 1023;
            DAC2.Name = "DAC2";
            DAC2.Size = new Size(291, 45);
            DAC2.TabIndex = 3;
            DAC2.TickFrequency = 10;
            // 
            // lblADC1bkg
            // 
            lblADC1bkg.BackColor = Color.SpringGreen;
            lblADC1bkg.Location = new Point(27, 74);
            lblADC1bkg.Name = "lblADC1bkg";
            lblADC1bkg.Size = new Size(291, 16);
            lblADC1bkg.TabIndex = 4;
            // 
            // groupBox10
            // 
            groupBox10.Controls.Add(pbLEDTRIACOK);
            groupBox10.Controls.Add(btnTriac2);
            groupBox10.Controls.Add(btnTriac1);
            groupBox10.Controls.Add(pictureBox2);
            groupBox10.Location = new Point(434, 355);
            groupBox10.Name = "groupBox10";
            groupBox10.Size = new Size(230, 88);
            groupBox10.TabIndex = 9;
            groupBox10.TabStop = false;
            groupBox10.Text = "TRIAC";
            // 
            // pbLEDTRIACOK
            // 
            pbLEDTRIACOK.Image = configuratoreSerial6._0.Resource1.LedVerdeOFF;
            pbLEDTRIACOK.Location = new Point(183, 27);
            pbLEDTRIACOK.Name = "pbLEDTRIACOK";
            pbLEDTRIACOK.Size = new Size(39, 43);
            pbLEDTRIACOK.SizeMode = PictureBoxSizeMode.StretchImage;
            pbLEDTRIACOK.TabIndex = 15;
            pbLEDTRIACOK.TabStop = false;
            // 
            // btnTriac2
            // 
            btnTriac2.Cursor = Cursors.Hand;
            btnTriac2.FlatAppearance.BorderSize = 0;
            btnTriac2.FlatStyle = FlatStyle.Flat;
            btnTriac2.Image = configuratoreSerial6._0.Resource1.triac_2_off;
            btnTriac2.Location = new Point(76, 53);
            btnTriac2.Name = "btnTriac2";
            btnTriac2.Size = new Size(91, 29);
            btnTriac2.TabIndex = 4;
            btnTriac2.UseVisualStyleBackColor = true;
            btnTriac2.MouseDown += btnTriac2_MouseDown;
            btnTriac2.MouseLeave += btnTriac2_MouseLeave;
            btnTriac2.MouseUp += btnTriac2_MouseUp;
            // 
            // btnTriac1
            // 
            btnTriac1.Cursor = Cursors.Hand;
            btnTriac1.FlatAppearance.BorderSize = 0;
            btnTriac1.FlatStyle = FlatStyle.Flat;
            btnTriac1.Image = configuratoreSerial6._0.Resource1.triac_1_off;
            btnTriac1.Location = new Point(76, 18);
            btnTriac1.Name = "btnTriac1";
            btnTriac1.Size = new Size(93, 29);
            btnTriac1.TabIndex = 3;
            btnTriac1.UseVisualStyleBackColor = true;
            btnTriac1.MouseDown += btnTriac1_MouseDown;
            btnTriac1.MouseLeave += btnTriac1_MouseLeave;
            btnTriac1.MouseUp += btnTriac1_MouseUp;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = configuratoreSerial6._0.Resource1.triac;
            pictureBox2.Location = new Point(6, 15);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(64, 67);
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(pbLEDDIOK);
            groupBox5.Controls.Add(label18);
            groupBox5.Controls.Add(label19);
            groupBox5.Controls.Add(label15);
            groupBox5.Controls.Add(label16);
            groupBox5.Controls.Add(label17);
            groupBox5.Controls.Add(pbLEDDI5);
            groupBox5.Controls.Add(pbLEDDI4);
            groupBox5.Controls.Add(pbLEDDI3);
            groupBox5.Controls.Add(pbLEDDI2);
            groupBox5.Controls.Add(pbLEDDI1);
            groupBox5.Location = new Point(23, 242);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(399, 100);
            groupBox5.TabIndex = 6;
            groupBox5.TabStop = false;
            groupBox5.Text = "DIGITAL INPUT";
            // 
            // pbLEDDIOK
            // 
            pbLEDDIOK.Image = configuratoreSerial6._0.Resource1.LedVerdeOFF;
            pbLEDDIOK.Location = new Point(354, 33);
            pbLEDDIOK.Name = "pbLEDDIOK";
            pbLEDDIOK.Size = new Size(39, 43);
            pbLEDDIOK.SizeMode = PictureBoxSizeMode.StretchImage;
            pbLEDDIOK.TabIndex = 24;
            pbLEDDIOK.TabStop = false;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(280, 79);
            label18.Name = "label18";
            label18.Size = new Size(13, 15);
            label18.TabIndex = 23;
            label18.Text = "5";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(212, 81);
            label19.Name = "label19";
            label19.Size = new Size(13, 15);
            label19.TabIndex = 22;
            label19.Text = "4";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(150, 81);
            label15.Name = "label15";
            label15.Size = new Size(13, 15);
            label15.TabIndex = 21;
            label15.Text = "3";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(91, 79);
            label16.Name = "label16";
            label16.Size = new Size(13, 15);
            label16.TabIndex = 20;
            label16.Text = "2";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(31, 81);
            label17.Name = "label17";
            label17.Size = new Size(13, 15);
            label17.TabIndex = 19;
            label17.Text = "1";
            // 
            // pbLEDDI5
            // 
            pbLEDDI5.Image = configuratoreSerial6._0.Resource1.LedBluOFF;
            pbLEDDI5.Location = new Point(266, 33);
            pbLEDDI5.Name = "pbLEDDI5";
            pbLEDDI5.Size = new Size(39, 43);
            pbLEDDI5.SizeMode = PictureBoxSizeMode.StretchImage;
            pbLEDDI5.TabIndex = 16;
            pbLEDDI5.TabStop = false;
            // 
            // pbLEDDI4
            // 
            pbLEDDI4.Image = configuratoreSerial6._0.Resource1.LedBluOFF;
            pbLEDDI4.Location = new Point(199, 33);
            pbLEDDI4.Name = "pbLEDDI4";
            pbLEDDI4.Size = new Size(39, 43);
            pbLEDDI4.SizeMode = PictureBoxSizeMode.StretchImage;
            pbLEDDI4.TabIndex = 15;
            pbLEDDI4.TabStop = false;
            // 
            // pbLEDDI3
            // 
            pbLEDDI3.Image = configuratoreSerial6._0.Resource1.LedBluOFF;
            pbLEDDI3.Location = new Point(138, 33);
            pbLEDDI3.Name = "pbLEDDI3";
            pbLEDDI3.Size = new Size(39, 43);
            pbLEDDI3.SizeMode = PictureBoxSizeMode.StretchImage;
            pbLEDDI3.TabIndex = 14;
            pbLEDDI3.TabStop = false;
            // 
            // pbLEDDI2
            // 
            pbLEDDI2.Image = configuratoreSerial6._0.Resource1.LedBluOFF;
            pbLEDDI2.Location = new Point(78, 33);
            pbLEDDI2.Name = "pbLEDDI2";
            pbLEDDI2.Size = new Size(39, 43);
            pbLEDDI2.SizeMode = PictureBoxSizeMode.StretchImage;
            pbLEDDI2.TabIndex = 13;
            pbLEDDI2.TabStop = false;
            // 
            // pbLEDDI1
            // 
            pbLEDDI1.Image = configuratoreSerial6._0.Resource1.LedBluOFF;
            pbLEDDI1.Location = new Point(18, 33);
            pbLEDDI1.Name = "pbLEDDI1";
            pbLEDDI1.Size = new Size(39, 43);
            pbLEDDI1.SizeMode = PictureBoxSizeMode.StretchImage;
            pbLEDDI1.TabIndex = 12;
            pbLEDDI1.TabStop = false;
            // 
            // groupBox9
            // 
            groupBox9.Controls.Add(label4);
            groupBox9.Controls.Add(pbLED_RS4852PLC);
            groupBox9.Controls.Add(label11);
            groupBox9.Controls.Add(pbLED_RS4851PLC);
            groupBox9.Location = new Point(434, 253);
            groupBox9.Name = "groupBox9";
            groupBox9.Size = new Size(397, 89);
            groupBox9.TabIndex = 8;
            groupBox9.TabStop = false;
            groupBox9.Text = "RS-485";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(265, 71);
            label4.Name = "label4";
            label4.Size = new Size(13, 15);
            label4.TabIndex = 19;
            label4.Text = "2";
            label4.UseMnemonic = false;
            // 
            // pbLED_RS4852PLC
            // 
            pbLED_RS4852PLC.Image = configuratoreSerial6._0.Resource1.LedRossoOFF;
            pbLED_RS4852PLC.Location = new Point(254, 20);
            pbLED_RS4852PLC.Name = "pbLED_RS4852PLC";
            pbLED_RS4852PLC.Size = new Size(39, 43);
            pbLED_RS4852PLC.SizeMode = PictureBoxSizeMode.StretchImage;
            pbLED_RS4852PLC.TabIndex = 18;
            pbLED_RS4852PLC.TabStop = false;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(82, 71);
            label11.Name = "label11";
            label11.Size = new Size(13, 15);
            label11.TabIndex = 16;
            label11.Text = "1";
            // 
            // pbLED_RS4851PLC
            // 
            pbLED_RS4851PLC.Image = configuratoreSerial6._0.Resource1.LedRossoOFF;
            pbLED_RS4851PLC.Location = new Point(71, 20);
            pbLED_RS4851PLC.Name = "pbLED_RS4851PLC";
            pbLED_RS4851PLC.Size = new Size(39, 43);
            pbLED_RS4851PLC.SizeMode = PictureBoxSizeMode.StretchImage;
            pbLED_RS4851PLC.TabIndex = 13;
            pbLED_RS4851PLC.TabStop = false;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(groupBox8);
            groupBox6.Controls.Add(groupBox7);
            groupBox6.Location = new Point(23, 348);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(333, 95);
            groupBox6.TabIndex = 7;
            groupBox6.TabStop = false;
            groupBox6.Text = "NTC";
            // 
            // groupBox8
            // 
            groupBox8.Controls.Add(pbLEDNTC2);
            groupBox8.Controls.Add(lblNTC2);
            groupBox8.Location = new Point(141, 22);
            groupBox8.Name = "groupBox8";
            groupBox8.Size = new Size(128, 55);
            groupBox8.TabIndex = 1;
            groupBox8.TabStop = false;
            groupBox8.Text = "NTC2";
            // 
            // pbLEDNTC2
            // 
            pbLEDNTC2.Image = configuratoreSerial6._0.Resource1.LedRossoOFF;
            pbLEDNTC2.Location = new Point(71, 12);
            pbLEDNTC2.Name = "pbLEDNTC2";
            pbLEDNTC2.Size = new Size(39, 43);
            pbLEDNTC2.SizeMode = PictureBoxSizeMode.StretchImage;
            pbLEDNTC2.TabIndex = 12;
            pbLEDNTC2.TabStop = false;
            // 
            // lblNTC2
            // 
            lblNTC2.AutoSize = true;
            lblNTC2.Location = new Point(12, 19);
            lblNTC2.Name = "lblNTC2";
            lblNTC2.Size = new Size(44, 15);
            lblNTC2.TabIndex = 0;
            lblNTC2.Text = "label10";
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(pbLEDNTC1);
            groupBox7.Controls.Add(lblNTC1);
            groupBox7.Location = new Point(7, 22);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new Size(128, 55);
            groupBox7.TabIndex = 0;
            groupBox7.TabStop = false;
            groupBox7.Text = "NTC1";
            // 
            // pbLEDNTC1
            // 
            pbLEDNTC1.Image = configuratoreSerial6._0.Resource1.LedRossoOFF;
            pbLEDNTC1.Location = new Point(71, 12);
            pbLEDNTC1.Name = "pbLEDNTC1";
            pbLEDNTC1.Size = new Size(39, 43);
            pbLEDNTC1.SizeMode = PictureBoxSizeMode.StretchImage;
            pbLEDNTC1.TabIndex = 12;
            pbLEDNTC1.TabStop = false;
            // 
            // lblNTC1
            // 
            lblNTC1.AutoSize = true;
            lblNTC1.Location = new Point(12, 19);
            lblNTC1.Name = "lblNTC1";
            lblNTC1.Size = new Size(38, 15);
            lblNTC1.TabIndex = 0;
            lblNTC1.Text = "label9";
            // 
            // TermostatoAnalogicoGrp
            // 
            TermostatoAnalogicoGrp.Controls.Add(pictureBox5);
            TermostatoAnalogicoGrp.Controls.Add(pictureBox4);
            TermostatoAnalogicoGrp.Controls.Add(groupBoxBEEP);
            TermostatoAnalogicoGrp.Controls.Add(groupBox17);
            TermostatoAnalogicoGrp.Controls.Add(groupBoxSWT);
            TermostatoAnalogicoGrp.Controls.Add(groupBoxLEDS);
            TermostatoAnalogicoGrp.Controls.Add(groupBox18);
            TermostatoAnalogicoGrp.Controls.Add(groupBox19);
            TermostatoAnalogicoGrp.Location = new Point(18, 23);
            TermostatoAnalogicoGrp.Name = "TermostatoAnalogicoGrp";
            TermostatoAnalogicoGrp.Size = new Size(855, 458);
            TermostatoAnalogicoGrp.TabIndex = 12;
            TermostatoAnalogicoGrp.TabStop = false;
            TermostatoAnalogicoGrp.Text = "TERMOSTATO ANALOGICO";
            // 
            // pictureBox5
            // 
            pictureBox5.Image = configuratoreSerial6._0.Resource1.CABINA_USBEMU;
            pictureBox5.Location = new Point(661, 339);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(93, 101);
            pictureBox5.TabIndex = 22;
            pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = configuratoreSerial6._0.Resource1.CABINA_MODBUS;
            pictureBox4.Location = new Point(482, 339);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(93, 101);
            pictureBox4.TabIndex = 21;
            pictureBox4.TabStop = false;
            // 
            // groupBoxBEEP
            // 
            groupBoxBEEP.Controls.Add(pbLEDBEEPOK);
            groupBoxBEEP.Controls.Add(pictureBox8);
            groupBoxBEEP.Location = new Point(600, 34);
            groupBoxBEEP.Name = "groupBoxBEEP";
            groupBoxBEEP.Size = new Size(182, 113);
            groupBoxBEEP.TabIndex = 20;
            groupBoxBEEP.TabStop = false;
            groupBoxBEEP.Text = "SPEAKER";
            // 
            // pbLEDBEEPOK
            // 
            pbLEDBEEPOK.Image = configuratoreSerial6._0.Resource1.LedVerdeOFF;
            pbLEDBEEPOK.Location = new Point(124, 38);
            pbLEDBEEPOK.Name = "pbLEDBEEPOK";
            pbLEDBEEPOK.Size = new Size(39, 43);
            pbLEDBEEPOK.SizeMode = PictureBoxSizeMode.StretchImage;
            pbLEDBEEPOK.TabIndex = 16;
            pbLEDBEEPOK.TabStop = false;
            // 
            // pictureBox8
            // 
            pictureBox8.ErrorImage = null;
            pictureBox8.Image = configuratoreSerial6._0.Resource1.SpeakerOFF;
            pictureBox8.Location = new Point(19, 22);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(92, 72);
            pictureBox8.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox8.TabIndex = 15;
            pictureBox8.TabStop = false;
            pictureBox8.MouseDown += pictureBox8_MouseDown;
            pictureBox8.MouseLeave += pictureBox8_MouseLeave;
            pictureBox8.MouseUp += pictureBox8_MouseUp;
            // 
            // groupBox17
            // 
            groupBox17.Controls.Add(pbLEDPOTOK);
            groupBox17.Controls.Add(forgroundKnob);
            groupBox17.Controls.Add(sliderBck);
            groupBox17.Location = new Point(428, 154);
            groupBox17.Name = "groupBox17";
            groupBox17.Size = new Size(356, 79);
            groupBox17.TabIndex = 20;
            groupBox17.TabStop = false;
            groupBox17.Text = "SLIDER/KNOB";
            // 
            // pbLEDPOTOK
            // 
            pbLEDPOTOK.Image = configuratoreSerial6._0.Resource1.LedVerdeOFF;
            pbLEDPOTOK.Location = new Point(299, 20);
            pbLEDPOTOK.Name = "pbLEDPOTOK";
            pbLEDPOTOK.Size = new Size(39, 43);
            pbLEDPOTOK.SizeMode = PictureBoxSizeMode.StretchImage;
            pbLEDPOTOK.TabIndex = 17;
            pbLEDPOTOK.TabStop = false;
            // 
            // forgroundKnob
            // 
            forgroundKnob.BackColor = Color.Red;
            forgroundKnob.Location = new Point(13, 32);
            forgroundKnob.Name = "forgroundKnob";
            forgroundKnob.Size = new Size(158, 23);
            forgroundKnob.TabIndex = 1;
            // 
            // sliderBck
            // 
            sliderBck.BackColor = Color.Lime;
            sliderBck.Location = new Point(13, 32);
            sliderBck.Name = "sliderBck";
            sliderBck.Size = new Size(280, 23);
            sliderBck.TabIndex = 0;
            // 
            // groupBoxSWT
            // 
            groupBoxSWT.Controls.Add(pbLEDTOUCHOK);
            groupBoxSWT.Controls.Add(pictureBoxOnOff);
            groupBoxSWT.Controls.Add(LEDOnOff);
            groupBoxSWT.Location = new Point(428, 34);
            groupBoxSWT.Name = "groupBoxSWT";
            groupBoxSWT.Size = new Size(151, 113);
            groupBoxSWT.TabIndex = 19;
            groupBoxSWT.TabStop = false;
            groupBoxSWT.Text = "SWITCH";
            // 
            // pbLEDTOUCHOK
            // 
            pbLEDTOUCHOK.Image = configuratoreSerial6._0.Resource1.LedVerdeOFF;
            pbLEDTOUCHOK.Location = new Point(13, 64);
            pbLEDTOUCHOK.Name = "pbLEDTOUCHOK";
            pbLEDTOUCHOK.Size = new Size(39, 43);
            pbLEDTOUCHOK.SizeMode = PictureBoxSizeMode.StretchImage;
            pbLEDTOUCHOK.TabIndex = 15;
            pbLEDTOUCHOK.TabStop = false;
            // 
            // pictureBoxOnOff
            // 
            pictureBoxOnOff.Image = configuratoreSerial6._0.Resource1.PushButton;
            pictureBoxOnOff.Location = new Point(80, 23);
            pictureBoxOnOff.Name = "pictureBoxOnOff";
            pictureBoxOnOff.Size = new Size(65, 84);
            pictureBoxOnOff.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxOnOff.TabIndex = 14;
            pictureBoxOnOff.TabStop = false;
            // 
            // LEDOnOff
            // 
            LEDOnOff.Image = configuratoreSerial6._0.Resource1.LedRossoOFF;
            LEDOnOff.Location = new Point(13, 22);
            LEDOnOff.Name = "LEDOnOff";
            LEDOnOff.Size = new Size(39, 43);
            LEDOnOff.SizeMode = PictureBoxSizeMode.StretchImage;
            LEDOnOff.TabIndex = 13;
            LEDOnOff.TabStop = false;
            // 
            // groupBoxLEDS
            // 
            groupBoxLEDS.Controls.Add(groupBox15);
            groupBoxLEDS.Controls.Add(groupBox14);
            groupBoxLEDS.Controls.Add(groupBox12);
            groupBoxLEDS.Location = new Point(17, 23);
            groupBoxLEDS.Name = "groupBoxLEDS";
            groupBoxLEDS.Size = new Size(333, 319);
            groupBoxLEDS.TabIndex = 0;
            groupBoxLEDS.TabStop = false;
            groupBoxLEDS.Text = "LED";
            // 
            // groupBox15
            // 
            groupBox15.Controls.Add(PBLEDBLUOK);
            groupBox15.Controls.Add(rbB0);
            groupBox15.Controls.Add(rbB50);
            groupBox15.Controls.Add(rbB100);
            groupBox15.Controls.Add(LEDBluPower);
            groupBox15.Location = new Point(7, 203);
            groupBox15.Name = "groupBox15";
            groupBox15.Size = new Size(300, 78);
            groupBox15.TabIndex = 19;
            groupBox15.TabStop = false;
            groupBox15.Text = "BLU";
            // 
            // PBLEDBLUOK
            // 
            PBLEDBLUOK.Image = configuratoreSerial6._0.Resource1.LedVerdeOFF;
            PBLEDBLUOK.Location = new Point(251, 22);
            PBLEDBLUOK.Name = "PBLEDBLUOK";
            PBLEDBLUOK.Size = new Size(39, 43);
            PBLEDBLUOK.SizeMode = PictureBoxSizeMode.StretchImage;
            PBLEDBLUOK.TabIndex = 19;
            PBLEDBLUOK.TabStop = false;
            // 
            // rbB0
            // 
            rbB0.AutoSize = true;
            rbB0.Checked = true;
            rbB0.Location = new Point(203, 31);
            rbB0.Name = "rbB0";
            rbB0.Size = new Size(41, 19);
            rbB0.TabIndex = 17;
            rbB0.TabStop = true;
            rbB0.Text = "0%";
            rbB0.UseVisualStyleBackColor = true;
            // 
            // rbB50
            // 
            rbB50.AutoSize = true;
            rbB50.Location = new Point(129, 31);
            rbB50.Name = "rbB50";
            rbB50.Size = new Size(47, 19);
            rbB50.TabIndex = 16;
            rbB50.Text = "50%";
            rbB50.UseVisualStyleBackColor = true;
            // 
            // rbB100
            // 
            rbB100.AutoSize = true;
            rbB100.Location = new Point(63, 31);
            rbB100.Name = "rbB100";
            rbB100.Size = new Size(53, 19);
            rbB100.TabIndex = 15;
            rbB100.Text = "100%";
            rbB100.UseVisualStyleBackColor = true;
            // 
            // LEDBluPower
            // 
            LEDBluPower.Image = configuratoreSerial6._0.Resource1.LedBluOFF;
            LEDBluPower.Location = new Point(12, 22);
            LEDBluPower.Name = "LEDBluPower";
            LEDBluPower.Size = new Size(39, 43);
            LEDBluPower.SizeMode = PictureBoxSizeMode.StretchImage;
            LEDBluPower.TabIndex = 16;
            LEDBluPower.TabStop = false;
            // 
            // groupBox14
            // 
            groupBox14.Controls.Add(PBLEDVERDEOK);
            groupBox14.Controls.Add(rbG0);
            groupBox14.Controls.Add(rbG50);
            groupBox14.Controls.Add(rbG100);
            groupBox14.Controls.Add(LEDVerdePower);
            groupBox14.Location = new Point(7, 106);
            groupBox14.Name = "groupBox14";
            groupBox14.Size = new Size(300, 78);
            groupBox14.TabIndex = 18;
            groupBox14.TabStop = false;
            groupBox14.Text = "VERDE";
            // 
            // PBLEDVERDEOK
            // 
            PBLEDVERDEOK.Image = configuratoreSerial6._0.Resource1.LedVerdeOFF;
            PBLEDVERDEOK.Location = new Point(252, 22);
            PBLEDVERDEOK.Name = "PBLEDVERDEOK";
            PBLEDVERDEOK.Size = new Size(39, 43);
            PBLEDVERDEOK.SizeMode = PictureBoxSizeMode.StretchImage;
            PBLEDVERDEOK.TabIndex = 19;
            PBLEDVERDEOK.TabStop = false;
            // 
            // rbG0
            // 
            rbG0.AutoSize = true;
            rbG0.Checked = true;
            rbG0.Location = new Point(203, 32);
            rbG0.Name = "rbG0";
            rbG0.Size = new Size(41, 19);
            rbG0.TabIndex = 17;
            rbG0.TabStop = true;
            rbG0.Text = "0%";
            rbG0.UseVisualStyleBackColor = true;
            // 
            // rbG50
            // 
            rbG50.AutoSize = true;
            rbG50.Location = new Point(129, 32);
            rbG50.Name = "rbG50";
            rbG50.Size = new Size(47, 19);
            rbG50.TabIndex = 16;
            rbG50.Text = "50%";
            rbG50.UseVisualStyleBackColor = true;
            // 
            // rbG100
            // 
            rbG100.AutoSize = true;
            rbG100.Location = new Point(63, 32);
            rbG100.Name = "rbG100";
            rbG100.Size = new Size(53, 19);
            rbG100.TabIndex = 15;
            rbG100.Text = "100%";
            rbG100.UseVisualStyleBackColor = true;
            // 
            // LEDVerdePower
            // 
            LEDVerdePower.Image = configuratoreSerial6._0.Resource1.LedVerdeOFF;
            LEDVerdePower.Location = new Point(12, 22);
            LEDVerdePower.Name = "LEDVerdePower";
            LEDVerdePower.Size = new Size(39, 43);
            LEDVerdePower.SizeMode = PictureBoxSizeMode.StretchImage;
            LEDVerdePower.TabIndex = 15;
            LEDVerdePower.TabStop = false;
            // 
            // groupBox12
            // 
            groupBox12.Controls.Add(pbLEDROSSOOK);
            groupBox12.Controls.Add(rbR0);
            groupBox12.Controls.Add(rbR50);
            groupBox12.Controls.Add(rbR100);
            groupBox12.Controls.Add(LEDRossoPower);
            groupBox12.Location = new Point(7, 22);
            groupBox12.Name = "groupBox12";
            groupBox12.Size = new Size(300, 78);
            groupBox12.TabIndex = 17;
            groupBox12.TabStop = false;
            groupBox12.Text = "ROSSO";
            // 
            // pbLEDROSSOOK
            // 
            pbLEDROSSOOK.Image = configuratoreSerial6._0.Resource1.LedVerdeOFF;
            pbLEDROSSOOK.Location = new Point(252, 23);
            pbLEDROSSOOK.Name = "pbLEDROSSOOK";
            pbLEDROSSOOK.Size = new Size(39, 43);
            pbLEDROSSOOK.SizeMode = PictureBoxSizeMode.StretchImage;
            pbLEDROSSOOK.TabIndex = 18;
            pbLEDROSSOOK.TabStop = false;
            // 
            // rbR0
            // 
            rbR0.AutoSize = true;
            rbR0.Checked = true;
            rbR0.Location = new Point(203, 31);
            rbR0.Name = "rbR0";
            rbR0.Size = new Size(41, 19);
            rbR0.TabIndex = 17;
            rbR0.TabStop = true;
            rbR0.Text = "0%";
            rbR0.UseVisualStyleBackColor = true;
            // 
            // rbR50
            // 
            rbR50.AutoSize = true;
            rbR50.Location = new Point(129, 31);
            rbR50.Name = "rbR50";
            rbR50.Size = new Size(47, 19);
            rbR50.TabIndex = 16;
            rbR50.Text = "50%";
            rbR50.UseVisualStyleBackColor = true;
            // 
            // rbR100
            // 
            rbR100.AutoSize = true;
            rbR100.Location = new Point(63, 31);
            rbR100.Name = "rbR100";
            rbR100.Size = new Size(53, 19);
            rbR100.TabIndex = 15;
            rbR100.Text = "100%";
            rbR100.UseVisualStyleBackColor = true;
            // 
            // LEDRossoPower
            // 
            LEDRossoPower.Image = configuratoreSerial6._0.Resource1.LedRossoOFF;
            LEDRossoPower.Location = new Point(12, 22);
            LEDRossoPower.Name = "LEDRossoPower";
            LEDRossoPower.Size = new Size(39, 43);
            LEDRossoPower.SizeMode = PictureBoxSizeMode.StretchImage;
            LEDRossoPower.TabIndex = 14;
            LEDRossoPower.TabStop = false;
            // 
            // groupBox18
            // 
            groupBox18.Controls.Add(groupBox24);
            groupBox18.Controls.Add(groupBox23);
            groupBox18.Location = new Point(428, 244);
            groupBox18.Name = "groupBox18";
            groupBox18.Size = new Size(356, 89);
            groupBox18.TabIndex = 8;
            groupBox18.TabStop = false;
            groupBox18.Text = "RS-485";
            // 
            // groupBox24
            // 
            groupBox24.Controls.Add(pbLED_RS4853T);
            groupBox24.Controls.Add(pbLED_RS48513T);
            groupBox24.Controls.Add(label5);
            groupBox24.Controls.Add(label7);
            groupBox24.Location = new Point(191, 13);
            groupBox24.Name = "groupBox24";
            groupBox24.Size = new Size(159, 66);
            groupBox24.TabIndex = 20;
            groupBox24.TabStop = false;
            groupBox24.Text = "1-3";
            // 
            // pbLED_RS4853T
            // 
            pbLED_RS4853T.Image = configuratoreSerial6._0.Resource1.LedRossoOFF;
            pbLED_RS4853T.Location = new Point(99, 12);
            pbLED_RS4853T.Name = "pbLED_RS4853T";
            pbLED_RS4853T.Size = new Size(39, 43);
            pbLED_RS4853T.SizeMode = PictureBoxSizeMode.StretchImage;
            pbLED_RS4853T.TabIndex = 14;
            pbLED_RS4853T.TabStop = false;
            // 
            // pbLED_RS48513T
            // 
            pbLED_RS48513T.Image = configuratoreSerial6._0.Resource1.LedRossoOFF;
            pbLED_RS48513T.Location = new Point(34, 11);
            pbLED_RS48513T.Name = "pbLED_RS48513T";
            pbLED_RS48513T.Size = new Size(39, 43);
            pbLED_RS48513T.SizeMode = PictureBoxSizeMode.StretchImage;
            pbLED_RS48513T.TabIndex = 13;
            pbLED_RS48513T.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(144, 22);
            label5.Name = "label5";
            label5.Size = new Size(13, 15);
            label5.TabIndex = 17;
            label5.Text = "3";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(82, 22);
            label7.Name = "label7";
            label7.Size = new Size(13, 15);
            label7.TabIndex = 16;
            label7.Text = "1";
            // 
            // groupBox23
            // 
            groupBox23.Controls.Add(pbLED_RS4852T);
            groupBox23.Controls.Add(pbLED_RS48512T);
            groupBox23.Controls.Add(label25);
            groupBox23.Controls.Add(label26);
            groupBox23.Location = new Point(13, 13);
            groupBox23.Name = "groupBox23";
            groupBox23.Size = new Size(164, 66);
            groupBox23.TabIndex = 19;
            groupBox23.TabStop = false;
            groupBox23.Text = "1-2";
            // 
            // pbLED_RS4852T
            // 
            pbLED_RS4852T.Image = configuratoreSerial6._0.Resource1.LedRossoOFF;
            pbLED_RS4852T.Location = new Point(101, 12);
            pbLED_RS4852T.Name = "pbLED_RS4852T";
            pbLED_RS4852T.Size = new Size(39, 43);
            pbLED_RS4852T.SizeMode = PictureBoxSizeMode.StretchImage;
            pbLED_RS4852T.TabIndex = 14;
            pbLED_RS4852T.TabStop = false;
            // 
            // pbLED_RS48512T
            // 
            pbLED_RS48512T.Image = configuratoreSerial6._0.Resource1.LedRossoOFF;
            pbLED_RS48512T.Location = new Point(33, 11);
            pbLED_RS48512T.Name = "pbLED_RS48512T";
            pbLED_RS48512T.Size = new Size(39, 43);
            pbLED_RS48512T.SizeMode = PictureBoxSizeMode.StretchImage;
            pbLED_RS48512T.TabIndex = 13;
            pbLED_RS48512T.TabStop = false;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new Point(146, 22);
            label25.Name = "label25";
            label25.Size = new Size(13, 15);
            label25.TabIndex = 17;
            label25.Text = "2";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Location = new Point(81, 22);
            label26.Name = "label26";
            label26.Size = new Size(13, 15);
            label26.TabIndex = 16;
            label26.Text = "1";
            // 
            // groupBox19
            // 
            groupBox19.Controls.Add(groupBox20);
            groupBox19.Controls.Add(groupBox21);
            groupBox19.Location = new Point(17, 348);
            groupBox19.Name = "groupBox19";
            groupBox19.Size = new Size(333, 95);
            groupBox19.TabIndex = 7;
            groupBox19.TabStop = false;
            groupBox19.Text = "NTC";
            // 
            // groupBox20
            // 
            groupBox20.Controls.Add(ledNTC2Anal);
            groupBox20.Controls.Add(lblNTC2val);
            groupBox20.Location = new Point(141, 22);
            groupBox20.Name = "groupBox20";
            groupBox20.Size = new Size(128, 55);
            groupBox20.TabIndex = 1;
            groupBox20.TabStop = false;
            groupBox20.Text = "NTC2";
            // 
            // ledNTC2Anal
            // 
            ledNTC2Anal.Image = configuratoreSerial6._0.Resource1.LedRossoOFF;
            ledNTC2Anal.Location = new Point(71, 12);
            ledNTC2Anal.Name = "ledNTC2Anal";
            ledNTC2Anal.Size = new Size(39, 43);
            ledNTC2Anal.SizeMode = PictureBoxSizeMode.StretchImage;
            ledNTC2Anal.TabIndex = 12;
            ledNTC2Anal.TabStop = false;
            // 
            // lblNTC2val
            // 
            lblNTC2val.AutoSize = true;
            lblNTC2val.Location = new Point(12, 19);
            lblNTC2val.Name = "lblNTC2val";
            lblNTC2val.Size = new Size(44, 15);
            lblNTC2val.TabIndex = 0;
            lblNTC2val.Text = "label10";
            // 
            // groupBox21
            // 
            groupBox21.Controls.Add(ledNTC1Anal);
            groupBox21.Controls.Add(lblNTC1val);
            groupBox21.Location = new Point(7, 22);
            groupBox21.Name = "groupBox21";
            groupBox21.Size = new Size(128, 55);
            groupBox21.TabIndex = 0;
            groupBox21.TabStop = false;
            groupBox21.Text = "NTC1";
            // 
            // ledNTC1Anal
            // 
            ledNTC1Anal.Image = configuratoreSerial6._0.Resource1.LedRossoOFF;
            ledNTC1Anal.Location = new Point(71, 12);
            ledNTC1Anal.Name = "ledNTC1Anal";
            ledNTC1Anal.Size = new Size(39, 43);
            ledNTC1Anal.SizeMode = PictureBoxSizeMode.StretchImage;
            ledNTC1Anal.TabIndex = 12;
            ledNTC1Anal.TabStop = false;
            // 
            // lblNTC1val
            // 
            lblNTC1val.AutoSize = true;
            lblNTC1val.Location = new Point(12, 19);
            lblNTC1val.Name = "lblNTC1val";
            lblNTC1val.Size = new Size(38, 15);
            lblNTC1val.TabIndex = 0;
            lblNTC1val.Text = "label9";
            // 
            // pictureBoxConnected
            // 
            pictureBoxConnected.ErrorImage = configuratoreSerial6._0.Resource1.roccheggianiSplash;
            pictureBoxConnected.InitialImage = null;
            pictureBoxConnected.Location = new Point(163, 565);
            pictureBoxConnected.Margin = new Padding(4, 3, 4, 3);
            pictureBoxConnected.Name = "pictureBoxConnected";
            pictureBoxConnected.Size = new Size(15, 15);
            pictureBoxConnected.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxConnected.TabIndex = 26;
            pictureBoxConnected.TabStop = false;
            // 
            // labelConnected
            // 
            labelConnected.AutoSize = true;
            labelConnected.Location = new Point(205, 565);
            labelConnected.Margin = new Padding(4, 0, 4, 0);
            labelConnected.Name = "labelConnected";
            labelConnected.Size = new Size(38, 15);
            labelConnected.TabIndex = 25;
            labelConnected.Text = "label1";
            // 
            // pictureBox1
            // 
            pictureBox1.ErrorImage = configuratoreSerial6._0.Resource1.roccheggianiSplash;
            pictureBox1.InitialImage = null;
            pictureBox1.Location = new Point(744, 565);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(54, 33);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 24;
            pictureBox1.TabStop = false;
            // 
            // timerTest
            // 
            timerTest.Enabled = true;
            timerTest.Interval = 10;
            timerTest.Tick += timerTest_Tick;
            // 
            // timerPowerOn
            // 
            timerPowerOn.Tick += timerPowerOn_Tick;
            // 
            // sysTimer
            // 
            sysTimer.Tick += sysTimer_Tick;
            // 
            // timerAutoClick
            // 
            timerAutoClick.Interval = 500;
            timerAutoClick.Tick += timerAutoClick_Tick;
            // 
            // frmStartUp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1010, 601);
            Controls.Add(pictureBoxConnected);
            Controls.Add(labelConnected);
            Controls.Add(pictureBox1);
            Controls.Add(tabControl1);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmStartUp";
            Text = "Roccheggiani";
            FormClosing += frmStartUp_FormClosing;
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownIndirizzoMaster).EndInit();
            tabPage2.ResumeLayout(false);
            CassetteFancoilGrp.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)btLEDSOK).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbLED5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbLED4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbLED3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbLED2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbLED1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbLED0).EndInit();
            groupBox11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbLEDPRESSOK).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbLEDADCDAC2OK).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbLEDADCDAC1OK).EndInit();
            ((System.ComponentModel.ISupportInitialize)DAC1).EndInit();
            ((System.ComponentModel.ISupportInitialize)DAC2).EndInit();
            groupBox10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbLEDTRIACOK).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbLEDDIOK).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbLEDDI5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbLEDDI4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbLEDDI3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbLEDDI2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbLEDDI1).EndInit();
            groupBox9.ResumeLayout(false);
            groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbLED_RS4852PLC).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbLED_RS4851PLC).EndInit();
            groupBox6.ResumeLayout(false);
            groupBox8.ResumeLayout(false);
            groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbLEDNTC2).EndInit();
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbLEDNTC1).EndInit();
            TermostatoAnalogicoGrp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            groupBoxBEEP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbLEDBEEPOK).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            groupBox17.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbLEDPOTOK).EndInit();
            groupBoxSWT.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbLEDTOUCHOK).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxOnOff).EndInit();
            ((System.ComponentModel.ISupportInitialize)LEDOnOff).EndInit();
            groupBoxLEDS.ResumeLayout(false);
            groupBox15.ResumeLayout(false);
            groupBox15.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PBLEDBLUOK).EndInit();
            ((System.ComponentModel.ISupportInitialize)LEDBluPower).EndInit();
            groupBox14.ResumeLayout(false);
            groupBox14.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PBLEDVERDEOK).EndInit();
            ((System.ComponentModel.ISupportInitialize)LEDVerdePower).EndInit();
            groupBox12.ResumeLayout(false);
            groupBox12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbLEDROSSOOK).EndInit();
            ((System.ComponentModel.ISupportInitialize)LEDRossoPower).EndInit();
            groupBox18.ResumeLayout(false);
            groupBox24.ResumeLayout(false);
            groupBox24.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbLED_RS4853T).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbLED_RS48513T).EndInit();
            groupBox23.ResumeLayout(false);
            groupBox23.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbLED_RS4852T).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbLED_RS48512T).EndInit();
            groupBox19.ResumeLayout(false);
            groupBox20.ResumeLayout(false);
            groupBox20.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ledNTC2Anal).EndInit();
            groupBox21.ResumeLayout(false);
            groupBox21.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ledNTC1Anal).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxConnected).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
        private ToolStripMenuItem spedisciTCPToolStripMenuItem;
        private System.Windows.Forms.Timer timerConnessione;
        private System.Windows.Forms.Timer timerRicezione;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.Timer timerDisconnetti;
        private System.Windows.Forms.Timer timerVerifica;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private GroupBox groupBox2;
        private CheckBox chkMatricola;
        private CheckBox chkModbus;
        private CheckBox chkNetlist;
        private CheckBox chkParametri;
        private Button btnReset;
        private GroupBox groupBox1;
        private Label label3;
        private Label label2;
        private Label lblVersione;
        private Button btnSet;
        private TextBox textBoxMatricola;
        private Label label6;
        private RadioButton radioButtonSlave;
        private Label lblDispositivo;
        private RadioButton radioButtonMaster;
        private Label labelIndirizzo;
        private NumericUpDown numericUpDownIndirizzoMaster;
        private TabPage tabPage2;
        private PictureBox pictureBoxConnected;
        private Label labelConnected;
        private PictureBox pictureBox1;
        private GroupBox groupBox3;
        private PictureBox pbLED0;
        private Button btnLED0;
        private PictureBox pbLED5;
        private Button btnLED5;
        private PictureBox pbLED4;
        private Button btnLED4;
        private PictureBox pbLED3;
        private Button btnLED3;
        private PictureBox pbLED2;
        private Button btnLED2;
        private PictureBox pbLED1;
        private Button btnLED1;
        private GroupBox groupBox5;
        private GroupBox groupBox4;
        private Label lblADC2;
        private Label lblADC1;
        private Label lblADC2bkg;
        private TrackBar DAC1;
        private TrackBar DAC2;
        private Label lblADC1bkg;
        private PictureBox pbLEDDI5;
        private PictureBox pbLEDDI4;
        private PictureBox pbLEDDI3;
        private PictureBox pbLEDDI2;
        private PictureBox pbLEDDI1;
        private GroupBox groupBox6;
        private GroupBox groupBox7;
        private PictureBox pbLEDNTC1;
        private Label lblNTC1;
        private GroupBox groupBox9;
        private Label label13;
        private Label label12;
        private Label label11;
        private PictureBox pbLED_RS4853;
        private PictureBox pbLED_RS4852;
        private PictureBox pbLED_RS4851PLC;
        private GroupBox groupBox8;
        private PictureBox pbLEDNTC2;
        private Label lblNTC2;
        private Label label18;
        private Label label19;
        private Label label15;
        private Label label16;
        private Label label17;
        private System.Windows.Forms.Timer timerTest;
        private GroupBox groupBox10;
        private Button btnTriac1;
        private PictureBox pictureBox2;
        private Button btnTriac2;
        private GroupBox groupBox11;
        private Label lblPressSensFrg;
        private Label lblPressSensBck;
        private PictureBox pictureBox3;
        private GroupBox CassetteFancoilGrp;
        private GroupBox TermostatoAnalogicoGrp;
        private GroupBox groupBoxLEDS;
        private GroupBox groupBox18;
        private Label label25;
        private Label label26;
        private PictureBox pbLED_RS4852T;
        private PictureBox pbLED_RS48512T;
        private GroupBox groupBox19;
        private GroupBox groupBox20;
        private PictureBox ledNTC2Anal;
        private Label lblNTC2val;
        private GroupBox groupBox21;
        private PictureBox ledNTC1Anal;
        private Label lblNTC1val;
        private PictureBox LEDBluPower;
        private PictureBox LEDVerdePower;
        private PictureBox LEDRossoPower;
        private GroupBox groupBoxSWT;
        private PictureBox LEDOnOff;
        private GroupBox groupBox15;
        private RadioButton rbB0;
        private RadioButton rbB50;
        private RadioButton rbB100;
        private GroupBox groupBox14;
        private RadioButton rbG0;
        private RadioButton rbG50;
        private RadioButton rbG100;
        private GroupBox groupBox12;
        private RadioButton rbR0;
        private RadioButton rbR50;
        private RadioButton rbR100;
        private PictureBox pictureBoxOnOff;
        private GroupBox groupBox17;
        private Label forgroundKnob;
        private Label sliderBck;
        private GroupBox groupBoxBEEP;
        private PictureBox pictureBox8;
        private Label label4;
        private PictureBox pbLED_RS4852PLC;
        private System.Windows.Forms.Timer timerPowerOn;
        private GroupBox groupBox23;
        private GroupBox groupBox24;
        private PictureBox pbLED_RS4853T;
        private PictureBox pbLED_RS48513T;
        private Label label5;
        private Label label7;
        private PictureBox pictureBox4;
        private PictureBox pictureBox5;
        private PictureBox pbLEDTOUCHOK;
        private PictureBox pbLEDBEEPOK;
        private PictureBox pbLEDPOTOK;
        private PictureBox PBLEDBLUOK;
        private PictureBox PBLEDVERDEOK;
        private PictureBox pbLEDROSSOOK;
        private PictureBox btLEDSOK;
        private PictureBox pbLEDDIOK;
        private PictureBox pbLEDTRIACOK;
        private PictureBox pbLEDPRESSOK;
        private PictureBox pbLEDADCDAC2OK;
        private PictureBox pbLEDADCDAC1OK;
        private System.Windows.Forms.Timer sysTimer;
        private Label msgErr;
        private System.Windows.Forms.Timer timerAutoClick;
        private Button btnAutotest;
        private Label label1;
    }
}

