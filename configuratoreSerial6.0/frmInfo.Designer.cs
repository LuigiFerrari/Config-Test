namespace configuratore
{
    partial class frmInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInfo));
            label1 = new Label();
            pictureBox1 = new PictureBox();
            button1 = new Button();
            softwareRelease = new Label();
            button2 = new Button();
            groupBox1 = new GroupBox();
            lblLivello = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(58, 57);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(264, 25);
            label1.TabIndex = 0;
            label1.Text = "P.L.C. CONFIGURATOR";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = configuratoreSerial6._0.Resource1.logo_x1;
            pictureBox1.BackgroundImageLayout = ImageLayout.None;
            pictureBox1.Location = new Point(76, 112);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(274, 68);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.Location = new Point(346, 254);
            button1.Margin = new Padding(4, 3, 4, 3);
            button1.Name = "button1";
            button1.Size = new Size(88, 27);
            button1.TabIndex = 2;
            button1.Text = "CLOSE";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // softwareRelease
            // 
            softwareRelease.AutoSize = true;
            softwareRelease.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            softwareRelease.Location = new Point(58, 205);
            softwareRelease.Margin = new Padding(4, 0, 4, 0);
            softwareRelease.Name = "softwareRelease";
            softwareRelease.Size = new Size(264, 25);
            softwareRelease.TabIndex = 3;
            softwareRelease.Text = "P.L.C. CONFIGURATOR";
            // 
            // button2
            // 
            button2.Location = new Point(215, 21);
            button2.Margin = new Padding(4, 3, 4, 3);
            button2.Name = "button2";
            button2.Size = new Size(88, 27);
            button2.TabIndex = 6;
            button2.Text = "CHANGE";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblLivello);
            groupBox1.Controls.Add(button2);
            groupBox1.Location = new Point(29, 233);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(310, 61);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "LEVEL";
            // 
            // lblLivello
            // 
            lblLivello.AutoSize = true;
            lblLivello.Location = new Point(22, 25);
            lblLivello.Name = "lblLivello";
            lblLivello.Size = new Size(38, 15);
            lblLivello.TabIndex = 7;
            lblLivello.Text = "label2";
            // 
            // frmInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(447, 315);
            ControlBox = false;
            Controls.Add(groupBox1);
            Controls.Add(softwareRelease);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmInfo";
            StartPosition = FormStartPosition.CenterParent;
            Text = "INFO";
            Load += frmInfo_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label softwareRelease;
        private Button button2;
        private GroupBox groupBox1;
        private Label lblLivello;
    }
}