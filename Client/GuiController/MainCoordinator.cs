using Client.Forms;
using Client.UserControls;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.GuiController
{
    internal class MainCoordinator
    {
        private static MainCoordinator instance;
        public static MainCoordinator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MainCoordinator();
                }
                return instance;
            }
        }

        public MainCoordinator()
        {
            //instancirati sve GUI kontrolere osim logina
            domacinstvoGUIController = new DomacinstvoGUIController();
            apartmanGuiController = new ApartmanGuiController();
            rezervacijaGuiController = new RezervacijaGuiController();
            
        }

        private FrmMain frmMain;
        private DomacinstvoGUIController domacinstvoGUIController;
        private ApartmanGuiController apartmanGuiController;
        private RezervacijaGuiController rezervacijaGuiController;

        internal void ShowFrmMain(User korisnik)
        {
            frmMain = new FrmMain(korisnik);
            frmMain.ShowDialog();
        }

        internal void ShowDomacinstvoPanel(UCMode mode, Domacinstvo domacinstvo = null)
        {
            frmMain.ChanglePanel(domacinstvoGUIController.CreateUCDomacinstvo(mode, domacinstvo));
        }

        internal void ShowDefault()
        {
            UCDefault ucDefault = new UCDefault();  
            frmMain.ChanglePanel(ucDefault);
        }

        internal void ShowApartmanPanel(User korisnik)
        {
            frmMain.ChanglePanel(apartmanGuiController.CreateUCApartman(korisnik));
        }

        internal void ShowUCRezervacija(UCMode mode, Apartman apartman = null, User korisnik = null)
        {
            frmMain.ChanglePanel(rezervacijaGuiController.CreateUCRezervacija(mode, apartman, korisnik));
        }
    }
}
