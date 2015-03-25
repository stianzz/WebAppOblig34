using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Oblig3MVC.Model;
using Oblig3MVC.BLL;

namespace Oblig3MVC.Controllers
{
    public class VareController : Controller
    {

        // Henter alle varer fra databasen
        public ActionResult AlleVarer()
        {
            var vareBll = new VareBLL();
            List<VareModel> alleVarer = vareBll.hentAlleVarer();
            return View(alleVarer);
        }

        // Setter en ny vare i databasen
        public ActionResult SettInnNyVare()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SettInnNyVare(VareModel nyVare)
        {
            if(ModelState.IsValid)
            {
                var vareBll = new VareBLL();
                bool insertOK = vareBll.settInnNyVare(nyVare);
                if (insertOK)
                {
                    return RedirectToAction("AlleVarer", "Vare");
                }
            }
            return View();
        }


        // Endrer opplysninger til en vare
        public ActionResult EndreVare(int id)
        {
            var dbVare = new VareBLL();
            VareModel enVare = dbVare.hentEnVare(id); 
            return View(enVare);
        }

        [HttpPost]
        public ActionResult EndreVare(int id, VareModel innVare)
        {
            if(ModelState.IsValid)
            {
                var vareBll = new VareBLL();
                bool endreOK = vareBll.endreVare(id, innVare);
                if(endreOK)
                {
                    return RedirectToAction("AlleVarer", "Vare");
                }
            }
            return View();
        }

        public ActionResult VareDetaljer(int id)
        {
            var vareBll = new VareBLL();
            VareModel enVare = vareBll.hentEnVare(id);
            return View(enVare);
        }

        // Fjerner en Vare
        public ActionResult SlettVare(int id)
        {
            var vareBll = new VareBLL();
            VareModel slettVare = vareBll.hentEnVare(id);
            return View(slettVare);
        }
        [HttpPost]
        public ActionResult SlettVare(int id, VareModel innVare)
        {
            var vareBll = new VareBLL();
            bool slettOK = vareBll.slettVare(id);
            if (slettOK)
            {
                return RedirectToAction("AlleVarer", "Vare");
            }
            return View();
        }
    }
}