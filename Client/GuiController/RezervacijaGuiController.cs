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
            ucKreirajRezervaciju.txtApartman.Text = apartman.Naziv;
            ucKreirajRezervaciju.txtDomacinstvo.Text = apartman.Domacinstvo.Naziv;

            if (apartman.ProsecnaOcena == 0) ucKreirajRezervaciju.txtProsecnaOcena.Text = "Jos nema recenzija za apartman!";
            else ucKreirajRezervaciju.txtProsecnaOcena.Text = apartman.ProsecnaOcena.ToString();

            ucKreirajRezervaciju.btnRezervisi.Click += (s, e) =>
                KreirajRezervaciju();

            return ucKreirajRezervaciju;
        }

        private void KreirajRezervaciju()
        {
            DateTime datumDolaska = ucKreirajRezervaciju.cldDatumDolaska.SelectionStart;
            DateTime datumOdlaska = ucKreirajRezervaciju.cldDatumOdlaska.SelectionStart;

            if(datumDolaska.Date <= DateTime.Now.Date)
            {
                MessageBox.Show("Mora se rezervisati najmanje 1 dan unapred!");
            }

            if(datumOdlaska <= datumDolaska)
            {
                MessageBox.Show("Datum odlaska mora biti veci od datuma dolaska!");
                return;
            }

            Rezervacija rezervacija = new Rezervacija()
            {
                Apartman = apartman,
                Domacinstvo = apartman.Domacinstvo,
                ApartmanID = apartman.ApartmanId,
                DatumDo = datumOdlaska,
                DatumOd = datumDolaska,
                DomacinstvoID = apartman.DomacinstvoId,
                Gost = korisnik,
                GostID = korisnik.Id,
                RezervacijaID = korisnik.Ime + korisnik.Prezime + apartman.DomacinstvoId + apartman.ApartmanId
                + datumDolaska.Day + datumDolaska.Month + datumDolaska.Year
                + datumOdlaska.Day + datumOdlaska.Month + datumOdlaska.Year
            };

            bool rezervisan = Communication.Instance.KreirajRezervaciju(rezervacija);

            if(rezervisan)
            {
                MessageBox.Show("Rezervacija uspesno kreirana\n" +
                    $"Apartman: {apartman.Naziv}\nDomacinstvo: {apartman.Domacinstvo.Naziv}\n" +
                    $"Period rezervisanja: {datumDolaska.ToShortDateString()} - {datumOdlaska.ToShortDateString()}\n" +
                    $"Id rezervacije: {rezervacija.RezervacijaID}");
            }
            else
            {
                MessageBox.Show("Doslo je do greske");
            }

        }
    }
}
