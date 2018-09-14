using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using EFD_REINF.Models;
using System.Xml.Linq;
using EFD_REINF.WsReinf;
using System.ServiceModel;
using System.Configuration;

namespace EFD_REINF.Controllers
{

    public class InformacoesContribuinteControl
    { 
        public string RetornaStatusCliente()
        {
            return "";
        }
        public bool RetornaReinfContribuinte(EmpresaCliente cliente)
        {
            try
            {
                bool acesso = false;           
                string strconTpAmb = ConfigurationManager.AppSettings["TpAmb"].ToString();
                string strconProcEmi = ConfigurationManager.AppSettings["ProcEmi"].ToString();
                string strconVerProc = ConfigurationManager.AppSettings["VerProc"].ToString();
                string strClassTrib = ConfigurationManager.AppSettings["classTrib"].ToString();
                string strindSitPJ = ConfigurationManager.AppSettings["indSitPJ"].ToString();     
                string strCnpjSoftHouse = ConfigurationManager.AppSettings["cnpjSoftHouse"].ToString();
                string strnmRazaoSoftHouse = ConfigurationManager.AppSettings["nmRazao"].ToString();
                string strnmContSoftHouse = ConfigurationManager.AppSettings["nmCont"].ToString();
                string strtelefoneSoftHouse = ConfigurationManager.AppSettings["telefone"].ToString();
                string stremailSoftHouse = ConfigurationManager.AppSettings["email"].ToString();
                string AcordoIsenMulta = "";      
                string impostoretCliente = "";                
                string descricaocliente = "";
                string cpfcnpjraiz = "";            
                string IDEvento = "";       

                using (var infocontribuinte = new WsReinf.ConsultaEFDClient("NetTcpBinding_IConsultaEFD")) 
                {
                     /* FAZ UMA AUTENTICAÇÃO NO SERVIÇO E RETORNA FALSO OU VERDADEIRO */
                   acesso = infocontribuinte.Authenticate(cliente.UsuarioSinacor, cliente.SenhaSinacor,cliente.CodigoEmpresa);   

                   if (acesso == true) 
                    {
                        /* PASSO AS INFORMAÇÕES QUE SÃO OBRIGATORIAS NO REQUEST */

                        EFDRequest request = new EFDRequest()
                        {
                            CodigoEmpresa = Convert.ToInt32(cliente.CodigoEmpresa),
                            DataInicio = cliente.DataInicio,
                            DataFinal = cliente.DataFinal,  
                            
                        };
                        EFDRequestCliente requestcliente = new EFDRequestCliente()
                        {
                            CodigoEmpresa = Convert.ToInt32(cliente.CodigoEmpresa),
                            DataInicio =  cliente.DataInicio,   
                            DataFinal =   cliente.DataFinal,   
                        };
                        EFDRequestInstitucional requestInsitucional = new EFDRequestInstitucional()
                        {
                            CodigoEmpresa = Convert.ToInt32(cliente.CodigoEmpresa)

                        }; 
                       /* CONSULTO LISTA DE RETENÇÃO CLIENTE PASSANDO O REQUEST(DADO ANTERIOR) RETORNANDO A LISTA DE RETENÇÃO */
                       var consulta = infocontribuinte.ConsultaListaRetencaoClientes(request).ListaRetencao;

                       foreach (var retCliente in consulta)
                       {
                           impostoretCliente = Convert.ToString(retCliente.CodigoImposto);
                           descricaocliente = retCliente.DescricaoImposto;
                       } 
                        /* CONSULTO DADOS DO CLIENTE PASSANDO O REQUEST(DADO ANTERIOR) RETORNANDO A LISTA DE RETENÇÃO */
                       var consultaCliente = infocontribuinte.ConsultarDadosClientes(requestcliente).ListaClientes;

                       if (strClassTrib == "60")
                           AcordoIsenMulta = "1";
                       else
                           AcordoIsenMulta = "0";
                      

                       //if (item.TipoPessoa == "J")
                       //{
                       //    item.TipoPessoa = "1";
                       //    cpfcnpjraiz = Convert.ToString(item.CPFCNPJ).Substring(0, 8);
                       //    IDEvento = "ID" + item.TipoPessoa + Convert.ToString(item.CPFCNPJ);//+ cliente.DataInicio;
                       //}  

                       InformacoesContribuinte cont = new InformacoesContribuinte()
                       {
                           ID = IDEvento,
                           TpAmb = strconTpAmb, //1 - Produção e 2 - Produção restrita;
                           ProcEmi = strconProcEmi,
                           VerProc = strconVerProc,
                           TpInsc = "1",
                           NrInsc = cpfcnpjraiz,
                           IniValid = cliente.DataInicio.ToString("yyyy-MM"),
                           FimValid = cliente.DataFinal.ToString("yyyy-MM"),
                           ClassTrib = strClassTrib,
                           IndEscrituracao = cliente.indEscrituracao,
                           IndDesoneracao = cliente.indDesoneracao,
                           IndAcordoIsenMulta = AcordoIsenMulta,
                           IndSitPJ = strindSitPJ,
                           NmCtt = cliente.NomeContatoContri,
                           CpfCtt = cliente.CPFContatoContri,
                           FoneFixo = cliente.TelefoneContatoContr,
                           FoneCel = cliente.CelularContatoContr,
                           Email = cliente.EmailContatoContr,
                           CnpjSoftHouse = strCnpjSoftHouse,
                           NmRazao = strnmRazaoSoftHouse,
                           NmCont = strnmContSoftHouse,
                           FoneFixosoftHouse = strtelefoneSoftHouse,
                           EmailSoftHouse = stremailSoftHouse,
                       };

                       AdicionarXml(cont, cliente.caminho); 
                      
                    }
                    else
                        Console.WriteLine(" Problemas na autenticação", DateTime.Now.ToString());                                   

                }          
            }
            catch (Exception ex)
            {                      
               Console.WriteLine(" 99-Erro na geração do XML" + ex, DateTime.Now.ToString());                
            }
            return true;
        }    
        public bool AdicionarXml(Models.InformacoesContribuinte cont, string caminho)
        {
            //cria uma instância do Produto e atribui valores às propriedades
            InformacoesContribuinte oContribuinte = new InformacoesContribuinte();

            XmlTextWriter writer = new XmlTextWriter(caminho + cont.CpfCtt, System.Text.Encoding.UTF8);
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 4;
            //writer.WriteAttributeString("classificacao", "R");
            writer.WriteStartElement("Reinf", "http://www.reinf.esocial.gov.br/schemas/evtInfoContribuinte/v1_03_02");
            writer.WriteStartElement("EvtInfoContri", cont.ID);
            writer.WriteStartElement("ideEvento");
            writer.WriteElementString("tpAmb",cont.TpAmb);
            writer.WriteElementString("procEmi", cont.ProcEmi);
            writer.WriteElementString("verProc", cont.VerProc);
            writer.WriteEndElement();
            writer.WriteStartElement("ideContri");
            writer.WriteElementString("tpInsc", cont.TpInsc);
            writer.WriteElementString("nrInsc", cont.NrInsc);
            writer.WriteEndElement();
            writer.WriteStartElement("infoContri");
            writer.WriteStartElement("inclusao");
            writer.WriteStartElement("idePeriodo");
            writer.WriteElementString("iniValid", cont.IniValid);
            writer.WriteElementString("fimValid", cont.FimValid);
            writer.WriteEndElement();
            writer.WriteStartElement("infoCadastro");
            writer.WriteElementString("classTrib", cont.ClassTrib);
            writer.WriteElementString("indEscrituracao", cont.IndEscrituracao);
            writer.WriteElementString("indDesoneracao", cont.IndDesoneracao);
            writer.WriteElementString("indAcordoIsenMulta", cont.IndAcordoIsenMulta);
            writer.WriteElementString("indSitPJ",cont.IndSitPJ);
            writer.WriteStartElement("contato");
            writer.WriteElementString("nmCtt", cont.NmCtt);
            writer.WriteElementString("cpfCtt", cont.CpfCtt);
            writer.WriteElementString("foneFixo", cont.FoneFixo);
            writer.WriteElementString("foneCel", cont.FoneCel);
            writer.WriteElementString("email", cont.FoneCel);
            writer.WriteEndElement();
            writer.WriteStartElement("softHouse");
            writer.WriteElementString("cnpjSoftHouse", cont.CnpjSoftHouse);
            writer.WriteElementString("nmRazao", cont.NmRazao);
            writer.WriteElementString("nmCont", cont.NmCont);
            writer.WriteElementString("telefone", cont.FoneFixosoftHouse);
            writer.WriteElementString("email", cont.EmailSoftHouse);
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();   

            return true;
          
        }         
    }
}

