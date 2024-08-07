﻿using Common.Domain;
using DBBroker;
using Server.SystemOperation.SOApartman;
using Server.SystemOperation.SODomacinstvo;
using Server.SystemOperation.SOGost;
using Server.SystemOperation.SOLogin;
using Server.SystemOperation.SOOcena;
using Server.SystemOperation.SORezervacija;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Controller
    {
        private static Controller _instance;
        public static Controller Instance {  get { if (_instance == null) _instance = new Controller(); return _instance; } }

        internal object DodajDomacinstvo(Domacinstvo domacinstvo)
        {
            DodajDomacinstvoSO dodajDomacinstvoSO = new DodajDomacinstvoSO(domacinstvo);
            dodajDomacinstvoSO.ExecuteTemplate();
            return dodajDomacinstvoSO.Result;
        }

        internal object GetAllApartman()
        {
            UcitajApartmaneSO ucitajApartmaneSO = new UcitajApartmaneSO();
            ucitajApartmaneSO.ExecuteTemplate();
            return ucitajApartmaneSO.Result;
        }

        internal object GetAllDomacinstvo()
        {
            UcitajDomacinstvaSO ucitajDomacinstvaSO = new UcitajDomacinstvaSO();
            ucitajDomacinstvaSO.ExecuteTemplate();
            return ucitajDomacinstvaSO.Result;
        }

        internal object GetAllGosti()
        {
            UcitajGosteSO ucitajGosteSO = new UcitajGosteSO();
            ucitajGosteSO.ExecuteTemplate();
            return ucitajGosteSO.Result;
        }

        internal object GetAllRezervacije()
        {
            UcitajRezervacijeSO ucitajRezervacijeSO = new UcitajRezervacijeSO();
            ucitajRezervacijeSO.ExecuteTemplate();
            return ucitajRezervacijeSO.Result;
        }

        internal object GetApartmentsOfDomacinstvo(Domacinstvo domacinstvo)
        {
            UcitajApartmaneDomacinstvaSO ucitajApartmaneDomacinstvaSO = new UcitajApartmaneDomacinstvaSO(domacinstvo);
            ucitajApartmaneDomacinstvaSO.ExecuteTemplate();
            return ucitajApartmaneDomacinstvaSO.Result.Cast<Apartman>().ToList();
        }

        internal object GetApartmanById(IEntity argument)
        {
            GetApartmanByIdSO getApartmanByIdSO = new GetApartmanByIdSO(argument);
            getApartmanByIdSO.ExecuteTemplate();
            return getApartmanByIdSO.Result;
        }

        internal object GetDomacinstvoById(IEntity argument)
        {
            GetDomacinstvoByIdSO getDomacinstvoByIdSO = new GetDomacinstvoByIdSO(argument);
            getDomacinstvoByIdSO.ExecuteTemplate();
            return getDomacinstvoByIdSO.Result;
        }

        internal object GetGostById(IEntity argument)
        {
            GetGostByIdSO getGostByIdSO = new GetGostByIdSO(argument);
            getGostByIdSO.ExecuteTemplate();
            return getGostByIdSO.Result;
        }

        internal object IzmeniDomacinstvo(Tuple<Domacinstvo, Domacinstvo> argument)
        {
            IzmeniDomacinstvoSO izmeniDomacinstvoSO = new IzmeniDomacinstvoSO(argument);
            izmeniDomacinstvoSO.ExecuteTemplate();
            return izmeniDomacinstvoSO.Result;
        }

        internal object KreirajRezervaciju(Rezervacija argument)
        {
            KreirajRezervacijuSO kreirajRezervacijuSO = new KreirajRezervacijuSO(argument);
            kreirajRezervacijuSO.ExecuteTemplate();
            return kreirajRezervacijuSO.Result;
        }

        internal object Login(User korisnik)
        {
            LoginSO loginSO = new LoginSO(korisnik);
            loginSO.ExecuteTemplate();
            return (User)loginSO.Result;
        }

        internal object OceniApartman(Ocena ocena)
        {
            OceniApartmanSO oceniApartmanSO = new OceniApartmanSO(ocena);
            oceniApartmanSO.ExecuteTemplate();
            return oceniApartmanSO.Result;
        }

        internal object OtkaziRezervaciju(Rezervacija rezervacija)
        {
            OtkaziRezervacijuSO otkaziRezervacijuSO = new OtkaziRezervacijuSO(rezervacija);
            otkaziRezervacijuSO.ExecuteTemplate();
            return otkaziRezervacijuSO.Result;
        }

        internal object PretraziApartmane(string argument)
        {
            PretraziApartmaneSO pretraziApartmaneSO = new PretraziApartmaneSO(argument);
            pretraziApartmaneSO.ExecuteTemplate();
            return pretraziApartmaneSO.Result.Cast<Apartman>().ToList();
        }

        internal object PretraziDomacinstva(string argument)
        {
            PretraziDomacinstvaSO pretraziDomacinstvaSO = new PretraziDomacinstvaSO(argument);
            pretraziDomacinstvaSO.ExecuteTemplate();
            return pretraziDomacinstvaSO.Result.Cast<Domacinstvo>().ToList();
        }

        internal object PretraziGoste(string upit)
        {
            PretraziGosteSO pretraziGosteSO = new PretraziGosteSO(upit);
            pretraziGosteSO.ExecuteTemplate();
            return pretraziGosteSO.Result.Cast<User>().ToList();
        }

        internal object PretraziRezervacije(string upit)
        {
            PretraziRezervacijeSO pretraziRezervacijeSO = new PretraziRezervacijeSO(upit);
            pretraziRezervacijeSO.ExecuteTemplate();
            return pretraziRezervacijeSO.Result.Cast<Rezervacija>().ToList();
        }
    }
}
