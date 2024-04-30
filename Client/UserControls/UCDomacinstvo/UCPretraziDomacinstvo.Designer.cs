namespace Client.UserControls.UCDomacinstvo
{
    partial class UCPretraziDomacinstvo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCPretraziDomacinstvo));
            this.txtUpit = new System.Windows.Forms.TextBox();
            this.btnPretrazi = new System.Windows.Forms.Button();
            this.dgvDomacinstva = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDomacinstva)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUpit
            // 
            this.txtUpit.Location = new System.Drawing.Point(23, 44);
            this.txtUpit.Name = "txtUpit";
            this.txtUpit.Size = new System.Drawing.Size(316, 22);
            this.txtUpit.TabIndex = 0;
            // 
            // btnPretrazi
            // 
            this.btnPretrazi.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPretrazi.BackgroundImage")));
            this.btnPretrazi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPretrazi.Location = new System.Drawing.Point(380, 30);
            this.btnPretrazi.Name = "btnPretrazi";
            this.btnPretrazi.Size = new System.Drawing.Size(58, 51);
            this.btnPretrazi.TabIndex = 1;
            this.btnPretrazi.UseVisualStyleBackColor = true;
            // 
            // dgvDomacinstva
            // 
            this.dgvDomacinstva.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDomacinstva.Location = new System.Drawing.Point(0, 3);
            this.dgvDomacinstva.MultiSelect = false;
            this.dgvDomacinstva.Name = "dgvDomacinstva";
            this.dgvDomacinstva.ReadOnly = true;
            this.dgvDomacinstva.RowHeadersWidth = 51;
            this.dgvDomacinstva.RowTemplate.Height = 24;
            this.dgvDomacinstva.Size = new System.Drawing.Size(415, 290);
            this.dgvDomacinstva.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvDomacinstva);
            this.panel1.Location = new System.Drawing.Point(23, 93);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(415, 296);
            this.panel1.TabIndex = 3;
            // 
            // UCPretraziDomacinstvo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnPretrazi);
            this.Controls.Add(this.txtUpit);
            this.Name = "UCPretraziDomacinstvo";
            this.Size = new System.Drawing.Size(477, 401);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDomacinstva)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtUpit;
        public System.Windows.Forms.Button btnPretrazi;
        public System.Windows.Forms.DataGridView dgvDomacinstva;
        private System.Windows.Forms.Panel panel1;
    }
}
