namespace Client.UserControls.UCRezervacija
{
    partial class UCObrisiRezervaciju
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
            this.btnOtkazi = new System.Windows.Forms.Button();
            this.txtDomacinstvo = new System.Windows.Forms.TextBox();
            this.txtApartman = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDatumOdlaska = new System.Windows.Forms.TextBox();
            this.txtDatumDolaska = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtGost = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnOtkazi
            // 
            this.btnOtkazi.Location = new System.Drawing.Point(442, 97);
            this.btnOtkazi.Name = "btnOtkazi";
            this.btnOtkazi.Size = new System.Drawing.Size(142, 64);
            this.btnOtkazi.TabIndex = 18;
            this.btnOtkazi.Text = "Otkazi rezervaciju";
            this.btnOtkazi.UseVisualStyleBackColor = true;
            // 
            // txtDomacinstvo
            // 
            this.txtDomacinstvo.Enabled = false;
            this.txtDomacinstvo.Location = new System.Drawing.Point(161, 97);
            this.txtDomacinstvo.Name = "txtDomacinstvo";
            this.txtDomacinstvo.Size = new System.Drawing.Size(228, 22);
            this.txtDomacinstvo.TabIndex = 17;
            // 
            // txtApartman
            // 
            this.txtApartman.Enabled = false;
            this.txtApartman.Location = new System.Drawing.Point(161, 19);
            this.txtApartman.Name = "txtApartman";
            this.txtApartman.Size = new System.Drawing.Size(228, 22);
            this.txtApartman.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Domacinstvo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Apartman:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 16);
            this.label4.TabIndex = 19;
            this.label4.Text = "Datum odlaska:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 16);
            this.label5.TabIndex = 20;
            this.label5.Text = "Datum dolaska:";
            // 
            // txtDatumOdlaska
            // 
            this.txtDatumOdlaska.Enabled = false;
            this.txtDatumOdlaska.Location = new System.Drawing.Point(161, 178);
            this.txtDatumOdlaska.Name = "txtDatumOdlaska";
            this.txtDatumOdlaska.Size = new System.Drawing.Size(228, 22);
            this.txtDatumOdlaska.TabIndex = 21;
            // 
            // txtDatumDolaska
            // 
            this.txtDatumDolaska.Enabled = false;
            this.txtDatumDolaska.Location = new System.Drawing.Point(161, 139);
            this.txtDatumDolaska.Name = "txtDatumDolaska";
            this.txtDatumDolaska.Size = new System.Drawing.Size(228, 22);
            this.txtDatumDolaska.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 16);
            this.label6.TabIndex = 23;
            this.label6.Text = "Gost:";
            // 
            // txtGost
            // 
            this.txtGost.Enabled = false;
            this.txtGost.Location = new System.Drawing.Point(161, 58);
            this.txtGost.Name = "txtGost";
            this.txtGost.Size = new System.Drawing.Size(228, 22);
            this.txtGost.TabIndex = 24;
            // 
            // UCObrisiRezervaciju
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtGost);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDatumDolaska);
            this.Controls.Add(this.txtDatumOdlaska);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnOtkazi);
            this.Controls.Add(this.txtDomacinstvo);
            this.Controls.Add(this.txtApartman);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "UCObrisiRezervaciju";
            this.Size = new System.Drawing.Size(641, 259);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btnOtkazi;
        public System.Windows.Forms.TextBox txtDomacinstvo;
        public System.Windows.Forms.TextBox txtApartman;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtDatumOdlaska;
        public System.Windows.Forms.TextBox txtDatumDolaska;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtGost;
    }
}
