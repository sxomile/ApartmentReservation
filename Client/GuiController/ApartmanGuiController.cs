using Client.UserControls;
using Client.UserControls.UCApartman;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.GuiController
{
    internal class ApartmanGuiController
    {
        private BindingList<Apartman> apartmani = new BindingList<Apartman>();
        private UserControl ucApartman;
        private User korisnik;
        private Apartman apartman = new Apartman();
        internal Control CreateUCApartman(User korisnik, UCMode mode)
        {
			apartmani.Clear();

			PrepareFormApartman(korisnik, mode);
            if(mode == UCMode.Search)
            {


				if (korisnik.Uloga == Role.Agent)
				{
					((ucPretraziApartman)ucApartman).btnRezervisi.Click += (s, e) =>
						KreirajRezervacijuPrekoAgenta();
				}
				else
				{
					((ucPretraziApartman)ucApartman).btnRezervisi.Click += (s, e) =>
						KreirajRezervaciju();
				}

				((ucPretraziApartman)ucApartman).btnPretrazi.Click += (s, e) =>
					PretraziApartmane(((ucPretraziApartman)ucApartman).txtUpit.Text);

				((ucPretraziApartman)ucApartman).btnPrikaziDetalje.Click += (s, e) =>
					PrikaziDetalje();

				((ucPretraziApartman)ucApartman).btnOceni.Click += (s, e) =>
					OceniApartman();


			} else if(mode == UCMode.Show)
            {

			}

            return ucApartman;
        }

		private void PrikaziDetalje()
		{
			var obj = ((ucPretraziApartman)ucApartman).dgvApartmani.SelectedCells[0].RowIndex;
			DataGridViewRow row = ((ucPretraziApartman)ucApartman).dgvApartmani.Rows[obj];
			if (row.Index != ((ucPretraziApartman)ucApartman).dgvApartmani.Rows.Count - 1 && row != null)
			{
                Apartman apartman = Communication.Instance.GetApartmanById
                    (new Apartman{ApartmanId = (int)row.Cells["ApartmanID"].Value});

				User korisnik = this.korisnik;
                this.apartman = apartman;
				MainCoordinator.Instance.ShowApartmanPanel(korisnik, UCMode.Show);
				MessageBox.Show("Sistem je ucitao apartman");
			}
			else
			{
				MessageBox.Show("Izaberi polje ili red!");
			}
		}

		private void PrepareFormApartman(User korisnik, UCMode mode)
		{
			if(mode == UCMode.Search)
            {
				ucApartman = new ucPretraziApartman();
				if (korisnik.Uloga == Role.Agent)
				{
					((ucPretraziApartman)ucApartman).btnOceni.Visible = false;
				}
				BindingList<IEntity> apts = Communication.Instance.GetAllApartman();
				foreach (IEntity entity in apts)
				{
					Apartman apt = (Apartman)entity;
					apartmani.Add(apt);
				}
				apts.Clear();

				((ucPretraziApartman)ucApartman).dgvApartmani.DataSource = apartmani;
				((ucPretraziApartman)ucApartman).dgvApartmani.Columns["TableName"].Visible = false;
				((ucPretraziApartman)ucApartman).dgvApartmani.Columns["Values"].Visible = false;
				((ucPretraziApartman)ucApartman).dgvApartmani.Columns["ApartmanId"].Visible = false;
				((ucPretraziApartman)ucApartman).dgvApartmani.Columns["Domacinstvo"].Visible = false;
				((ucPretraziApartman)ucApartman).dgvApartmani.Columns["DomacinstvoID"].Visible = false;


				foreach (DataGridViewColumn column in ((ucPretraziApartman)ucApartman).dgvApartmani.Columns)
				{
					column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
				}

				((ucPretraziApartman)ucApartman).dgvApartmani.Dock = DockStyle.Fill;

				this.korisnik = korisnik;
			} else if(mode == UCMode.Show)
            {
                ucApartman = new UCApartmanDetails();
                ((UCApartmanDetails)ucApartman).txtApartman.Text = apartman.Naziv;
                ((UCApartmanDetails)ucApartman).txtDomacinstvo.Text = apartman.Domacinstvo.Naziv;
                if(apartman.ProsecnaOcena != 0)
                {
					((UCApartmanDetails)ucApartman).txtProsecnaOcena.Text = apartman.ProsecnaOcena.ToString();
                }
                else
                {
					((UCApartmanDetails)ucApartman).txtProsecnaOcena.Text = "Jos nema ocena za izabrani apartman";
				}
			}
		}

		private void OceniApartman()
        {
            var obj = ((ucPretraziApartman)ucApartman).dgvApartmani.SelectedCells[0].RowIndex;
            DataGridViewRow row = ((ucPretraziApartman)ucApartman).dgvApartmani.Rows[obj];
            if (row.Index != ((ucPretraziApartman)ucApartman).dgvApartmani.Rows.Count - 1 && row != null)
            {
                Apartman apartman = Communication.Instance.GetApartmanById
                    (new Apartman { ApartmanId = (int)row.Cells["ApartmanID"].Value });
                User korisnik = this.korisnik;
                MainCoordinator.Instance.ShowUCOceni(apartman, korisnik);
                MessageBox.Show("Sistem je ucitao apartman");
            }
            else
            {
                MessageBox.Show("Izaberi polje ili red!");
            }
        }

        private void KreirajRezervaciju()
        {
            var obj = ((ucPretraziApartman)ucApartman).dgvApartmani.SelectedCells[0].RowIndex;
            DataGridViewRow row = ((ucPretraziApartman)ucApartman).dgvApartmani.Rows[obj];
            if (row.Index != ((ucPretraziApartman)ucApartman).dgvApartmani.Rows.Count - 1 && row != null)
            {
				Apartman apartman = Communication.Instance.GetApartmanById
					(new Apartman { ApartmanId = (int)row.Cells["ApartmanID"].Value });
				User korisnik = this.korisnik;
                MainCoordinator.Instance.ShowUCRezervacija(UCMode.Create, korisnik,  apartman);
            }
            else
            {
                MessageBox.Show("Izaberi polje ili red!");
            }
            
        }

        private void KreirajRezervacijuPrekoAgenta()
        {
            var obj = ((ucPretraziApartman)ucApartman).dgvApartmani.SelectedCells[0].RowIndex;
            DataGridViewRow row = ((ucPretraziApartman)ucApartman).dgvApartmani.Rows[obj];
            if (row.Index != ((ucPretraziApartman)ucApartman).dgvApartmani.Rows.Count - 1 && row != null)
            {
				Apartman apartman = Communication.Instance.GetApartmanById
					(new Apartman { ApartmanId = (int)row.Cells["ApartmanID"].Value });
				MainCoordinator.Instance.ShowUCRezervacija(UCMode.Create, korisnik, apartman);
            }
            else
            {
                MessageBox.Show("Izaberi polje ili red!");
            }
        }

        private void PretraziApartmane(string upit)
        {
            apartmani = Communication.Instance.PretraziApartmane(upit);
			((ucPretraziApartman)ucApartman).dgvApartmani.DataSource = apartmani;
            if(apartmani.Count > 0)
            {
				MessageBox.Show("Sistem je nasao apartmane po zadatoj vrednosti!");
            }
            else
            {
				MessageBox.Show("Sistem ne moze da nadje apartmane po zadatoj vrednosti!");
			}
		}
    }
}
