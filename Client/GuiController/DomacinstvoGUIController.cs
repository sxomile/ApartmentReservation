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
            }
            else if (mode == UCMode.Update)
            {
                //Azuriraj korisnika uc
            }

            ucDomacinstvo.dgvApartmani.ColumnCount = 1;
            ucDomacinstvo.dgvApartmani.Columns[0].HeaderText = "Naziv apartmana";

            return ucDomacinstvo;

        }


    }
}
