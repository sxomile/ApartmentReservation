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
        private readonly Role uloga;
        public FrmMain(Role uloga)
        {
            this.uloga = uloga;
            InitializeComponent();

            if(uloga == Role.Gost)
            {

                domacinstvoToolStripMenuItem.Visible = false;

            }
            else
            {
                //ovo usput po potrebi obavezno menjaj
            }

            kreirajDomacinstvoToolStripMenuItem.Click += (s, e) =>
                MainCoordinator.Instance.ShowDomacinstvoPanel(UCMode.Create);

            pretraziDomacinstvaToolStripMenuItem.Click += (s, e) =>
                MainCoordinator.Instance.ShowDomacinstvoPanel(UCMode.Search);

            pretraziApartmaneToolStripMenuItem.Click += (s, e) =>
                MainCoordinator.Instance.ShowApartmanPanel();
        }

        internal void ChanglePanel(Control control)
        {
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(control);
            control.Dock = DockStyle.Fill;
            
        }
    }
}
