﻿namespace Client.Forms
{
    partial class FrmMain
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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.domacinstvoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.kreirajDomacinstvoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pretraziDomacinstvaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.apartmanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pretraziApartmaneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.rezervacijeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pretraziRezervacijeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pnlMain = new System.Windows.Forms.Panel();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.domacinstvoToolStripMenuItem,
            this.apartmanToolStripMenuItem,
            this.rezervacijeToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(800, 28);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// domacinstvoToolStripMenuItem
			// 
			this.domacinstvoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kreirajDomacinstvoToolStripMenuItem,
            this.pretraziDomacinstvaToolStripMenuItem});
			this.domacinstvoToolStripMenuItem.Name = "domacinstvoToolStripMenuItem";
			this.domacinstvoToolStripMenuItem.Size = new System.Drawing.Size(110, 24);
			this.domacinstvoToolStripMenuItem.Text = "Domacinstvo";
			// 
			// kreirajDomacinstvoToolStripMenuItem
			// 
			this.kreirajDomacinstvoToolStripMenuItem.Name = "kreirajDomacinstvoToolStripMenuItem";
			this.kreirajDomacinstvoToolStripMenuItem.Size = new System.Drawing.Size(230, 26);
			this.kreirajDomacinstvoToolStripMenuItem.Text = "Kreiraj domacinstvo";
			// 
			// pretraziDomacinstvaToolStripMenuItem
			// 
			this.pretraziDomacinstvaToolStripMenuItem.Name = "pretraziDomacinstvaToolStripMenuItem";
			this.pretraziDomacinstvaToolStripMenuItem.Size = new System.Drawing.Size(230, 26);
			this.pretraziDomacinstvaToolStripMenuItem.Text = "Pretrazi domacinstva";
			// 
			// apartmanToolStripMenuItem
			// 
			this.apartmanToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pretraziApartmaneToolStripMenuItem});
			this.apartmanToolStripMenuItem.Name = "apartmanToolStripMenuItem";
			this.apartmanToolStripMenuItem.Size = new System.Drawing.Size(89, 24);
			this.apartmanToolStripMenuItem.Text = "Apartman";
			// 
			// pretraziApartmaneToolStripMenuItem
			// 
			this.pretraziApartmaneToolStripMenuItem.Name = "pretraziApartmaneToolStripMenuItem";
			this.pretraziApartmaneToolStripMenuItem.Size = new System.Drawing.Size(218, 26);
			this.pretraziApartmaneToolStripMenuItem.Text = "Pretrazi apartmane";
			// 
			// rezervacijeToolStripMenuItem
			// 
			this.rezervacijeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pretraziRezervacijeToolStripMenuItem});
			this.rezervacijeToolStripMenuItem.Name = "rezervacijeToolStripMenuItem";
			this.rezervacijeToolStripMenuItem.Size = new System.Drawing.Size(98, 24);
			this.rezervacijeToolStripMenuItem.Text = "Rezervacije";
			// 
			// pretraziRezervacijeToolStripMenuItem
			// 
			this.pretraziRezervacijeToolStripMenuItem.Name = "pretraziRezervacijeToolStripMenuItem";
			this.pretraziRezervacijeToolStripMenuItem.Size = new System.Drawing.Size(217, 26);
			this.pretraziRezervacijeToolStripMenuItem.Text = "Pretrazi rezervacije";
			// 
			// pnlMain
			// 
			this.pnlMain.Location = new System.Drawing.Point(13, 32);
			this.pnlMain.Name = "pnlMain";
			this.pnlMain.Size = new System.Drawing.Size(775, 499);
			this.pnlMain.TabIndex = 1;
			// 
			// FrmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 543);
			this.Controls.Add(this.pnlMain);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "FrmMain";
			this.Text = "FrmMainDomacin";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem domacinstvoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kreirajDomacinstvoToolStripMenuItem;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.ToolStripMenuItem pretraziDomacinstvaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem apartmanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pretraziApartmaneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rezervacijeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pretraziRezervacijeToolStripMenuItem;
    }
}