using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace EFD_REINF.Models
{
    /// <summary>
    /// Atributos e Propriedades das Retenções da fonte
    /// Analista: Gilcelaine
    /// Data: 28-08-2018
    /// </summary>
    /// <param name="dto">Retenções da Fonte</param>
    /// 

    public class RetencoesFonte
    {
        #region Atributos

        //Reinf
        //Evento Pagamentos ou Créditos Efetuados - Retenções na Fonte de IR, CSLL, Cofins e PIS/PASEP.
        private string id; //Identificação única do evento.
        //Informações de Identificação do Evento
        private string ideEvento;
        private string indRetif;
        private string nrRecibo;
        private string perApur;
        private string tpAmb;
        private string procEmi;
        private string verProc;
        // ideContri Informações de identificação do contribuinte
        private string tpInsc;
        private string nrInsc;
        // ideBenef Identificação do Beneficiário e do Rendimento      
        private string codPgto;
        private string tpInscBenef;
        private string nrInscBenef;
        private string nmRazaoBenef;
        //ideBenef --> infoResidExt Informações complementares de beneficiário residente ou domiciliado no exterior  
        // infoResidExt --> infoEnder - Endereço de beneficiário residente ou domiciliado no exterior      
        private string paisResid;
        private string dscLograd;
        private string nrLograd;
        private string complem;
        private string bairro;
        private string cidade;
        private string codPostal;
        //infoResidExt -->infoFiscal Informações fiscais de beneficiário residente ou domiciliado no exterior
        private string infoFiscal;
        private string indNIF;
        private string nifBenef;
        private string relFontePagad;
        //infoMolestia Informações de Beneficiário portador de moléstia grave
        private string dtLaudo;
        // infoPgto Informações do Pagamento
        //infoPgto-->ideEstab Identificação do Estabelecimento 
        private string tpInscpgto;
        private string nrInscpgto;
        //pgtoResidBR Pagamento a Pessoa Física ou Jurídica residente ou domiciliada no Brasil
        //pgtoResidBR -->pgtoPF  Beneficiário Pessoa Física - Residente no Brasil
        private string dtPgto;
        private string indSuspExig;
        private string indDecTerceiro;
        private string vlrRendTributavel;
        private string vlrIRRF;
        //pgtoResidBR -->detDeducao Detalhamento das Deduções     
        private string indTpDeducao;
        private string vlrDeducao;
        //pgtoPF -->rendIsento Rendimentos Isentos/Não Tributáveis     
        private string tpIsencao;
        private string vlrIsento;
        private string descRendimento;
        //pgtoPF -->detCompet Detalhamento das Competências
        private string indPerReferencia;
        private string perRefPagto;
        private string vlrRendTributavelCompet;
        //pgtoPF -->compJud Compensação Judicial     
        private string vlrCompAnoCalend;
        private string vlrCompAnoAnt;
        //pgtoPF-->infoRRA Informações Complementares - Rendimentos Recebidos Acumuladamente       
        private string tpProcRRA;
        private string nrProcRRA;
        private string codSusp;
        private string natRRA;
        private string qtdMesesRRA;
        //pgtoPF_->infoRRA -->despProcJud Detalhamento das despesas de processo judicial
        private string vlrDespCustas;
        private string vlrDespAdvogados;
        //pgtoPF_->infoRRA -->despProcJud --> ideAdvogado Identificação do Advogado
        private string tpInscAdvogado;
        private string nrInscAdvogado;
        private string vlrAdvogado;
        //pgtoPF -->infoProcJud  Informações Complementares - Demais rendimentos decorrentes de Decisão Judicial     
        private string nrProcJud;
        private string codSuspJud;
        private string indOrigemRecursos;       
        //pgtoPF -->infoProcJud -->despProcJud  Detalhamento das despesas de processo judicial    
        private string vlrDespCustaspgtoPF;
        private string vlrDespAdvogadospgtoPF;
        //pgtoPF -->infoProcJud -->despProcJud -->ideAdvogado  Identificação do Advogado  
        private string tpInscAdvogadopgtoPF;
        private string nrInscAdvogadopgtoPF;
        private string vlrAdvogadopgtoPF;
        //Identificação da origem dos recurso       
        private string cnpjOrigemRecursos;
        //depJudicial-->Depósito Judicial
        private string vlrDepJudicial;
        //Pagamento a Beneficiário Pessoa Jurídica - Domiciliado no Brasil
        private string dtPagto;
        private string vlrRendTributavelJud;       
        private string vlrRet;
        //Informações Complementares - Demais rendimentos decorrentes de Decisão Judicial
        private string nrProcJuddepJudicial;
        private string codSuspdepJudicial;
        private string indOrigemRecursosdepJudicial;
        //Detalhamento das despesas de processo judicial
        private string vlrDespCustasdepJudicial;
        private string vlrDespAdvogadosdepJudicial;
        //Identificação do Advogado
        private string tpInscAdvogadopgtoPJ;
        private string nrInscAdvogadopgtoPJ;
        private string vlrAdvogadopgtoPJ;
        //Identificação da origem dos recurso
        private string cnpjOrigemRecursospgtoPJ;
        //Pagamento a não residente ou domiciliado no exterior
        private string dtPagtoExt;
        private string tpRendimentoExt;
        private string formaTributacaoExt;
        private string vlrPgtoExt;
        private string vlrRetExt;        
          
       
        #endregion

        #region Propriedades
        
        public string ID
        {
            get { return id; }
            set { id = value; }
        }
        //Informações de Identificação do Evento  
        public string IdeEvento
        {
            get { return ideEvento; }
            set { ideEvento = value; }
        }
        public string IndRetif
        {
            get { return indRetif; }
            set { indRetif = value; }
        }
        public string NrRecibo
        {
            get { return nrRecibo; }
            set { nrRecibo = value; }
        }
        public string PerApur
        {
            get { return perApur; }
            set { perApur = value; }
        }
        public string TpAmb
        {
            get { return tpAmb; }
            set { tpAmb = value; }
        }
        public string ProcEmi
        {
            get { return procEmi; }
            set { procEmi = value; }
        }
        public string VerProc
        {
            get { return verProc; }
            set { verProc = value; }
        }
        // Informações de identificação do contribuinte       
        public string TpInsc
        {
            get { return tpInsc; }
            set { tpInsc = value; }
        }
        public string NrInsc
        {
            get { return nrInsc; }
            set { nrInsc = value; }
        }
        // Identificação do Beneficiário e do Rendimento  
        public string CodPgto
        {
            get { return codPgto; }
            set { codPgto = value; }
        }
        public string TpInscBenef
        {
            get { return tpInscBenef; }
            set { tpInscBenef = value; }
        }
        public string NrInscBenef
        {
            get { return nrInscBenef; }
            set { nrInscBenef = value; }
        }
        public string NmRazaoBenef
        {
            get { return nmRazaoBenef; }
            set { nmRazaoBenef = value; }
        }
        // Endereço de beneficiário residente ou domiciliado no exterior      
        public string PaisResid
        {
            get { return paisResid; }
            set { paisResid = value; }
        }
        public string DscLograd
        {
            get { return dscLograd; }
            set { dscLograd = value; }
        }
        public string NrLograd
        {
            get { return nrLograd; }
            set { nrLograd = value; }
        }
        public string Complem
        {
            get { return complem; }
            set { complem = value; }
        }
        public string Bairro
        {
            get { return bairro; }
            set { bairro = value; }
        }
        public string Cidade
        {
            get { return cidade; }
            set { cidade = value; }
        }
        public string CodPostal
        {
            get { return codPostal; }
            set { codPostal = value; }
        }
        //Informações fiscais de beneficiário residente ou domiciliado no exterior 
        public string InfoFiscal
        {
            get { return infoFiscal; }
            set { infoFiscal = value; }
        }
        public string IndNIF
        {
            get { return indNIF; }
            set { indNIF = value; }
        }
        public string NifBenef
        {
            get { return nifBenef; }
            set { nifBenef = value; }
        }
        public string RelFontePagad
        {
            get { return relFontePagad; }
            set { relFontePagad = value; }
        }
        //Informações de Beneficiário portador de moléstia grave
        public string DtLaudo
        {
            get { return dtLaudo; }
            set { dtLaudo = value; }
        }
        //Informações do Pagamento
        public string TpInscPgto
        {
            get { return tpInscpgto; }
            set { tpInscpgto = value; }
        }
        public string NrInscPgto
        {
            get { return nrInscpgto; }
            set { nrInscpgto = value; }
        }
        //Beneficiário Pessoa Física - Residente no Brasil 
        public string DtPgto
        {
            get { return dtPgto; }
            set { dtPgto = value; }
        }
        public string IndSuspExig
        {
            get { return indSuspExig; }
            set { indSuspExig = value; }
        }
        public string IndDecTerceiro
        {
            get { return indDecTerceiro; }
            set { indDecTerceiro = value; }
        }
        public string VlrRendTributavel
        {
            get { return vlrRendTributavel; }
            set { vlrRendTributavel = value; }
        }
        public string VlrIRRF
        {
            get { return vlrIRRF; }
            set { vlrIRRF = value; }
        }
        //Detalhamento das Deduções
        public string IndTpDeducao
        {
            get { return indTpDeducao; }
            set { indTpDeducao = value; }
        }
        public string VlrDeducao
        {
            get { return vlrDeducao; }
            set { vlrDeducao = value; }
        }
        //Rendimentos Isentos/Não Tributáveis        
        public string TpIsencao
        {
            get { return tpIsencao; }
            set { tpIsencao = value; }
        }
        public string VlrIsento
        {
            get { return vlrIsento; }
            set { vlrIsento = value; }
        }
        public string DescRendimento
        {
            get { return descRendimento; }
            set { descRendimento = value; }
        }
        //Detalhamento das Competências        
        public string IndPerReferencia
        {
            get { return indPerReferencia; }
            set { indPerReferencia = value; }
        }
        public string PerRefPagto
        {
            get { return perRefPagto; }
            set { perRefPagto = value; }
        }
        public string VlrRendTributavelCompet
        {
            get { return vlrRendTributavelCompet; }
            set { vlrRendTributavelCompet = value; }
        }
        //Compensação Judicial  
        public string VlrCompAnoCalend
        {
            get { return vlrCompAnoCalend; }
            set { vlrCompAnoCalend = value; }
        }
        public string VlrCompAnoAnt
        {
            get { return vlrCompAnoAnt; }
            set { vlrCompAnoAnt = value; }
        }
        //Rendimentos Recebidos Acumuladamente
        public string TpProcRRA
        {
            get { return tpProcRRA; }
            set { tpProcRRA = value; }
        }
        public string NrProcRRA
        {
            get { return nrProcRRA; }
            set { nrProcRRA = value; }
        }
        public string CodSusp
        {
            get { return codSusp; }
            set { codSusp = value; }
        }
        public string NatRRA
        {
            get { return natRRA; }
            set { natRRA = value; }
        }
        public string QtdMesesRRA
        {
            get { return qtdMesesRRA; }
            set { qtdMesesRRA = value; }
        }
        //Detalhamento das despesas de processo judicial    
        public string VlrDespCustas
        {
            get { return vlrDespCustas; }
            set { vlrDespCustas = value; }
        }
        public string VlrDespAdvogados
        {
            get { return vlrDespAdvogados; }
            set { vlrDespAdvogados = value; }
        }
        //Identificação do Advogado
        public string TpInscAdvogado
        {
            get { return tpInscAdvogado; }
            set { tpInscAdvogado = value; }
        }
        public string NrInscAdvogado
        {
            get { return nrInscAdvogado; }
            set { nrInscAdvogado = value; }
        }
        public string VlrAdvogado
        {
            get { return vlrAdvogado; }
            set { vlrAdvogado = value; }
        }
        //Informações Complementares - Demais rendimentos decorrentes de Decisão Judicial 
        public string NrProcJud
        {
            get { return nrProcJud; }
            set { nrProcJud = value; }
        }
        public string CodSuspJud
        {
            get { return codSuspJud; }
            set { codSuspJud = value; }
        }
        public string IndOrigemRecursos
        {
            get { return indOrigemRecursos; }
            set { indOrigemRecursos = value; }
        }
        //Detalhamento das despesas de processo judicial      
        public string CnpjOrigemRecursos
        {
            get { return cnpjOrigemRecursos; }
            set { cnpjOrigemRecursos = value; }
        }

        public string VlrDespCustaspgtoPF
        {
            get { return vlrDespCustaspgtoPF; }
            set { vlrDespCustaspgtoPF = value; }
        }

        public string VlrDespAdvogadospgtoPF
        {
            get { return vlrDespAdvogadospgtoPF; }
            set { vlrDespAdvogadospgtoPF = value; }
        }
        //Identificação do Advogado
        public string TpInscAdvogadopgtoPF
        {
            get { return tpInscAdvogadopgtoPF; }
            set { tpInscAdvogadopgtoPF = value; }
        }
        public string NpInscAdvogadopgtoPF
        {
            get { return nrInscAdvogadopgtoPF; }
            set { nrInscAdvogadopgtoPF = value; }
        }
        public string VlrAdvogadopgtoPF
        {
            get { return vlrAdvogadopgtoPF; }
            set { vlrAdvogadopgtoPF = value; }
        }
        //Depósito Judicial
        public string VlrDepJudicial
        {
            get { return vlrDepJudicial; }
            set { vlrDepJudicial = value; }
        }

        //Pagamento a Beneficiário Pessoa Jurídica - Domiciliado no Brasil -- campo 85

        public string DtPagto
        {
            get { return dtPagto; }
            set { dtPagto = value; }
        }
        public string VlrRet
        {
            get { return vlrRet; }
            set { vlrRet = value; }
        }

        //Informações Complementares - Demais rendimentos decorrentes de Decisão Judicial

        public string NrProcJuddepJudicial
        {
            get { return nrProcJuddepJudicial; }
            set { nrProcJuddepJudicial = value; }
        }
        public string CodSuspdepJudicial
        {
            get { return codSuspdepJudicial; }
            set { codSuspdepJudicial = value; }
        }
        public string IndOrigemRecursosdepJudicial
        {
            get { return indOrigemRecursosdepJudicial; }
            set { indOrigemRecursosdepJudicial = value; }
        }
         //Detalhamento das despesas de processo judicial
        public string VlrDespCustasdepJudicial
        {
            get { return vlrDespCustasdepJudicial; }
            set { vlrDespCustasdepJudicial = value; }
        }

        public string VlrDespAdvogadosdepJudicial
        {
            get { return vlrDespAdvogadosdepJudicial; }
            set { vlrDespAdvogadosdepJudicial = value; }
        }

        public string VlrRendTributaveldepJudicial
        {
            get { return vlrRendTributavelJud; }
            set { vlrRendTributavelJud = value; }
        }
        //Identificação do Advogado
        public string TpInscAdvogadopgtoPJ
        {
            get { return tpInscAdvogadopgtoPJ; }
            set { tpInscAdvogadopgtoPJ = value; }
        }

        public string NrInscAdvogadopgtoPJ
        {
            get { return vlrAdvogadopgtoPJ; }
            set { vlrAdvogadopgtoPJ = value; }
        }

        public string VlrAdvogadopgtoPJ
        {
            get { return vlrAdvogadopgtoPJ; }
            set { vlrAdvogadopgtoPJ = value; }
        }       

        public string CnpjOrigemRecursospgtoPJ
        {
            get { return cnpjOrigemRecursospgtoPJ; }
            set { cnpjOrigemRecursospgtoPJ = value; }
        }

        //Pagamento a Beneficiário Pessoa Jurídica - Domiciliado no Brasil         

        public string DtPagtoExt
        {
            get { return dtPagtoExt; }
            set { dtPagtoExt = value; }
        }
        public string VlrRetExt
        {
            get { return vlrRetExt; }
            set { vlrRetExt = value; }
        }       
        public string TpRendimentoExt
        {
            get { return tpRendimentoExt; }
            set { tpRendimentoExt = value; }
        }
        public string FormaTributacaoExt
        {
            get { return formaTributacaoExt; }
            set { formaTributacaoExt = value; }
        }
        public string VlrPgtoExt
        {
            get { return vlrPgtoExt; }
            set { vlrPgtoExt = value; }
        }

 


        #endregion

    }

}