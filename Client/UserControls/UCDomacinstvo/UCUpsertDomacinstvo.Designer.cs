namespace Client.UserControls.UCDomacinstvo
{
    partial class UCUpsertDomacinstvo
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
            this.btnDodaj = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNazivDomacinstva = new System.Windows.Forms.TextBox();
            this.dgvApartmani = new System.Windows.Forms.DataGridView();
            this.btnOtkazi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApartmani)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDodaj
            // 
            this.btnDodaj.Location = new System.Drawing.Point(399, 352);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(114, 61);
            this.btnDodaj.TabIndex = 0;
            this.btnDodaj.Text = "Dodaj domacinstvo";
            this.btnDodaj.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Naziv domacinstva:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Apartmani:";
            // 
            // txtNazivDomacinstva
            // 
            this.txtNazivDomacinstva.Location = new System.Drawing.Point(213, 31);
            this.txtNazivDomacinstva.Name = "txtNazivDomacinstva";
            this.txtNazivDomacinstva.Size = new System.Drawing.Size(300, 22);
            this.txtNazivDomacinstva.TabIndex = 3;
            // 
            // dgvApartmani
            // 
            this.dgvApartmani.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApartmani.Location = new System.Drawing.Point(37, 123);
            this.dgvApartmani.Name = "dgvApartmani";
            this.dgvApartmani.RowHeadersWidth = 51;
            this.dgvApartmani.RowTemplate.Height = 24;
            this.dgvApartmani.Size = new System.Drawing.Size(476, 205);
            this.dgvApartmani.TabIndex = 4;
            // 
            // btnOtkazi
            // 
            this.btnOtkazi.Location = new System.Drawing.Point(37, 352);
            this.btnOtkazi.Name = "btnOtkazi";
            this.btnOtkazi.Size = new System.Drawing.Size(114, 61);
            this.btnOtkazi.TabIndex = 5;
            this.btnOtkazi.Text = "Zavrsi rad";
            this.btnOtkazi.UseVisualStyleBackColor = true;
            // 
            // UCUpsertDomacinstvo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnOtkazi);
            this.Controls.Add(this.dgvApartmani);
            this.Controls.Add(this.txtNazivDomacinstva);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDodaj);
            this.Name = "UCUpsertDomacinstvo";
            this.Size = new System.Drawing.Size(573, 441);
            ((System.ComponentModel.ISupportInitialize)(this.dgvApartmani)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtNazivDomacinstva;
        public System.Windows.Forms.DataGridView dgvApartmani;
        public System.Windows.Forms.Button btnOtkazi;
    }
}
