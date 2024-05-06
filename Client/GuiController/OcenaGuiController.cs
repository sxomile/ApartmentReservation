using Client.UserControls.UCOcena;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.GuiController
{
    internal class OcenaGuiController
    {
        private UCOceni ucOceni;
        private Apartman apartman;
        private User korisnik;
        internal Control CreateUCOcena(Apartman apartman, User korisnik)
        {
            ucOceni = new UCOceni();
            this.apartman = apartman;
            this.korisnik = korisnik;

            ucOceni.txtApartman.Text = apartman.Naziv;
            ucOceni.txtDomacinstvo.Text = apartman.Domacinstvo.Naziv;

            ucOceni.btnOceni.Click += (s, e) =>
                OceniApartman(apartman, korisnik, ucOceni.comboBox1.SelectedItem?.ToString());

            return ucOceni;
        }

        private void OceniApartman(Apartman apartman, User korisnik, object selectedItem = null)
        {
            if(selectedItem != null && selectedItem.ToString() != string.Empty)
            {
                Ocena ocena = new Ocena()
                {
                    Apartman = apartman,
                    ApartmanId = apartman.ApartmanId,
                    Domacinstvo = apartman.Domacinstvo,
                    DomacinstvoId = apartman.DomacinstvoId,
                    Gost = korisnik,
                    GostId = korisnik.Id,
                    OcenaApartmana = int.Parse(selectedItem.ToString())
                };
                if (Communication.Instance.OceniApartman(ocena))
                {
                    MessageBox.Show("Ocena uspesno zabelezena!");
                }
                else
                {
                    MessageBox.Show("Apartman vec ocenjen! Moguce je ostaviti samo jednu ocenu!");
                }
                
                MainCoordinator.Instance.ShowApartmanPanel(korisnik);
                 
            }
            else
            {
                MessageBox.Show("Izaberi ocenu!");
            }
        }
    }
}
