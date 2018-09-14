using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFD_REINF.Models
{
    public class EmpresaCliente
    {
        public int CodigoEmpresa { get; set; }
        public string Dominio { get; set; }
        public string UsuarioSinacor { get; set; }
        public string SenhaSinacor { get; set; }
        public string Produto { get; set; }
        public string caminho { get; set; }
        public string Ano { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFinal { get; set; }
        public string indDesoneracao { get; set; }
        public string indEscrituracao { get; set; }
        public string NomeContatoContri { get; set; }
        public string CPFContatoContri { get; set; }
        public string TelefoneContatoContr { get; set; }
        public string CelularContatoContr { get; set; }
        public string EmailContatoContr { get; set; }
        public string Retifico { get; set; } 
        public string Recibo { get; set; } 
    }
  
}
