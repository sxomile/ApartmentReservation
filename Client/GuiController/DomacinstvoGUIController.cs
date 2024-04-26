using Client.UserControls;
using Client.UserControls.UCDomacinstvo;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.GuiController
{
    internal class DomacinstvoGUIController
    {
        private UCDomacinstvo ucDomacinstvo;
        internal Control CreateUCProdavac(UCMode mode, Domacinstvo domacinstvo)
        {
            ucDomacinstvo = new UCDomacinstvo();

            if (mode == UCMode.Create)
            {
                ucDomacinstvo.btnOtkazi.Click += (s, e) =>
                    MainCoordinator.Instance.ShowDefault();

                ucDomacinstvo.btnDodaj.Click += (s, e) =>
                    DodajDomacinstvo(ucDomacinstvo.txtNazivDomacinstva.Text, ucDomacinstvo.dgvApartmani);

            }
            else if (mode == UCMode.Update)
            {
                //Azuriraj korisnika uc
            }

            ucDomacinstvo.dgvApartmani.ColumnCount = 1;
            ucDomacinstvo.dgvApartmani.Columns[0].HeaderText = "Naziv apartmana";

            foreach (DataGridViewColumn column in ucDomacinstvo.dgvApartmani.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            return ucDomacinstvo;

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
