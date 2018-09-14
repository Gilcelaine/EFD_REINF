using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace EFD_REINF.Models
{
    public class InformacoesContribuinte
    {
        #region Atributos


      
        private string id;      
        private string tpAmb;
        private string procEmi;
        private string verProc;   
        private string tpInsc;
        private string nrInsc;  
        private string iniValid;
        private string fimValid;
        private string classTrib;
        private string indEscrituracao;
        private string indDesoneracao;
        private string indAcordoIsenMulta;
        private string indSitPJ;
        private string contato;
        private string nmCtt;
        private string cpfCtt;
        private string foneFixo;
        private string foneCel;
        private string email;
        private string softHouse;
        private string cnpjSoftHouse;
        private string nmRazao;
        private string nmCont;
        private string foneFixosoftHouse;
        private string emailSoftHouse;
        
        #endregion

        #region Propriedades
       
        public string ID
        {
            get { return id; }
            set { id = value; }
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
        public string IniValid
        {
            get { return iniValid; }
            set { iniValid = value; }
        }
        public string FimValid
        {
            get { return fimValid; }
            set { fimValid = value; }
        }
        public string ClassTrib
        {
            get { return classTrib; }
            set { classTrib = value; }
        }
        public string IndEscrituracao
        {
            get { return indEscrituracao; }
            set { indEscrituracao = value; }
        }
        public string IndDesoneracao
        {
            get { return indDesoneracao; }
            set { indDesoneracao = value; }
        }
        public string IndAcordoIsenMulta
        {
            get { return indAcordoIsenMulta; }
            set { indAcordoIsenMulta = value; }
        }
        public string IndSitPJ
        {
            get { return indSitPJ; }
            set { indSitPJ = value; }
        }
        public string Contato
        {
            get { return contato; }
            set { contato = value; }
        }
        public string NmCtt
        {
            get { return nmCtt; }
            set { nmCtt = value; }
        }
        public string CpfCtt
        {
            get { return cpfCtt; }
            set { cpfCtt = value; }
        }
        public string FoneFixo
        {
            get { return foneFixo; }
            set { foneFixo = value; }
        }
        public string FoneCel
        {
            get { return foneCel; }
            set { foneCel = value; }
        }
        public string SoftHouse
        {
            get { return softHouse; }
            set { softHouse = value; }
        }
        public string CnpjSoftHouse
        {
            get { return cnpjSoftHouse; }
            set { cnpjSoftHouse = value; }
        }
        public string NmRazao
        {
            get { return nmRazao; }
            set { nmRazao = value; }
        }
        public string NmCont
        {
            get { return nmCont; }
            set { nmCont = value; }
        }
        public string FoneFixosoftHouse
        {
            get { return foneFixosoftHouse; }
            set { foneFixosoftHouse = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string EmailSoftHouse
        {
            get { return emailSoftHouse; }
            set { emailSoftHouse = value; }
        } 
     
        

        #endregion       

    }
}