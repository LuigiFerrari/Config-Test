namespace configuratore
{
    partial class frmMasterNetwork
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dataGridDevices = new DataGridView();
            DISPOSITIVO = new DataGridViewTextBoxColumn();
            INDIRIZZO = new DataGridViewTextBoxColumn();
            MATRICOLA = new DataGridViewTextBoxColumn();
            VERSIONE = new DataGridViewTextBoxColumn();
            STATO = new DataGridViewTextBoxColumn();
            CONNECT = new DataGridViewImageColumn();
            CODICE = new DataGridViewTextBoxColumn();
            FLAGPRINCIPALE = new DataGridViewTextBoxColumn();
            SUBTYPE = new DataGridViewTextBoxColumn();
            PRINCIPALE = new DataGridViewImageColumn();
            btnResetRete = new Button();
            btnAggiornaRete = new Button();
            btnSalvaRete = new Button();
            btnExit = new Button();
            timerRicezione = new System.Windows.Forms.Timer(components);
            btnRestartMaster = new Button();
            picPleaseWait = new PictureBox();
            Fintosave = new System.Windows.Forms.Timer(components);
            timerTick = new System.Windows.Forms.Timer(components);
            timerDelay = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)dataGridDevices).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picPleaseWait).BeginInit();
            SuspendLayout();
            // 
            // dataGridDevices
            // 
            dataGridDevices.AllowUserToAddRows = false;
            dataGridDevices.AllowUserToDeleteRows = false;
            dataGridDevices.AllowUserToResizeRows = false;
            dataGridDevices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridDevices.Columns.AddRange(new DataGridViewColumn[] { DISPOSITIVO, INDIRIZZO, MATRICOLA, VERSIONE, STATO, CONNECT, CODICE, FLAGPRINCIPALE, SUBTYPE, PRINCIPALE });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridDevices.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridDevices.Location = new Point(13, 29);
            dataGridDevices.Margin = new Padding(4, 3, 4, 3);
            dataGridDevices.MultiSelect = false;
            dataGridDevices.Name = "dataGridDevices";
            dataGridDevices.ReadOnly = true;
            dataGridDevices.RowHeadersVisible = false;
            dataGridDevices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridDevices.ShowCellToolTips = false;
            dataGridDevices.Size = new Size(809, 355);
            dataGridDevices.TabIndex = 0;
            dataGridDevices.CellClick += dataGridDevices_CellClick;
            dataGridDevices.CellMouseDown += dataGridDevices_CellMouseDown;
            dataGridDevices.CellMouseMove += dataGridDevices_CellMouseMove;
            dataGridDevices.MouseUp += dataGridDevices_MouseUp;
            // 
            // DISPOSITIVO
            // 
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            DISPOSITIVO.DefaultCellStyle = dataGridViewCellStyle1;
            DISPOSITIVO.FillWeight = 300F;
            DISPOSITIVO.HeaderText = "DISPOSITIVO";
            DISPOSITIVO.Name = "DISPOSITIVO";
            DISPOSITIVO.ReadOnly = true;
            DISPOSITIVO.SortMode = DataGridViewColumnSortMode.NotSortable;
            DISPOSITIVO.Width = 300;
            // 
            // INDIRIZZO
            // 
            INDIRIZZO.FillWeight = 70F;
            INDIRIZZO.HeaderText = "INDIRIZZO";
            INDIRIZZO.Name = "INDIRIZZO";
            INDIRIZZO.ReadOnly = true;
            INDIRIZZO.SortMode = DataGridViewColumnSortMode.NotSortable;
            INDIRIZZO.Width = 70;
            // 
            // MATRICOLA
            // 
            MATRICOLA.HeaderText = "MATRICOLA";
            MATRICOLA.Name = "MATRICOLA";
            MATRICOLA.ReadOnly = true;
            MATRICOLA.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // VERSIONE
            // 
            VERSIONE.HeaderText = "VERSIONE";
            VERSIONE.Name = "VERSIONE";
            VERSIONE.ReadOnly = true;
            VERSIONE.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // STATO
            // 
            STATO.FillWeight = 50F;
            STATO.HeaderText = "STATO";
            STATO.Name = "STATO";
            STATO.ReadOnly = true;
            STATO.SortMode = DataGridViewColumnSortMode.NotSortable;
            STATO.Width = 50;
            // 
            // CONNECT
            // 
            CONNECT.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            CONNECT.HeaderText = "CONNECT";
            CONNECT.Name = "CONNECT";
            CONNECT.ReadOnly = true;
            CONNECT.Resizable = DataGridViewTriState.True;
            CONNECT.Width = 68;
            // 
            // CODICE
            // 
            CODICE.HeaderText = "CODICE";
            CODICE.Name = "CODICE";
            CODICE.ReadOnly = true;
            CODICE.SortMode = DataGridViewColumnSortMode.NotSortable;
            CODICE.Visible = false;
            // 
            // FLAGPRINCIPALE
            // 
            FLAGPRINCIPALE.HeaderText = "FLAGPRINCIPALE";
            FLAGPRINCIPALE.Name = "FLAGPRINCIPALE";
            FLAGPRINCIPALE.ReadOnly = true;
            FLAGPRINCIPALE.SortMode = DataGridViewColumnSortMode.NotSortable;
            FLAGPRINCIPALE.Visible = false;
            // 
            // SUBTYPE
            // 
            SUBTYPE.HeaderText = "SUBTYPE";
            SUBTYPE.Name = "SUBTYPE";
            SUBTYPE.ReadOnly = true;
            SUBTYPE.SortMode = DataGridViewColumnSortMode.NotSortable;
            SUBTYPE.Visible = false;
            // 
            // PRINCIPALE
            // 
            PRINCIPALE.HeaderText = "";
            PRINCIPALE.Name = "PRINCIPALE";
            PRINCIPALE.ReadOnly = true;
            PRINCIPALE.Resizable = DataGridViewTriState.True;
            // 
            // btnResetRete
            // 
            btnResetRete.Location = new Point(935, 50);
            btnResetRete.Margin = new Padding(4, 3, 4, 3);
            btnResetRete.Name = "btnResetRete";
            btnResetRete.Size = new Size(131, 27);
            btnResetRete.TabIndex = 1;
            btnResetRete.Text = "RESET AND SCAN";
            btnResetRete.UseVisualStyleBackColor = true;
            btnResetRete.Click += btnRescan_Click;
            // 
            // btnAggiornaRete
            // 
            btnAggiornaRete.Location = new Point(935, 97);
            btnAggiornaRete.Margin = new Padding(4, 3, 4, 3);
            btnAggiornaRete.Name = "btnAggiornaRete";
            btnAggiornaRete.Size = new Size(131, 27);
            btnAggiornaRete.TabIndex = 2;
            btnAggiornaRete.Text = "UPDATE";
            btnAggiornaRete.UseVisualStyleBackColor = true;
            btnAggiornaRete.Click += btnAggiornaRete_Click;
            // 
            // btnSalvaRete
            // 
            btnSalvaRete.Location = new Point(935, 151);
            btnSalvaRete.Margin = new Padding(4, 3, 4, 3);
            btnSalvaRete.Name = "btnSalvaRete";
            btnSalvaRete.Size = new Size(131, 27);
            btnSalvaRete.TabIndex = 3;
            btnSalvaRete.Text = "salva";
            btnSalvaRete.UseVisualStyleBackColor = true;
            btnSalvaRete.Click += btnSalvaRete_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(935, 332);
            btnExit.Margin = new Padding(4, 3, 4, 3);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(131, 27);
            btnExit.TabIndex = 4;
            btnExit.Text = "EXIT";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // timerRicezione
            // 
            timerRicezione.Interval = 1;
            timerRicezione.Tick += timerRicezione_Tick;
            // 
            // btnRestartMaster
            // 
            btnRestartMaster.Location = new Point(935, 262);
            btnRestartMaster.Margin = new Padding(4, 3, 4, 3);
            btnRestartMaster.Name = "btnRestartMaster";
            btnRestartMaster.Size = new Size(131, 27);
            btnRestartMaster.TabIndex = 5;
            btnRestartMaster.Text = "RIAVVIA";
            btnRestartMaster.UseVisualStyleBackColor = true;
            btnRestartMaster.Click += btnRestartMaster_Click;
            // 
            // picPleaseWait
            // 
            picPleaseWait.Anchor = AnchorStyles.None;
            picPleaseWait.Image = configuratoreSerial6._0.Resource1.pleasewait;
            picPleaseWait.Location = new Point(87, 98);
            picPleaseWait.Name = "picPleaseWait";
            picPleaseWait.Size = new Size(809, 355);
            picPleaseWait.SizeMode = PictureBoxSizeMode.CenterImage;
            picPleaseWait.TabIndex = 6;
            picPleaseWait.TabStop = false;
            // 
            // Fintosave
            // 
            Fintosave.Interval = 1000;
            Fintosave.Tick += Fintosave_Tick;
            // 
            // timerTick
            // 
            timerTick.Tick += timerTick_Tick;
            // 
            // timerDelay
            // 
            timerDelay.Interval = 2500;
            timerDelay.Tick += timerDelay_Tick;
            // 
            // frmMasterNetwork
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1105, 465);
            Controls.Add(picPleaseWait);
            Controls.Add(btnRestartMaster);
            Controls.Add(btnExit);
            Controls.Add(btnSalvaRete);
            Controls.Add(btnAggiornaRete);
            Controls.Add(btnResetRete);
            Controls.Add(dataGridDevices);
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmMasterNetwork";
            Text = "frmMasterNetwork";
            Load += frmMasterNetwork_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridDevices).EndInit();
            ((System.ComponentModel.ISupportInitialize)picPleaseWait).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridDevices;
        private Button btnResetRete;
        private Button btnAggiornaRete;
        private Button btnSalvaRete;
        private Button btnExit;
        private System.Windows.Forms.Timer timerRicezione;
        private Button btnRestartMaster;
        private PictureBox picPleaseWait;
        private System.Windows.Forms.Timer Fintosave;
        private System.Windows.Forms.Timer timerTick;
        private System.Windows.Forms.Timer timerDelay;
        private DataGridViewTextBoxColumn DISPOSITIVO;
        private DataGridViewTextBoxColumn INDIRIZZO;
        private DataGridViewTextBoxColumn MATRICOLA;
        private DataGridViewTextBoxColumn VERSIONE;
        private DataGridViewTextBoxColumn STATO;
        private DataGridViewImageColumn CONNECT;
        private DataGridViewTextBoxColumn CODICE;
        private DataGridViewTextBoxColumn FLAGPRINCIPALE;
        private DataGridViewTextBoxColumn SUBTYPE;
        private DataGridViewImageColumn PRINCIPALE;
    }
}