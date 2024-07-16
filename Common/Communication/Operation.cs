using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Communication
{
    public enum Operation
    {
        Login,
        DodajDomacinstvo,
        GetAllDomacinstvo,
        PretraziDomacinstva,
        GetAllApartman,
        PretraziApartmane,
        GetApartmanById,
        KreirajRezervaciju,
        GetAllGosti,
        PretraziGoste,
        GetAllRezervacije,
        PretraziRezervacije,
        Oceni,
        OtkaziRezervaciju,
        GetApartmentsOfDomacinstvo,
        IzmeniDomacinstvo,
		GetDomacinstvoById,
		GetGostById
	}
}
