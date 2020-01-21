using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LojaNet.Models;
using LojaNet.BLL;

namespace LojaNet.UI.Web.Controllers
{
    public class ClienteController : Controller
    {
        private ClienteBLL bll;

        public ClienteController()
        {
            bll = new ClienteBLL();
        }
        public ActionResult Index()
        {
            var lista = bll.ObterTodos();
            return View(lista);
        }

        public ActionResult Detalhes(string id)
        {
            var cliente = bll.ObterPorId(id);
            return View(cliente);
        }

        public ActionResult Incluir()
        {
            var cliente = new Cliente();
            return View(cliente);
        }

        [HttpPost]
        public ActionResult Incluir(Cliente cliente)
        {
            try
            {
                bll.Incluir(cliente);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(cliente);
            }
        }
    }
}