using System.Web.Mvc;


namespace EFD_REINF.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Models.Cep cep)
        {
            if (!ModelState.IsValid)
            {
                return View(cep);
            }

            using (var correios = new Correios.AtendeClienteClient())
            {
                var consulta = correios.consultaCEP(cep.Codigo.Replace("-", ""));

                if (consulta != null)
                {
                    ViewBag.Endereco = new Models.Endereco()
                    {
                        Descricao = consulta.end,
                        Complemento = consulta.complemento,
                        Bairro = consulta.bairro,
                        Cidade = consulta.cidade,
                        UF = consulta.uf
                    };
                }

            }

            return View(cep);
        }
    }
}