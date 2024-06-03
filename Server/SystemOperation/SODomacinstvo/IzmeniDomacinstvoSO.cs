using Common.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation.SODomacinstvo
{
    internal class IzmeniDomacinstvoSO : SystemOperationBase
    {
        private Tuple<Domacinstvo, Domacinstvo> domacinstva = null;
        public bool Result { get; set; } = false;
        public IzmeniDomacinstvoSO(Tuple<Domacinstvo, Domacinstvo> domacinstva)
        {
            this.domacinstva = domacinstva;
        }
        protected override void ExecuteConcreteOperation()
        {
            //item 1 novi, item 2 stari
            //1. deo - brisanje
            int brojObrisanih = 0;
            int brojAptPre = domacinstva.Item2.BrojApartmana;
            List<Apartman> obrisani = new List<Apartman>();

            for(int i = 0; i < domacinstva.Item2.Apartmani.Count();  i++)
            {
                if (domacinstva.Item1.Apartmani[i].Naziv == string.Empty)
                {
                    Ocena ocena = new Ocena() 
                    {
                        ApartmanId = domacinstva.Item2.Apartmani[i].ApartmanId,
                    };
                    broker.Delete(ocena);
                    try
                    {
                        broker.Delete(domacinstva.Item2.Apartmani[i]);
                    } catch(SqlException ex)
                    {
                        Result = false;
                        return;
                    }
                    obrisani.Add(domacinstva.Item2.Apartmani[i]);
                    brojObrisanih++;
                }
            }

            domacinstva.Item1.Apartmani.RemoveAll(a => a.Naziv == string.Empty);
            
            foreach(Apartman o in obrisani)
            {
                domacinstva.Item2.Apartmani.Remove(o);
            }

            domacinstva.Item1.BrojApartmana = domacinstva.Item1.Apartmani.Count();


            //2. deo - izmena podataka o dom

            if (domacinstva.Item1.Naziv != domacinstva.Item2.Naziv)
            {
                broker.Update("Naziv", $"'{domacinstva.Item1.Naziv}'", domacinstva.Item2);
            }

            if(domacinstva.Item1.BrojApartmana != domacinstva.Item2.BrojApartmana)
            {
                broker.Update("BrojApartmana", $"{domacinstva.Item1.BrojApartmana}", domacinstva.Item2);
            }

            //3. deo - logika oko same izmene apartmana
            domacinstva.Item2.BrojApartmana = domacinstva.Item2.Apartmani.Count();

            for (int i = 0; i < domacinstva.Item1.BrojApartmana; i++)
            {
                if(i < domacinstva.Item2.BrojApartmana)
                {
                    broker.Update("Naziv", $"'{domacinstva.Item1.Apartmani[i].Naziv}'", domacinstva.Item2.Apartmani[i]);
                }
                else
                {
                    broker.Add(domacinstva.Item1.Apartmani[i]);
                }
            }

            Result = true;

        }
    }
}
