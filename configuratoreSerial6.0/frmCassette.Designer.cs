namespace configuratore
{
    partial class frmCassette
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCassette));
            gbFunzionamentoCassetta = new GroupBox();
            comboFunzionamento = new ComboBox();
            lbl_Funzionamento = new Label();
            gbRiepilogoRiscaldamento = new GroupBox();
            rb_PresenzaResistenzaON = new RadioButton();
            rb_PresenzaResistenzaOFF = new RadioButton();
            lbl_PresenzaResistenza = new Label();
            nud_PotenzaNominaleResistenza = new NumericUpDown();
            lbl_PotenzaNominaleResistenza = new Label();
            nud_MassimoDutyCycle = new NumericUpDown();
            lbl_MassimoDutyCycle = new Label();
            nud_MinimoDutyCycle = new NumericUpDown();
            lbl_MinimoDutyCycle = new Label();
            nud_PeriofoModulazionePWM = new NumericUpDown();
            lbl_PeriodoModulazionePWM = new Label();
            nud_KIRegolazioneRiscaldamento = new NumericUpDown();
            lbl_KIRegolazioneRiscaldamento = new Label();
            nud_BandaDiregolazione = new NumericUpDown();
            lbl_BandaDiregolazione = new Label();
            nud_ZonaMortaRiscaldamento = new NumericUpDown();
            lbl_ZomaMortaRiscaldamento = new Label();
            gbMaxPotenzaResistenzaFunzPortata = new GroupBox();
            rb_LimPotMaxResistenzaON = new RadioButton();
            rb_LimPotMaxResistenzaOFF = new RadioButton();
            lbl_LimPotMaxResistenza = new Label();
            nud_TempAriaPrimaria = new NumericUpDown();
            lbl_TenpAriaPrimaria = new Label();
            gbImpostazioneRegolazioneAmbiente = new GroupBox();
            nud_IncZMEconomy = new NumericUpDown();
            lbl_IncZMEconomy = new Label();
            nud_SetPointDefault = new NumericUpDown();
            lbl_SetPointDefault = new Label();
            nud_deviazMaxSetpoint = new NumericUpDown();
            lbl_deviazMaxSetpoint = new Label();
            gbGestioneTemperaturaInterna = new GroupBox();
            nud_IsteresiSecondaSoglia = new NumericUpDown();
            lbl_IsteresiSecondaSoglia = new Label();
            nud_SecondaSogliaOFFResitenza = new NumericUpDown();
            lbl_SecondaSogliaOFFResitenza = new Label();
            nud_PrimaSogliaOFFResitenza = new NumericUpDown();
            lbl_PrimaSogliaOFFResitenza = new Label();
            nud__IsteresiPrimaSoglia = new NumericUpDown();
            lbl_IsteresiPrimaSoglia = new Label();
            gbGeometriaCassetta = new GroupBox();
            comboDiffusione = new ComboBox();
            lbl_Diffusione = new Label();
            gbLimitiTemperaturaMandata = new GroupBox();
            nud_SetpointLimiteMassimoHLSP = new NumericUpDown();
            lbl_SetpointLimiteMassimoHLSP = new Label();
            nud_BandaRegolazioneLimiti = new NumericUpDown();
            lbl_BandaRegolazioneLimiti = new Label();
            gbRegolazioneSerranda = new GroupBox();
            nud_TensioneSerrandaMassima = new NumericUpDown();
            lbl_TensioneSerrandaMassima = new Label();
            nud_TensioneSerrandaMinima = new NumericUpDown();
            lbl_TensioneSerrandaMinima = new Label();
            panel11 = new Panel();
            rb_PresenzaSerrandaOFF = new RadioButton();
            rb_PresenzaSerrandaON = new RadioButton();
            lbl_PresenzaSerranda = new Label();
            nud_AperturaserrandaMassima = new NumericUpDown();
            lbl_AperturaserrandaMassima = new Label();
            nud_AperturaSerrandaMinima = new NumericUpDown();
            lbl_AperturaSerrandaMinima = new Label();
            nud_KIRegolazioneSerranda = new NumericUpDown();
            lbl_KIRegolazioneSerranda = new Label();
            nud_BandaDiRegolazioneSerranda = new NumericUpDown();
            lbl_BandaDiRegolazioneSerranda = new Label();
            nud_ZonaMortaSerrandaDDZ = new NumericUpDown();
            rb_LogicaInv = new RadioButton();
            lbl_ZonaMortaSerrandaDDZ = new Label();
            rb_LogicaDir = new RadioButton();
            lbl_LogicaFunzSerranda = new Label();
            gbGestioneModalitaEconomy = new GroupBox();
            comboTipoEcomomy = new ComboBox();
            lbl_TipoEconomy = new Label();
            nud_TastoEconomyRiduzione = new NumericUpDown();
            lbl_TastoEconomyRiduzione = new Label();
            gbGestionePortata = new GroupBox();
            lbl_PortataMinimaSicurezzaLS = new Label();
            lbl_PortataMassimaLS = new Label();
            lbl_PortataMinimaLS = new Label();
            nud_KApertura_90_100 = new NumericUpDown();
            lbl_KApertura_90_100 = new Label();
            nud_KApertura_80_90 = new NumericUpDown();
            lbl_KApertura_80_90 = new Label();
            nud_KApertura_70_80 = new NumericUpDown();
            lbl_KApertura_70_80 = new Label();
            nud_KApertura_60_70 = new NumericUpDown();
            lbl_KApertura_60_70 = new Label();
            nud_KApertura_50_60 = new NumericUpDown();
            lbl_KApertura_50_60 = new Label();
            nud_KApertura_40_50 = new NumericUpDown();
            lbl_KApertura_40_50 = new Label();
            nud_KApertura_30_40 = new NumericUpDown();
            lbl_KApertura_30_40 = new Label();
            nud_KApertura_20_30 = new NumericUpDown();
            lbl_KApertura_20_30 = new Label();
            nud_KApertura_10_20 = new NumericUpDown();
            lbl_KApertura_10_20 = new Label();
            rb_AbilitaDisabilitaPortataIstantaneaON = new RadioButton();
            rb_AbilitaDisabilitaPortataIstantaneaOFF = new RadioButton();
            lbl_AbilitaDisabilitaPortataIstantanea = new Label();
            nud_TempoLetturaSensore = new NumericUpDown();
            lbl_TempoLetturaSensore = new Label();
            nud_OffsetMisurazioneDiPortata = new NumericUpDown();
            lbl_OffsetMisurazioneDiPortata = new Label();
            nud_SezionePerMisiurazPortata = new NumericUpDown();
            lbl_SezionePerMisiurazPortata = new Label();
            nud_PortataMinimaSicurezza = new NumericUpDown();
            lbl_PortataMinimaSicurezza = new Label();
            nud_PortataMassima = new NumericUpDown();
            lbl_PortataMassima = new Label();
            nud_PortataMinima = new NumericUpDown();
            lbl_PortataMinima = new Label();
            nud_KApertura_0_10 = new NumericUpDown();
            lbl_KApertura_0_10 = new Label();
            gbIngressi = new GroupBox();
            panel10 = new Panel();
            rb_NTC2_SAmbiente = new RadioButton();
            rb_NTC2_OFF = new RadioButton();
            rb_NTC2_SMandata = new RadioButton();
            lbl_Int_IntMandata = new Label();
            panel8 = new Panel();
            rb_NCD3 = new RadioButton();
            rb_NOD3 = new RadioButton();
            panel7 = new Panel();
            rb_NCD2 = new RadioButton();
            rb_NOD2 = new RadioButton();
            panel1 = new Panel();
            rb_NOD1 = new RadioButton();
            rb_NCD1 = new RadioButton();
            panel4 = new Panel();
            rb_D3OFF = new RadioButton();
            rb_D3ON = new RadioButton();
            panel3 = new Panel();
            rb_D2OFF = new RadioButton();
            rb_D2ON = new RadioButton();
            panel2 = new Panel();
            rb_D1OFF = new RadioButton();
            rb_D1ON = new RadioButton();
            lbl_LogocaD3 = new Label();
            lbl_LogocaD2 = new Label();
            lbl_LogocaD1 = new Label();
            lbl_OFF = new Label();
            lbl_ON = new Label();
            comboIngressoDigitaleD3 = new ComboBox();
            comboIngressoDigitaleD2 = new ComboBox();
            lbl_IngressoDigitaleNTC2 = new Label();
            lbl_IngressoDigitaleNTC1 = new Label();
            lbl_IngressoDigitaleD3 = new Label();
            lbl_IngressoDigitaleD2 = new Label();
            comboIngressoDigitaleD1 = new ComboBox();
            lbl_IngressoDigitaleD1 = new Label();
            gbIntensitaLED = new GroupBox();
            nud_IntensitaLED = new NumericUpDown();
            lblIntensitaLED = new Label();
            timerRxDati = new System.Windows.Forms.Timer(components);
            labelFondo = new Label();
            labelIndice = new Label();
            labelPleaseWait = new Label();
            menuStrip1 = new MenuStrip();
            fILEToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            salvaToolStripMenuItem = new ToolStripMenuItem();
            salvaComeToolStripMenuItem = new ToolStripMenuItem();
            esciToolStripMenuItem = new ToolStripMenuItem();
            saveFileDialog1 = new SaveFileDialog();
            tabControl = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            gb_14_impPrinc = new GroupBox();
            lbl_14_00 = new Label();
            panel21 = new Panel();
            rb_14_00_sec = new RadioButton();
            rb_14_00_princ = new RadioButton();
            gb_13_impMODBUS = new GroupBox();
            cb_13_04_StopBit = new ComboBox();
            lbl_13_00_TipDisp = new Label();
            panel20 = new Panel();
            rb_13_00_TipDisp_SLAVE = new RadioButton();
            rb_13_00_TipDisp_MASTER = new RadioButton();
            cb_13_03_Parita = new ComboBox();
            cb_13_02_Baudrate = new ComboBox();
            nud_13_01_Indirizzo = new NumericUpDown();
            lbl_13_04_StopBit = new Label();
            lbl_13_03_Parita = new Label();
            lbl_13_01_Indirizzo = new Label();
            lbl_13_02_Baudrate = new Label();
            timerTick = new System.Windows.Forms.Timer(components);
            systemTimer = new System.Windows.Forms.Timer(components);
            openFileDialog1 = new OpenFileDialog();
            gbFunzionamentoCassetta.SuspendLayout();
            gbRiepilogoRiscaldamento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nud_PotenzaNominaleResistenza).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_MassimoDutyCycle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_MinimoDutyCycle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_PeriofoModulazionePWM).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_KIRegolazioneRiscaldamento).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_BandaDiregolazione).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_ZonaMortaRiscaldamento).BeginInit();
            gbMaxPotenzaResistenzaFunzPortata.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nud_TempAriaPrimaria).BeginInit();
            gbImpostazioneRegolazioneAmbiente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nud_IncZMEconomy).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_SetPointDefault).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_deviazMaxSetpoint).BeginInit();
            gbGestioneTemperaturaInterna.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nud_IsteresiSecondaSoglia).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_SecondaSogliaOFFResitenza).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_PrimaSogliaOFFResitenza).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud__IsteresiPrimaSoglia).BeginInit();
            gbGeometriaCassetta.SuspendLayout();
            gbLimitiTemperaturaMandata.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nud_SetpointLimiteMassimoHLSP).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_BandaRegolazioneLimiti).BeginInit();
            gbRegolazioneSerranda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nud_TensioneSerrandaMassima).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_TensioneSerrandaMinima).BeginInit();
            panel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nud_AperturaserrandaMassima).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_AperturaSerrandaMinima).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_KIRegolazioneSerranda).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_BandaDiRegolazioneSerranda).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_ZonaMortaSerrandaDDZ).BeginInit();
            gbGestioneModalitaEconomy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nud_TastoEconomyRiduzione).BeginInit();
            gbGestionePortata.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nud_KApertura_90_100).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_KApertura_80_90).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_KApertura_70_80).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_KApertura_60_70).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_KApertura_50_60).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_KApertura_40_50).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_KApertura_30_40).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_KApertura_20_30).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_KApertura_10_20).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_TempoLetturaSensore).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_OffsetMisurazioneDiPortata).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_SezionePerMisiurazPortata).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_PortataMinimaSicurezza).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_PortataMassima).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_PortataMinima).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_KApertura_0_10).BeginInit();
            gbIngressi.SuspendLayout();
            panel10.SuspendLayout();
            panel8.SuspendLayout();
            panel7.SuspendLayout();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            gbIntensitaLED.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nud_IntensitaLED).BeginInit();
            menuStrip1.SuspendLayout();
            tabControl.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            gb_14_impPrinc.SuspendLayout();
            panel21.SuspendLayout();
            gb_13_impMODBUS.SuspendLayout();
            panel20.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nud_13_01_Indirizzo).BeginInit();
            SuspendLayout();
            // 
            // gbFunzionamentoCassetta
            // 
            gbFunzionamentoCassetta.Controls.Add(comboFunzionamento);
            gbFunzionamentoCassetta.Controls.Add(lbl_Funzionamento);
            gbFunzionamentoCassetta.Location = new Point(7, 3);
            gbFunzionamentoCassetta.Margin = new Padding(4, 3, 4, 3);
            gbFunzionamentoCassetta.Name = "gbFunzionamentoCassetta";
            gbFunzionamentoCassetta.Padding = new Padding(4, 3, 4, 3);
            gbFunzionamentoCassetta.Size = new Size(407, 48);
            gbFunzionamentoCassetta.TabIndex = 1;
            gbFunzionamentoCassetta.TabStop = false;
            gbFunzionamentoCassetta.Text = "0 Funzionamento cassetta";
            // 
            // comboFunzionamento
            // 
            comboFunzionamento.DropDownStyle = ComboBoxStyle.DropDownList;
            comboFunzionamento.FormattingEnabled = true;
            comboFunzionamento.Location = new Point(284, 17);
            comboFunzionamento.Margin = new Padding(4, 3, 4, 3);
            comboFunzionamento.Name = "comboFunzionamento";
            comboFunzionamento.Size = new Size(98, 23);
            comboFunzionamento.TabIndex = 1;
            // 
            // lbl_Funzionamento
            // 
            lbl_Funzionamento.AutoSize = true;
            lbl_Funzionamento.Location = new Point(13, 21);
            lbl_Funzionamento.Margin = new Padding(4, 0, 4, 0);
            lbl_Funzionamento.Name = "lbl_Funzionamento";
            lbl_Funzionamento.Size = new Size(90, 15);
            lbl_Funzionamento.TabIndex = 0;
            lbl_Funzionamento.Text = "Funzionamento";
            // 
            // gbRiepilogoRiscaldamento
            // 
            gbRiepilogoRiscaldamento.Controls.Add(rb_PresenzaResistenzaON);
            gbRiepilogoRiscaldamento.Controls.Add(rb_PresenzaResistenzaOFF);
            gbRiepilogoRiscaldamento.Controls.Add(lbl_PresenzaResistenza);
            gbRiepilogoRiscaldamento.Controls.Add(nud_PotenzaNominaleResistenza);
            gbRiepilogoRiscaldamento.Controls.Add(lbl_PotenzaNominaleResistenza);
            gbRiepilogoRiscaldamento.Controls.Add(nud_MassimoDutyCycle);
            gbRiepilogoRiscaldamento.Controls.Add(lbl_MassimoDutyCycle);
            gbRiepilogoRiscaldamento.Controls.Add(nud_MinimoDutyCycle);
            gbRiepilogoRiscaldamento.Controls.Add(lbl_MinimoDutyCycle);
            gbRiepilogoRiscaldamento.Controls.Add(nud_PeriofoModulazionePWM);
            gbRiepilogoRiscaldamento.Controls.Add(lbl_PeriodoModulazionePWM);
            gbRiepilogoRiscaldamento.Controls.Add(nud_KIRegolazioneRiscaldamento);
            gbRiepilogoRiscaldamento.Controls.Add(lbl_KIRegolazioneRiscaldamento);
            gbRiepilogoRiscaldamento.Controls.Add(nud_BandaDiregolazione);
            gbRiepilogoRiscaldamento.Controls.Add(lbl_BandaDiregolazione);
            gbRiepilogoRiscaldamento.Controls.Add(nud_ZonaMortaRiscaldamento);
            gbRiepilogoRiscaldamento.Controls.Add(lbl_ZomaMortaRiscaldamento);
            gbRiepilogoRiscaldamento.Location = new Point(7, 51);
            gbRiepilogoRiscaldamento.Margin = new Padding(4, 3, 4, 3);
            gbRiepilogoRiscaldamento.Name = "gbRiepilogoRiscaldamento";
            gbRiepilogoRiscaldamento.Padding = new Padding(4, 3, 4, 3);
            gbRiepilogoRiscaldamento.Size = new Size(407, 217);
            gbRiepilogoRiscaldamento.TabIndex = 2;
            gbRiepilogoRiscaldamento.TabStop = false;
            gbRiepilogoRiscaldamento.Text = "1 Funzionamento cassetta";
            // 
            // rb_PresenzaResistenzaON
            // 
            rb_PresenzaResistenzaON.AutoSize = true;
            rb_PresenzaResistenzaON.CheckAlign = ContentAlignment.MiddleRight;
            rb_PresenzaResistenzaON.Location = new Point(335, 193);
            rb_PresenzaResistenzaON.Margin = new Padding(4, 3, 4, 3);
            rb_PresenzaResistenzaON.Name = "rb_PresenzaResistenzaON";
            rb_PresenzaResistenzaON.Size = new Size(43, 19);
            rb_PresenzaResistenzaON.TabIndex = 180;
            rb_PresenzaResistenzaON.Text = "ON";
            rb_PresenzaResistenzaON.UseVisualStyleBackColor = false;
            // 
            // rb_PresenzaResistenzaOFF
            // 
            rb_PresenzaResistenzaOFF.AutoSize = true;
            rb_PresenzaResistenzaOFF.CheckAlign = ContentAlignment.MiddleRight;
            rb_PresenzaResistenzaOFF.Location = new Point(278, 193);
            rb_PresenzaResistenzaOFF.Margin = new Padding(4, 3, 4, 3);
            rb_PresenzaResistenzaOFF.Name = "rb_PresenzaResistenzaOFF";
            rb_PresenzaResistenzaOFF.Size = new Size(46, 19);
            rb_PresenzaResistenzaOFF.TabIndex = 170;
            rb_PresenzaResistenzaOFF.Text = "OFF";
            rb_PresenzaResistenzaOFF.UseVisualStyleBackColor = false;
            // 
            // lbl_PresenzaResistenza
            // 
            lbl_PresenzaResistenza.AutoSize = true;
            lbl_PresenzaResistenza.Location = new Point(13, 195);
            lbl_PresenzaResistenza.Margin = new Padding(4, 0, 4, 0);
            lbl_PresenzaResistenza.Name = "lbl_PresenzaResistenza";
            lbl_PresenzaResistenza.Size = new Size(90, 15);
            lbl_PresenzaResistenza.TabIndex = 16;
            lbl_PresenzaResistenza.Text = "Funzionamento";
            // 
            // nud_PotenzaNominaleResistenza
            // 
            nud_PotenzaNominaleResistenza.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            nud_PotenzaNominaleResistenza.Location = new Point(316, 168);
            nud_PotenzaNominaleResistenza.Margin = new Padding(4, 3, 4, 3);
            nud_PotenzaNominaleResistenza.Maximum = new decimal(new int[] { 2400, 0, 0, 0 });
            nud_PotenzaNominaleResistenza.Minimum = new decimal(new int[] { 800, 0, 0, 0 });
            nud_PotenzaNominaleResistenza.Name = "nud_PotenzaNominaleResistenza";
            nud_PotenzaNominaleResistenza.Size = new Size(66, 23);
            nud_PotenzaNominaleResistenza.TabIndex = 15;
            nud_PotenzaNominaleResistenza.Value = new decimal(new int[] { 800, 0, 0, 0 });
            // 
            // lbl_PotenzaNominaleResistenza
            // 
            lbl_PotenzaNominaleResistenza.AutoSize = true;
            lbl_PotenzaNominaleResistenza.Location = new Point(13, 170);
            lbl_PotenzaNominaleResistenza.Margin = new Padding(4, 0, 4, 0);
            lbl_PotenzaNominaleResistenza.Name = "lbl_PotenzaNominaleResistenza";
            lbl_PotenzaNominaleResistenza.Size = new Size(90, 15);
            lbl_PotenzaNominaleResistenza.TabIndex = 14;
            lbl_PotenzaNominaleResistenza.Text = "Funzionamento";
            // 
            // nud_MassimoDutyCycle
            // 
            nud_MassimoDutyCycle.Location = new Point(316, 143);
            nud_MassimoDutyCycle.Margin = new Padding(4, 3, 4, 3);
            nud_MassimoDutyCycle.Name = "nud_MassimoDutyCycle";
            nud_MassimoDutyCycle.Size = new Size(66, 23);
            nud_MassimoDutyCycle.TabIndex = 13;
            // 
            // lbl_MassimoDutyCycle
            // 
            lbl_MassimoDutyCycle.AutoSize = true;
            lbl_MassimoDutyCycle.Location = new Point(13, 145);
            lbl_MassimoDutyCycle.Margin = new Padding(4, 0, 4, 0);
            lbl_MassimoDutyCycle.Name = "lbl_MassimoDutyCycle";
            lbl_MassimoDutyCycle.Size = new Size(90, 15);
            lbl_MassimoDutyCycle.TabIndex = 12;
            lbl_MassimoDutyCycle.Text = "Funzionamento";
            // 
            // nud_MinimoDutyCycle
            // 
            nud_MinimoDutyCycle.Location = new Point(316, 118);
            nud_MinimoDutyCycle.Margin = new Padding(4, 3, 4, 3);
            nud_MinimoDutyCycle.Name = "nud_MinimoDutyCycle";
            nud_MinimoDutyCycle.Size = new Size(66, 23);
            nud_MinimoDutyCycle.TabIndex = 11;
            // 
            // lbl_MinimoDutyCycle
            // 
            lbl_MinimoDutyCycle.AutoSize = true;
            lbl_MinimoDutyCycle.Location = new Point(13, 120);
            lbl_MinimoDutyCycle.Margin = new Padding(4, 0, 4, 0);
            lbl_MinimoDutyCycle.Name = "lbl_MinimoDutyCycle";
            lbl_MinimoDutyCycle.Size = new Size(90, 15);
            lbl_MinimoDutyCycle.TabIndex = 10;
            lbl_MinimoDutyCycle.Text = "Funzionamento";
            // 
            // nud_PeriofoModulazionePWM
            // 
            nud_PeriofoModulazionePWM.DecimalPlaces = 1;
            nud_PeriofoModulazionePWM.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            nud_PeriofoModulazionePWM.Location = new Point(316, 93);
            nud_PeriofoModulazionePWM.Margin = new Padding(4, 3, 4, 3);
            nud_PeriofoModulazionePWM.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nud_PeriofoModulazionePWM.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nud_PeriofoModulazionePWM.Name = "nud_PeriofoModulazionePWM";
            nud_PeriofoModulazionePWM.Size = new Size(66, 23);
            nud_PeriofoModulazionePWM.TabIndex = 9;
            nud_PeriofoModulazionePWM.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lbl_PeriodoModulazionePWM
            // 
            lbl_PeriodoModulazionePWM.AutoSize = true;
            lbl_PeriodoModulazionePWM.Location = new Point(13, 95);
            lbl_PeriodoModulazionePWM.Margin = new Padding(4, 0, 4, 0);
            lbl_PeriodoModulazionePWM.Name = "lbl_PeriodoModulazionePWM";
            lbl_PeriodoModulazionePWM.Size = new Size(90, 15);
            lbl_PeriodoModulazionePWM.TabIndex = 8;
            lbl_PeriodoModulazionePWM.Text = "Funzionamento";
            // 
            // nud_KIRegolazioneRiscaldamento
            // 
            nud_KIRegolazioneRiscaldamento.Location = new Point(316, 68);
            nud_KIRegolazioneRiscaldamento.Margin = new Padding(4, 3, 4, 3);
            nud_KIRegolazioneRiscaldamento.Name = "nud_KIRegolazioneRiscaldamento";
            nud_KIRegolazioneRiscaldamento.Size = new Size(66, 23);
            nud_KIRegolazioneRiscaldamento.TabIndex = 7;
            // 
            // lbl_KIRegolazioneRiscaldamento
            // 
            lbl_KIRegolazioneRiscaldamento.AutoSize = true;
            lbl_KIRegolazioneRiscaldamento.Location = new Point(13, 70);
            lbl_KIRegolazioneRiscaldamento.Margin = new Padding(4, 0, 4, 0);
            lbl_KIRegolazioneRiscaldamento.Name = "lbl_KIRegolazioneRiscaldamento";
            lbl_KIRegolazioneRiscaldamento.Size = new Size(90, 15);
            lbl_KIRegolazioneRiscaldamento.TabIndex = 6;
            lbl_KIRegolazioneRiscaldamento.Text = "Funzionamento";
            // 
            // nud_BandaDiregolazione
            // 
            nud_BandaDiregolazione.DecimalPlaces = 1;
            nud_BandaDiregolazione.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            nud_BandaDiregolazione.Location = new Point(316, 43);
            nud_BandaDiregolazione.Margin = new Padding(4, 3, 4, 3);
            nud_BandaDiregolazione.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nud_BandaDiregolazione.Minimum = new decimal(new int[] { 5, 0, 0, 65536 });
            nud_BandaDiregolazione.Name = "nud_BandaDiregolazione";
            nud_BandaDiregolazione.Size = new Size(66, 23);
            nud_BandaDiregolazione.TabIndex = 5;
            nud_BandaDiregolazione.Value = new decimal(new int[] { 5, 0, 0, 65536 });
            // 
            // lbl_BandaDiregolazione
            // 
            lbl_BandaDiregolazione.AutoSize = true;
            lbl_BandaDiregolazione.Location = new Point(13, 45);
            lbl_BandaDiregolazione.Margin = new Padding(4, 0, 4, 0);
            lbl_BandaDiregolazione.Name = "lbl_BandaDiregolazione";
            lbl_BandaDiregolazione.Size = new Size(90, 15);
            lbl_BandaDiregolazione.TabIndex = 4;
            lbl_BandaDiregolazione.Text = "Funzionamento";
            // 
            // nud_ZonaMortaRiscaldamento
            // 
            nud_ZonaMortaRiscaldamento.DecimalPlaces = 1;
            nud_ZonaMortaRiscaldamento.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            nud_ZonaMortaRiscaldamento.Location = new Point(316, 18);
            nud_ZonaMortaRiscaldamento.Margin = new Padding(4, 3, 4, 3);
            nud_ZonaMortaRiscaldamento.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            nud_ZonaMortaRiscaldamento.Name = "nud_ZonaMortaRiscaldamento";
            nud_ZonaMortaRiscaldamento.Size = new Size(66, 23);
            nud_ZonaMortaRiscaldamento.TabIndex = 3;
            nud_ZonaMortaRiscaldamento.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lbl_ZomaMortaRiscaldamento
            // 
            lbl_ZomaMortaRiscaldamento.AutoSize = true;
            lbl_ZomaMortaRiscaldamento.Location = new Point(13, 20);
            lbl_ZomaMortaRiscaldamento.Margin = new Padding(4, 0, 4, 0);
            lbl_ZomaMortaRiscaldamento.Name = "lbl_ZomaMortaRiscaldamento";
            lbl_ZomaMortaRiscaldamento.Size = new Size(207, 15);
            lbl_ZomaMortaRiscaldamento.TabIndex = 0;
            lbl_ZomaMortaRiscaldamento.Text = "Zona morta riscaldamento H.D.Z. [C°]";
            lbl_ZomaMortaRiscaldamento.Click += lbl_ZomaMortaRiscaldamento_Click;
            // 
            // gbMaxPotenzaResistenzaFunzPortata
            // 
            gbMaxPotenzaResistenzaFunzPortata.Controls.Add(rb_LimPotMaxResistenzaON);
            gbMaxPotenzaResistenzaFunzPortata.Controls.Add(rb_LimPotMaxResistenzaOFF);
            gbMaxPotenzaResistenzaFunzPortata.Controls.Add(lbl_LimPotMaxResistenza);
            gbMaxPotenzaResistenzaFunzPortata.Controls.Add(nud_TempAriaPrimaria);
            gbMaxPotenzaResistenzaFunzPortata.Controls.Add(lbl_TenpAriaPrimaria);
            gbMaxPotenzaResistenzaFunzPortata.Location = new Point(7, 269);
            gbMaxPotenzaResistenzaFunzPortata.Margin = new Padding(4, 3, 4, 3);
            gbMaxPotenzaResistenzaFunzPortata.Name = "gbMaxPotenzaResistenzaFunzPortata";
            gbMaxPotenzaResistenzaFunzPortata.Padding = new Padding(4, 3, 4, 3);
            gbMaxPotenzaResistenzaFunzPortata.Size = new Size(407, 75);
            gbMaxPotenzaResistenzaFunzPortata.TabIndex = 3;
            gbMaxPotenzaResistenzaFunzPortata.TabStop = false;
            gbMaxPotenzaResistenzaFunzPortata.Text = "2 Funzionamento Max potenza resistenza in funzione della portata";
            // 
            // rb_LimPotMaxResistenzaON
            // 
            rb_LimPotMaxResistenzaON.AutoSize = true;
            rb_LimPotMaxResistenzaON.CheckAlign = ContentAlignment.MiddleRight;
            rb_LimPotMaxResistenzaON.Location = new Point(335, 18);
            rb_LimPotMaxResistenzaON.Margin = new Padding(4, 3, 4, 3);
            rb_LimPotMaxResistenzaON.Name = "rb_LimPotMaxResistenzaON";
            rb_LimPotMaxResistenzaON.Size = new Size(43, 19);
            rb_LimPotMaxResistenzaON.TabIndex = 3;
            rb_LimPotMaxResistenzaON.Text = "ON";
            rb_LimPotMaxResistenzaON.UseVisualStyleBackColor = false;
            // 
            // rb_LimPotMaxResistenzaOFF
            // 
            rb_LimPotMaxResistenzaOFF.AutoSize = true;
            rb_LimPotMaxResistenzaOFF.CheckAlign = ContentAlignment.MiddleRight;
            rb_LimPotMaxResistenzaOFF.Location = new Point(278, 18);
            rb_LimPotMaxResistenzaOFF.Margin = new Padding(4, 3, 4, 3);
            rb_LimPotMaxResistenzaOFF.Name = "rb_LimPotMaxResistenzaOFF";
            rb_LimPotMaxResistenzaOFF.Size = new Size(46, 19);
            rb_LimPotMaxResistenzaOFF.TabIndex = 4;
            rb_LimPotMaxResistenzaOFF.Text = "OFF";
            rb_LimPotMaxResistenzaOFF.UseVisualStyleBackColor = false;
            // 
            // lbl_LimPotMaxResistenza
            // 
            lbl_LimPotMaxResistenza.AutoSize = true;
            lbl_LimPotMaxResistenza.Location = new Point(13, 20);
            lbl_LimPotMaxResistenza.Margin = new Padding(4, 0, 4, 0);
            lbl_LimPotMaxResistenza.Name = "lbl_LimPotMaxResistenza";
            lbl_LimPotMaxResistenza.Size = new Size(90, 15);
            lbl_LimPotMaxResistenza.TabIndex = 163;
            lbl_LimPotMaxResistenza.Text = "Funzionamento";
            // 
            // nud_TempAriaPrimaria
            // 
            nud_TempAriaPrimaria.Location = new Point(316, 43);
            nud_TempAriaPrimaria.Margin = new Padding(4, 3, 4, 3);
            nud_TempAriaPrimaria.Name = "nud_TempAriaPrimaria";
            nud_TempAriaPrimaria.Size = new Size(66, 23);
            nud_TempAriaPrimaria.TabIndex = 0;
            // 
            // lbl_TenpAriaPrimaria
            // 
            lbl_TenpAriaPrimaria.AutoSize = true;
            lbl_TenpAriaPrimaria.Location = new Point(13, 45);
            lbl_TenpAriaPrimaria.Margin = new Padding(4, 0, 4, 0);
            lbl_TenpAriaPrimaria.Name = "lbl_TenpAriaPrimaria";
            lbl_TenpAriaPrimaria.Size = new Size(207, 15);
            lbl_TenpAriaPrimaria.TabIndex = 1;
            lbl_TenpAriaPrimaria.Text = "Zona morta riscaldamento H.D.Z. [C°]";
            // 
            // gbImpostazioneRegolazioneAmbiente
            // 
            gbImpostazioneRegolazioneAmbiente.Controls.Add(nud_IncZMEconomy);
            gbImpostazioneRegolazioneAmbiente.Controls.Add(lbl_IncZMEconomy);
            gbImpostazioneRegolazioneAmbiente.Controls.Add(nud_SetPointDefault);
            gbImpostazioneRegolazioneAmbiente.Controls.Add(lbl_SetPointDefault);
            gbImpostazioneRegolazioneAmbiente.Controls.Add(nud_deviazMaxSetpoint);
            gbImpostazioneRegolazioneAmbiente.Controls.Add(lbl_deviazMaxSetpoint);
            gbImpostazioneRegolazioneAmbiente.Location = new Point(7, 344);
            gbImpostazioneRegolazioneAmbiente.Margin = new Padding(4, 3, 4, 3);
            gbImpostazioneRegolazioneAmbiente.Name = "gbImpostazioneRegolazioneAmbiente";
            gbImpostazioneRegolazioneAmbiente.Padding = new Padding(4, 3, 4, 3);
            gbImpostazioneRegolazioneAmbiente.Size = new Size(407, 97);
            gbImpostazioneRegolazioneAmbiente.TabIndex = 11;
            gbImpostazioneRegolazioneAmbiente.TabStop = false;
            gbImpostazioneRegolazioneAmbiente.Text = "3 Impostazione regolazione ambiente";
            // 
            // nud_IncZMEconomy
            // 
            nud_IncZMEconomy.Location = new Point(316, 68);
            nud_IncZMEconomy.Margin = new Padding(4, 3, 4, 3);
            nud_IncZMEconomy.Name = "nud_IncZMEconomy";
            nud_IncZMEconomy.Size = new Size(66, 23);
            nud_IncZMEconomy.TabIndex = 5;
            // 
            // lbl_IncZMEconomy
            // 
            lbl_IncZMEconomy.AutoSize = true;
            lbl_IncZMEconomy.Location = new Point(13, 70);
            lbl_IncZMEconomy.Margin = new Padding(4, 0, 4, 0);
            lbl_IncZMEconomy.Name = "lbl_IncZMEconomy";
            lbl_IncZMEconomy.Size = new Size(207, 15);
            lbl_IncZMEconomy.TabIndex = 18;
            lbl_IncZMEconomy.Text = "Zona morta riscaldamento H.D.Z. [C°]";
            // 
            // nud_SetPointDefault
            // 
            nud_SetPointDefault.Location = new Point(316, 18);
            nud_SetPointDefault.Margin = new Padding(4, 3, 4, 3);
            nud_SetPointDefault.Name = "nud_SetPointDefault";
            nud_SetPointDefault.Size = new Size(66, 23);
            nud_SetPointDefault.TabIndex = 1;
            // 
            // lbl_SetPointDefault
            // 
            lbl_SetPointDefault.AutoSize = true;
            lbl_SetPointDefault.Location = new Point(13, 20);
            lbl_SetPointDefault.Margin = new Padding(4, 0, 4, 0);
            lbl_SetPointDefault.Name = "lbl_SetPointDefault";
            lbl_SetPointDefault.Size = new Size(90, 15);
            lbl_SetPointDefault.TabIndex = 4;
            lbl_SetPointDefault.Text = "Funzionamento";
            // 
            // nud_deviazMaxSetpoint
            // 
            nud_deviazMaxSetpoint.Location = new Point(316, 43);
            nud_deviazMaxSetpoint.Margin = new Padding(4, 3, 4, 3);
            nud_deviazMaxSetpoint.Name = "nud_deviazMaxSetpoint";
            nud_deviazMaxSetpoint.Size = new Size(66, 23);
            nud_deviazMaxSetpoint.TabIndex = 3;
            // 
            // lbl_deviazMaxSetpoint
            // 
            lbl_deviazMaxSetpoint.AutoSize = true;
            lbl_deviazMaxSetpoint.Location = new Point(13, 45);
            lbl_deviazMaxSetpoint.Margin = new Padding(4, 0, 4, 0);
            lbl_deviazMaxSetpoint.Name = "lbl_deviazMaxSetpoint";
            lbl_deviazMaxSetpoint.Size = new Size(207, 15);
            lbl_deviazMaxSetpoint.TabIndex = 2;
            lbl_deviazMaxSetpoint.Text = "Zona morta riscaldamento H.D.Z. [C°]";
            // 
            // gbGestioneTemperaturaInterna
            // 
            gbGestioneTemperaturaInterna.Controls.Add(nud_IsteresiSecondaSoglia);
            gbGestioneTemperaturaInterna.Controls.Add(lbl_IsteresiSecondaSoglia);
            gbGestioneTemperaturaInterna.Controls.Add(nud_SecondaSogliaOFFResitenza);
            gbGestioneTemperaturaInterna.Controls.Add(lbl_SecondaSogliaOFFResitenza);
            gbGestioneTemperaturaInterna.Controls.Add(nud_PrimaSogliaOFFResitenza);
            gbGestioneTemperaturaInterna.Controls.Add(lbl_PrimaSogliaOFFResitenza);
            gbGestioneTemperaturaInterna.Controls.Add(nud__IsteresiPrimaSoglia);
            gbGestioneTemperaturaInterna.Controls.Add(lbl_IsteresiPrimaSoglia);
            gbGestioneTemperaturaInterna.Location = new Point(8, 441);
            gbGestioneTemperaturaInterna.Margin = new Padding(4, 3, 4, 3);
            gbGestioneTemperaturaInterna.Name = "gbGestioneTemperaturaInterna";
            gbGestioneTemperaturaInterna.Padding = new Padding(4, 3, 4, 3);
            gbGestioneTemperaturaInterna.Size = new Size(407, 122);
            gbGestioneTemperaturaInterna.TabIndex = 0;
            gbGestioneTemperaturaInterna.TabStop = false;
            gbGestioneTemperaturaInterna.Text = "4 Gestione temperatura  interna";
            gbGestioneTemperaturaInterna.Enter += gbGestioneTemperaturaInterna_Enter;
            // 
            // nud_IsteresiSecondaSoglia
            // 
            nud_IsteresiSecondaSoglia.Location = new Point(316, 93);
            nud_IsteresiSecondaSoglia.Margin = new Padding(4, 3, 4, 3);
            nud_IsteresiSecondaSoglia.Name = "nud_IsteresiSecondaSoglia";
            nud_IsteresiSecondaSoglia.Size = new Size(66, 23);
            nud_IsteresiSecondaSoglia.TabIndex = 21;
            // 
            // lbl_IsteresiSecondaSoglia
            // 
            lbl_IsteresiSecondaSoglia.AutoSize = true;
            lbl_IsteresiSecondaSoglia.Location = new Point(13, 95);
            lbl_IsteresiSecondaSoglia.Margin = new Padding(4, 0, 4, 0);
            lbl_IsteresiSecondaSoglia.Name = "lbl_IsteresiSecondaSoglia";
            lbl_IsteresiSecondaSoglia.Size = new Size(207, 15);
            lbl_IsteresiSecondaSoglia.TabIndex = 20;
            lbl_IsteresiSecondaSoglia.Text = "Zona morta riscaldamento H.D.Z. [C°]";
            // 
            // nud_SecondaSogliaOFFResitenza
            // 
            nud_SecondaSogliaOFFResitenza.Location = new Point(316, 68);
            nud_SecondaSogliaOFFResitenza.Margin = new Padding(4, 3, 4, 3);
            nud_SecondaSogliaOFFResitenza.Name = "nud_SecondaSogliaOFFResitenza";
            nud_SecondaSogliaOFFResitenza.Size = new Size(66, 23);
            nud_SecondaSogliaOFFResitenza.TabIndex = 19;
            // 
            // lbl_SecondaSogliaOFFResitenza
            // 
            lbl_SecondaSogliaOFFResitenza.AutoSize = true;
            lbl_SecondaSogliaOFFResitenza.Location = new Point(13, 70);
            lbl_SecondaSogliaOFFResitenza.Margin = new Padding(4, 0, 4, 0);
            lbl_SecondaSogliaOFFResitenza.Name = "lbl_SecondaSogliaOFFResitenza";
            lbl_SecondaSogliaOFFResitenza.Size = new Size(207, 15);
            lbl_SecondaSogliaOFFResitenza.TabIndex = 18;
            lbl_SecondaSogliaOFFResitenza.Text = "Zona morta riscaldamento H.D.Z. [C°]";
            // 
            // nud_PrimaSogliaOFFResitenza
            // 
            nud_PrimaSogliaOFFResitenza.Location = new Point(316, 18);
            nud_PrimaSogliaOFFResitenza.Margin = new Padding(4, 3, 4, 3);
            nud_PrimaSogliaOFFResitenza.Name = "nud_PrimaSogliaOFFResitenza";
            nud_PrimaSogliaOFFResitenza.Size = new Size(66, 23);
            nud_PrimaSogliaOFFResitenza.TabIndex = 17;
            // 
            // lbl_PrimaSogliaOFFResitenza
            // 
            lbl_PrimaSogliaOFFResitenza.AutoSize = true;
            lbl_PrimaSogliaOFFResitenza.Location = new Point(13, 20);
            lbl_PrimaSogliaOFFResitenza.Margin = new Padding(4, 0, 4, 0);
            lbl_PrimaSogliaOFFResitenza.Name = "lbl_PrimaSogliaOFFResitenza";
            lbl_PrimaSogliaOFFResitenza.Size = new Size(90, 15);
            lbl_PrimaSogliaOFFResitenza.TabIndex = 16;
            lbl_PrimaSogliaOFFResitenza.Text = "Funzionamento";
            // 
            // nud__IsteresiPrimaSoglia
            // 
            nud__IsteresiPrimaSoglia.Location = new Point(316, 43);
            nud__IsteresiPrimaSoglia.Margin = new Padding(4, 3, 4, 3);
            nud__IsteresiPrimaSoglia.Name = "nud__IsteresiPrimaSoglia";
            nud__IsteresiPrimaSoglia.Size = new Size(66, 23);
            nud__IsteresiPrimaSoglia.TabIndex = 3;
            // 
            // lbl_IsteresiPrimaSoglia
            // 
            lbl_IsteresiPrimaSoglia.AutoSize = true;
            lbl_IsteresiPrimaSoglia.Location = new Point(13, 45);
            lbl_IsteresiPrimaSoglia.Margin = new Padding(4, 0, 4, 0);
            lbl_IsteresiPrimaSoglia.Name = "lbl_IsteresiPrimaSoglia";
            lbl_IsteresiPrimaSoglia.Size = new Size(207, 15);
            lbl_IsteresiPrimaSoglia.TabIndex = 0;
            lbl_IsteresiPrimaSoglia.Text = "Zona morta riscaldamento H.D.Z. [C°]";
            // 
            // gbGeometriaCassetta
            // 
            gbGeometriaCassetta.Controls.Add(comboDiffusione);
            gbGeometriaCassetta.Controls.Add(lbl_Diffusione);
            gbGeometriaCassetta.Location = new Point(421, 3);
            gbGeometriaCassetta.Margin = new Padding(4, 3, 4, 3);
            gbGeometriaCassetta.Name = "gbGeometriaCassetta";
            gbGeometriaCassetta.Padding = new Padding(4, 3, 4, 3);
            gbGeometriaCassetta.Size = new Size(407, 48);
            gbGeometriaCassetta.TabIndex = 2;
            gbGeometriaCassetta.TabStop = false;
            gbGeometriaCassetta.Text = "5 Geometria cassetta";
            // 
            // comboDiffusione
            // 
            comboDiffusione.DropDownStyle = ComboBoxStyle.DropDownList;
            comboDiffusione.FormattingEnabled = true;
            comboDiffusione.Location = new Point(284, 17);
            comboDiffusione.Margin = new Padding(4, 3, 4, 3);
            comboDiffusione.Name = "comboDiffusione";
            comboDiffusione.Size = new Size(98, 23);
            comboDiffusione.TabIndex = 1;
            // 
            // lbl_Diffusione
            // 
            lbl_Diffusione.AutoSize = true;
            lbl_Diffusione.Location = new Point(13, 21);
            lbl_Diffusione.Margin = new Padding(4, 0, 4, 0);
            lbl_Diffusione.Name = "lbl_Diffusione";
            lbl_Diffusione.Size = new Size(90, 15);
            lbl_Diffusione.TabIndex = 0;
            lbl_Diffusione.Text = "Funzionamento";
            // 
            // gbLimitiTemperaturaMandata
            // 
            gbLimitiTemperaturaMandata.Controls.Add(nud_SetpointLimiteMassimoHLSP);
            gbLimitiTemperaturaMandata.Controls.Add(lbl_SetpointLimiteMassimoHLSP);
            gbLimitiTemperaturaMandata.Controls.Add(nud_BandaRegolazioneLimiti);
            gbLimitiTemperaturaMandata.Controls.Add(lbl_BandaRegolazioneLimiti);
            gbLimitiTemperaturaMandata.Location = new Point(422, 51);
            gbLimitiTemperaturaMandata.Margin = new Padding(4, 3, 4, 3);
            gbLimitiTemperaturaMandata.Name = "gbLimitiTemperaturaMandata";
            gbLimitiTemperaturaMandata.Padding = new Padding(4, 3, 4, 3);
            gbLimitiTemperaturaMandata.Size = new Size(407, 77);
            gbLimitiTemperaturaMandata.TabIndex = 19;
            gbLimitiTemperaturaMandata.TabStop = false;
            gbLimitiTemperaturaMandata.Text = "6 Limiti temperatura mandata";
            // 
            // nud_SetpointLimiteMassimoHLSP
            // 
            nud_SetpointLimiteMassimoHLSP.Location = new Point(316, 18);
            nud_SetpointLimiteMassimoHLSP.Margin = new Padding(4, 3, 4, 3);
            nud_SetpointLimiteMassimoHLSP.Name = "nud_SetpointLimiteMassimoHLSP";
            nud_SetpointLimiteMassimoHLSP.Size = new Size(66, 23);
            nud_SetpointLimiteMassimoHLSP.TabIndex = 17;
            // 
            // lbl_SetpointLimiteMassimoHLSP
            // 
            lbl_SetpointLimiteMassimoHLSP.AutoSize = true;
            lbl_SetpointLimiteMassimoHLSP.Location = new Point(13, 20);
            lbl_SetpointLimiteMassimoHLSP.Margin = new Padding(4, 0, 4, 0);
            lbl_SetpointLimiteMassimoHLSP.Name = "lbl_SetpointLimiteMassimoHLSP";
            lbl_SetpointLimiteMassimoHLSP.Size = new Size(90, 15);
            lbl_SetpointLimiteMassimoHLSP.TabIndex = 16;
            lbl_SetpointLimiteMassimoHLSP.Text = "Funzionamento";
            // 
            // nud_BandaRegolazioneLimiti
            // 
            nud_BandaRegolazioneLimiti.Location = new Point(316, 43);
            nud_BandaRegolazioneLimiti.Margin = new Padding(4, 3, 4, 3);
            nud_BandaRegolazioneLimiti.Name = "nud_BandaRegolazioneLimiti";
            nud_BandaRegolazioneLimiti.Size = new Size(66, 23);
            nud_BandaRegolazioneLimiti.TabIndex = 3;
            // 
            // lbl_BandaRegolazioneLimiti
            // 
            lbl_BandaRegolazioneLimiti.AutoSize = true;
            lbl_BandaRegolazioneLimiti.Location = new Point(13, 45);
            lbl_BandaRegolazioneLimiti.Margin = new Padding(4, 0, 4, 0);
            lbl_BandaRegolazioneLimiti.Name = "lbl_BandaRegolazioneLimiti";
            lbl_BandaRegolazioneLimiti.Size = new Size(207, 15);
            lbl_BandaRegolazioneLimiti.TabIndex = 0;
            lbl_BandaRegolazioneLimiti.Text = "Zona morta riscaldamento H.D.Z. [C°]";
            // 
            // gbRegolazioneSerranda
            // 
            gbRegolazioneSerranda.Controls.Add(nud_TensioneSerrandaMassima);
            gbRegolazioneSerranda.Controls.Add(lbl_TensioneSerrandaMassima);
            gbRegolazioneSerranda.Controls.Add(nud_TensioneSerrandaMinima);
            gbRegolazioneSerranda.Controls.Add(lbl_TensioneSerrandaMinima);
            gbRegolazioneSerranda.Controls.Add(panel11);
            gbRegolazioneSerranda.Controls.Add(lbl_PresenzaSerranda);
            gbRegolazioneSerranda.Controls.Add(nud_AperturaserrandaMassima);
            gbRegolazioneSerranda.Controls.Add(lbl_AperturaserrandaMassima);
            gbRegolazioneSerranda.Controls.Add(nud_AperturaSerrandaMinima);
            gbRegolazioneSerranda.Controls.Add(lbl_AperturaSerrandaMinima);
            gbRegolazioneSerranda.Controls.Add(nud_KIRegolazioneSerranda);
            gbRegolazioneSerranda.Controls.Add(lbl_KIRegolazioneSerranda);
            gbRegolazioneSerranda.Controls.Add(nud_BandaDiRegolazioneSerranda);
            gbRegolazioneSerranda.Controls.Add(lbl_BandaDiRegolazioneSerranda);
            gbRegolazioneSerranda.Controls.Add(nud_ZonaMortaSerrandaDDZ);
            gbRegolazioneSerranda.Controls.Add(rb_LogicaInv);
            gbRegolazioneSerranda.Controls.Add(lbl_ZonaMortaSerrandaDDZ);
            gbRegolazioneSerranda.Controls.Add(rb_LogicaDir);
            gbRegolazioneSerranda.Controls.Add(lbl_LogicaFunzSerranda);
            gbRegolazioneSerranda.Location = new Point(421, 129);
            gbRegolazioneSerranda.Margin = new Padding(4, 3, 4, 3);
            gbRegolazioneSerranda.Name = "gbRegolazioneSerranda";
            gbRegolazioneSerranda.Padding = new Padding(4, 3, 4, 3);
            gbRegolazioneSerranda.Size = new Size(407, 255);
            gbRegolazioneSerranda.TabIndex = 21;
            gbRegolazioneSerranda.TabStop = false;
            gbRegolazioneSerranda.Text = "7 Regolazione serranda";
            // 
            // nud_TensioneSerrandaMassima
            // 
            nud_TensioneSerrandaMassima.Location = new Point(316, 168);
            nud_TensioneSerrandaMassima.Margin = new Padding(4, 3, 4, 3);
            nud_TensioneSerrandaMassima.Name = "nud_TensioneSerrandaMassima";
            nud_TensioneSerrandaMassima.Size = new Size(66, 23);
            nud_TensioneSerrandaMassima.TabIndex = 48;
            nud_TensioneSerrandaMassima.ValueChanged += nud_TensioneSerrandaMassima_ValueChanged;
            // 
            // lbl_TensioneSerrandaMassima
            // 
            lbl_TensioneSerrandaMassima.AutoSize = true;
            lbl_TensioneSerrandaMassima.Location = new Point(13, 170);
            lbl_TensioneSerrandaMassima.Margin = new Padding(4, 0, 4, 0);
            lbl_TensioneSerrandaMassima.Name = "lbl_TensioneSerrandaMassima";
            lbl_TensioneSerrandaMassima.Size = new Size(71, 15);
            lbl_TensioneSerrandaMassima.TabIndex = 47;
            lbl_TensioneSerrandaMassima.Text = "V max 100%";
            // 
            // nud_TensioneSerrandaMinima
            // 
            nud_TensioneSerrandaMinima.Location = new Point(316, 143);
            nud_TensioneSerrandaMinima.Margin = new Padding(4, 3, 4, 3);
            nud_TensioneSerrandaMinima.Name = "nud_TensioneSerrandaMinima";
            nud_TensioneSerrandaMinima.Size = new Size(66, 23);
            nud_TensioneSerrandaMinima.TabIndex = 46;
            nud_TensioneSerrandaMinima.ValueChanged += nud_TensioneSerrandaMinima_ValueChanged;
            // 
            // lbl_TensioneSerrandaMinima
            // 
            lbl_TensioneSerrandaMinima.AutoSize = true;
            lbl_TensioneSerrandaMinima.Location = new Point(13, 145);
            lbl_TensioneSerrandaMinima.Margin = new Padding(4, 0, 4, 0);
            lbl_TensioneSerrandaMinima.Name = "lbl_TensioneSerrandaMinima";
            lbl_TensioneSerrandaMinima.Size = new Size(57, 15);
            lbl_TensioneSerrandaMinima.TabIndex = 45;
            lbl_TensioneSerrandaMinima.Text = "V min 0%";
            lbl_TensioneSerrandaMinima.Click += lbl_TensioneSerrandaMinima_Click;
            // 
            // panel11
            // 
            panel11.Controls.Add(rb_PresenzaSerrandaOFF);
            panel11.Controls.Add(rb_PresenzaSerrandaON);
            panel11.Location = new Point(258, 218);
            panel11.Margin = new Padding(4, 3, 4, 3);
            panel11.Name = "panel11";
            panel11.Size = new Size(125, 32);
            panel11.TabIndex = 19;
            // 
            // rb_PresenzaSerrandaOFF
            // 
            rb_PresenzaSerrandaOFF.AutoSize = true;
            rb_PresenzaSerrandaOFF.CheckAlign = ContentAlignment.MiddleRight;
            rb_PresenzaSerrandaOFF.Location = new Point(12, 3);
            rb_PresenzaSerrandaOFF.Margin = new Padding(4, 3, 4, 3);
            rb_PresenzaSerrandaOFF.Name = "rb_PresenzaSerrandaOFF";
            rb_PresenzaSerrandaOFF.Size = new Size(46, 19);
            rb_PresenzaSerrandaOFF.TabIndex = 17;
            rb_PresenzaSerrandaOFF.TabStop = true;
            rb_PresenzaSerrandaOFF.Text = "OFF";
            rb_PresenzaSerrandaOFF.UseVisualStyleBackColor = false;
            // 
            // rb_PresenzaSerrandaON
            // 
            rb_PresenzaSerrandaON.AutoSize = true;
            rb_PresenzaSerrandaON.CheckAlign = ContentAlignment.MiddleRight;
            rb_PresenzaSerrandaON.Location = new Point(71, 3);
            rb_PresenzaSerrandaON.Margin = new Padding(4, 3, 4, 3);
            rb_PresenzaSerrandaON.Name = "rb_PresenzaSerrandaON";
            rb_PresenzaSerrandaON.Size = new Size(43, 19);
            rb_PresenzaSerrandaON.TabIndex = 18;
            rb_PresenzaSerrandaON.TabStop = true;
            rb_PresenzaSerrandaON.Text = "ON";
            rb_PresenzaSerrandaON.UseVisualStyleBackColor = false;
            // 
            // lbl_PresenzaSerranda
            // 
            lbl_PresenzaSerranda.AutoSize = true;
            lbl_PresenzaSerranda.Location = new Point(13, 220);
            lbl_PresenzaSerranda.Margin = new Padding(4, 0, 4, 0);
            lbl_PresenzaSerranda.Name = "lbl_PresenzaSerranda";
            lbl_PresenzaSerranda.Size = new Size(90, 15);
            lbl_PresenzaSerranda.TabIndex = 16;
            lbl_PresenzaSerranda.Text = "Funzionamento";
            // 
            // nud_AperturaserrandaMassima
            // 
            nud_AperturaserrandaMassima.Location = new Point(316, 118);
            nud_AperturaserrandaMassima.Margin = new Padding(4, 3, 4, 3);
            nud_AperturaserrandaMassima.Name = "nud_AperturaserrandaMassima";
            nud_AperturaserrandaMassima.Size = new Size(66, 23);
            nud_AperturaserrandaMassima.TabIndex = 11;
            // 
            // lbl_AperturaserrandaMassima
            // 
            lbl_AperturaserrandaMassima.AutoSize = true;
            lbl_AperturaserrandaMassima.Location = new Point(13, 120);
            lbl_AperturaserrandaMassima.Margin = new Padding(4, 0, 4, 0);
            lbl_AperturaserrandaMassima.Name = "lbl_AperturaserrandaMassima";
            lbl_AperturaserrandaMassima.Size = new Size(90, 15);
            lbl_AperturaserrandaMassima.TabIndex = 10;
            lbl_AperturaserrandaMassima.Text = "Funzionamento";
            // 
            // nud_AperturaSerrandaMinima
            // 
            nud_AperturaSerrandaMinima.Location = new Point(316, 93);
            nud_AperturaSerrandaMinima.Margin = new Padding(4, 3, 4, 3);
            nud_AperturaSerrandaMinima.Name = "nud_AperturaSerrandaMinima";
            nud_AperturaSerrandaMinima.Size = new Size(66, 23);
            nud_AperturaSerrandaMinima.TabIndex = 9;
            // 
            // lbl_AperturaSerrandaMinima
            // 
            lbl_AperturaSerrandaMinima.AutoSize = true;
            lbl_AperturaSerrandaMinima.Location = new Point(13, 95);
            lbl_AperturaSerrandaMinima.Margin = new Padding(4, 0, 4, 0);
            lbl_AperturaSerrandaMinima.Name = "lbl_AperturaSerrandaMinima";
            lbl_AperturaSerrandaMinima.Size = new Size(90, 15);
            lbl_AperturaSerrandaMinima.TabIndex = 8;
            lbl_AperturaSerrandaMinima.Text = "Funzionamento";
            // 
            // nud_KIRegolazioneSerranda
            // 
            nud_KIRegolazioneSerranda.Location = new Point(316, 68);
            nud_KIRegolazioneSerranda.Margin = new Padding(4, 3, 4, 3);
            nud_KIRegolazioneSerranda.Name = "nud_KIRegolazioneSerranda";
            nud_KIRegolazioneSerranda.Size = new Size(66, 23);
            nud_KIRegolazioneSerranda.TabIndex = 7;
            // 
            // lbl_KIRegolazioneSerranda
            // 
            lbl_KIRegolazioneSerranda.AutoSize = true;
            lbl_KIRegolazioneSerranda.Location = new Point(13, 70);
            lbl_KIRegolazioneSerranda.Margin = new Padding(4, 0, 4, 0);
            lbl_KIRegolazioneSerranda.Name = "lbl_KIRegolazioneSerranda";
            lbl_KIRegolazioneSerranda.Size = new Size(90, 15);
            lbl_KIRegolazioneSerranda.TabIndex = 6;
            lbl_KIRegolazioneSerranda.Text = "Funzionamento";
            // 
            // nud_BandaDiRegolazioneSerranda
            // 
            nud_BandaDiRegolazioneSerranda.Location = new Point(316, 43);
            nud_BandaDiRegolazioneSerranda.Margin = new Padding(4, 3, 4, 3);
            nud_BandaDiRegolazioneSerranda.Name = "nud_BandaDiRegolazioneSerranda";
            nud_BandaDiRegolazioneSerranda.Size = new Size(66, 23);
            nud_BandaDiRegolazioneSerranda.TabIndex = 5;
            // 
            // lbl_BandaDiRegolazioneSerranda
            // 
            lbl_BandaDiRegolazioneSerranda.AutoSize = true;
            lbl_BandaDiRegolazioneSerranda.Location = new Point(13, 45);
            lbl_BandaDiRegolazioneSerranda.Margin = new Padding(4, 0, 4, 0);
            lbl_BandaDiRegolazioneSerranda.Name = "lbl_BandaDiRegolazioneSerranda";
            lbl_BandaDiRegolazioneSerranda.Size = new Size(90, 15);
            lbl_BandaDiRegolazioneSerranda.TabIndex = 4;
            lbl_BandaDiRegolazioneSerranda.Text = "Funzionamento";
            // 
            // nud_ZonaMortaSerrandaDDZ
            // 
            nud_ZonaMortaSerrandaDDZ.Location = new Point(316, 18);
            nud_ZonaMortaSerrandaDDZ.Margin = new Padding(4, 3, 4, 3);
            nud_ZonaMortaSerrandaDDZ.Name = "nud_ZonaMortaSerrandaDDZ";
            nud_ZonaMortaSerrandaDDZ.Size = new Size(66, 23);
            nud_ZonaMortaSerrandaDDZ.TabIndex = 3;
            // 
            // rb_LogicaInv
            // 
            rb_LogicaInv.AutoSize = true;
            rb_LogicaInv.CheckAlign = ContentAlignment.MiddleRight;
            rb_LogicaInv.Location = new Point(299, 193);
            rb_LogicaInv.Margin = new Padding(4, 3, 4, 3);
            rb_LogicaInv.Name = "rb_LogicaInv";
            rb_LogicaInv.Size = new Size(71, 19);
            rb_LogicaInv.TabIndex = 44;
            rb_LogicaInv.TabStop = true;
            rb_LogicaInv.Text = "INVERSA";
            rb_LogicaInv.UseVisualStyleBackColor = false;
            rb_LogicaInv.CheckedChanged += radioButton1_CheckedChanged_1;
            // 
            // lbl_ZonaMortaSerrandaDDZ
            // 
            lbl_ZonaMortaSerrandaDDZ.AutoSize = true;
            lbl_ZonaMortaSerrandaDDZ.Location = new Point(13, 20);
            lbl_ZonaMortaSerrandaDDZ.Margin = new Padding(4, 0, 4, 0);
            lbl_ZonaMortaSerrandaDDZ.Name = "lbl_ZonaMortaSerrandaDDZ";
            lbl_ZonaMortaSerrandaDDZ.Size = new Size(207, 15);
            lbl_ZonaMortaSerrandaDDZ.TabIndex = 0;
            lbl_ZonaMortaSerrandaDDZ.Text = "Zona morta riscaldamento H.D.Z. [C°]";
            // 
            // rb_LogicaDir
            // 
            rb_LogicaDir.AutoSize = true;
            rb_LogicaDir.CheckAlign = ContentAlignment.MiddleRight;
            rb_LogicaDir.Location = new Point(208, 193);
            rb_LogicaDir.Margin = new Padding(4, 3, 4, 3);
            rb_LogicaDir.Name = "rb_LogicaDir";
            rb_LogicaDir.Size = new Size(68, 19);
            rb_LogicaDir.TabIndex = 43;
            rb_LogicaDir.TabStop = true;
            rb_LogicaDir.Text = "DIRETTA";
            rb_LogicaDir.UseVisualStyleBackColor = false;
            // 
            // lbl_LogicaFunzSerranda
            // 
            lbl_LogicaFunzSerranda.AutoSize = true;
            lbl_LogicaFunzSerranda.Location = new Point(13, 195);
            lbl_LogicaFunzSerranda.Margin = new Padding(4, 0, 4, 0);
            lbl_LogicaFunzSerranda.Name = "lbl_LogicaFunzSerranda";
            lbl_LogicaFunzSerranda.Size = new Size(174, 15);
            lbl_LogicaFunzSerranda.TabIndex = 42;
            lbl_LogicaFunzSerranda.Text = "Logica funzionamento serranda";
            // 
            // gbGestioneModalitaEconomy
            // 
            gbGestioneModalitaEconomy.Controls.Add(comboTipoEcomomy);
            gbGestioneModalitaEconomy.Controls.Add(lbl_TipoEconomy);
            gbGestioneModalitaEconomy.Controls.Add(nud_TastoEconomyRiduzione);
            gbGestioneModalitaEconomy.Controls.Add(lbl_TastoEconomyRiduzione);
            gbGestioneModalitaEconomy.Location = new Point(421, 384);
            gbGestioneModalitaEconomy.Margin = new Padding(4, 3, 4, 3);
            gbGestioneModalitaEconomy.Name = "gbGestioneModalitaEconomy";
            gbGestioneModalitaEconomy.Padding = new Padding(4, 3, 4, 3);
            gbGestioneModalitaEconomy.Size = new Size(407, 75);
            gbGestioneModalitaEconomy.TabIndex = 20;
            gbGestioneModalitaEconomy.TabStop = false;
            gbGestioneModalitaEconomy.Text = "8 Gestione modalità economy";
            // 
            // comboTipoEcomomy
            // 
            comboTipoEcomomy.DropDownStyle = ComboBoxStyle.DropDownList;
            comboTipoEcomomy.FormattingEnabled = true;
            comboTipoEcomomy.Location = new Point(183, 18);
            comboTipoEcomomy.Margin = new Padding(4, 3, 4, 3);
            comboTipoEcomomy.Name = "comboTipoEcomomy";
            comboTipoEcomomy.Size = new Size(199, 23);
            comboTipoEcomomy.TabIndex = 17;
            // 
            // lbl_TipoEconomy
            // 
            lbl_TipoEconomy.AutoSize = true;
            lbl_TipoEconomy.Location = new Point(13, 20);
            lbl_TipoEconomy.Margin = new Padding(4, 0, 4, 0);
            lbl_TipoEconomy.Name = "lbl_TipoEconomy";
            lbl_TipoEconomy.Size = new Size(90, 15);
            lbl_TipoEconomy.TabIndex = 16;
            lbl_TipoEconomy.Text = "Funzionamento";
            // 
            // nud_TastoEconomyRiduzione
            // 
            nud_TastoEconomyRiduzione.Location = new Point(316, 43);
            nud_TastoEconomyRiduzione.Margin = new Padding(4, 3, 4, 3);
            nud_TastoEconomyRiduzione.Name = "nud_TastoEconomyRiduzione";
            nud_TastoEconomyRiduzione.Size = new Size(66, 23);
            nud_TastoEconomyRiduzione.TabIndex = 3;
            // 
            // lbl_TastoEconomyRiduzione
            // 
            lbl_TastoEconomyRiduzione.AutoSize = true;
            lbl_TastoEconomyRiduzione.Location = new Point(13, 45);
            lbl_TastoEconomyRiduzione.Margin = new Padding(4, 0, 4, 0);
            lbl_TastoEconomyRiduzione.Name = "lbl_TastoEconomyRiduzione";
            lbl_TastoEconomyRiduzione.Size = new Size(207, 15);
            lbl_TastoEconomyRiduzione.TabIndex = 0;
            lbl_TastoEconomyRiduzione.Text = "Zona morta riscaldamento H.D.Z. [C°]";
            // 
            // gbGestionePortata
            // 
            gbGestionePortata.Controls.Add(lbl_PortataMinimaSicurezzaLS);
            gbGestionePortata.Controls.Add(lbl_PortataMassimaLS);
            gbGestionePortata.Controls.Add(lbl_PortataMinimaLS);
            gbGestionePortata.Controls.Add(nud_KApertura_90_100);
            gbGestionePortata.Controls.Add(lbl_KApertura_90_100);
            gbGestionePortata.Controls.Add(nud_KApertura_80_90);
            gbGestionePortata.Controls.Add(lbl_KApertura_80_90);
            gbGestionePortata.Controls.Add(nud_KApertura_70_80);
            gbGestionePortata.Controls.Add(lbl_KApertura_70_80);
            gbGestionePortata.Controls.Add(nud_KApertura_60_70);
            gbGestionePortata.Controls.Add(lbl_KApertura_60_70);
            gbGestionePortata.Controls.Add(nud_KApertura_50_60);
            gbGestionePortata.Controls.Add(lbl_KApertura_50_60);
            gbGestionePortata.Controls.Add(nud_KApertura_40_50);
            gbGestionePortata.Controls.Add(lbl_KApertura_40_50);
            gbGestionePortata.Controls.Add(nud_KApertura_30_40);
            gbGestionePortata.Controls.Add(lbl_KApertura_30_40);
            gbGestionePortata.Controls.Add(nud_KApertura_20_30);
            gbGestionePortata.Controls.Add(lbl_KApertura_20_30);
            gbGestionePortata.Controls.Add(nud_KApertura_10_20);
            gbGestionePortata.Controls.Add(lbl_KApertura_10_20);
            gbGestionePortata.Controls.Add(rb_AbilitaDisabilitaPortataIstantaneaON);
            gbGestionePortata.Controls.Add(rb_AbilitaDisabilitaPortataIstantaneaOFF);
            gbGestionePortata.Controls.Add(lbl_AbilitaDisabilitaPortataIstantanea);
            gbGestionePortata.Controls.Add(nud_TempoLetturaSensore);
            gbGestionePortata.Controls.Add(lbl_TempoLetturaSensore);
            gbGestionePortata.Controls.Add(nud_OffsetMisurazioneDiPortata);
            gbGestionePortata.Controls.Add(lbl_OffsetMisurazioneDiPortata);
            gbGestionePortata.Controls.Add(nud_SezionePerMisiurazPortata);
            gbGestionePortata.Controls.Add(lbl_SezionePerMisiurazPortata);
            gbGestionePortata.Controls.Add(nud_PortataMinimaSicurezza);
            gbGestionePortata.Controls.Add(lbl_PortataMinimaSicurezza);
            gbGestionePortata.Controls.Add(nud_PortataMassima);
            gbGestionePortata.Controls.Add(lbl_PortataMassima);
            gbGestionePortata.Controls.Add(nud_PortataMinima);
            gbGestionePortata.Controls.Add(lbl_PortataMinima);
            gbGestionePortata.Controls.Add(nud_KApertura_0_10);
            gbGestionePortata.Controls.Add(lbl_KApertura_0_10);
            gbGestionePortata.Location = new Point(835, 3);
            gbGestionePortata.Margin = new Padding(4, 3, 4, 3);
            gbGestionePortata.Name = "gbGestionePortata";
            gbGestionePortata.Padding = new Padding(4, 3, 4, 3);
            gbGestionePortata.Size = new Size(476, 448);
            gbGestionePortata.TabIndex = 22;
            gbGestionePortata.TabStop = false;
            gbGestionePortata.Text = "9 Gestione portata";
            // 
            // lbl_PortataMinimaSicurezzaLS
            // 
            lbl_PortataMinimaSicurezzaLS.AutoSize = true;
            lbl_PortataMinimaSicurezzaLS.Location = new Point(407, 93);
            lbl_PortataMinimaSicurezzaLS.Margin = new Padding(4, 0, 4, 0);
            lbl_PortataMinimaSicurezzaLS.Name = "lbl_PortataMinimaSicurezzaLS";
            lbl_PortataMinimaSicurezzaLS.Size = new Size(20, 15);
            lbl_PortataMinimaSicurezzaLS.TabIndex = 39;
            lbl_PortataMinimaSicurezzaLS.Text = "l/s";
            // 
            // lbl_PortataMassimaLS
            // 
            lbl_PortataMassimaLS.AutoSize = true;
            lbl_PortataMassimaLS.Location = new Point(407, 68);
            lbl_PortataMassimaLS.Margin = new Padding(4, 0, 4, 0);
            lbl_PortataMassimaLS.Name = "lbl_PortataMassimaLS";
            lbl_PortataMassimaLS.Size = new Size(20, 15);
            lbl_PortataMassimaLS.TabIndex = 38;
            lbl_PortataMassimaLS.Text = "l/s";
            // 
            // lbl_PortataMinimaLS
            // 
            lbl_PortataMinimaLS.AutoSize = true;
            lbl_PortataMinimaLS.Location = new Point(407, 43);
            lbl_PortataMinimaLS.Margin = new Padding(4, 0, 4, 0);
            lbl_PortataMinimaLS.Name = "lbl_PortataMinimaLS";
            lbl_PortataMinimaLS.Size = new Size(20, 15);
            lbl_PortataMinimaLS.TabIndex = 37;
            lbl_PortataMinimaLS.Text = "l/s";
            // 
            // nud_KApertura_90_100
            // 
            nud_KApertura_90_100.Location = new Point(316, 418);
            nud_KApertura_90_100.Margin = new Padding(4, 3, 4, 3);
            nud_KApertura_90_100.Name = "nud_KApertura_90_100";
            nud_KApertura_90_100.Size = new Size(66, 23);
            nud_KApertura_90_100.TabIndex = 36;
            // 
            // lbl_KApertura_90_100
            // 
            lbl_KApertura_90_100.AutoSize = true;
            lbl_KApertura_90_100.Location = new Point(13, 420);
            lbl_KApertura_90_100.Margin = new Padding(4, 0, 4, 0);
            lbl_KApertura_90_100.Name = "lbl_KApertura_90_100";
            lbl_KApertura_90_100.Size = new Size(207, 15);
            lbl_KApertura_90_100.TabIndex = 35;
            lbl_KApertura_90_100.Text = "Zona morta riscaldamento H.D.Z. [C°]";
            // 
            // nud_KApertura_80_90
            // 
            nud_KApertura_80_90.Location = new Point(316, 393);
            nud_KApertura_80_90.Margin = new Padding(4, 3, 4, 3);
            nud_KApertura_80_90.Name = "nud_KApertura_80_90";
            nud_KApertura_80_90.Size = new Size(66, 23);
            nud_KApertura_80_90.TabIndex = 34;
            // 
            // lbl_KApertura_80_90
            // 
            lbl_KApertura_80_90.AutoSize = true;
            lbl_KApertura_80_90.Location = new Point(13, 395);
            lbl_KApertura_80_90.Margin = new Padding(4, 0, 4, 0);
            lbl_KApertura_80_90.Name = "lbl_KApertura_80_90";
            lbl_KApertura_80_90.Size = new Size(207, 15);
            lbl_KApertura_80_90.TabIndex = 33;
            lbl_KApertura_80_90.Text = "Zona morta riscaldamento H.D.Z. [C°]";
            // 
            // nud_KApertura_70_80
            // 
            nud_KApertura_70_80.Location = new Point(316, 368);
            nud_KApertura_70_80.Margin = new Padding(4, 3, 4, 3);
            nud_KApertura_70_80.Name = "nud_KApertura_70_80";
            nud_KApertura_70_80.Size = new Size(66, 23);
            nud_KApertura_70_80.TabIndex = 32;
            // 
            // lbl_KApertura_70_80
            // 
            lbl_KApertura_70_80.AutoSize = true;
            lbl_KApertura_70_80.Location = new Point(13, 370);
            lbl_KApertura_70_80.Margin = new Padding(4, 0, 4, 0);
            lbl_KApertura_70_80.Name = "lbl_KApertura_70_80";
            lbl_KApertura_70_80.Size = new Size(207, 15);
            lbl_KApertura_70_80.TabIndex = 31;
            lbl_KApertura_70_80.Text = "Zona morta riscaldamento H.D.Z. [C°]";
            // 
            // nud_KApertura_60_70
            // 
            nud_KApertura_60_70.Location = new Point(316, 343);
            nud_KApertura_60_70.Margin = new Padding(4, 3, 4, 3);
            nud_KApertura_60_70.Name = "nud_KApertura_60_70";
            nud_KApertura_60_70.Size = new Size(66, 23);
            nud_KApertura_60_70.TabIndex = 30;
            // 
            // lbl_KApertura_60_70
            // 
            lbl_KApertura_60_70.AutoSize = true;
            lbl_KApertura_60_70.Location = new Point(13, 345);
            lbl_KApertura_60_70.Margin = new Padding(4, 0, 4, 0);
            lbl_KApertura_60_70.Name = "lbl_KApertura_60_70";
            lbl_KApertura_60_70.Size = new Size(207, 15);
            lbl_KApertura_60_70.TabIndex = 29;
            lbl_KApertura_60_70.Text = "Zona morta riscaldamento H.D.Z. [C°]";
            // 
            // nud_KApertura_50_60
            // 
            nud_KApertura_50_60.Location = new Point(316, 318);
            nud_KApertura_50_60.Margin = new Padding(4, 3, 4, 3);
            nud_KApertura_50_60.Name = "nud_KApertura_50_60";
            nud_KApertura_50_60.Size = new Size(66, 23);
            nud_KApertura_50_60.TabIndex = 28;
            // 
            // lbl_KApertura_50_60
            // 
            lbl_KApertura_50_60.AutoSize = true;
            lbl_KApertura_50_60.Location = new Point(13, 320);
            lbl_KApertura_50_60.Margin = new Padding(4, 0, 4, 0);
            lbl_KApertura_50_60.Name = "lbl_KApertura_50_60";
            lbl_KApertura_50_60.Size = new Size(207, 15);
            lbl_KApertura_50_60.TabIndex = 27;
            lbl_KApertura_50_60.Text = "Zona morta riscaldamento H.D.Z. [C°]";
            // 
            // nud_KApertura_40_50
            // 
            nud_KApertura_40_50.Location = new Point(316, 293);
            nud_KApertura_40_50.Margin = new Padding(4, 3, 4, 3);
            nud_KApertura_40_50.Name = "nud_KApertura_40_50";
            nud_KApertura_40_50.Size = new Size(66, 23);
            nud_KApertura_40_50.TabIndex = 26;
            // 
            // lbl_KApertura_40_50
            // 
            lbl_KApertura_40_50.AutoSize = true;
            lbl_KApertura_40_50.Location = new Point(13, 295);
            lbl_KApertura_40_50.Margin = new Padding(4, 0, 4, 0);
            lbl_KApertura_40_50.Name = "lbl_KApertura_40_50";
            lbl_KApertura_40_50.Size = new Size(207, 15);
            lbl_KApertura_40_50.TabIndex = 25;
            lbl_KApertura_40_50.Text = "Zona morta riscaldamento H.D.Z. [C°]";
            // 
            // nud_KApertura_30_40
            // 
            nud_KApertura_30_40.Location = new Point(316, 268);
            nud_KApertura_30_40.Margin = new Padding(4, 3, 4, 3);
            nud_KApertura_30_40.Name = "nud_KApertura_30_40";
            nud_KApertura_30_40.Size = new Size(66, 23);
            nud_KApertura_30_40.TabIndex = 24;
            // 
            // lbl_KApertura_30_40
            // 
            lbl_KApertura_30_40.AutoSize = true;
            lbl_KApertura_30_40.Location = new Point(13, 270);
            lbl_KApertura_30_40.Margin = new Padding(4, 0, 4, 0);
            lbl_KApertura_30_40.Name = "lbl_KApertura_30_40";
            lbl_KApertura_30_40.Size = new Size(207, 15);
            lbl_KApertura_30_40.TabIndex = 23;
            lbl_KApertura_30_40.Text = "Zona morta riscaldamento H.D.Z. [C°]";
            // 
            // nud_KApertura_20_30
            // 
            nud_KApertura_20_30.Location = new Point(316, 243);
            nud_KApertura_20_30.Margin = new Padding(4, 3, 4, 3);
            nud_KApertura_20_30.Name = "nud_KApertura_20_30";
            nud_KApertura_20_30.Size = new Size(66, 23);
            nud_KApertura_20_30.TabIndex = 22;
            // 
            // lbl_KApertura_20_30
            // 
            lbl_KApertura_20_30.AutoSize = true;
            lbl_KApertura_20_30.Location = new Point(13, 245);
            lbl_KApertura_20_30.Margin = new Padding(4, 0, 4, 0);
            lbl_KApertura_20_30.Name = "lbl_KApertura_20_30";
            lbl_KApertura_20_30.Size = new Size(207, 15);
            lbl_KApertura_20_30.TabIndex = 21;
            lbl_KApertura_20_30.Text = "Zona morta riscaldamento H.D.Z. [C°]";
            // 
            // nud_KApertura_10_20
            // 
            nud_KApertura_10_20.Location = new Point(316, 218);
            nud_KApertura_10_20.Margin = new Padding(4, 3, 4, 3);
            nud_KApertura_10_20.Name = "nud_KApertura_10_20";
            nud_KApertura_10_20.Size = new Size(66, 23);
            nud_KApertura_10_20.TabIndex = 20;
            // 
            // lbl_KApertura_10_20
            // 
            lbl_KApertura_10_20.AutoSize = true;
            lbl_KApertura_10_20.Location = new Point(13, 220);
            lbl_KApertura_10_20.Margin = new Padding(4, 0, 4, 0);
            lbl_KApertura_10_20.Name = "lbl_KApertura_10_20";
            lbl_KApertura_10_20.Size = new Size(207, 15);
            lbl_KApertura_10_20.TabIndex = 19;
            lbl_KApertura_10_20.Text = "Zona morta riscaldamento H.D.Z. [C°]";
            // 
            // rb_AbilitaDisabilitaPortataIstantaneaON
            // 
            rb_AbilitaDisabilitaPortataIstantaneaON.AutoSize = true;
            rb_AbilitaDisabilitaPortataIstantaneaON.CheckAlign = ContentAlignment.MiddleRight;
            rb_AbilitaDisabilitaPortataIstantaneaON.Location = new Point(335, 18);
            rb_AbilitaDisabilitaPortataIstantaneaON.Margin = new Padding(4, 3, 4, 3);
            rb_AbilitaDisabilitaPortataIstantaneaON.Name = "rb_AbilitaDisabilitaPortataIstantaneaON";
            rb_AbilitaDisabilitaPortataIstantaneaON.Size = new Size(43, 19);
            rb_AbilitaDisabilitaPortataIstantaneaON.TabIndex = 18;
            rb_AbilitaDisabilitaPortataIstantaneaON.TabStop = true;
            rb_AbilitaDisabilitaPortataIstantaneaON.Text = "ON";
            rb_AbilitaDisabilitaPortataIstantaneaON.UseVisualStyleBackColor = false;
            // 
            // rb_AbilitaDisabilitaPortataIstantaneaOFF
            // 
            rb_AbilitaDisabilitaPortataIstantaneaOFF.AutoSize = true;
            rb_AbilitaDisabilitaPortataIstantaneaOFF.CheckAlign = ContentAlignment.MiddleRight;
            rb_AbilitaDisabilitaPortataIstantaneaOFF.Location = new Point(278, 18);
            rb_AbilitaDisabilitaPortataIstantaneaOFF.Margin = new Padding(4, 3, 4, 3);
            rb_AbilitaDisabilitaPortataIstantaneaOFF.Name = "rb_AbilitaDisabilitaPortataIstantaneaOFF";
            rb_AbilitaDisabilitaPortataIstantaneaOFF.Size = new Size(46, 19);
            rb_AbilitaDisabilitaPortataIstantaneaOFF.TabIndex = 17;
            rb_AbilitaDisabilitaPortataIstantaneaOFF.TabStop = true;
            rb_AbilitaDisabilitaPortataIstantaneaOFF.Text = "OFF";
            rb_AbilitaDisabilitaPortataIstantaneaOFF.UseVisualStyleBackColor = false;
            // 
            // lbl_AbilitaDisabilitaPortataIstantanea
            // 
            lbl_AbilitaDisabilitaPortataIstantanea.AutoSize = true;
            lbl_AbilitaDisabilitaPortataIstantanea.Location = new Point(13, 20);
            lbl_AbilitaDisabilitaPortataIstantanea.Margin = new Padding(4, 0, 4, 0);
            lbl_AbilitaDisabilitaPortataIstantanea.Name = "lbl_AbilitaDisabilitaPortataIstantanea";
            lbl_AbilitaDisabilitaPortataIstantanea.Size = new Size(13, 15);
            lbl_AbilitaDisabilitaPortataIstantanea.TabIndex = 16;
            lbl_AbilitaDisabilitaPortataIstantanea.Text = "0";
            // 
            // nud_TempoLetturaSensore
            // 
            nud_TempoLetturaSensore.Location = new Point(316, 168);
            nud_TempoLetturaSensore.Margin = new Padding(4, 3, 4, 3);
            nud_TempoLetturaSensore.Name = "nud_TempoLetturaSensore";
            nud_TempoLetturaSensore.Size = new Size(66, 23);
            nud_TempoLetturaSensore.TabIndex = 15;
            // 
            // lbl_TempoLetturaSensore
            // 
            lbl_TempoLetturaSensore.AutoSize = true;
            lbl_TempoLetturaSensore.Location = new Point(13, 170);
            lbl_TempoLetturaSensore.Margin = new Padding(4, 0, 4, 0);
            lbl_TempoLetturaSensore.Name = "lbl_TempoLetturaSensore";
            lbl_TempoLetturaSensore.Size = new Size(13, 15);
            lbl_TempoLetturaSensore.TabIndex = 14;
            lbl_TempoLetturaSensore.Text = "6";
            // 
            // nud_OffsetMisurazioneDiPortata
            // 
            nud_OffsetMisurazioneDiPortata.Location = new Point(316, 143);
            nud_OffsetMisurazioneDiPortata.Margin = new Padding(4, 3, 4, 3);
            nud_OffsetMisurazioneDiPortata.Name = "nud_OffsetMisurazioneDiPortata";
            nud_OffsetMisurazioneDiPortata.Size = new Size(66, 23);
            nud_OffsetMisurazioneDiPortata.TabIndex = 13;
            // 
            // lbl_OffsetMisurazioneDiPortata
            // 
            lbl_OffsetMisurazioneDiPortata.AutoSize = true;
            lbl_OffsetMisurazioneDiPortata.Location = new Point(13, 145);
            lbl_OffsetMisurazioneDiPortata.Margin = new Padding(4, 0, 4, 0);
            lbl_OffsetMisurazioneDiPortata.Name = "lbl_OffsetMisurazioneDiPortata";
            lbl_OffsetMisurazioneDiPortata.Size = new Size(13, 15);
            lbl_OffsetMisurazioneDiPortata.TabIndex = 12;
            lbl_OffsetMisurazioneDiPortata.Text = "5";
            // 
            // nud_SezionePerMisiurazPortata
            // 
            nud_SezionePerMisiurazPortata.Location = new Point(316, 118);
            nud_SezionePerMisiurazPortata.Margin = new Padding(4, 3, 4, 3);
            nud_SezionePerMisiurazPortata.Name = "nud_SezionePerMisiurazPortata";
            nud_SezionePerMisiurazPortata.Size = new Size(66, 23);
            nud_SezionePerMisiurazPortata.TabIndex = 11;
            // 
            // lbl_SezionePerMisiurazPortata
            // 
            lbl_SezionePerMisiurazPortata.AutoSize = true;
            lbl_SezionePerMisiurazPortata.Location = new Point(13, 120);
            lbl_SezionePerMisiurazPortata.Margin = new Padding(4, 0, 4, 0);
            lbl_SezionePerMisiurazPortata.Name = "lbl_SezionePerMisiurazPortata";
            lbl_SezionePerMisiurazPortata.Size = new Size(13, 15);
            lbl_SezionePerMisiurazPortata.TabIndex = 10;
            lbl_SezionePerMisiurazPortata.Text = "4";
            // 
            // nud_PortataMinimaSicurezza
            // 
            nud_PortataMinimaSicurezza.Location = new Point(316, 93);
            nud_PortataMinimaSicurezza.Margin = new Padding(4, 3, 4, 3);
            nud_PortataMinimaSicurezza.Name = "nud_PortataMinimaSicurezza";
            nud_PortataMinimaSicurezza.Size = new Size(66, 23);
            nud_PortataMinimaSicurezza.TabIndex = 9;
            // 
            // lbl_PortataMinimaSicurezza
            // 
            lbl_PortataMinimaSicurezza.AutoSize = true;
            lbl_PortataMinimaSicurezza.Location = new Point(13, 95);
            lbl_PortataMinimaSicurezza.Margin = new Padding(4, 0, 4, 0);
            lbl_PortataMinimaSicurezza.Name = "lbl_PortataMinimaSicurezza";
            lbl_PortataMinimaSicurezza.Size = new Size(13, 15);
            lbl_PortataMinimaSicurezza.TabIndex = 8;
            lbl_PortataMinimaSicurezza.Text = "3";
            // 
            // nud_PortataMassima
            // 
            nud_PortataMassima.Location = new Point(316, 68);
            nud_PortataMassima.Margin = new Padding(4, 3, 4, 3);
            nud_PortataMassima.Name = "nud_PortataMassima";
            nud_PortataMassima.Size = new Size(66, 23);
            nud_PortataMassima.TabIndex = 7;
            // 
            // lbl_PortataMassima
            // 
            lbl_PortataMassima.AutoSize = true;
            lbl_PortataMassima.Location = new Point(13, 70);
            lbl_PortataMassima.Margin = new Padding(4, 0, 4, 0);
            lbl_PortataMassima.Name = "lbl_PortataMassima";
            lbl_PortataMassima.Size = new Size(13, 15);
            lbl_PortataMassima.TabIndex = 6;
            lbl_PortataMassima.Text = "2";
            // 
            // nud_PortataMinima
            // 
            nud_PortataMinima.Location = new Point(316, 43);
            nud_PortataMinima.Margin = new Padding(4, 3, 4, 3);
            nud_PortataMinima.Name = "nud_PortataMinima";
            nud_PortataMinima.Size = new Size(66, 23);
            nud_PortataMinima.TabIndex = 5;
            // 
            // lbl_PortataMinima
            // 
            lbl_PortataMinima.AutoSize = true;
            lbl_PortataMinima.Location = new Point(13, 45);
            lbl_PortataMinima.Margin = new Padding(4, 0, 4, 0);
            lbl_PortataMinima.Name = "lbl_PortataMinima";
            lbl_PortataMinima.Size = new Size(13, 15);
            lbl_PortataMinima.TabIndex = 4;
            lbl_PortataMinima.Text = "1";
            // 
            // nud_KApertura_0_10
            // 
            nud_KApertura_0_10.Location = new Point(316, 193);
            nud_KApertura_0_10.Margin = new Padding(4, 3, 4, 3);
            nud_KApertura_0_10.Name = "nud_KApertura_0_10";
            nud_KApertura_0_10.Size = new Size(66, 23);
            nud_KApertura_0_10.TabIndex = 3;
            // 
            // lbl_KApertura_0_10
            // 
            lbl_KApertura_0_10.AutoSize = true;
            lbl_KApertura_0_10.Location = new Point(13, 195);
            lbl_KApertura_0_10.Margin = new Padding(4, 0, 4, 0);
            lbl_KApertura_0_10.Name = "lbl_KApertura_0_10";
            lbl_KApertura_0_10.Size = new Size(207, 15);
            lbl_KApertura_0_10.TabIndex = 0;
            lbl_KApertura_0_10.Text = "Zona morta riscaldamento H.D.Z. [C°]";
            lbl_KApertura_0_10.Click += lbl_KApertura_0_10_Click;
            // 
            // gbIngressi
            // 
            gbIngressi.Controls.Add(panel10);
            gbIngressi.Controls.Add(lbl_Int_IntMandata);
            gbIngressi.Controls.Add(panel8);
            gbIngressi.Controls.Add(panel7);
            gbIngressi.Controls.Add(panel1);
            gbIngressi.Controls.Add(panel4);
            gbIngressi.Controls.Add(panel3);
            gbIngressi.Controls.Add(panel2);
            gbIngressi.Controls.Add(lbl_LogocaD3);
            gbIngressi.Controls.Add(lbl_LogocaD2);
            gbIngressi.Controls.Add(lbl_LogocaD1);
            gbIngressi.Controls.Add(lbl_OFF);
            gbIngressi.Controls.Add(lbl_ON);
            gbIngressi.Controls.Add(comboIngressoDigitaleD3);
            gbIngressi.Controls.Add(comboIngressoDigitaleD2);
            gbIngressi.Controls.Add(lbl_IngressoDigitaleNTC2);
            gbIngressi.Controls.Add(lbl_IngressoDigitaleNTC1);
            gbIngressi.Controls.Add(lbl_IngressoDigitaleD3);
            gbIngressi.Controls.Add(lbl_IngressoDigitaleD2);
            gbIngressi.Controls.Add(comboIngressoDigitaleD1);
            gbIngressi.Controls.Add(lbl_IngressoDigitaleD1);
            gbIngressi.Location = new Point(421, 459);
            gbIngressi.Margin = new Padding(4, 3, 4, 3);
            gbIngressi.Name = "gbIngressi";
            gbIngressi.Padding = new Padding(4, 3, 4, 3);
            gbIngressi.Size = new Size(890, 170);
            gbIngressi.TabIndex = 2;
            gbIngressi.TabStop = false;
            gbIngressi.Text = "10 Ingressi";
            // 
            // panel10
            // 
            panel10.Controls.Add(rb_NTC2_SAmbiente);
            panel10.Controls.Add(rb_NTC2_OFF);
            panel10.Controls.Add(rb_NTC2_SMandata);
            panel10.Location = new Point(183, 128);
            panel10.Margin = new Padding(4, 3, 4, 3);
            panel10.Name = "panel10";
            panel10.Size = new Size(379, 27);
            panel10.TabIndex = 50;
            // 
            // rb_NTC2_SAmbiente
            // 
            rb_NTC2_SAmbiente.AutoSize = true;
            rb_NTC2_SAmbiente.CheckAlign = ContentAlignment.MiddleRight;
            rb_NTC2_SAmbiente.Location = new Point(1, 4);
            rb_NTC2_SAmbiente.Margin = new Padding(4, 3, 4, 3);
            rb_NTC2_SAmbiente.Name = "rb_NTC2_SAmbiente";
            rb_NTC2_SAmbiente.Size = new Size(124, 19);
            rb_NTC2_SAmbiente.TabIndex = 44;
            rb_NTC2_SAmbiente.TabStop = true;
            rb_NTC2_SAmbiente.Text = "SONDA AMBIENTE";
            rb_NTC2_SAmbiente.UseVisualStyleBackColor = false;
            // 
            // rb_NTC2_OFF
            // 
            rb_NTC2_OFF.AutoSize = true;
            rb_NTC2_OFF.CheckAlign = ContentAlignment.MiddleRight;
            rb_NTC2_OFF.Location = new Point(320, 3);
            rb_NTC2_OFF.Margin = new Padding(4, 3, 4, 3);
            rb_NTC2_OFF.Name = "rb_NTC2_OFF";
            rb_NTC2_OFF.Size = new Size(46, 19);
            rb_NTC2_OFF.TabIndex = 43;
            rb_NTC2_OFF.TabStop = true;
            rb_NTC2_OFF.Text = "OFF";
            rb_NTC2_OFF.UseVisualStyleBackColor = false;
            // 
            // rb_NTC2_SMandata
            // 
            rb_NTC2_SMandata.AutoSize = true;
            rb_NTC2_SMandata.CheckAlign = ContentAlignment.MiddleRight;
            rb_NTC2_SMandata.Location = new Point(158, 4);
            rb_NTC2_SMandata.Margin = new Padding(4, 3, 4, 3);
            rb_NTC2_SMandata.Name = "rb_NTC2_SMandata";
            rb_NTC2_SMandata.Size = new Size(124, 19);
            rb_NTC2_SMandata.TabIndex = 42;
            rb_NTC2_SMandata.TabStop = true;
            rb_NTC2_SMandata.Text = "SONDA MANDATA";
            rb_NTC2_SMandata.UseVisualStyleBackColor = false;
            // 
            // lbl_Int_IntMandata
            // 
            lbl_Int_IntMandata.Location = new Point(187, 103);
            lbl_Int_IntMandata.Margin = new Padding(4, 0, 4, 0);
            lbl_Int_IntMandata.Name = "lbl_Int_IntMandata";
            lbl_Int_IntMandata.Size = new Size(259, 22);
            lbl_Int_IntMandata.TabIndex = 50;
            lbl_Int_IntMandata.Text = "NTC1";
            lbl_Int_IntMandata.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel8
            // 
            panel8.Controls.Add(rb_NCD3);
            panel8.Controls.Add(rb_NOD3);
            panel8.Location = new Point(694, 78);
            panel8.Margin = new Padding(4, 3, 4, 3);
            panel8.Name = "panel8";
            panel8.Size = new Size(166, 24);
            panel8.TabIndex = 49;
            // 
            // rb_NCD3
            // 
            rb_NCD3.AutoSize = true;
            rb_NCD3.CheckAlign = ContentAlignment.MiddleRight;
            rb_NCD3.Location = new Point(92, 2);
            rb_NCD3.Margin = new Padding(4, 3, 4, 3);
            rb_NCD3.Name = "rb_NCD3";
            rb_NCD3.Size = new Size(41, 19);
            rb_NCD3.TabIndex = 39;
            rb_NCD3.TabStop = true;
            rb_NCD3.Text = "nc.";
            rb_NCD3.UseVisualStyleBackColor = false;
            // 
            // rb_NOD3
            // 
            rb_NOD3.AutoSize = true;
            rb_NOD3.CheckAlign = ContentAlignment.MiddleRight;
            rb_NOD3.Location = new Point(28, 2);
            rb_NOD3.Margin = new Padding(4, 3, 4, 3);
            rb_NOD3.Name = "rb_NOD3";
            rb_NOD3.Size = new Size(42, 19);
            rb_NOD3.TabIndex = 38;
            rb_NOD3.TabStop = true;
            rb_NOD3.Text = "no.";
            rb_NOD3.UseVisualStyleBackColor = false;
            // 
            // panel7
            // 
            panel7.Controls.Add(rb_NCD2);
            panel7.Controls.Add(rb_NOD2);
            panel7.Location = new Point(694, 53);
            panel7.Margin = new Padding(4, 3, 4, 3);
            panel7.Name = "panel7";
            panel7.Size = new Size(166, 24);
            panel7.TabIndex = 48;
            // 
            // rb_NCD2
            // 
            rb_NCD2.AutoSize = true;
            rb_NCD2.CheckAlign = ContentAlignment.MiddleRight;
            rb_NCD2.Location = new Point(92, 2);
            rb_NCD2.Margin = new Padding(4, 3, 4, 3);
            rb_NCD2.Name = "rb_NCD2";
            rb_NCD2.Size = new Size(41, 19);
            rb_NCD2.TabIndex = 37;
            rb_NCD2.TabStop = true;
            rb_NCD2.Text = "nc.";
            rb_NCD2.UseVisualStyleBackColor = false;
            // 
            // rb_NOD2
            // 
            rb_NOD2.AutoSize = true;
            rb_NOD2.CheckAlign = ContentAlignment.MiddleRight;
            rb_NOD2.Location = new Point(28, 2);
            rb_NOD2.Margin = new Padding(4, 3, 4, 3);
            rb_NOD2.Name = "rb_NOD2";
            rb_NOD2.Size = new Size(42, 19);
            rb_NOD2.TabIndex = 36;
            rb_NOD2.TabStop = true;
            rb_NOD2.Text = "no.";
            rb_NOD2.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(rb_NOD1);
            panel1.Controls.Add(rb_NCD1);
            panel1.Location = new Point(694, 28);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(164, 24);
            panel1.TabIndex = 47;
            // 
            // rb_NOD1
            // 
            rb_NOD1.AutoSize = true;
            rb_NOD1.CheckAlign = ContentAlignment.MiddleRight;
            rb_NOD1.Location = new Point(28, 2);
            rb_NOD1.Margin = new Padding(4, 3, 4, 3);
            rb_NOD1.Name = "rb_NOD1";
            rb_NOD1.Size = new Size(42, 19);
            rb_NOD1.TabIndex = 32;
            rb_NOD1.TabStop = true;
            rb_NOD1.Text = "no.";
            rb_NOD1.UseVisualStyleBackColor = false;
            // 
            // rb_NCD1
            // 
            rb_NCD1.AutoSize = true;
            rb_NCD1.CheckAlign = ContentAlignment.MiddleRight;
            rb_NCD1.Location = new Point(92, 2);
            rb_NCD1.Margin = new Padding(4, 3, 4, 3);
            rb_NCD1.Name = "rb_NCD1";
            rb_NCD1.Size = new Size(41, 19);
            rb_NCD1.TabIndex = 33;
            rb_NCD1.TabStop = true;
            rb_NCD1.Text = "nc.";
            rb_NCD1.UseVisualStyleBackColor = false;
            // 
            // panel4
            // 
            panel4.Controls.Add(rb_D3OFF);
            panel4.Controls.Add(rb_D3ON);
            panel4.Location = new Point(495, 78);
            panel4.Margin = new Padding(4, 3, 4, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(68, 27);
            panel4.TabIndex = 46;
            // 
            // rb_D3OFF
            // 
            rb_D3OFF.AutoSize = true;
            rb_D3OFF.CheckAlign = ContentAlignment.MiddleRight;
            rb_D3OFF.Location = new Point(7, 6);
            rb_D3OFF.Margin = new Padding(4, 3, 4, 3);
            rb_D3OFF.Name = "rb_D3OFF";
            rb_D3OFF.Size = new Size(14, 13);
            rb_D3OFF.TabIndex = 24;
            rb_D3OFF.TabStop = true;
            rb_D3OFF.UseVisualStyleBackColor = false;
            // 
            // rb_D3ON
            // 
            rb_D3ON.AutoSize = true;
            rb_D3ON.CheckAlign = ContentAlignment.MiddleRight;
            rb_D3ON.Location = new Point(46, 6);
            rb_D3ON.Margin = new Padding(4, 3, 4, 3);
            rb_D3ON.Name = "rb_D3ON";
            rb_D3ON.Size = new Size(14, 13);
            rb_D3ON.TabIndex = 25;
            rb_D3ON.TabStop = true;
            rb_D3ON.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            panel3.Controls.Add(rb_D2OFF);
            panel3.Controls.Add(rb_D2ON);
            panel3.Location = new Point(495, 53);
            panel3.Margin = new Padding(4, 3, 4, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(68, 27);
            panel3.TabIndex = 46;
            // 
            // rb_D2OFF
            // 
            rb_D2OFF.AutoSize = true;
            rb_D2OFF.CheckAlign = ContentAlignment.MiddleRight;
            rb_D2OFF.Location = new Point(7, 6);
            rb_D2OFF.Margin = new Padding(4, 3, 4, 3);
            rb_D2OFF.Name = "rb_D2OFF";
            rb_D2OFF.Size = new Size(14, 13);
            rb_D2OFF.TabIndex = 22;
            rb_D2OFF.TabStop = true;
            rb_D2OFF.UseVisualStyleBackColor = false;
            // 
            // rb_D2ON
            // 
            rb_D2ON.AutoSize = true;
            rb_D2ON.CheckAlign = ContentAlignment.MiddleRight;
            rb_D2ON.Location = new Point(46, 6);
            rb_D2ON.Margin = new Padding(4, 3, 4, 3);
            rb_D2ON.Name = "rb_D2ON";
            rb_D2ON.Size = new Size(14, 13);
            rb_D2ON.TabIndex = 23;
            rb_D2ON.TabStop = true;
            rb_D2ON.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(rb_D1OFF);
            panel2.Controls.Add(rb_D1ON);
            panel2.Location = new Point(495, 28);
            panel2.Margin = new Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(68, 27);
            panel2.TabIndex = 45;
            // 
            // rb_D1OFF
            // 
            rb_D1OFF.AutoSize = true;
            rb_D1OFF.CheckAlign = ContentAlignment.MiddleRight;
            rb_D1OFF.Location = new Point(7, 6);
            rb_D1OFF.Margin = new Padding(4, 3, 4, 3);
            rb_D1OFF.Name = "rb_D1OFF";
            rb_D1OFF.Size = new Size(14, 13);
            rb_D1OFF.TabIndex = 20;
            rb_D1OFF.TabStop = true;
            rb_D1OFF.UseVisualStyleBackColor = false;
            // 
            // rb_D1ON
            // 
            rb_D1ON.AutoSize = true;
            rb_D1ON.CheckAlign = ContentAlignment.MiddleRight;
            rb_D1ON.Location = new Point(46, 6);
            rb_D1ON.Margin = new Padding(4, 3, 4, 3);
            rb_D1ON.Name = "rb_D1ON";
            rb_D1ON.Size = new Size(14, 13);
            rb_D1ON.TabIndex = 21;
            rb_D1ON.TabStop = true;
            rb_D1ON.UseVisualStyleBackColor = false;
            // 
            // lbl_LogocaD3
            // 
            lbl_LogocaD3.AutoSize = true;
            lbl_LogocaD3.Location = new Point(595, 80);
            lbl_LogocaD3.Margin = new Padding(4, 0, 4, 0);
            lbl_LogocaD3.Name = "lbl_LogocaD3";
            lbl_LogocaD3.Size = new Size(90, 15);
            lbl_LogocaD3.TabIndex = 30;
            lbl_LogocaD3.Text = "Funzionamento";
            // 
            // lbl_LogocaD2
            // 
            lbl_LogocaD2.AutoSize = true;
            lbl_LogocaD2.Location = new Point(595, 55);
            lbl_LogocaD2.Margin = new Padding(4, 0, 4, 0);
            lbl_LogocaD2.Name = "lbl_LogocaD2";
            lbl_LogocaD2.Size = new Size(90, 15);
            lbl_LogocaD2.TabIndex = 29;
            lbl_LogocaD2.Text = "Funzionamento";
            // 
            // lbl_LogocaD1
            // 
            lbl_LogocaD1.AutoSize = true;
            lbl_LogocaD1.Location = new Point(595, 30);
            lbl_LogocaD1.Margin = new Padding(4, 0, 4, 0);
            lbl_LogocaD1.Name = "lbl_LogocaD1";
            lbl_LogocaD1.Size = new Size(90, 15);
            lbl_LogocaD1.TabIndex = 28;
            lbl_LogocaD1.Text = "Funzionamento";
            // 
            // lbl_OFF
            // 
            lbl_OFF.AutoSize = true;
            lbl_OFF.Location = new Point(491, 12);
            lbl_OFF.Margin = new Padding(4, 0, 4, 0);
            lbl_OFF.Name = "lbl_OFF";
            lbl_OFF.Size = new Size(28, 15);
            lbl_OFF.TabIndex = 11;
            lbl_OFF.Text = "OFF";
            // 
            // lbl_ON
            // 
            lbl_ON.AutoSize = true;
            lbl_ON.Location = new Point(530, 12);
            lbl_ON.Margin = new Padding(4, 0, 4, 0);
            lbl_ON.Name = "lbl_ON";
            lbl_ON.Size = new Size(25, 15);
            lbl_ON.TabIndex = 10;
            lbl_ON.Text = "ON";
            // 
            // comboIngressoDigitaleD3
            // 
            comboIngressoDigitaleD3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboIngressoDigitaleD3.FormattingEnabled = true;
            comboIngressoDigitaleD3.Location = new Point(183, 78);
            comboIngressoDigitaleD3.Margin = new Padding(4, 3, 4, 3);
            comboIngressoDigitaleD3.Name = "comboIngressoDigitaleD3";
            comboIngressoDigitaleD3.Size = new Size(262, 23);
            comboIngressoDigitaleD3.TabIndex = 7;
            // 
            // comboIngressoDigitaleD2
            // 
            comboIngressoDigitaleD2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboIngressoDigitaleD2.FormattingEnabled = true;
            comboIngressoDigitaleD2.Location = new Point(183, 53);
            comboIngressoDigitaleD2.Margin = new Padding(4, 3, 4, 3);
            comboIngressoDigitaleD2.Name = "comboIngressoDigitaleD2";
            comboIngressoDigitaleD2.Size = new Size(262, 23);
            comboIngressoDigitaleD2.TabIndex = 6;
            // 
            // lbl_IngressoDigitaleNTC2
            // 
            lbl_IngressoDigitaleNTC2.AutoSize = true;
            lbl_IngressoDigitaleNTC2.Location = new Point(13, 130);
            lbl_IngressoDigitaleNTC2.Margin = new Padding(4, 0, 4, 0);
            lbl_IngressoDigitaleNTC2.Name = "lbl_IngressoDigitaleNTC2";
            lbl_IngressoDigitaleNTC2.Size = new Size(35, 15);
            lbl_IngressoDigitaleNTC2.TabIndex = 5;
            lbl_IngressoDigitaleNTC2.Text = "NTC2";
            // 
            // lbl_IngressoDigitaleNTC1
            // 
            lbl_IngressoDigitaleNTC1.AutoSize = true;
            lbl_IngressoDigitaleNTC1.Location = new Point(13, 105);
            lbl_IngressoDigitaleNTC1.Margin = new Padding(4, 0, 4, 0);
            lbl_IngressoDigitaleNTC1.Name = "lbl_IngressoDigitaleNTC1";
            lbl_IngressoDigitaleNTC1.Size = new Size(35, 15);
            lbl_IngressoDigitaleNTC1.TabIndex = 4;
            lbl_IngressoDigitaleNTC1.Text = "NTC1";
            // 
            // lbl_IngressoDigitaleD3
            // 
            lbl_IngressoDigitaleD3.AutoSize = true;
            lbl_IngressoDigitaleD3.Location = new Point(13, 80);
            lbl_IngressoDigitaleD3.Margin = new Padding(4, 0, 4, 0);
            lbl_IngressoDigitaleD3.Name = "lbl_IngressoDigitaleD3";
            lbl_IngressoDigitaleD3.Size = new Size(21, 15);
            lbl_IngressoDigitaleD3.TabIndex = 3;
            lbl_IngressoDigitaleD3.Text = "D3";
            // 
            // lbl_IngressoDigitaleD2
            // 
            lbl_IngressoDigitaleD2.AutoSize = true;
            lbl_IngressoDigitaleD2.Location = new Point(13, 55);
            lbl_IngressoDigitaleD2.Margin = new Padding(4, 0, 4, 0);
            lbl_IngressoDigitaleD2.Name = "lbl_IngressoDigitaleD2";
            lbl_IngressoDigitaleD2.Size = new Size(21, 15);
            lbl_IngressoDigitaleD2.TabIndex = 2;
            lbl_IngressoDigitaleD2.Text = "D2";
            // 
            // comboIngressoDigitaleD1
            // 
            comboIngressoDigitaleD1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboIngressoDigitaleD1.FormattingEnabled = true;
            comboIngressoDigitaleD1.Location = new Point(183, 28);
            comboIngressoDigitaleD1.Margin = new Padding(4, 3, 4, 3);
            comboIngressoDigitaleD1.Name = "comboIngressoDigitaleD1";
            comboIngressoDigitaleD1.Size = new Size(262, 23);
            comboIngressoDigitaleD1.TabIndex = 1;
            // 
            // lbl_IngressoDigitaleD1
            // 
            lbl_IngressoDigitaleD1.AutoSize = true;
            lbl_IngressoDigitaleD1.Location = new Point(13, 30);
            lbl_IngressoDigitaleD1.Margin = new Padding(4, 0, 4, 0);
            lbl_IngressoDigitaleD1.Name = "lbl_IngressoDigitaleD1";
            lbl_IngressoDigitaleD1.Size = new Size(21, 15);
            lbl_IngressoDigitaleD1.TabIndex = 0;
            lbl_IngressoDigitaleD1.Text = "D1";
            // 
            // gbIntensitaLED
            // 
            gbIntensitaLED.Controls.Add(nud_IntensitaLED);
            gbIntensitaLED.Controls.Add(lblIntensitaLED);
            gbIntensitaLED.Location = new Point(8, 564);
            gbIntensitaLED.Margin = new Padding(4, 3, 4, 3);
            gbIntensitaLED.Name = "gbIntensitaLED";
            gbIntensitaLED.Padding = new Padding(4, 3, 4, 3);
            gbIntensitaLED.Size = new Size(407, 46);
            gbIntensitaLED.TabIndex = 21;
            gbIntensitaLED.TabStop = false;
            gbIntensitaLED.Text = "11 gestione LED";
            gbIntensitaLED.Enter += groupBox1_Enter;
            // 
            // nud_IntensitaLED
            // 
            nud_IntensitaLED.Location = new Point(316, 18);
            nud_IntensitaLED.Margin = new Padding(4, 3, 4, 3);
            nud_IntensitaLED.Name = "nud_IntensitaLED";
            nud_IntensitaLED.Size = new Size(66, 23);
            nud_IntensitaLED.TabIndex = 3;
            // 
            // lblIntensitaLED
            // 
            lblIntensitaLED.AutoSize = true;
            lblIntensitaLED.Location = new Point(13, 20);
            lblIntensitaLED.Margin = new Padding(4, 0, 4, 0);
            lblIntensitaLED.Name = "lblIntensitaLED";
            lblIntensitaLED.Size = new Size(92, 15);
            lblIntensitaLED.TabIndex = 0;
            lblIntensitaLED.Text = "Luminosita' LED";
            lblIntensitaLED.Click += lblIntensitaLED_Click;
            // 
            // timerRxDati
            // 
            timerRxDati.Enabled = true;
            timerRxDati.Interval = 1;
            timerRxDati.Tick += timerRxDati_Tick;
            // 
            // labelFondo
            // 
            labelFondo.BackColor = SystemColors.MenuText;
            labelFondo.Font = new Font("Microsoft Sans Serif", 14.25F);
            labelFondo.ForeColor = Color.White;
            labelFondo.Location = new Point(293, 706);
            labelFondo.Margin = new Padding(4, 0, 4, 0);
            labelFondo.Name = "labelFondo";
            labelFondo.Size = new Size(674, 27);
            labelFondo.TabIndex = 19;
            labelFondo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelIndice
            // 
            labelIndice.BackColor = Color.Lime;
            labelIndice.Font = new Font("Microsoft Sans Serif", 14.25F);
            labelIndice.Location = new Point(306, 694);
            labelIndice.Margin = new Padding(4, 0, 4, 0);
            labelIndice.Name = "labelIndice";
            labelIndice.Size = new Size(674, 54);
            labelIndice.TabIndex = 23;
            labelIndice.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelPleaseWait
            // 
            labelPleaseWait.BackColor = Color.Transparent;
            labelPleaseWait.Font = new Font("Microsoft Sans Serif", 14.25F);
            labelPleaseWait.ForeColor = Color.Black;
            labelPleaseWait.Location = new Point(21, 708);
            labelPleaseWait.Margin = new Padding(4, 0, 4, 0);
            labelPleaseWait.Name = "labelPleaseWait";
            labelPleaseWait.Size = new Size(674, 27);
            labelPleaseWait.TabIndex = 24;
            labelPleaseWait.Text = "aaa";
            labelPleaseWait.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fILEToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 2, 0, 2);
            menuStrip1.Size = new Size(1376, 24);
            menuStrip1.TabIndex = 25;
            menuStrip1.Text = "menuStrip1";
            // 
            // fILEToolStripMenuItem
            // 
            fILEToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem, salvaToolStripMenuItem, salvaComeToolStripMenuItem, esciToolStripMenuItem });
            fILEToolStripMenuItem.Name = "fILEToolStripMenuItem";
            fILEToolStripMenuItem.Size = new Size(40, 20);
            fILEToolStripMenuItem.Text = "FILE";
            fILEToolStripMenuItem.Click += fILEToolStripMenuItem_Click;
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(134, 22);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // salvaToolStripMenuItem
            // 
            salvaToolStripMenuItem.Name = "salvaToolStripMenuItem";
            salvaToolStripMenuItem.Size = new Size(134, 22);
            salvaToolStripMenuItem.Text = "Salva";
            salvaToolStripMenuItem.Click += salvaToolStripMenuItem_Click;
            // 
            // salvaComeToolStripMenuItem
            // 
            salvaComeToolStripMenuItem.Name = "salvaComeToolStripMenuItem";
            salvaComeToolStripMenuItem.Size = new Size(134, 22);
            salvaComeToolStripMenuItem.Text = "Salva come";
            salvaComeToolStripMenuItem.Click += salvaComeToolStripMenuItem_Click;
            // 
            // esciToolStripMenuItem
            // 
            esciToolStripMenuItem.Name = "esciToolStripMenuItem";
            esciToolStripMenuItem.Size = new Size(134, 22);
            esciToolStripMenuItem.Text = "Esci";
            esciToolStripMenuItem.Click += esciToolStripMenuItem_Click;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPage1);
            tabControl.Controls.Add(tabPage2);
            tabControl.Location = new Point(13, 27);
            tabControl.Margin = new Padding(4, 3, 4, 3);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1344, 664);
            tabControl.TabIndex = 26;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(gbFunzionamentoCassetta);
            tabPage1.Controls.Add(gbIntensitaLED);
            tabPage1.Controls.Add(gbIngressi);
            tabPage1.Controls.Add(gbRiepilogoRiscaldamento);
            tabPage1.Controls.Add(gbGestionePortata);
            tabPage1.Controls.Add(gbMaxPotenzaResistenzaFunzPortata);
            tabPage1.Controls.Add(gbGestioneModalitaEconomy);
            tabPage1.Controls.Add(gbImpostazioneRegolazioneAmbiente);
            tabPage1.Controls.Add(gbRegolazioneSerranda);
            tabPage1.Controls.Add(gbGestioneTemperaturaInterna);
            tabPage1.Controls.Add(gbLimitiTemperaturaMandata);
            tabPage1.Controls.Add(gbGeometriaCassetta);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Margin = new Padding(4, 3, 4, 3);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(4, 3, 4, 3);
            tabPage1.Size = new Size(1336, 636);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Impostazioni";
            tabPage1.UseVisualStyleBackColor = true;
            tabPage1.Click += tabPage1_Click;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(gb_14_impPrinc);
            tabPage2.Controls.Add(gb_13_impMODBUS);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Margin = new Padding(4, 3, 4, 3);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(4, 3, 4, 3);
            tabPage2.Size = new Size(1336, 636);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Impostazioni MODBUS";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // gb_14_impPrinc
            // 
            gb_14_impPrinc.Controls.Add(lbl_14_00);
            gb_14_impPrinc.Controls.Add(panel21);
            gb_14_impPrinc.Location = new Point(444, 459);
            gb_14_impPrinc.Margin = new Padding(4, 3, 4, 3);
            gb_14_impPrinc.Name = "gb_14_impPrinc";
            gb_14_impPrinc.Padding = new Padding(4, 3, 4, 3);
            gb_14_impPrinc.Size = new Size(446, 106);
            gb_14_impPrinc.TabIndex = 77;
            gb_14_impPrinc.TabStop = false;
            gb_14_impPrinc.Text = "Impostazione CASSETTA";
            gb_14_impPrinc.Visible = false;
            // 
            // lbl_14_00
            // 
            lbl_14_00.AutoSize = true;
            lbl_14_00.Location = new Point(13, 45);
            lbl_14_00.Margin = new Padding(4, 0, 4, 0);
            lbl_14_00.Name = "lbl_14_00";
            lbl_14_00.Size = new Size(81, 15);
            lbl_14_00.TabIndex = 73;
            lbl_14_00.Text = "Tipo FANCOIL";
            // 
            // panel21
            // 
            panel21.Controls.Add(rb_14_00_sec);
            panel21.Controls.Add(rb_14_00_princ);
            panel21.Location = new Point(139, 37);
            panel21.Margin = new Padding(4, 3, 4, 3);
            panel21.Name = "panel21";
            panel21.Size = new Size(281, 29);
            panel21.TabIndex = 70;
            // 
            // rb_14_00_sec
            // 
            rb_14_00_sec.AutoSize = true;
            rb_14_00_sec.Location = new Point(160, 6);
            rb_14_00_sec.Margin = new Padding(4, 3, 4, 3);
            rb_14_00_sec.Name = "rb_14_00_sec";
            rb_14_00_sec.Size = new Size(98, 19);
            rb_14_00_sec.TabIndex = 1;
            rb_14_00_sec.TabStop = true;
            rb_14_00_sec.Text = "SECONDARIO";
            rb_14_00_sec.UseVisualStyleBackColor = true;
            rb_14_00_sec.CheckedChanged += rb_14_00_sec_CheckedChanged;
            // 
            // rb_14_00_princ
            // 
            rb_14_00_princ.AutoSize = true;
            rb_14_00_princ.Location = new Point(30, 6);
            rb_14_00_princ.Margin = new Padding(4, 3, 4, 3);
            rb_14_00_princ.Name = "rb_14_00_princ";
            rb_14_00_princ.Size = new Size(88, 19);
            rb_14_00_princ.TabIndex = 0;
            rb_14_00_princ.TabStop = true;
            rb_14_00_princ.Text = "PRINCIPALE";
            rb_14_00_princ.UseVisualStyleBackColor = true;
            // 
            // gb_13_impMODBUS
            // 
            gb_13_impMODBUS.Controls.Add(cb_13_04_StopBit);
            gb_13_impMODBUS.Controls.Add(lbl_13_00_TipDisp);
            gb_13_impMODBUS.Controls.Add(panel20);
            gb_13_impMODBUS.Controls.Add(cb_13_03_Parita);
            gb_13_impMODBUS.Controls.Add(cb_13_02_Baudrate);
            gb_13_impMODBUS.Controls.Add(nud_13_01_Indirizzo);
            gb_13_impMODBUS.Controls.Add(lbl_13_04_StopBit);
            gb_13_impMODBUS.Controls.Add(lbl_13_03_Parita);
            gb_13_impMODBUS.Controls.Add(lbl_13_01_Indirizzo);
            gb_13_impMODBUS.Controls.Add(lbl_13_02_Baudrate);
            gb_13_impMODBUS.Location = new Point(444, 230);
            gb_13_impMODBUS.Margin = new Padding(4, 3, 4, 3);
            gb_13_impMODBUS.Name = "gb_13_impMODBUS";
            gb_13_impMODBUS.Padding = new Padding(4, 3, 4, 3);
            gb_13_impMODBUS.Size = new Size(446, 208);
            gb_13_impMODBUS.TabIndex = 76;
            gb_13_impMODBUS.TabStop = false;
            gb_13_impMODBUS.Text = "Impostazione rete";
            // 
            // cb_13_04_StopBit
            // 
            cb_13_04_StopBit.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_13_04_StopBit.FormattingEnabled = true;
            cb_13_04_StopBit.Location = new Point(312, 173);
            cb_13_04_StopBit.Margin = new Padding(4, 3, 4, 3);
            cb_13_04_StopBit.Name = "cb_13_04_StopBit";
            cb_13_04_StopBit.Size = new Size(108, 23);
            cb_13_04_StopBit.TabIndex = 74;
            // 
            // lbl_13_00_TipDisp
            // 
            lbl_13_00_TipDisp.AutoSize = true;
            lbl_13_00_TipDisp.Location = new Point(13, 45);
            lbl_13_00_TipDisp.Margin = new Padding(4, 0, 4, 0);
            lbl_13_00_TipDisp.Name = "lbl_13_00_TipDisp";
            lbl_13_00_TipDisp.Size = new Size(116, 15);
            lbl_13_00_TipDisp.TabIndex = 73;
            lbl_13_00_TipDisp.Text = "Tipologia dispositivo";
            // 
            // panel20
            // 
            panel20.Controls.Add(rb_13_00_TipDisp_SLAVE);
            panel20.Controls.Add(rb_13_00_TipDisp_MASTER);
            panel20.Location = new Point(139, 37);
            panel20.Margin = new Padding(4, 3, 4, 3);
            panel20.Name = "panel20";
            panel20.Size = new Size(281, 29);
            panel20.TabIndex = 70;
            // 
            // rb_13_00_TipDisp_SLAVE
            // 
            rb_13_00_TipDisp_SLAVE.AutoSize = true;
            rb_13_00_TipDisp_SLAVE.Location = new Point(194, 6);
            rb_13_00_TipDisp_SLAVE.Margin = new Padding(4, 3, 4, 3);
            rb_13_00_TipDisp_SLAVE.Name = "rb_13_00_TipDisp_SLAVE";
            rb_13_00_TipDisp_SLAVE.Size = new Size(57, 19);
            rb_13_00_TipDisp_SLAVE.TabIndex = 1;
            rb_13_00_TipDisp_SLAVE.TabStop = true;
            rb_13_00_TipDisp_SLAVE.Text = "SLAVE";
            rb_13_00_TipDisp_SLAVE.UseVisualStyleBackColor = true;
            rb_13_00_TipDisp_SLAVE.CheckedChanged += rb_13_00_TipDisp_SLAVE_CheckedChanged;
            // 
            // rb_13_00_TipDisp_MASTER
            // 
            rb_13_00_TipDisp_MASTER.AutoSize = true;
            rb_13_00_TipDisp_MASTER.Location = new Point(30, 6);
            rb_13_00_TipDisp_MASTER.Margin = new Padding(4, 3, 4, 3);
            rb_13_00_TipDisp_MASTER.Name = "rb_13_00_TipDisp_MASTER";
            rb_13_00_TipDisp_MASTER.Size = new Size(69, 19);
            rb_13_00_TipDisp_MASTER.TabIndex = 0;
            rb_13_00_TipDisp_MASTER.TabStop = true;
            rb_13_00_TipDisp_MASTER.Text = "MASTER";
            rb_13_00_TipDisp_MASTER.UseVisualStyleBackColor = true;
            rb_13_00_TipDisp_MASTER.CheckedChanged += rb_13_00_TipDisp_MASTER_CheckedChanged;
            // 
            // cb_13_03_Parita
            // 
            cb_13_03_Parita.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_13_03_Parita.FormattingEnabled = true;
            cb_13_03_Parita.Location = new Point(312, 140);
            cb_13_03_Parita.Margin = new Padding(4, 3, 4, 3);
            cb_13_03_Parita.Name = "cb_13_03_Parita";
            cb_13_03_Parita.Size = new Size(108, 23);
            cb_13_03_Parita.TabIndex = 69;
            // 
            // cb_13_02_Baudrate
            // 
            cb_13_02_Baudrate.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_13_02_Baudrate.FormattingEnabled = true;
            cb_13_02_Baudrate.Location = new Point(312, 106);
            cb_13_02_Baudrate.Margin = new Padding(4, 3, 4, 3);
            cb_13_02_Baudrate.Name = "cb_13_02_Baudrate";
            cb_13_02_Baudrate.Size = new Size(108, 23);
            cb_13_02_Baudrate.TabIndex = 68;
            // 
            // nud_13_01_Indirizzo
            // 
            nud_13_01_Indirizzo.Location = new Point(357, 74);
            nud_13_01_Indirizzo.Margin = new Padding(4, 3, 4, 3);
            nud_13_01_Indirizzo.Name = "nud_13_01_Indirizzo";
            nud_13_01_Indirizzo.Size = new Size(63, 23);
            nud_13_01_Indirizzo.TabIndex = 61;
            // 
            // lbl_13_04_StopBit
            // 
            lbl_13_04_StopBit.AutoSize = true;
            lbl_13_04_StopBit.Location = new Point(13, 172);
            lbl_13_04_StopBit.Margin = new Padding(4, 0, 4, 0);
            lbl_13_04_StopBit.Name = "lbl_13_04_StopBit";
            lbl_13_04_StopBit.Size = new Size(47, 15);
            lbl_13_04_StopBit.TabIndex = 59;
            lbl_13_04_StopBit.Text = "Bit stop";
            // 
            // lbl_13_03_Parita
            // 
            lbl_13_03_Parita.AutoSize = true;
            lbl_13_03_Parita.Location = new Point(13, 144);
            lbl_13_03_Parita.Margin = new Padding(4, 0, 4, 0);
            lbl_13_03_Parita.Name = "lbl_13_03_Parita";
            lbl_13_03_Parita.Size = new Size(37, 15);
            lbl_13_03_Parita.TabIndex = 4;
            lbl_13_03_Parita.Text = "Parità";
            // 
            // lbl_13_01_Indirizzo
            // 
            lbl_13_01_Indirizzo.AutoSize = true;
            lbl_13_01_Indirizzo.Location = new Point(13, 76);
            lbl_13_01_Indirizzo.Margin = new Padding(4, 0, 4, 0);
            lbl_13_01_Indirizzo.Name = "lbl_13_01_Indirizzo";
            lbl_13_01_Indirizzo.Size = new Size(51, 15);
            lbl_13_01_Indirizzo.TabIndex = 1;
            lbl_13_01_Indirizzo.Text = "Indirizzo";
            // 
            // lbl_13_02_Baudrate
            // 
            lbl_13_02_Baudrate.AutoSize = true;
            lbl_13_02_Baudrate.Location = new Point(13, 111);
            lbl_13_02_Baudrate.Margin = new Padding(4, 0, 4, 0);
            lbl_13_02_Baudrate.Name = "lbl_13_02_Baudrate";
            lbl_13_02_Baudrate.Size = new Size(54, 15);
            lbl_13_02_Baudrate.TabIndex = 0;
            lbl_13_02_Baudrate.Text = "Baudrate";
            // 
            // timerTick
            // 
            timerTick.Tick += timerTick_Tick;
            // 
            // systemTimer
            // 
            systemTimer.Enabled = true;
            systemTimer.Interval = 500;
            systemTimer.Tick += systemTimer_Tick;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmCassette
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(1376, 687);
            Controls.Add(tabControl);
            Controls.Add(menuStrip1);
            Controls.Add(labelPleaseWait);
            Controls.Add(labelIndice);
            Controls.Add(labelFondo);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmCassette";
            Text = "Roccheggiani";
            FormClosing += frmCassette_FormClosing;
            Load += frmCassette_Load;
            gbFunzionamentoCassetta.ResumeLayout(false);
            gbFunzionamentoCassetta.PerformLayout();
            gbRiepilogoRiscaldamento.ResumeLayout(false);
            gbRiepilogoRiscaldamento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nud_PotenzaNominaleResistenza).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_MassimoDutyCycle).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_MinimoDutyCycle).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_PeriofoModulazionePWM).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_KIRegolazioneRiscaldamento).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_BandaDiregolazione).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_ZonaMortaRiscaldamento).EndInit();
            gbMaxPotenzaResistenzaFunzPortata.ResumeLayout(false);
            gbMaxPotenzaResistenzaFunzPortata.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nud_TempAriaPrimaria).EndInit();
            gbImpostazioneRegolazioneAmbiente.ResumeLayout(false);
            gbImpostazioneRegolazioneAmbiente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nud_IncZMEconomy).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_SetPointDefault).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_deviazMaxSetpoint).EndInit();
            gbGestioneTemperaturaInterna.ResumeLayout(false);
            gbGestioneTemperaturaInterna.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nud_IsteresiSecondaSoglia).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_SecondaSogliaOFFResitenza).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_PrimaSogliaOFFResitenza).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud__IsteresiPrimaSoglia).EndInit();
            gbGeometriaCassetta.ResumeLayout(false);
            gbGeometriaCassetta.PerformLayout();
            gbLimitiTemperaturaMandata.ResumeLayout(false);
            gbLimitiTemperaturaMandata.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nud_SetpointLimiteMassimoHLSP).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_BandaRegolazioneLimiti).EndInit();
            gbRegolazioneSerranda.ResumeLayout(false);
            gbRegolazioneSerranda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nud_TensioneSerrandaMassima).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_TensioneSerrandaMinima).EndInit();
            panel11.ResumeLayout(false);
            panel11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nud_AperturaserrandaMassima).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_AperturaSerrandaMinima).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_KIRegolazioneSerranda).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_BandaDiRegolazioneSerranda).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_ZonaMortaSerrandaDDZ).EndInit();
            gbGestioneModalitaEconomy.ResumeLayout(false);
            gbGestioneModalitaEconomy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nud_TastoEconomyRiduzione).EndInit();
            gbGestionePortata.ResumeLayout(false);
            gbGestionePortata.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nud_KApertura_90_100).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_KApertura_80_90).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_KApertura_70_80).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_KApertura_60_70).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_KApertura_50_60).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_KApertura_40_50).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_KApertura_30_40).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_KApertura_20_30).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_KApertura_10_20).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_TempoLetturaSensore).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_OffsetMisurazioneDiPortata).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_SezionePerMisiurazPortata).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_PortataMinimaSicurezza).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_PortataMassima).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_PortataMinima).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_KApertura_0_10).EndInit();
            gbIngressi.ResumeLayout(false);
            gbIngressi.PerformLayout();
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            gbIntensitaLED.ResumeLayout(false);
            gbIntensitaLED.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nud_IntensitaLED).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tabControl.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            gb_14_impPrinc.ResumeLayout(false);
            gb_14_impPrinc.PerformLayout();
            panel21.ResumeLayout(false);
            panel21.PerformLayout();
            gb_13_impMODBUS.ResumeLayout(false);
            gb_13_impMODBUS.PerformLayout();
            panel20.ResumeLayout(false);
            panel20.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nud_13_01_Indirizzo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private GroupBox gbFunzionamentoCassetta;
        private ComboBox comboFunzionamento;
        private Label lbl_Funzionamento;
        private GroupBox gbRiepilogoRiscaldamento;
        private Label lbl_ZomaMortaRiscaldamento;
        private Label lbl_PresenzaResistenza;
        private NumericUpDown nud_PotenzaNominaleResistenza;
        private Label lbl_PotenzaNominaleResistenza;
        private NumericUpDown nud_MassimoDutyCycle;
        private Label lbl_MassimoDutyCycle;
        private NumericUpDown nud_MinimoDutyCycle;
        private Label lbl_MinimoDutyCycle;
        private NumericUpDown nud_PeriofoModulazionePWM;
        private Label lbl_PeriodoModulazionePWM;
        private NumericUpDown nud_KIRegolazioneRiscaldamento;
        private Label lbl_KIRegolazioneRiscaldamento;
        private NumericUpDown nud_BandaDiregolazione;
        private Label lbl_BandaDiregolazione;
        private NumericUpDown nud_ZonaMortaRiscaldamento;
        private RadioButton rb_PresenzaResistenzaOFF;
        private RadioButton rb_PresenzaResistenzaON;
        private GroupBox gbMaxPotenzaResistenzaFunzPortata;
        private RadioButton rb_LimPotMaxResistenzaON;
        private RadioButton rb_LimPotMaxResistenzaOFF;
        private Label lbl_LimPotMaxResistenza;
        private NumericUpDown nud_TempAriaPrimaria;
        private Label lbl_TenpAriaPrimaria;
        private GroupBox gbImpostazioneRegolazioneAmbiente;
        private NumericUpDown nud_SetPointDefault;
        private Label lbl_SetPointDefault;
        private NumericUpDown nud_deviazMaxSetpoint;
        private Label lbl_deviazMaxSetpoint;
        private NumericUpDown nud_IncZMEconomy;
        private Label lbl_IncZMEconomy;
        private GroupBox gbGestioneTemperaturaInterna;
        private NumericUpDown nud_IsteresiSecondaSoglia;
        private Label lbl_IsteresiSecondaSoglia;
        private NumericUpDown nud_SecondaSogliaOFFResitenza;
        private Label lbl_SecondaSogliaOFFResitenza;
        private NumericUpDown nud_PrimaSogliaOFFResitenza;
        private Label lbl_PrimaSogliaOFFResitenza;
        private NumericUpDown nud__IsteresiPrimaSoglia;
        private Label lbl_IsteresiPrimaSoglia;
        private GroupBox gbGeometriaCassetta;
        private ComboBox comboDiffusione;
        private Label lbl_Diffusione;
        private GroupBox gbLimitiTemperaturaMandata;
        private NumericUpDown nud_SetpointLimiteMassimoHLSP;
        private Label lbl_SetpointLimiteMassimoHLSP;
        private NumericUpDown nud_BandaRegolazioneLimiti;
        private Label lbl_BandaRegolazioneLimiti;
        private GroupBox gbRegolazioneSerranda;
        private RadioButton rb_PresenzaSerrandaON;
        private RadioButton rb_PresenzaSerrandaOFF;
        private Label lbl_PresenzaSerranda;
        private NumericUpDown nud_AperturaserrandaMassima;
        private Label lbl_AperturaserrandaMassima;
        private NumericUpDown nud_AperturaSerrandaMinima;
        private Label lbl_AperturaSerrandaMinima;
        private NumericUpDown nud_KIRegolazioneSerranda;
        private Label lbl_KIRegolazioneSerranda;
        private NumericUpDown nud_BandaDiRegolazioneSerranda;
        private Label lbl_BandaDiRegolazioneSerranda;
        private NumericUpDown nud_ZonaMortaSerrandaDDZ;
        private Label lbl_ZonaMortaSerrandaDDZ;
        private GroupBox gbGestioneModalitaEconomy;
        private ComboBox comboTipoEcomomy;
        private Label lbl_TipoEconomy;
        private NumericUpDown nud_TastoEconomyRiduzione;
        private Label lbl_TastoEconomyRiduzione;
        private GroupBox gbGestionePortata;
        private RadioButton rb_AbilitaDisabilitaPortataIstantaneaON;
        private RadioButton rb_AbilitaDisabilitaPortataIstantaneaOFF;
        private Label lbl_AbilitaDisabilitaPortataIstantanea;
        private NumericUpDown nud_TempoLetturaSensore;
        private Label lbl_TempoLetturaSensore;
        private NumericUpDown nud_OffsetMisurazioneDiPortata;
        private Label lbl_OffsetMisurazioneDiPortata;
        private NumericUpDown nud_SezionePerMisiurazPortata;
        private Label lbl_SezionePerMisiurazPortata;
        private NumericUpDown nud_PortataMinimaSicurezza;
        private Label lbl_PortataMinimaSicurezza;
        private NumericUpDown nud_PortataMassima;
        private Label lbl_PortataMassima;
        private NumericUpDown nud_PortataMinima;
        private Label lbl_PortataMinima;
        private NumericUpDown nud_KApertura_0_10;
        private Label lbl_KApertura_0_10;
        private NumericUpDown nud_KApertura_90_100;
        private Label lbl_KApertura_90_100;
        private NumericUpDown nud_KApertura_80_90;
        private Label lbl_KApertura_80_90;
        private NumericUpDown nud_KApertura_70_80;
        private Label lbl_KApertura_70_80;
        private NumericUpDown nud_KApertura_60_70;
        private Label lbl_KApertura_60_70;
        private NumericUpDown nud_KApertura_50_60;
        private Label lbl_KApertura_50_60;
        private NumericUpDown nud_KApertura_40_50;
        private Label lbl_KApertura_40_50;
        private NumericUpDown nud_KApertura_30_40;
        private Label lbl_KApertura_30_40;
        private NumericUpDown nud_KApertura_20_30;
        private Label lbl_KApertura_20_30;
        private NumericUpDown nud_KApertura_10_20;
        private Label lbl_KApertura_10_20;
        private GroupBox gbIngressi;
        private RadioButton rb_NCD1;
        private RadioButton rb_NOD1;
        private Label lbl_LogocaD3;
        private Label lbl_LogocaD2;
        private Label lbl_LogocaD1;
        private Label lbl_OFF;
        private Label lbl_ON;
        private ComboBox comboIngressoDigitaleD3;
        private ComboBox comboIngressoDigitaleD2;
        private Label lbl_IngressoDigitaleNTC2;
        private Label lbl_IngressoDigitaleNTC1;
        private Label lbl_IngressoDigitaleD3;
        private Label lbl_IngressoDigitaleD2;
        private ComboBox comboIngressoDigitaleD1;
        private Label lbl_IngressoDigitaleD1;
        private Label lbl_PortataMinimaSicurezzaLS;
        private Label lbl_PortataMassimaLS;
        private Label lbl_PortataMinimaLS;
        private RadioButton rb_LogicaInv;
        private RadioButton rb_LogicaDir;
        private Label lbl_LogicaFunzSerranda;
        private Panel panel4;
        private RadioButton rb_D3OFF;
        private RadioButton rb_D3ON;
        private Panel panel3;
        private RadioButton rb_D2OFF;
        private RadioButton rb_D2ON;
        private Panel panel2;
        private RadioButton rb_D1OFF;
        private RadioButton rb_D1ON;
        private Panel panel8;
        private RadioButton rb_NCD3;
        private RadioButton rb_NOD3;
        private Panel panel7;
        private RadioButton rb_NCD2;
        private RadioButton rb_NOD2;
        private Panel panel1;
        private GroupBox gbIntensitaLED;
        private NumericUpDown nud_IntensitaLED;
        private Label lblIntensitaLED;
        private System.Windows.Forms.Timer timerRxDati;
        private Label labelFondo;
        private Label labelIndice;
        private Label lbl_Int_IntMandata;
        private Panel panel11;
        private Panel panel10;
        private RadioButton rb_NTC2_SAmbiente;
        private RadioButton rb_NTC2_OFF;
        private RadioButton rb_NTC2_SMandata;
        private Label labelPleaseWait;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fILEToolStripMenuItem;
        private ToolStripMenuItem salvaToolStripMenuItem;
        private ToolStripMenuItem salvaComeToolStripMenuItem;
        private ToolStripMenuItem esciToolStripMenuItem;
        private SaveFileDialog saveFileDialog1;
        private NumericUpDown nud_TensioneSerrandaMassima;
        private Label lbl_TensioneSerrandaMassima;
        private NumericUpDown nud_TensioneSerrandaMinima;
        private Label lbl_TensioneSerrandaMinima;
        private TabControl tabControl;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private GroupBox gb_14_impPrinc;
        private Label lbl_14_00;
        private Panel panel21;
        private RadioButton rb_14_00_sec;
        private RadioButton rb_14_00_princ;
        private GroupBox gb_13_impMODBUS;
        private ComboBox cb_13_04_StopBit;
        private Label lbl_13_00_TipDisp;
        private Panel panel20;
        private RadioButton rb_13_00_TipDisp_SLAVE;
        private RadioButton rb_13_00_TipDisp_MASTER;
        private ComboBox cb_13_03_Parita;
        private ComboBox cb_13_02_Baudrate;
        private NumericUpDown nud_13_01_Indirizzo;
        private Label lbl_13_04_StopBit;
        private Label lbl_13_03_Parita;
        private Label lbl_13_01_Indirizzo;
        private Label lbl_13_02_Baudrate;
        private System.Windows.Forms.Timer timerTick;
        private System.Windows.Forms.Timer systemTimer;
        private ToolStripMenuItem openToolStripMenuItem;
        private OpenFileDialog openFileDialog1;
    }
}