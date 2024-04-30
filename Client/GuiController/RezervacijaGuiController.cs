using Client.UserControls;
using Client.UserControls.UCRezervacija;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.GuiController
{
    internal class RezervacijaGuiController
    {
        private UCKreirajRezervaciju ucKreirajRezervaciju;
        private Apartman apartman;
        private User korisnik;

        internal Control CreateUCRezervacija(UCMode mode, Apartman apartman, User korisnik)
        {
            //Create mode
            ucKreirajRezervaciju = new UCKreirajRezervaciju();
            this.apartman = apartman;
            this.korisnik = korisnik;
            //cita sve

            return ucKreirajRezervaciju;
        }
    }
}
