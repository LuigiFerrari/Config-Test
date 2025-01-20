namespace configuratore
{
    partial class frmSerialPortSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSerialPortSelect));
            listBoxPortList = new ListBox();
            btnOK = new Button();
            button2 = new Button();
            btnAnnulla = new Button();
            timerUpateList = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // listBoxPortList
            // 
            listBoxPortList.FormattingEnabled = true;
            listBoxPortList.ItemHeight = 15;
            listBoxPortList.Location = new Point(41, 25);
            listBoxPortList.Margin = new Padding(4, 3, 4, 3);
            listBoxPortList.Name = "listBoxPortList";
            listBoxPortList.Size = new Size(255, 169);
            listBoxPortList.TabIndex = 1;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(41, 223);
            btnOK.Margin = new Padding(4, 3, 4, 3);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(88, 27);
            btnOK.TabIndex = 2;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // button2
            // 
            button2.Location = new Point(330, 127);
            button2.Margin = new Padding(4, 3, 4, 3);
            button2.Name = "button2";
            button2.Size = new Size(9, 9);
            button2.TabIndex = 3;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // btnAnnulla
            // 
            btnAnnulla.Location = new Point(209, 223);
            btnAnnulla.Margin = new Padding(4, 3, 4, 3);
            btnAnnulla.Name = "btnAnnulla";
            btnAnnulla.Size = new Size(88, 27);
            btnAnnulla.TabIndex = 4;
            btnAnnulla.Text = "Annulla";
            btnAnnulla.UseVisualStyleBackColor = true;
            btnAnnulla.Click += btnAnnulla_Click;
            // 
            // timerUpateList
            // 
            timerUpateList.Enabled = true;
            timerUpateList.Tick += timerUpateList_Tick;
            // 
            // frmSerialPortSelect
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(337, 263);
            Controls.Add(btnAnnulla);
            Controls.Add(button2);
            Controls.Add(btnOK);
            Controls.Add(listBoxPortList);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmSerialPortSelect";
            StartPosition = FormStartPosition.CenterParent;
            Text = "frmSerialPortSelect";
            Load += frmSerialPortSelect_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBoxPortList;
        private Button btnOK;
        private Button button2;
        private Button btnAnnulla;
        private BindingSource locaBindingSource;
        private System.Windows.Forms.Timer timerUpateList;
    }
}