using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using T2S.Models;

namespace T2S.Controllers
{
    public class ConteinerController : Controller
    {
        // GET: Conteiner
        public ActionResult Index()
        {

            ConteinerModel conteinerModel = new ConteinerModel();
            List<Conteiner> listaconteiner = conteinerModel.Read();

            return View(listaconteiner);
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


    }
}