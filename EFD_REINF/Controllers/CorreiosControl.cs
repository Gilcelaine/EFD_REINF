using EFD_REINF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EFD_REINF.Controllers
{
    public class CorreiosControl
    {
        public bool RetornaCorreio(Cep cep)
        {          
            using (var correios = new WsCorreios.AtendeClienteClient())
            {
                var consulta = correios.consultaCEP(cep.Codigo.Replace("-", ""));

                if (consulta != null)
                {
                    Endereco endereco = new Endereco()
                    {
                        Descricao = consulta.end,
                        Complemento = consulta.complemento,
                        Bairro = consulta.bairro,
                        Cidade = consulta.cidade,
                        UF = consulta.uf
                    };
                   
                    AdicionarCorreio(endereco);                    
                }               
            }
            return true;
           
        }
        public bool AdicionarCorreio(Models.Endereco end)
        {

            XElement x = new XElement("correios");
            x.Add(new XAttribute("uf", end.UF.ToString()));
            x.Add(new XAttribute("cidade", end.Cidade.ToString()));
            x.Add(new XAttribute("bairro", end.Bairro));
            x.Add(new XAttribute("complemento", end.Complemento));
            x.Add(new XAttribute("descricao", end.Descricao));

            x.Save("C://PROJETOS//02- EFD_REINF//3-CODIGO FONTE//Correio//Clientes.xml");

            return true;
            //XElement xml = XElement.Load("correio.xml");
            //xml.Add(x);
            //xml.Save("correio.xml");
        }
       
    }
}
