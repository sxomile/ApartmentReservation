namespace Client.UserControls.UCRezervacija
{
    partial class UCKreirajRezervacijuPrekoAgenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCKreirajRezervacijuPrekoAgenta));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDomacinstvo = new System.Windows.Forms.TextBox();
            this.txtProsecnaOcena = new System.Windows.Forms.TextBox();
            this.txtApartman = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cldDatumDolaska = new System.Windows.Forms.MonthCalendar();
            this.cldDatumOdlaska = new System.Windows.Forms.MonthCalendar();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvGosti = new System.Windows.Forms.DataGridView();
            this.txtGost = new System.Windows.Forms.TextBox();
            this.btnRezervisi = new System.Windows.Forms.Button();
            this.btnPretraziGosta = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGosti)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Apartman:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Prosecna ocena:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Domacinstvo:";
            // 
            // txtDomacinstvo
            // 
            this.txtDomacinstvo.Enabled = false;
            this.txtDomacinstvo.Location = new System.Drawing.Point(141, 86);
            this.txtDomacinstvo.Name = "txtDomacinstvo";
            this.txtDomacinstvo.Size = new System.Drawing.Size(228, 22);
            this.txtDomacinstvo.TabIndex = 5;
            // 
            // txtProsecnaOcena
            // 
            this.txtProsecnaOcena.Enabled = false;
            this.txtProsecnaOcena.Location = new System.Drawing.Point(141, 51);
            this.txtProsecnaOcena.Name = "txtProsecnaOcena";
            this.txtProsecnaOcena.Size = new System.Drawing.Size(228, 22);
            this.txtProsecnaOcena.TabIndex = 6;
            // 
            // txtApartman
            // 
            this.txtApartman.Enabled = false;
            this.txtApartman.Location = new System.Drawing.Point(141, 12);
            this.txtApartman.Name = "txtApartman";
            this.txtApartman.Size = new System.Drawing.Size(228, 22);
            this.txtApartman.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(411, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Izaberite datum dolaska:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(411, 253);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(153, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Izaberite datum odlaska:";
            // 
            // cldDatumDolaska
            // 
            this.cldDatumDolaska.Location = new System.Drawing.Point(414, 37);
            this.cldDatumDolaska.MaxSelectionCount = 1;
            this.cldDatumDolaska.Name = "cldDatumDolaska";
            this.cldDatumDolaska.TabIndex = 10;
            // 
            // cldDatumOdlaska
            // 
            this.cldDatumOdlaska.Location = new System.Drawing.Point(414, 279);
            this.cldDatumOdlaska.MaxSelectionCount = 1;
            this.cldDatumOdlaska.Name = "cldDatumOdlaska";
            this.cldDatumOdlaska.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Gost:";
            // 
            // dgvGosti
            // 
            this.dgvGosti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGosti.Location = new System.Drawing.Point(18, 157);
            this.dgvGosti.MultiSelect = false;
            this.dgvGosti.Name = "dgvGosti";
            this.dgvGosti.ReadOnly = true;
            this.dgvGosti.RowHeadersWidth = 51;
            this.dgvGosti.RowTemplate.Height = 24;
            this.dgvGosti.Size = new System.Drawing.Size(351, 257);
            this.dgvGosti.TabIndex = 13;
            // 
            // txtGost
            // 
            this.txtGost.Location = new System.Drawing.Point(141, 123);
            this.txtGost.Name = "txtGost";
            this.txtGost.Size = new System.Drawing.Size(186, 22);
            this.txtGost.TabIndex = 14;
            // 
            // btnRezervisi
            // 
            this.btnRezervisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRezervisi.Location = new System.Drawing.Point(18, 420);
            this.btnRezervisi.Name = "btnRezervisi";
            this.btnRezervisi.Size = new System.Drawing.Size(351, 66);
            this.btnRezervisi.TabIndex = 15;
            this.btnRezervisi.Text = "Rezervisi";
            this.btnRezervisi.UseVisualStyleBackColor = true;
            // 
            // btnPretraziGosta
            // 
            this.btnPretraziGosta.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPretraziGosta.BackgroundImage")));
            this.btnPretraziGosta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPretraziGosta.Location = new System.Drawing.Point(333, 114);
            this.btnPretraziGosta.Name = "btnPretraziGosta";
            this.btnPretraziGosta.Size = new System.Drawing.Size(36, 37);
            this.btnPretraziGosta.TabIndex = 16;
            this.btnPretraziGosta.UseVisualStyleBackColor = true;
            // 
            // UCKreirajRezervacijuPrekoAgenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnPretraziGosta);
            this.Controls.Add(this.btnRezervisi);
            this.Controls.Add(this.txtGost);
            this.Controls.Add(this.dgvGosti);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cldDatumOdlaska);
            this.Controls.Add(this.cldDatumDolaska);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtApartman);
            this.Controls.Add(this.txtProsecnaOcena);
            this.Controls.Add(this.txtDomacinstvo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UCKreirajRezervacijuPrekoAgenta";
            this.Size = new System.Drawing.Size(711, 505);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGosti)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtDomacinstvo;
        public System.Windows.Forms.TextBox txtProsecnaOcena;
        public System.Windows.Forms.TextBox txtApartman;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.MonthCalendar cldDatumDolaska;
        public System.Windows.Forms.MonthCalendar cldDatumOdlaska;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.DataGridView dgvGosti;
        public System.Windows.Forms.TextBox txtGost;
        public System.Windows.Forms.Button btnRezervisi;
        public System.Windows.Forms.Button btnPretraziGosta;
    }
}
