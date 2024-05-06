namespace Client.UserControls.UCOcena
{
    partial class UCOceni
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtApartman = new System.Windows.Forms.TextBox();
            this.txtDomacinstvo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOceni = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Apartman:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Domacinstvo:";
            // 
            // txtApartman
            // 
            this.txtApartman.Enabled = false;
            this.txtApartman.Location = new System.Drawing.Point(148, 17);
            this.txtApartman.Name = "txtApartman";
            this.txtApartman.Size = new System.Drawing.Size(224, 22);
            this.txtApartman.TabIndex = 2;
            // 
            // txtDomacinstvo
            // 
            this.txtDomacinstvo.Enabled = false;
            this.txtDomacinstvo.Location = new System.Drawing.Point(148, 63);
            this.txtDomacinstvo.Name = "txtDomacinstvo";
            this.txtDomacinstvo.Size = new System.Drawing.Size(224, 22);
            this.txtDomacinstvo.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ocena:";
            // 
            // btnOceni
            // 
            this.btnOceni.Location = new System.Drawing.Point(268, 133);
            this.btnOceni.Name = "btnOceni";
            this.btnOceni.Size = new System.Drawing.Size(104, 41);
            this.btnOceni.TabIndex = 6;
            this.btnOceni.Text = "Ostavi ocenu";
            this.btnOceni.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.comboBox1.Location = new System.Drawing.Point(148, 150);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(95, 24);
            this.comboBox1.TabIndex = 7;
            // 
            // UCOceni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnOceni);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDomacinstvo);
            this.Controls.Add(this.txtApartman);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UCOceni";
            this.Size = new System.Drawing.Size(436, 208);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtApartman;
        public System.Windows.Forms.TextBox txtDomacinstvo;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button btnOceni;
        public System.Windows.Forms.ComboBox comboBox1;
    }
}
