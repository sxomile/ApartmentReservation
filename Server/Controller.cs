using Common.Domain;
using DBBroker;
using Server.SystemOperation.SOApartman;
using Server.SystemOperation.SODomacinstvo;
using Server.SystemOperation.SOEntity;
using Server.SystemOperation.SOLogin;
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

        internal IEntity GetEntityById(IEntity argument)
        {
            GetEntityByIdSO getEntityByIdSO = new GetEntityByIdSO(argument);
            getEntityByIdSO.ExecuteTemplate();
            return getEntityByIdSO.Result;
        }

        internal object Login(User korisnik)
        {
            LoginSO loginSO = new LoginSO(korisnik);
            loginSO.ExecuteTemplate();
            return loginSO.Result;
        }

        internal object PretraziApartmane(string argument)
        {
            PretraziApartmaneSO pretraziApartmaneSO = new PretraziApartmaneSO(argument);
            pretraziApartmaneSO.ExecuteTemplate();
            return pretraziApartmaneSO.Result;
        }

        internal object PretraziDomacinstva(string argument)
        {
            PretraziDomacinstvaSO pretraziDomacinstvaSO = new PretraziDomacinstvaSO(argument);
            pretraziDomacinstvaSO.ExecuteTemplate();
            return pretraziDomacinstvaSO.Result;
        }
    }
}
