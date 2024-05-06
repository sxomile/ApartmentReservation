namespace Client.UserControls.UCApartman
{
    partial class ucPretraziApartman
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucPretraziApartman));
            this.txtUpit = new System.Windows.Forms.TextBox();
            this.btnPretrazi = new System.Windows.Forms.Button();
            this.dgvApartmani = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRezervisi = new System.Windows.Forms.Button();
            this.btnOceni = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApartmani)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUpit
            // 
            this.txtUpit.Location = new System.Drawing.Point(22, 49);
            this.txtUpit.Name = "txtUpit";
            this.txtUpit.Size = new System.Drawing.Size(316, 22);
            this.txtUpit.TabIndex = 1;
            // 
            // btnPretrazi
            // 
            this.btnPretrazi.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPretrazi.BackgroundImage")));
            this.btnPretrazi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPretrazi.Location = new System.Drawing.Point(379, 35);
            this.btnPretrazi.Name = "btnPretrazi";
            this.btnPretrazi.Size = new System.Drawing.Size(58, 51);
            this.btnPretrazi.TabIndex = 2;
            this.btnPretrazi.UseVisualStyleBackColor = true;
            // 
            // dgvApartmani
            // 
            this.dgvApartmani.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApartmani.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvApartmani.Location = new System.Drawing.Point(0, 0);
            this.dgvApartmani.MultiSelect = false;
            this.dgvApartmani.Name = "dgvApartmani";
            this.dgvApartmani.ReadOnly = true;
            this.dgvApartmani.RowHeadersWidth = 51;
            this.dgvApartmani.RowTemplate.Height = 24;
            this.dgvApartmani.Size = new System.Drawing.Size(415, 283);
            this.dgvApartmani.TabIndex = 3;
            this.dgvApartmani.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvApartmani_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvApartmani);
            this.panel1.Location = new System.Drawing.Point(22, 106);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(415, 283);
            this.panel1.TabIndex = 4;
            // 
            // btnRezervisi
            // 
            this.btnRezervisi.Location = new System.Drawing.Point(476, 214);
            this.btnRezervisi.Name = "btnRezervisi";
            this.btnRezervisi.Size = new System.Drawing.Size(96, 51);
            this.btnRezervisi.TabIndex = 5;
            this.btnRezervisi.Text = "Rezervisi apartman";
            this.btnRezervisi.UseVisualStyleBackColor = true;
            this.btnRezervisi.Click += new System.EventHandler(this.btnRezervisi_Click);
            // 
            // btnOceni
            // 
            this.btnOceni.Location = new System.Drawing.Point(476, 300);
            this.btnOceni.Name = "btnOceni";
            this.btnOceni.Size = new System.Drawing.Size(96, 51);
            this.btnOceni.TabIndex = 6;
            this.btnOceni.Text = "Oceni apartman";
            this.btnOceni.UseVisualStyleBackColor = true;
            // 
            // ucPretraziApartman
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnOceni);
            this.Controls.Add(this.btnRezervisi);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnPretrazi);
            this.Controls.Add(this.txtUpit);
            this.Name = "ucPretraziApartman";
            this.Size = new System.Drawing.Size(611, 401);
            ((System.ComponentModel.ISupportInitialize)(this.dgvApartmani)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtUpit;
        public System.Windows.Forms.Button btnPretrazi;
        public System.Windows.Forms.DataGridView dgvApartmani;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button btnRezervisi;
        public System.Windows.Forms.Button btnOceni;
    }
}
