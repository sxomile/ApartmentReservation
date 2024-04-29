using Client.UserControls;
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

                ((UCUpsertDomacinstvo)ucDomacinstvo).btnDodaj.Click += (s, e) =>
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

            }

            return ucDomacinstvo;

        }

        private void PretraziDomacinstvo(string upit)
        {
            domacinstva = Communication.Instance.PretraziDomacinstva(upit);
            ((UCPretraziDomacinstvo)ucDomacinstvo).dgvDomacinstva.DataSource = domacinstva;
        }

        internal void DodajDomacinstvo(string naziv, DataGridView dgvApartmani)
        {
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
