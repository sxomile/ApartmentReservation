namespace Client.UserControls.UCApartman
{
	partial class UCApartmanDetails
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
			this.txtDomacinstvo = new System.Windows.Forms.TextBox();
			this.txtApartman = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtProsecnaOcena = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// txtDomacinstvo
			// 
			this.txtDomacinstvo.Enabled = false;
			this.txtDomacinstvo.Location = new System.Drawing.Point(137, 65);
			this.txtDomacinstvo.Name = "txtDomacinstvo";
			this.txtDomacinstvo.Size = new System.Drawing.Size(224, 22);
			this.txtDomacinstvo.TabIndex = 7;
			// 
			// txtApartman
			// 
			this.txtApartman.Enabled = false;
			this.txtApartman.Location = new System.Drawing.Point(137, 19);
			this.txtApartman.Name = "txtApartman";
			this.txtApartman.Size = new System.Drawing.Size(224, 22);
			this.txtApartman.TabIndex = 6;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 68);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(89, 16);
			this.label2.TabIndex = 5;
			this.label2.Text = "Domacinstvo:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(68, 16);
			this.label1.TabIndex = 4;
			this.label1.Text = "Apartman:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 115);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(109, 16);
			this.label3.TabIndex = 8;
			this.label3.Text = "Prosecna ocena:";
			// 
			// txtProsecnaOcena
			// 
			this.txtProsecnaOcena.Enabled = false;
			this.txtProsecnaOcena.Location = new System.Drawing.Point(137, 112);
			this.txtProsecnaOcena.Name = "txtProsecnaOcena";
			this.txtProsecnaOcena.Size = new System.Drawing.Size(224, 22);
			this.txtProsecnaOcena.TabIndex = 9;
			// 
			// UCApartmanDetails
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.txtProsecnaOcena);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtDomacinstvo);
			this.Controls.Add(this.txtApartman);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "UCApartmanDetails";
			this.Size = new System.Drawing.Size(419, 171);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public System.Windows.Forms.TextBox txtDomacinstvo;
		public System.Windows.Forms.TextBox txtApartman;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		public System.Windows.Forms.TextBox txtProsecnaOcena;
	}
}
