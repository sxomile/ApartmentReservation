﻿using Client.Forms;
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
        }

        private FrmMain frmMain;
        private DomacinstvoGUIController domacinstvoGUIController;
        private ApartmanGuiController apartmanGuiController;

        internal void ShowFrmMain(Role uloga)
        {
            frmMain = new FrmMain(uloga);
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

        internal void ShowApartmanPanel()
        {
            frmMain.ChanglePanel(apartmanGuiController.CreateUCApartman());
        }
    }
}
