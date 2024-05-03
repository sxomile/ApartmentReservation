namespace Client.UserControls.UCRezervacija
{
    partial class UCKreirajRezervaciju
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txtApartman = new System.Windows.Forms.TextBox();
            this.txtProsecnaOcena = new System.Windows.Forms.TextBox();
            this.txtDomacinstvo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cldDatumDolaska = new System.Windows.Forms.MonthCalendar();
            this.label5 = new System.Windows.Forms.Label();
            this.cldDatumOdlaska = new System.Windows.Forms.MonthCalendar();
            this.btnRezervisi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Apartman:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Prosecna ocena:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Domacinstvo:";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // txtApartman
            // 
            this.txtApartman.Enabled = false;
            this.txtApartman.Location = new System.Drawing.Point(160, 16);
            this.txtApartman.Name = "txtApartman";
            this.txtApartman.Size = new System.Drawing.Size(228, 22);
            this.txtApartman.TabIndex = 4;
            // 
            // txtProsecnaOcena
            // 
            this.txtProsecnaOcena.Enabled = false;
            this.txtProsecnaOcena.Location = new System.Drawing.Point(160, 55);
            this.txtProsecnaOcena.Name = "txtProsecnaOcena";
            this.txtProsecnaOcena.Size = new System.Drawing.Size(228, 22);
            this.txtProsecnaOcena.TabIndex = 5;
            // 
            // txtDomacinstvo
            // 
            this.txtDomacinstvo.Enabled = false;
            this.txtDomacinstvo.Location = new System.Drawing.Point(160, 94);
            this.txtDomacinstvo.Name = "txtDomacinstvo";
            this.txtDomacinstvo.Size = new System.Drawing.Size(228, 22);
            this.txtDomacinstvo.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Izaberite datum dolaska:";
            // 
            // cldDatumDolaska
            // 
            this.cldDatumDolaska.Location = new System.Drawing.Point(18, 171);
            this.cldDatumDolaska.MaxSelectionCount = 1;
            this.cldDatumDolaska.Name = "cldDatumDolaska";
            this.cldDatumDolaska.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(317, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(153, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Izaberite datum odlaska:";
            // 
            // cldDatumOdlaska
            // 
            this.cldDatumOdlaska.Location = new System.Drawing.Point(320, 171);
            this.cldDatumOdlaska.MaxSelectionCount = 1;
            this.cldDatumOdlaska.Name = "cldDatumOdlaska";
            this.cldDatumOdlaska.TabIndex = 10;
            // 
            // btnRezervisi
            // 
            this.btnRezervisi.Location = new System.Drawing.Point(466, 38);
            this.btnRezervisi.Name = "btnRezervisi";
            this.btnRezervisi.Size = new System.Drawing.Size(116, 57);
            this.btnRezervisi.TabIndex = 11;
            this.btnRezervisi.Text = "Rezervisi";
            this.btnRezervisi.UseVisualStyleBackColor = true;
            // 
            // UCKreirajRezervaciju
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRezervisi);
            this.Controls.Add(this.cldDatumOdlaska);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cldDatumDolaska);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDomacinstvo);
            this.Controls.Add(this.txtProsecnaOcena);
            this.Controls.Add(this.txtApartman);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UCKreirajRezervaciju";
            this.Size = new System.Drawing.Size(686, 446);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        public System.Windows.Forms.TextBox txtApartman;
        public System.Windows.Forms.TextBox txtProsecnaOcena;
        public System.Windows.Forms.TextBox txtDomacinstvo;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.MonthCalendar cldDatumDolaska;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.MonthCalendar cldDatumOdlaska;
        public System.Windows.Forms.Button btnRezervisi;
    }
}
