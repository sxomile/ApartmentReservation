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

            if(korisnik.Uloga == Role.Gost)
            {

                domacinstvoToolStripMenuItem.Visible = false;

                pretraziRezervacijeToolStripMenuItem.Click += (s, e) =>
                    MainCoordinator.Instance.ShowUCRezervacija(UCMode.Search, korisnik: korisnik);

            }
            else
            {
                pretraziRezervacijeToolStripMenuItem.Click += (s, e) => 
                    MainCoordinator.Instance.ShowUCRezervacija(UCMode.Search);
            }

            kreirajDomacinstvoToolStripMenuItem.Click += (s, e) =>
                MainCoordinator.Instance.ShowDomacinstvoPanel(UCMode.Create);

            pretraziDomacinstvaToolStripMenuItem.Click += (s, e) =>
                MainCoordinator.Instance.ShowDomacinstvoPanel(UCMode.Search);

            pretraziApartmaneToolStripMenuItem.Click += (s, e) =>
                MainCoordinator.Instance.ShowApartmanPanel(korisnik);

        }

        internal void ChangePanel(Control control)
        {
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(control);
            control.Dock = DockStyle.Fill;
            
        }
    }
}
