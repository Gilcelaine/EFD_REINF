using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFD_REINF.Models
{
    public static class Helper
    {

    }

    public class Enums
    {
        public enum eCodigoPagamento
        {
            Prêmios_obtidos_em_concursos_e_sorteios,
            Aluguéis_e_royalties
        }

        public static KeyValuePair<string,string> getDescription(eCodigoPagamento name)
        {
            switch (name)
            {
                case eCodigoPagamento.Prêmios_obtidos_em_concursos_e_sorteios:
                    return new KeyValuePair<string,string>("0916",  "Prêmios obtidos em concursos e sorteios");
                case eCodigoPagamento.Aluguéis_e_royalties:
                    return new KeyValuePair<string,string>("3208",  "Aluguéis e royalties");;
                default:
                    return new KeyValuePair<string, string>("0916", "Prêmios obtidos em concursos e sorteios");
            }
        }

    }
}
