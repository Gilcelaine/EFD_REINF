using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace EFD_REINF.Controllers
{   

    public class AutenticacaoControl
    {
        
        string login = ConfigurationManager.AppSettings["UsuarioSinacor"];
        string senha = ConfigurationManager.AppSettings["SenhaSinacor"];

      
    }
}
