using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFD_REINF.Models;
using System.Xml;
using EFD_REINF.WsReinf;
using System.ServiceModel;
using System.Configuration;


namespace EFD_REINF.Controllers
{
    public class RetencoesFonteControl
    {
       
        /// <summary>
        /// Método responsável por retornar as informações do Serviço e montar xml das Retenções da fonte
        /// Analista: Gilcelaine
        /// Data: 04-09-2018
        /// </summary>
        /// <param name="dto">EmpresaCliente cliente</param>
        /// 
        public bool RetornaReinfFonte(EmpresaCliente cliente)
        {
            try
            {
                var codPagamento = Models.Enums.getDescription( Models.Enums.eCodigoPagamento.Aluguéis_e_royalties);
                

                bool acesso = false;
                string nomearquivo = "";
                string strconTpAmb = ConfigurationManager.AppSettings["TpAmb"].ToString();
                string strconProcEmi = ConfigurationManager.AppSettings["ProcEmi"].ToString();
                string strconVerProc = ConfigurationManager.AppSettings["VerProc"].ToString();  
                //string strindRetif = ConfigurationManager.AppSettings["indRetif"].ToString();                
                string strtipoInscricao= "";
                

                using (var infocontribuinte = new WsReinf.ConsultaEFDClient("NetTcpBinding_IConsultaEFD"))
                {
                    /* FAZ UMA AUTENTICAÇÃO NO SERVIÇO E RETORNA FALSO OU VERDADEIRO */
                    acesso = infocontribuinte.Authenticate(cliente.UsuarioSinacor, cliente.SenhaSinacor, cliente.CodigoEmpresa);

                    if (acesso == true)
                    {
                        /* PASSO AS INFORMAÇÕES QUE SÃO OBRIGATORIAS NO REQUEST */

                        EFDRequest request = new EFDRequest()
                        {
                            CodigoEmpresa = Convert.ToInt32(cliente.CodigoEmpresa),
                            DataInicio = DateTime.Now.Date,
                            DataFinal = DateTime.Now.AddDays(1).Date,

                        };
                        EFDRequestCliente requestcliente = new EFDRequestCliente()
                        {
                            CodigoEmpresa = Convert.ToInt32(cliente.CodigoEmpresa),
                            DataInicio = DateTime.Now,
                            DataFinal = DateTime.Now
                        };
                        
                           EFDRequestInstitucional requestInstitucional = new EFDRequestInstitucional()
                        {
                            CodigoEmpresa = Convert.ToInt32(cliente.CodigoEmpresa),
                            DataInicio = DateTime.Now,
                            DataFinal = DateTime.Now
                        };                                            


                        /* CONSULTO LISTA DE RETENÇÃO CLIENTE PASSANDO O REQUEST(DADO ANTERIOR) RETORNANDO A LISTA DE RETENÇÃO */
                        var consulta = infocontribuinte.ConsultaListaRetencaoClientes(request).ListaRetencao;
                        if (consulta != null && consulta.Length > 0)
                        {

                            foreach (var retCliente in consulta)
                            {
                                string imposto = Convert.ToString(retCliente.CodigoImposto);
                                string a = retCliente.DescricaoImposto;
                            }

                        } 
                        /* CONSULTO DADOS DA INSTITUIÇÃO REQUEST INSTITUIÇÃO (DADO ANTERIOR) RETORNANDO A LISTA DE INSTITUIÇÃO */
                        var consultaInstitucional = infocontribuinte.ConsultarDadosInstituicoes(requestInstitucional).ListaInstituicoes;
                        if (consultaInstitucional != null && consultaInstitucional.Length > 0)
                        {
                            foreach (var retInst in consultaInstitucional)
                            {
                                string imposto = Convert.ToString(retInst.ImpostoInstitucional);
                                string Nome = retInst.Nome;
                                string TipoPessoa = retInst.TipoPessoa;
                                string cnpj = Convert.ToString(retInst.CPFCNPJ);
                                string logradouro = retInst.Endereco.Logradouro;
                                string cidade = retInst.Endereco.Cidade;
                                string bairro = retInst.Endereco.Bairro;
                                string estado = retInst.Endereco.Estado;
                                string complemento = retInst.Endereco.Complemento;
                                string cep = retInst.Endereco.CEP;
                                string numero = retInst.Endereco.Numero;
                                string pais = retInst.Endereco.PaisEndereco;
                                string paisNacionalidade = retInst.Endereco.PaisNacionalidade;
                            }  
                        }
                        var consultaListaCpfCgc = infocontribuinte.ConsultarDadosClientes(requestcliente).ListaClientes;
                        if (consultaListaCpfCgc != null && consultaListaCpfCgc.Length > 0)
                        {
                            foreach (var ListaCpfCgc in consultaListaCpfCgc)
                            {
                                string a = ListaCpfCgc.NomeCliente;

                            }  
                        } 
                        /* CONSULTO DADOS DO CLIENTE PASSANDO O REQUEST(DADO ANTERIOR) RETORNANDO A LISTA DE RETENÇÃO */
                        var consultaCliente = infocontribuinte.ConsultarDadosClientes(requestcliente).ListaClientes;
                        if (consultaCliente != null && consultaCliente.Length > 0)
                        {
                            foreach (var item in consultaCliente)
                            {
                                string cpfcnpjraiz = "";
                                string SituacaoPJ = "";
                                string IDEvento = "";
                                string strRecibo = "";


                                if (item.TipoPessoa == "J")
                                {
                                    strtipoInscricao = "1";
                                    cpfcnpjraiz = Convert.ToString(item.CPFCNPJ).Substring(0, 8);
                                    IDEvento = "ID" + strtipoInscricao + Convert.ToString(item.CPFCNPJ) + String.Format("{0:yyyyMMddHHMMss}", DateTime.Now);

                                }
                                else if (item.TipoPessoa == "F")
                                {
                                    strtipoInscricao = "2";
                                    cpfcnpjraiz = Convert.ToString(item.CPFCNPJ);
                                    SituacaoPJ = Convert.ToString(item.CodigoCondDependencia);
                                    IDEvento = "ID" + strtipoInscricao + Convert.ToString(item.CPFCNPJ) + "000" + String.Format("{0:yyyyMMddHHMMss}", DateTime.Now);
                                    //+ cliente.DataInicio.ToString("yyyy-MM-dd HH:mm:ss.fff");
                                }
                                if (cliente.DataInicio.ToString("yyyy-MM"), == "2")
                                {
                                    // a condiçao
                                    strRecibo = "1";
                                }

                                RetencoesFonte cont = new RetencoesFonte()
                                {
                                    //Informações de Identificação do Evento
                                    ID = IDEvento,
                                    IndRetif = strindRetif,
                                    NrRecibo = strRecibo,
                                    PerApur = request.DataInicio.ToString("YYYY-MM"),
                                    TpAmb = strconTpAmb,
                                    ProcEmi = strconProcEmi,
                                    VerProc = strconVerProc,
                                    TpInsc = strtipoInscricao,
                                    NrInsc = cpfcnpjraiz,
                                    //Identificação do Beneficiário e do Rendimento
                                    CodPgto = Convert.ToString(item.CodigoCondDependencia),
                                    TpInscBenef = item.TipoPessoa,
                                    NrInscBenef = cpfcnpjraiz,
                                    NmRazaoBenef = item.NomeCliente,
                                    PaisResid = item.Endereco.PaisEndereco,
                                    DscLograd = item.Endereco.Logradouro,
                                    NrLograd = item.Endereco.Numero,
                                    Complem = item.Endereco.Complemento,
                                    Bairro = item.Endereco.Bairro,
                                    Cidade = item.Endereco.Cidade,
                                    CodPostal = item.Endereco.CEP,
                                    //Informações fiscais de beneficiário residente ou domiciliado no exterior
                                    IndNIF = item.ClienteEstrangeiro,
                                    NifBenef = Convert.ToString(item.CPFCNPJEstrangeiro),
                                    RelFontePagad = item.NomeCliente,
                                    DtLaudo = request.DataInicio.ToString("yyyy-MM"),
                                    //Informações do Pagamento
                                    TpInscPgto = "TpInscPgto",
                                    NrInscPgto = "NrInscPgto",
                                    DtPgto = item.ClienteEstrangeiro,
                                    IndSuspExig = item.ClienteEstrangeiro,
                                    IndDecTerceiro = item.ClienteEstrangeiro,
                                    VlrRendTributavel = item.ClienteEstrangeiro,
                                    VlrIRRF = item.ClienteEstrangeiro,
                                    //Detalhamento das Deduções
                                    IndTpDeducao = item.ClienteEstrangeiro,
                                    VlrDeducao = item.ClienteEstrangeiro,
                                    //Rendimentos Isentos/Não Tributáveis
                                    TpIsencao = "TpIsencao",
                                    VlrIsento = item.ClienteEstrangeiro,
                                    DescRendimento = item.ClienteEstrangeiro,
                                    //Detalhamento das Competências
                                    IndPerReferencia = item.ClienteEstrangeiro,
                                    PerRefPagto = request.DataInicio.ToString("yyyy-MM"),
                                    VlrRendTributavelCompet = Convert.ToString(item.CPFCNPJ),
                                    //Compensação Judicial
                                    VlrCompAnoCalend = item.ClienteEstrangeiro,
                                    VlrCompAnoAnt = item.ClienteEstrangeiro,
                                    //Informações Complementares - Rendimentos Recebidos Acumuladamente
                                    TpProcRRA = item.ClienteEstrangeiro,
                                    NrProcRRA = item.ClienteEstrangeiro,
                                    CodSuspJud = item.ClienteEstrangeiro,
                                    NatRRA = item.ClienteEstrangeiro,
                                    QtdMesesRRA = item.ClienteEstrangeiro,
                                    VlrDespCustas = item.ClienteEstrangeiro,
                                    VlrDespAdvogados = item.ClienteEstrangeiro,
                                    TpInscAdvogado = item.ClienteEstrangeiro,
                                    NrInscAdvogado = item.ClienteEstrangeiro,
                                    VlrAdvogado = item.ClienteEstrangeiro,
                                    NrProcJud = item.ClienteEstrangeiro,
                                    IndOrigemRecursos = item.ClienteEstrangeiro,
                                    CnpjOrigemRecursos = item.ClienteEstrangeiro,
                                    VlrDepJudicial = item.ClienteEstrangeiro,
                                    DtPagto = item.ClienteEstrangeiro,
                                    VlrRet = item.ClienteEstrangeiro,
                                    TpRendimentoExt = item.ClienteEstrangeiro,
                                    FormaTributacaoExt = item.ClienteEstrangeiro,
                                    VlrPgtoExt = item.ClienteEstrangeiro,

                                    //NmCont = Convert.ToString(consultaCliente[0].Imposto[0].Conta)
                                };

                                nomearquivo = Convert.ToString(item.CPFCNPJ);

                                AdicionarXml(cont, cliente.caminho, nomearquivo);

                            }
                        }
                    }
                    else
                        Console.WriteLine(" Problemas na autenticação", DateTime.Now.ToString());
                }
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
                // Console.WriteLine(" 99-Erro de gravação" + ex, DateTime.Now.ToString());                
            }

            return true;
        }
        //public bool AdicionarXml(Models.Endereco end,string caminho)
        public bool AdicionarXml(Models.RetencoesFonte ret, string caminho, string nomearquivo)
        {
            //DateTime data = DateTime.Now.Date;
            //string dataInicio = String.Format("{0:yyyyMMddHHMMss}", DateTime.Now);         
          

            //cria uma instância do Produto e atribui valores às propriedades
            InformacoesContribuinte oRetencaoFonte = new InformacoesContribuinte();

            XmlTextWriter writer = new XmlTextWriter(caminho + nomearquivo, System.Text.Encoding.UTF8);
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 4;
            //writer.WriteAttributeString("classificacao", "R");
            writer.WriteStartElement("Reinf", "xmlns=http://www.reinf.esocial.gov.br/schemas/evtRetFonte/v1_03_02");
            writer.WriteStartElement("evtPgtosDivs", ret.ID);
            writer.WriteStartElement("ideEvento");
            writer.WriteElementString("indRetif", ret.IndRetif);
            writer.WriteElementString("nrRecibo", ret.NrRecibo);
            writer.WriteElementString("perApur", ret.PerApur);
            writer.WriteElementString("tpAmb", ret.TpAmb);
            writer.WriteElementString("procEmi", ret.ProcEmi);
            writer.WriteElementString("verProc", ret.VerProc);            
            writer.WriteEndElement();
            writer.WriteStartElement("ideContri");
            writer.WriteElementString("tpInsc", ret.TpInsc);
            writer.WriteElementString("nrInsc", ret.NrInsc);
            writer.WriteEndElement();
            writer.WriteStartElement("ideBenef");
            writer.WriteElementString("codPgto", ret.CodPgto);
            writer.WriteElementString("tpInscBenef", ret.TpInscBenef);
            writer.WriteElementString("nrInscBenef", ret.NrInscBenef);
            writer.WriteElementString("nmRazaoBenef", ret.NmRazaoBenef);
            writer.WriteStartElement("infoResidExt");
            writer.WriteStartElement("infoEnder");
            writer.WriteElementString("paisResid", ret.PaisResid);
            writer.WriteElementString("dscLograd", ret.DscLograd);
            writer.WriteElementString("nrLograd", ret.NrLograd);
            writer.WriteElementString("complem", ret.Complem);
            writer.WriteElementString("bairro", ret.Bairro);
            writer.WriteElementString("cidade", ret.Cidade);
            writer.WriteElementString("codPostal", ret.CodPostal);
            writer.WriteEndElement();
            writer.WriteStartElement("infoFiscal");
            writer.WriteElementString("indNIF", ret.IndNIF);
            writer.WriteElementString("nifBenef", ret.NifBenef);
            writer.WriteElementString("relFontePagad", ret.RelFontePagad);
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteStartElement("infoMolestia");
            writer.WriteElementString("dtLaudo", ret.DtLaudo);   
            writer.WriteEndElement();
            writer.WriteStartElement("infoPgto");
            writer.WriteStartElement("ideEstab");
            writer.WriteElementString("tpInsc", ret.TpInscPgto);
            writer.WriteElementString("nrInsc", ret.NrInscPgto);
            writer.WriteStartElement("pgtoResidBR");
            writer.WriteStartElement("pgtoPF");
            writer.WriteElementString("dtPgto", ret.DtPagto);
            writer.WriteElementString("indSuspExig", ret.IndSuspExig);
            writer.WriteElementString("indDecTerceiro", ret.IndDecTerceiro);
            writer.WriteElementString("vlrRendTributavel", ret.VlrRendTributavel);
            writer.WriteElementString("vlrIRRF", ret.VlrIRRF);         
            writer.WriteStartElement("detDeducao");
            writer.WriteElementString("indTpDeducao", ret.IndTpDeducao);
            writer.WriteElementString("vlrDeducao", ret.VlrDeducao);
            writer.WriteEndElement();
            writer.WriteStartElement("rendIsento");
            writer.WriteElementString("tpIsencao", ret.TpIsencao);
            writer.WriteElementString("vlrIsento", ret.VlrIsento);
            writer.WriteElementString("descRendimento", ret.DescRendimento);
            writer.WriteEndElement();
            writer.WriteStartElement("detCompet");
            writer.WriteElementString("indPerReferencia", ret.IndPerReferencia);
            writer.WriteElementString("perRefPagto", ret.PerRefPagto);
            writer.WriteElementString("vlrRendTributavel", ret.VlrRendTributavelCompet);
            writer.WriteEndElement();
            writer.WriteStartElement("compJud");
            writer.WriteElementString("vlrCompAnoCalend", ret.VlrCompAnoCalend);
            writer.WriteElementString("vlrCompAnoAnt", ret.VlrCompAnoAnt);
            writer.WriteEndElement();
            writer.WriteStartElement("infoRRA");
            writer.WriteElementString("tpProcRRA", ret.TpProcRRA);
            writer.WriteElementString("nrProcRRA", ret.NrProcRRA);
            writer.WriteElementString("codSusp", ret.CodSusp);
            writer.WriteElementString("natRRA", ret.NatRRA);
            writer.WriteElementString("qtdMesesRRA", ret.QtdMesesRRA);            
            writer.WriteStartElement("despProcJud");
            writer.WriteElementString("vlrDespCustas", ret.VlrDespCustas);
            writer.WriteElementString("vlrDespAdvogados", ret.VlrDespAdvogados);//linha 67
            writer.WriteStartElement("ideAdvogado");
            writer.WriteElementString("tpInscAdvogado", ret.TpInscAdvogado);
            writer.WriteElementString("nrInscAdvogado", ret.NrInscAdvogado);
            writer.WriteElementString("vlrAdvogado", ret.VlrAdvogado);//71
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();
            // continua aqui
            writer.WriteStartElement("infoProcJud");
            writer.WriteElementString("nrProcJud", ret.NrProcJud);
            writer.WriteElementString("codSusp", ret.CodSuspJud);
            writer.WriteElementString("indOrigemRecursos", ret.IndOrigemRecursos);//75        
            writer.WriteStartElement("despProcJud");
            writer.WriteElementString("vlrDespCustas", ret.VlrDespCustaspgtoPF);
            writer.WriteElementString("vlrDespAdvogados", ret.VlrDespAdvogadospgtoPF);         
            writer.WriteStartElement("ideAdvogado");
            writer.WriteElementString("tpInscAdvogado", ret.TpInscAdvogadopgtoPF);//80
            writer.WriteElementString("nrInscAdvogado", ret.NpInscAdvogadopgtoPF);
            writer.WriteElementString("vlrAdvogado", ret.VlrAdvogadopgtoPF );       
            writer.WriteStartElement("origemRecursos");
            writer.WriteElementString("cnpjOrigemRecursos",ret.CnpjOrigemRecursos);         
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteStartElement("depJudicial");
            writer.WriteElementString("vlrDepJudicial", ret.VlrDepJudicial); //86  
            writer.WriteStartElement("pgtoPJ");
            writer.WriteElementString("dtPagto", ret.DtPagto); //88
            writer.WriteElementString("vlrRendTributavel", ret.VlrRendTributaveldepJudicial);
            writer.WriteElementString("vlrRet", ret.VlrRet);
            writer.WriteStartElement("infoProcJud");
            writer.WriteElementString("nrProcJud", ret.NrProcJuddepJudicial); //92
            writer.WriteElementString("codSusp", ret.CodSuspdepJudicial);
            writer.WriteElementString("indOrigemRecursos", ret.IndOrigemRecursosdepJudicial);
            writer.WriteStartElement("despProcJud");
            writer.WriteElementString("vlrDespCustas", ret.VlrDespCustasdepJudicial);
            writer.WriteElementString("vlrDespAdvogados", ret.VlrDespAdvogadosdepJudicial);//97
            writer.WriteStartElement("ideAdvogado");
            writer.WriteElementString("tpInscAdvogado", ret.TpInscAdvogadopgtoPJ);
            writer.WriteElementString("nrInscAdvogado", ret.NrInscAdvogadopgtoPJ);
            writer.WriteElementString("vlrAdvogado", ret.VlrAdvogadopgtoPJ);          
            writer.WriteStartElement("origemRecursos");
            writer.WriteElementString("cnpjOrigemRecursos", ret.CnpjOrigemRecursospgtoPJ);    
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();
            if (ret.CodPgto == "S")
            {
                writer.WriteStartElement("pgtoResidExt");
                writer.WriteElementString("dtPagto", ret.DtPagtoExt);//105
                writer.WriteElementString("tpRendimento", ret.TpRendimentoExt);
                writer.WriteElementString("formaTributacao", ret.FormaTributacaoExt);
                writer.WriteElementString("vlrPgto", ret.VlrPgtoExt);
                writer.WriteElementString("vlrRet", ret.VlrRetExt);
                writer.WriteEndElement();
       
            }
           
            writer.WriteEndDocument();
            writer.Close();

            return true;
        }       
    }
}
