using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace EFD_REINF.Models
{
    public class RetencoesFonte
    {
        [XmlRoot("pessoa")]
        public class pessoa
        {
            //[CPFValidation]
            [XmlElement("cpf")]
            public virtual string cpf { get; set; }

            [XmlElement("nome")]
            public virtual string nome { get; set; }

            [XmlElement("telefone")]
            public virtual string telefone { get; set; }
        }

    }
}