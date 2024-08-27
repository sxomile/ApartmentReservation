using Client.Forms;
using Client.UserControls;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            //instancira sve GUI kontrolere osim logina
            domacinstvoGUIController = new DomacinstvoGUIController();
            apartmanGuiController = new ApartmanGuiController();
            rezervacijaGuiController = new RezervacijaGuiController();
            ocenaGuiController = new OcenaGuiController();
            
        }

        private FrmMain frmMain;
        private DomacinstvoGUIController domacinstvoGUIController;
        private ApartmanGuiController apartmanGuiController;
        private RezervacijaGuiController rezervacijaGuiController;
        private OcenaGuiController ocenaGuiController;

        internal void ShowFrmMain(User korisnik)
        {
            frmMain = new FrmMain(korisnik);
            frmMain.ShowDialog();
        }

        internal void ShowDomacinstvoPanel(UCMode mode, Domacinstvo domacinstvo = null)
        {
            frmMain.ChangePanel(domacinstvoGUIController.CreateUCDomacinstvo(mode, domacinstvo));
        }

        internal void ShowDefault()
        {
            UCDefault ucDefault = new UCDefault();  
            frmMain.ChangePanel(ucDefault);
        }

        internal void ShowApartmanPanel(User korisnik, UCMode mode)
        {
            frmMain.ChangePanel(apartmanGuiController.CreateUCApartman(korisnik, mode));
        }

        internal void ShowUCRezervacija(UCMode mode, User korisnik, Apartman apartman = null, Rezervacija rezervacija = null)
        {
            frmMain.ChangePanel(rezervacijaGuiController.CreateUCRezervacija(mode, korisnik, apartman, rezervacija));

		}

		internal void ShowUCOceni(Apartman apartman, User korisnik)
        {
            frmMain.ChangePanel(ocenaGuiController.CreateUCOcena(apartman, korisnik));
        }
    }
}
