using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFD_REINF.Models
{
    public class Endereco
    {
        //public string Descricao { get; set; }
        //public string Complemento { get; set; }
        //public string Bairro { get; set; }
        //public string Cidade { get; set; }
        //public string UF { get; set; }


        #region Atributos
        private string _uf;
        private string _cidade;
        private string _bairro;
        private string _complemento;
        private string _descricao;
        #endregion


        #region Propriedades

        public string UF
        {
            get { return _uf; }
            set { _uf = value; }
        }
        public string Cidade
        {
            get { return _cidade; }
            set { _cidade = value; }
        }
        public string Bairro
        {
            get { return _bairro; }
            set { _bairro = value; }
        }

        public string Complemento
        {
            get { return _complemento; }
            set { _complemento = value; }
        }
        public string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }

        #endregion
    }

}
