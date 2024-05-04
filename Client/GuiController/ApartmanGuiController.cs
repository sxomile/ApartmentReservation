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
        private ucPretraziApartman ucPretraziApartman;
        private User korisnik;
        internal Control CreateUCApartman(User korisnik)
        {
            apartmani.Clear();
            ucPretraziApartman = new ucPretraziApartman();
            BindingList<IEntity> apts = Communication.Instance.GetAllApartman();
            foreach (IEntity entity in apts)
            {
                Apartman apt = (Apartman)entity;
                apartmani.Add(apt);
            }
            apts.Clear();

            ucPretraziApartman.dgvApartmani.DataSource = apartmani;
            ucPretraziApartman.dgvApartmani.Columns["TableName"].Visible = false;
            ucPretraziApartman.dgvApartmani.Columns["Values"].Visible = false;
            ucPretraziApartman.dgvApartmani.Columns["ApartmanId"].Visible = false;
            ucPretraziApartman.dgvApartmani.Columns["Domacinstvo"].Visible = false;
            ucPretraziApartman.dgvApartmani.Columns["DomacinstvoID"].Visible = false;


            foreach (DataGridViewColumn column in ucPretraziApartman.dgvApartmani.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            ucPretraziApartman.dgvApartmani.Dock = DockStyle.Fill;

            this.korisnik = korisnik;
            if (korisnik.Uloga == Role.Agent)
            {
                ucPretraziApartman.btnRezervisi.Click += (s, e) =>
                    KreirajRezervacijuPrekoAgenta();
            }
            else
            {
                ucPretraziApartman.btnRezervisi.Click += (s, e) =>
                    KreirajRezervaciju();
            }

            ucPretraziApartman.btnPretrazi.Click += (s, e) =>
                PretraziApartmane(ucPretraziApartman.txtUpit.Text);

            return ucPretraziApartman;
        }

        private void KreirajRezervaciju()
        {
            var obj = ucPretraziApartman.dgvApartmani.SelectedCells[0].RowIndex;
            DataGridViewRow row = ucPretraziApartman.dgvApartmani.Rows[obj];
            if (row.Index != ucPretraziApartman.dgvApartmani.Rows.Count - 1 && row != null)
            {
                Apartman apartman = new Apartman()
                {
                    ApartmanId = (int)row.Cells["ApartmanID"].Value,
                    DomacinstvoId = (int)row.Cells["DomacinstvoID"].Value,
                    Naziv = row.Cells["Naziv"].Value.ToString(),
                    ProsecnaOcena = (double)row.Cells["ProsecnaOcena"].Value,
                };
                Domacinstvo domacinstvo = new Domacinstvo();
                domacinstvo.DomacinstvoId = apartman.DomacinstvoId;
                apartman.Domacinstvo = (Domacinstvo)Communication.Instance.GetEntityById(domacinstvo);
                User korisnik = this.korisnik;
                MainCoordinator.Instance.ShowUCRezervacija(UCMode.Create, apartman,  korisnik);
            }
            else
            {
                MessageBox.Show("Izaberi polje ili red!");
            }
            
        }

        private void KreirajRezervacijuPrekoAgenta()
        {
            var obj = ucPretraziApartman.dgvApartmani.SelectedCells[0].RowIndex;
            DataGridViewRow row = ucPretraziApartman.dgvApartmani.Rows[obj];
            if (row.Index != ucPretraziApartman.dgvApartmani.Rows.Count - 1 && row != null)
            {
                Apartman apartman = new Apartman()
                {
                    ApartmanId = (int)row.Cells["ApartmanID"].Value,
                    DomacinstvoId = (int)row.Cells["DomacinstvoID"].Value,
                    Naziv = row.Cells["Naziv"].Value.ToString(),
                    ProsecnaOcena = (double)row.Cells["ProsecnaOcena"].Value,
                };
                Domacinstvo domacinstvo = new Domacinstvo();
                domacinstvo.DomacinstvoId = apartman.DomacinstvoId;
                apartman.Domacinstvo = (Domacinstvo)Communication.Instance.GetEntityById(domacinstvo);
                User korisnik = null;
                MainCoordinator.Instance.ShowUCRezervacija(UCMode.Create, apartman, korisnik);
            }
            else
            {
                MessageBox.Show("Izaberi polje ili red!");
            }
        }

        private void PretraziApartmane(string upit)
        {
            apartmani = Communication.Instance.PretraziApartmane(upit);
            ucPretraziApartman.dgvApartmani.DataSource = apartmani;
        }
    }
}
