namespace Client.UserControls.UCRezervacija
{
    partial class UCPretraziRezervacije
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCPretraziRezervacije));
            this.label1 = new System.Windows.Forms.Label();
            this.txtPretraziRezervacije = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPretraziRezervacije = new System.Windows.Forms.Button();
            this.dgvRezervacije = new System.Windows.Forms.DataGridView();
            this.btnOtkaziRezervaciju = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRezervacije)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID rezervacije:";
            // 
            // txtPretraziRezervacije
            // 
            this.txtPretraziRezervacije.Location = new System.Drawing.Point(114, 19);
            this.txtPretraziRezervacije.Name = "txtPretraziRezervacije";
            this.txtPretraziRezervacije.Size = new System.Drawing.Size(336, 22);
            this.txtPretraziRezervacije.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "label1";
            // 
            // btnPretraziRezervacije
            // 
            this.btnPretraziRezervacije.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPretraziRezervacije.BackgroundImage")));
            this.btnPretraziRezervacije.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPretraziRezervacije.Location = new System.Drawing.Point(569, 12);
            this.btnPretraziRezervacije.Name = "btnPretraziRezervacije";
            this.btnPretraziRezervacije.Size = new System.Drawing.Size(50, 37);
            this.btnPretraziRezervacije.TabIndex = 17;
            this.btnPretraziRezervacije.UseVisualStyleBackColor = true;
            // 
            // dgvRezervacije
            // 
            this.dgvRezervacije.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRezervacije.Location = new System.Drawing.Point(19, 98);
            this.dgvRezervacije.Name = "dgvRezervacije";
            this.dgvRezervacije.RowHeadersWidth = 51;
            this.dgvRezervacije.RowTemplate.Height = 24;
            this.dgvRezervacije.Size = new System.Drawing.Size(600, 251);
            this.dgvRezervacije.TabIndex = 18;
            // 
            // btnOtkaziRezervaciju
            // 
            this.btnOtkaziRezervaciju.Location = new System.Drawing.Point(639, 197);
            this.btnOtkaziRezervaciju.Name = "btnOtkaziRezervaciju";
            this.btnOtkaziRezervaciju.Size = new System.Drawing.Size(120, 65);
            this.btnOtkaziRezervaciju.TabIndex = 19;
            this.btnOtkaziRezervaciju.Text = "Otkazi rezervaciju";
            this.btnOtkaziRezervaciju.UseVisualStyleBackColor = true;
            // 
            // UCPretraziRezervacije
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnOtkaziRezervaciju);
            this.Controls.Add(this.dgvRezervacije);
            this.Controls.Add(this.btnPretraziRezervacije);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPretraziRezervacije);
            this.Controls.Add(this.label1);
            this.Name = "UCPretraziRezervacije";
            this.Size = new System.Drawing.Size(780, 390);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRezervacije)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtPretraziRezervacije;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button btnPretraziRezervacije;
        public System.Windows.Forms.DataGridView dgvRezervacije;
        public System.Windows.Forms.Button btnOtkaziRezervaciju;
    }
}
