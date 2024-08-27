using Client.GuiController;
using Client.UserControls;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Forms
{
	public partial class FrmMain : Form
	{
		private readonly User korisnik;
		public FrmMain(User korisnik)
		{
			this.korisnik = korisnik;
			InitializeComponent();
			MaximizeBox = false;

			//uvek treba proslediti ovog korisnika za rez jer je jako bitno, i onda nema potrebe za onim cudom od hardcode-ovanja
			//sad zbog ovoga se desavalo ono da mi se korisnik zagubi i onda krene da se gubi nesto program

			if(korisnik.Uloga == Role.Gost)
				domacinstvoToolStripMenuItem.Visible = false;

			pretraziRezervacijeToolStripMenuItem.Click += (s, e) =>
				MainCoordinator.Instance.ShowUCRezervacija(UCMode.Search, korisnik: korisnik);

			kreirajDomacinstvoToolStripMenuItem.Click += (s, e) =>
				MainCoordinator.Instance.ShowDomacinstvoPanel(UCMode.Create);

			pretraziDomacinstvaToolStripMenuItem.Click += (s, e) =>
				MainCoordinator.Instance.ShowDomacinstvoPanel(UCMode.Search);

			pretraziApartmaneToolStripMenuItem.Click += (s, e) =>
				MainCoordinator.Instance.ShowApartmanPanel(korisnik, UCMode.Search);

		}

		internal void ChangePanel(Control control)
		{
			pnlMain.Controls.Clear();
			pnlMain.Controls.Add(control);
			control.Dock = DockStyle.Fill;

		}
	}
}
