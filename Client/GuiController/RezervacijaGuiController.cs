using Client.UserControls;
using Client.UserControls.UCApartman;
using Client.UserControls.UCRezervacija;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.GuiController
{
    internal class RezervacijaGuiController
    {
        private UserControl ucRezervacija;
        private Apartman apartman;
        private BindingList<User> gosti = new BindingList<User>();
        private BindingList<Rezervacija> rezervacije = new BindingList<Rezervacija>();
        private User korisnik;

        internal Control CreateUCRezervacija(UCMode mode, Apartman apartman = null, User korisnik = null, Rezervacija reservation = null, bool roleAdmin = false)
        {
            if(mode == UCMode.Create && korisnik.Uloga == Role.Gost)
            {
                //Create mode
                ucRezervacija = new UCKreirajRezervaciju();
                this.apartman = apartman;
                this.korisnik = korisnik;
                //cita sve
                ((UCKreirajRezervaciju)ucRezervacija).txtApartman.Text = apartman.Naziv;
                ((UCKreirajRezervaciju)ucRezervacija).txtDomacinstvo.Text = apartman.Domacinstvo.Naziv;

                if (apartman.ProsecnaOcena == 0) ((UCKreirajRezervaciju)ucRezervacija).txtProsecnaOcena.Text = "Jos nema recenzija za apartman!";
                else ((UCKreirajRezervaciju)ucRezervacija).txtProsecnaOcena.Text = apartman.ProsecnaOcena.ToString();

                ((UCKreirajRezervaciju)ucRezervacija).btnRezervisi.Click += (s, e) =>
                    KreirajRezervaciju();

            } else if(mode == UCMode.Create && korisnik.Uloga == Role.Agent)
            {
                ucRezervacija = new UCKreirajRezervacijuPrekoAgenta();
                gosti.Clear();
                this.apartman = apartman;
                this.korisnik = korisnik;
                ((UCKreirajRezervacijuPrekoAgenta)ucRezervacija).txtApartman.Text = apartman.Naziv;
                ((UCKreirajRezervacijuPrekoAgenta)ucRezervacija).txtDomacinstvo.Text = apartman.Domacinstvo.Naziv;
                if (apartman.ProsecnaOcena == 0) ((UCKreirajRezervacijuPrekoAgenta)ucRezervacija).txtProsecnaOcena.Text = "Jos nema recenzija za apartman!";
                else ((UCKreirajRezervacijuPrekoAgenta)ucRezervacija).txtProsecnaOcena.Text = apartman.ProsecnaOcena.ToString();

                BindingList<IEntity> gosts = Communication.Instance.GetAllGosti();
                foreach(IEntity entity in gosts)
                {
                    User gost = (User)entity;
                    if(gost.Uloga == Role.Gost) gosti.Add(gost);
                }

                gosts.Clear();
                
                ((UCKreirajRezervacijuPrekoAgenta)ucRezervacija).dgvGosti.DataSource = gosti;
                ((UCKreirajRezervacijuPrekoAgenta)ucRezervacija).dgvGosti.Columns["TableName"].Visible = false;
                ((UCKreirajRezervacijuPrekoAgenta)ucRezervacija).dgvGosti.Columns["Values"].Visible = false;
                ((UCKreirajRezervacijuPrekoAgenta)ucRezervacija).dgvGosti.Columns["Password"].Visible = false;
                ((UCKreirajRezervacijuPrekoAgenta)ucRezervacija).dgvGosti.Columns["Id"].Visible = false;
                ((UCKreirajRezervacijuPrekoAgenta)ucRezervacija).dgvGosti.Columns["Uloga"].Visible = false;

                ((UCKreirajRezervacijuPrekoAgenta)ucRezervacija).btnPretraziGosta.Click += (s, e) =>
                    PretraziGosta(((UCKreirajRezervacijuPrekoAgenta)ucRezervacija).txtGost.Text);
                ((UCKreirajRezervacijuPrekoAgenta)ucRezervacija).btnRezervisi.Click += (s, e) =>
                    KreirajRezervacijuPrekoAgenta();
            } else if((mode == UCMode.Search && korisnik == null) || (mode == UCMode.Search && roleAdmin))
            {
                bool isAdmin = true;
                ucRezervacija = new UCPretraziRezervacije();
                rezervacije.Clear();
                ((UCPretraziRezervacije)ucRezervacija).label2.Text = "Kreirane rezervacije: ";
                BindingList<IEntity> rezs = Communication.Instance.UcitajRezervacije();
                foreach (IEntity entity in rezs)
                {
                    Rezervacija rezervacija = (Rezervacija)entity;
                    rezervacije.Add(rezervacija);
                }
                rezs.Clear();

                ((UCPretraziRezervacije)ucRezervacija).dgvRezervacije.DataSource = rezervacije;
                ((UCPretraziRezervacije)ucRezervacija).dgvRezervacije.Columns["DomacinstvoId"].Visible = false;
                ((UCPretraziRezervacije)ucRezervacija).dgvRezervacije.Columns["ApartmanId"].Visible = false;
                ((UCPretraziRezervacije)ucRezervacija).dgvRezervacije.Columns["GostId"].Visible = false;
                ((UCPretraziRezervacije)ucRezervacija).dgvRezervacije.Columns["TableName"].Visible = false;
                ((UCPretraziRezervacije)ucRezervacija).dgvRezervacije.Columns["Values"].Visible = false;

                ((UCPretraziRezervacije)ucRezervacija).btnPretraziRezervacije.Click += (s, e) =>
                    PretraziRezervacije(((UCPretraziRezervacije)ucRezervacija).txtPretraziRezervacije.Text);
                ((UCPretraziRezervacije)ucRezervacija).btnOtkaziRezervaciju.Click += (s, e) =>
                    OtkaziRezervaciju(isAdmin);
            } else if(mode == UCMode.Search && korisnik != null)
            {
                bool isAdmin = false;
                ucRezervacija = new UCPretraziRezervacije();
                rezervacije.Clear();
                this.korisnik = korisnik;
                ((UCPretraziRezervacije)ucRezervacija).label2.Text = "Moje rezervacije: ";
                BindingList<IEntity> rezs = Communication.Instance.UcitajRezervacije();
                foreach (IEntity entity in rezs)
                {
                    Rezervacija rezervacija = (Rezervacija)entity;
                    if(((Rezervacija)entity).GostID == korisnik.Id)
                        rezervacije.Add(rezervacija);
                }
                rezs.Clear();

                ((UCPretraziRezervacije)ucRezervacija).dgvRezervacije.DataSource = rezervacije;
                ((UCPretraziRezervacije)ucRezervacija).dgvRezervacije.Columns["DomacinstvoId"].Visible = false;
                ((UCPretraziRezervacije)ucRezervacija).dgvRezervacije.Columns["ApartmanId"].Visible = false;
                ((UCPretraziRezervacije)ucRezervacija).dgvRezervacije.Columns["GostId"].Visible = false;
                ((UCPretraziRezervacije)ucRezervacija).dgvRezervacije.Columns["TableName"].Visible = false;
                ((UCPretraziRezervacije)ucRezervacija).dgvRezervacije.Columns["Values"].Visible = false;
                ((UCPretraziRezervacije)ucRezervacija).dgvRezervacije.Columns["Gost"].Visible = false;

                ((UCPretraziRezervacije)ucRezervacija).btnPretraziRezervacije.Click += (s, e) =>
                    PretraziRezervacijeKaoGost(((UCPretraziRezervacije)ucRezervacija).txtPretraziRezervacije.Text);
                ((UCPretraziRezervacije)ucRezervacija).btnOtkaziRezervaciju.Click += (s, e) =>
                    OtkaziRezervaciju(isAdmin);
            } else if(mode == UCMode.Delete)
            {
                ucRezervacija = new UCObrisiRezervaciju();
                ((UCObrisiRezervaciju)ucRezervacija).txtApartman.Text = reservation.Apartman.Naziv;
                ((UCObrisiRezervaciju)ucRezervacija).txtDomacinstvo.Text = reservation.Apartman.Naziv;
                ((UCObrisiRezervaciju)ucRezervacija).txtGost.Text = reservation.Gost.Ime + " " + reservation.Gost.Prezime;
                ((UCObrisiRezervaciju)ucRezervacija).txtDatumDolaska.Text = reservation.DatumOd.ToShortDateString();
                ((UCObrisiRezervaciju)ucRezervacija).txtDatumOdlaska.Text = reservation.DatumDo.ToShortDateString();

                ((UCObrisiRezervaciju)ucRezervacija).btnOtkazi.Click += (s, e) =>
                    ObrisiRezervaciju(reservation, roleAdmin);

            }

            return ucRezervacija;
        }

        private void ObrisiRezervaciju(Rezervacija reservation, bool roleAdmin)
        {
            DialogResult dialogResult = MessageBox.Show("Da li ste sigurni da zelite da otkazete rezervaciju?",
                "Otkazivanje", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                if (Communication.Instance.OtkaziRezervaciju(reservation))
                {
                    MessageBox.Show("Rezervacija uspesno otkazana!");
                    MainCoordinator.Instance.ShowUCRezervacija(UCMode.Search, null, this.korisnik, null, roleAdmin);

                }
                else
                {
                    MessageBox.Show("Doslo je do greske!");
                }
            
            }

        }

        private void OtkaziRezervaciju(bool isAdmin)
        {
            var obj = ((UCPretraziRezervacije)ucRezervacija).dgvRezervacije.SelectedCells[0].RowIndex;
            DataGridViewRow row = ((UCPretraziRezervacije)ucRezervacija).dgvRezervacije.Rows[obj];
            if (row.Index != ((UCPretraziRezervacije)ucRezervacija).dgvRezervacije.Rows.Count - 1 && row != null)
            {
                Rezervacija rezervacija = new Rezervacija()
                {
                    RezervacijaID = row.Cells["RezervacijaId"].Value.ToString(),
                    ApartmanID = (int)row.Cells["ApartmanID"].Value,
                    DomacinstvoID = (int)row.Cells["DomacinstvoID"].Value,
                    GostID = (int)row.Cells["GostID"].Value,
                    DatumOd = (DateTime)row.Cells["DatumOd"].Value,
                    DatumDo = (DateTime)row.Cells["DatumDo"].Value,
                };
                Domacinstvo domacinstvo = new Domacinstvo();
                Apartman apartman = new Apartman();
                User gost = new User();
                domacinstvo.DomacinstvoId = rezervacija.DomacinstvoID;
                apartman.ApartmanId = rezervacija.ApartmanID;
                gost.Id = rezervacija.GostID;
                rezervacija.Domacinstvo = Communication.Instance.GetDomacinstvoById(domacinstvo);
                rezervacija.Apartman = Communication.Instance.GetApartmanById (apartman);
                rezervacija.Gost = Communication.Instance.GetGostById(gost);
                //User korisnik = this.korisnik;
                MainCoordinator.Instance.ShowUCRezervacija(UCMode.Delete, rezervacija: rezervacija, isAdmin: isAdmin);
            }
            else
            {
                MessageBox.Show("Izaberi polje ili red!");
            }
        }

        private void PretraziRezervacijeKaoGost(string upit)
        {
            rezervacije.Clear();
            BindingList<Rezervacija> rezs = Communication.Instance.PretraziRezervacije(upit);
            foreach(Rezervacija r in rezs)
            {
                if(r.GostID == korisnik.Id) rezervacije.Add(r);
            }
            rezs.Clear();
            ((UCPretraziRezervacije)ucRezervacija).dgvRezervacije.DataSource = rezervacije;
        }

        private void PretraziRezervacije(string upit)
        {
            rezervacije = Communication.Instance.PretraziRezervacije(upit);
            ((UCPretraziRezervacije)ucRezervacija).dgvRezervacije.DataSource = rezervacije;
        }

        private void PretraziGosta(string upit)
        {
            gosti = Communication.Instance.PretraziGoste(upit);
            ((UCKreirajRezervacijuPrekoAgenta)ucRezervacija).dgvGosti.DataSource = gosti;
        }

        private void KreirajRezervacijuPrekoAgenta()
        {
            DateTime datumDolaska = ((UCKreirajRezervacijuPrekoAgenta)ucRezervacija).cldDatumDolaska.SelectionStart;
            DateTime datumOdlaska = ((UCKreirajRezervacijuPrekoAgenta)ucRezervacija).cldDatumOdlaska.SelectionStart;
            var obj = ((UCKreirajRezervacijuPrekoAgenta)ucRezervacija).dgvGosti.SelectedCells[0].RowIndex;
            DataGridViewRow row = ((UCKreirajRezervacijuPrekoAgenta)ucRezervacija).dgvGosti.Rows[obj];

            if (row.Index != ((UCKreirajRezervacijuPrekoAgenta)ucRezervacija).dgvGosti.Rows.Count - 1
                && row != null)
            {
                User gost = new User()
                {
                    Id = (int)row.Cells["Id"].Value,
                    Username = row.Cells["Username"].Value.ToString(),
                    Ime = row.Cells["Ime"].Value.ToString(),
                    Prezime = row.Cells["Prezime"].Value.ToString(),
                };

                korisnik = gost;

                //MessageBox.Show(korisnik.Ime + " " + korisnik.Prezime + " " + korisnik.Username + " " + korisnik.Id);
            }
            else
            {
                MessageBox.Show("Odaberi korisnika!");
                return;
            }

            if (datumDolaska.Date <= DateTime.Now.Date)
            {
                MessageBox.Show("Mora se rezervisati najmanje 1 dan unapred!");
                return;
            }
            
            if (datumOdlaska <= datumDolaska)
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

            if (rezervisan)
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

        private void KreirajRezervaciju()
        {
            DateTime datumDolaska = ((UCKreirajRezervaciju)ucRezervacija).cldDatumDolaska.SelectionStart;
            DateTime datumOdlaska = ((UCKreirajRezervaciju)ucRezervacija).cldDatumOdlaska.SelectionStart;

            if(datumDolaska.Date <= DateTime.Now.Date)
            {
                MessageBox.Show("Mora se rezervisati najmanje 1 dan unapred!");
                return;
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

            bool slobodan = Communication.Instance.KreirajRezervaciju(rezervacija);

            if(slobodan)
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
