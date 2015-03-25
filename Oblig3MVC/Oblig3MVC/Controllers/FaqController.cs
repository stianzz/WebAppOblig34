using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Oblig3MVC.Controllers
{
    public class FaqController : Controller
    {
        // GET: Faqs
        public ActionResult Faqs()
        {
            var db = new Models.KundeContext();
            List<Models.Kategori> listeAvKategorier = db.Kategorier.ToList();
            ViewData.Model = listeAvKategorier;
            ViewData["Melding"] = "Finner du ikke det du leter etter ovenfor? Spør oss!: ";
            ViewData["Melding2"] = "Lyst å lese innsendte spørsmål?: ";
            return View();
           
        }



        // GET: Faq1
        public ActionResult Faq1()
        {

            var db = new Models.KundeContext();
            List<Models.Faq> listeAvSpørsmål = db.Faqs.ToList();
            ViewData.Model = listeAvSpørsmål;

            return View();

        }

        // GET: Faq11
        public ActionResult Faq11()
        {

            var db = new Models.KundeContext();
            List<Models.Faq> listeAvSpørsmål = db.Faqs.ToList();
            ViewData.Model = listeAvSpørsmål;

            return View();

        }

        // GET: Faq12
        public ActionResult Faq12()
        {

            var db = new Models.KundeContext();
            List<Models.Faq> listeAvSpørsmål = db.Faqs.ToList();
            ViewData.Model = listeAvSpørsmål;

            return View();

        }

        // GET: Faq13
        public ActionResult Faq13()
        {

            var db = new Models.KundeContext();
            List<Models.Faq> listeAvSpørsmål = db.Faqs.ToList();
            ViewData.Model = listeAvSpørsmål;

            return View();

        }







        // GET: Faq2
        public ActionResult Faq2()
        {
            var db = new Models.KundeContext();
            List<Models.Faq> listeAvSpørsmål = db.Faqs.ToList();
            ViewData.Model = listeAvSpørsmål;

            return View();

        }

        // GET: Faq2
        public ActionResult Faq21()
        {
            var db = new Models.KundeContext();
            List<Models.Faq> listeAvSpørsmål = db.Faqs.ToList();
            ViewData.Model = listeAvSpørsmål;

            return View();

        }

        public ActionResult Faq22()
        {
            var db = new Models.KundeContext();
            List<Models.Faq> listeAvSpørsmål = db.Faqs.ToList();
            ViewData.Model = listeAvSpørsmål;

            return View();

        }

        public ActionResult Faq23()
        {
            var db = new Models.KundeContext();
            List<Models.Faq> listeAvSpørsmål = db.Faqs.ToList();
            ViewData.Model = listeAvSpørsmål;

            return View();

        }







        // GET: Faq3
        public ActionResult Faq3()
        {
            var db = new Models.KundeContext();
            List<Models.Faq> listeAvSpørsmål = db.Faqs.ToList();
            ViewData.Model = listeAvSpørsmål;

            return View();
        }

        // GET: Faq3
        public ActionResult Faq31()
        {
            var db = new Models.KundeContext();
            List<Models.Faq> listeAvSpørsmål = db.Faqs.ToList();
            ViewData.Model = listeAvSpørsmål;

            return View();
        }
        // GET: Faq3
        public ActionResult Faq32()
        {
            var db = new Models.KundeContext();
            List<Models.Faq> listeAvSpørsmål = db.Faqs.ToList();
            ViewData.Model = listeAvSpørsmål;

            return View();
        }
        // GET: Faq3
        public ActionResult Faq33()
        {
            var db = new Models.KundeContext();
            List<Models.Faq> listeAvSpørsmål = db.Faqs.ToList();
            ViewData.Model = listeAvSpørsmål;

            return View();
        }
    }
}