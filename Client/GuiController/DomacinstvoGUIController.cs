using Client.UserControls;
using Client.UserControls.UCApartman;
using Client.UserControls.UCDomacinstvo;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.GuiController
{
    internal class DomacinstvoGUIController
    {
        private BindingList<Domacinstvo> domacinstva = new BindingList<Domacinstvo>();
        private UserControl ucDomacinstvo;
        internal Control CreateUCDomacinstvo(UCMode mode, Domacinstvo domacinstvo)
        {

            if (mode == UCMode.Create)
            {
                ucDomacinstvo = new UCUpsertDomacinstvo();
                ((UCUpsertDomacinstvo)ucDomacinstvo).dgvApartmani.ColumnCount = 1;
                ((UCUpsertDomacinstvo)ucDomacinstvo).dgvApartmani.Columns[0].HeaderText = "Naziv apartmana";

                foreach (DataGridViewColumn column in ((UCUpsertDomacinstvo)ucDomacinstvo).dgvApartmani.Columns)
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                ((UCUpsertDomacinstvo)ucDomacinstvo).btnOtkazi.Click += (s, e) =>
                    MainCoordinator.Instance.ShowDefault();

                ((UCUpsertDomacinstvo)ucDomacinstvo).btnUpsert.Click += (s, e) =>
                    DodajDomacinstvo(((UCUpsertDomacinstvo)ucDomacinstvo).txtNazivDomacinstva.Text, ((UCUpsertDomacinstvo)ucDomacinstvo).dgvApartmani);

            }
            else if (mode == UCMode.Search)
            {
                domacinstva.Clear();
                ucDomacinstvo = new UCPretraziDomacinstvo();
                BindingList<IEntity> doms = Communication.Instance.GetAllDomacinstvo();

                foreach(IEntity entity in doms)
                {
                    Domacinstvo dom = (Domacinstvo)entity;
                    domacinstva.Add(dom);
                }

                doms.Clear();

                ((UCPretraziDomacinstvo)ucDomacinstvo).dgvDomacinstva.DataSource = domacinstva;
                ((UCPretraziDomacinstvo)ucDomacinstvo).dgvDomacinstva.Columns["DomacinstvoId"].Visible = false;
                ((UCPretraziDomacinstvo)ucDomacinstvo).dgvDomacinstva.Columns["TableName"].Visible = false;
                ((UCPretraziDomacinstvo)ucDomacinstvo).dgvDomacinstva.Columns["Values"].Visible = false;

                ((UCPretraziDomacinstvo)ucDomacinstvo).dgvDomacinstva.Dock = DockStyle.Fill;

                foreach (DataGridViewColumn column in ((UCPretraziDomacinstvo)ucDomacinstvo).dgvDomacinstva.Columns)
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                ((UCPretraziDomacinstvo)ucDomacinstvo).btnPretrazi.Click += (s, e) =>
                    PretraziDomacinstvo(((UCPretraziDomacinstvo)ucDomacinstvo).txtUpit.Text);

                ((UCPretraziDomacinstvo)ucDomacinstvo).btnIzmeniDomacinstvo.Click += (s, e) =>
                    OdaberiDomacinstvo();

            } else if(mode == UCMode.Update)
            {
                ucDomacinstvo = new UCUpsertDomacinstvo();

                ((UCUpsertDomacinstvo)ucDomacinstvo).dgvApartmani.ColumnCount = 3;
                ((UCUpsertDomacinstvo)ucDomacinstvo).dgvApartmani.Columns[0].HeaderText = "Naziv apartmana";
                ((UCUpsertDomacinstvo)ucDomacinstvo).dgvApartmani.Columns[1].HeaderText = "Prosecna ocena";
                ((UCUpsertDomacinstvo)ucDomacinstvo).dgvApartmani.Columns[1].ReadOnly = true;
                ((UCUpsertDomacinstvo)ucDomacinstvo).dgvApartmani.Columns[2].Visible = false;

                foreach (Apartman apt in domacinstvo.Apartmani)
                {
                    ((UCUpsertDomacinstvo)ucDomacinstvo).dgvApartmani.Rows.Add(apt.Naziv, apt.ProsecnaOcena, apt.ApartmanId);
                }

                foreach (DataGridViewColumn column in ((UCUpsertDomacinstvo)ucDomacinstvo).dgvApartmani.Columns)
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                ((UCUpsertDomacinstvo)ucDomacinstvo).txtNazivDomacinstva.Text = domacinstvo.Naziv;

                ((UCUpsertDomacinstvo)ucDomacinstvo).btnUpsert.Text = "Izmeni domacinstvo";

                ((UCUpsertDomacinstvo)ucDomacinstvo).btnOtkazi.Click += (s, e) =>
                    MainCoordinator.Instance.ShowDefault();

                ((UCUpsertDomacinstvo)ucDomacinstvo).btnUpsert.Click += (s, e) =>
                    IzmeniDomacinstvo(((UCUpsertDomacinstvo)ucDomacinstvo).txtNazivDomacinstva.Text, ((UCUpsertDomacinstvo)ucDomacinstvo).dgvApartmani, domacinstvo);
            }

            return ucDomacinstvo;

        }

        private void IzmeniDomacinstvo(string nazivDomacinstva, DataGridView dgvApartmani, Domacinstvo staroDomacinstvo)
        {

            if (((UCUpsertDomacinstvo)ucDomacinstvo).txtNazivDomacinstva.Text == string.Empty)
            {
                MessageBox.Show("Unesi naziv domacinstva!");
                return;
            }


            DialogResult dialog = MessageBox.Show("Da li ste sigurni da zelite da izmenite domacinstvo?", 
                "Izmena domacinstva", MessageBoxButtons.YesNo);

            if(dialog == DialogResult.Yes)
            {
                List<Apartman> apartmani = new List<Apartman>();
                foreach (DataGridViewRow row in dgvApartmani.Rows)
                {
                    if (row.Cells[0].Value != null && !row.IsNewRow && row.Cells[0].Value.ToString() != string.Empty)
                    {
                        Apartman apartman = new Apartman()
                        {
                            Naziv = row.Cells[0].Value.ToString() ?? string.Empty,
                            ProsecnaOcena = (double?)row.Cells[1].Value ?? 0,
                            ApartmanId = (int?)row.Cells[2].Value ?? 0,
                        };

                        apartmani.Add(apartman);
                    } else if (row.Cells[1].Value != null)
                    {
                        Apartman apartman = new Apartman()
                        {
                            Naziv = string.Empty,
                            ProsecnaOcena = (double)row.Cells[1].Value,
                            ApartmanId = (int?)row.Cells[2].Value ?? 0,
                        };

                        apartmani.Add(apartman);
                    }
                }
                ////////////////////////////////////////////////////////////////////
                ///NE DOZVOLI BRISANJE APARTMANA KOJI IMAJU NEKU REZERVACIJU DA SE VEZUJE ZA NJIH
                ///
                /// 
                /// MORAM I BRISATI SVE OCENE KOJE SE VEZUJU ZA ODREDJENI APARTMAN
                ///////////////////////////////////////////////////////////////
                Domacinstvo domacinstvo = new Domacinstvo()
                {
                    Naziv = nazivDomacinstva,
                    Apartmani = apartmani,
                    BrojApartmana = apartmani.Count(),
                    DomacinstvoId = staroDomacinstvo.DomacinstvoId,
                };

                foreach (Apartman apt in domacinstvo.Apartmani)
                {
                    apt.Domacinstvo = domacinstvo;
                }

                bool izmenjeno = Communication.Instance.IzmeniDomacinstvo(domacinstvo, staroDomacinstvo);

                if (izmenjeno)
                {
                    MessageBox.Show("Domacinstvo je uspesno izmenjeno!");
                }
                else
                {
                    MessageBox.Show("Doslo je do greske! Probaj ponovo!");
                }

                MainCoordinator.Instance.ShowDomacinstvoPanel(UCMode.Search);
            }
        }

        private void OdaberiDomacinstvo()
		{
            var obj = ((UCPretraziDomacinstvo)ucDomacinstvo).dgvDomacinstva.SelectedCells[0].RowIndex;
            DataGridViewRow row = ((UCPretraziDomacinstvo)ucDomacinstvo).dgvDomacinstva.Rows[obj];
			if (row.Index != ((UCPretraziDomacinstvo)ucDomacinstvo).dgvDomacinstva.Rows.Count - 1 && row != null)
			{
                Domacinstvo domacinstvo = new Domacinstvo()
                {
                    DomacinstvoId = (int)row.Cells["DomacinstvoId"].Value,
                    Naziv = row.Cells["Naziv"].Value.ToString(),
                    BrojApartmana = (int)row.Cells["BrojApartmana"].Value
                };
                domacinstvo.Apartmani = Communication.Instance.GetApartmentsOfDomacinstvo(domacinstvo);

                MainCoordinator.Instance.ShowDomacinstvoPanel(UCMode.Update, domacinstvo);

			}
			else
			{
				MessageBox.Show("Izaberi polje ili red!");
			}
		}

		private void PretraziDomacinstvo(string upit)
        {
            domacinstva = Communication.Instance.PretraziDomacinstva(upit);
            ((UCPretraziDomacinstvo)ucDomacinstvo).dgvDomacinstva.DataSource = domacinstva;
        }

        internal void DodajDomacinstvo(string naziv, DataGridView dgvApartmani)
        {
            if (((UCUpsertDomacinstvo)ucDomacinstvo).txtNazivDomacinstva.Text == string.Empty)
            {
                MessageBox.Show("Unesi naziv domacinstva!");
                return;
            }

            bool domacinstvo = Communication.Instance.DodajDomacinstvo(naziv, dgvApartmani);

            if(domacinstvo)
            {
                MessageBox.Show("Domacinstvo je uspesno dodato!");
            }
            else
            {
                MessageBox.Show("Doslo je do greske! Probaj ponovo!");
            }

        }


    }
}
