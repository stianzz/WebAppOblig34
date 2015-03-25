using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Oblig3MVC.Model;
using Oblig3MVC.BLL;

namespace Oblig3MVC.Controllers
{
    public class AdminController : Controller
    {
        
        public ActionResult AdminSide()
        {
            if (Session["LoggetAdmin"] == null )
            {
                Session["LoggetAdmin"] = false;
                ViewBag.AdminInnlogget = false;
            }
           
            else
            {
               // return RedirectToAction("AdminSide", "Admin");
              //ViewBag.Innlogget = (bool)Session["LoggetAdmin"];
              Session["LoggetAdmin"] = true;
              ViewBag.AdminInnlogget = true;
            }
            return View();
        }
       
     
        [HttpPost]
        public ActionResult AdminSide(Admin innLogget)
        {
            // sjekk om innlogging OK
            if (Admin_i_db(innLogget))
            {
                // ja brukernavn og passord er OK!
                Session["LoggetAdmin"] = true;
                ViewBag.AdminInnlogget = true;
                return View();
            }
            else
            {
                // ja brukernavn og passord er ikke OK!
                Session["LoggetAdmin"] = false;
                ViewBag.AdminInnlogget = false;
                return RedirectToAction("AdminSide", "Admin");
            }
        }

        // Sjekker om admin finnes i databasen
        private static bool Admin_i_db(Admin innAdmin)
        {
            var adminBll = new AdminBLL();
            return adminBll.Admin_i_db(innAdmin);
        }

        // Registrerer ny admin
        public ActionResult Registrer()
        {
            if (Session["LoggetAdmin"] != null)
            {
                bool loggetInn = (bool)Session["LoggetAdmin"];
                if (loggetInn)
                {
                    return View();
                }
            }
            return RedirectToAction("AdminSide", "Admin");
        }
        
        [HttpPost]
        public ActionResult Registrer(Admin nyAdmin)
        {
            if(ModelState.IsValid)
            {
                var adminBll = new AdminBLL();
                bool insertOK = adminBll.settInnNyAdmin(nyAdmin);
                if (insertOK)
                    return RedirectToAction("AdminSide", "Admin");
            }
            return View();
        }

     

        // Henter alle Adminer
        public ActionResult AlleAdminer()
        {
            if (Session["LoggetAdmin"] != null)
            {
                bool loggetInn = (bool)Session["LoggetAdmin"];
                if (loggetInn)
                {
                    var adminBll = new AdminBLL();
                    List<Admin> alleAdmin = adminBll.hentAlleAdminer();
                    return View(alleAdmin);
                }
            }
            ViewBag.AdminInnlogget = false;
            return RedirectToAction("AdminSide", "Admin");
        }

        // Endrer informasjonen til en Admin
        public ActionResult EndreAdmin( int id)
        {
            if (Session["LoggetAdmin"] != null)
            {
                bool loggetInn = (bool)Session["LoggetAdmin"];
                if (loggetInn)
                {
                    var adminBll = new AdminBLL();
                    Admin enAdmin = adminBll.hentEnAdmin(id);
                    return View(enAdmin);
                }
            }
            ViewBag.AdminInnlogget = false;
            return RedirectToAction("AdminSide", "Admin");
        }

        [HttpPost]
        public ActionResult EndreAdmin( int id, Admin innAdmin)
        {
            if (Session["LoggetAdmin"] != null)
            {
                bool loggetInn = (bool)Session["LoggetAdmin"];
                if (loggetInn)
                {
                    var adminBll = new AdminBLL();
                    bool endreOK = adminBll.endreAdmin(id, innAdmin);
                    if (endreOK)
                    {
                        return RedirectToAction("AlleAdminer", "Admin");
                    }
                    return View();
                }
            }
            ViewBag.AdminInnlogget = false;
            return RedirectToAction("AdminSide", "Admin");
        }

        // henter info om en Admin
        public ActionResult AdminDetaljer(int id)
        {
            if (Session["LoggetAdmin"] != null)
            {
                bool loggetInn = (bool)Session["LoggetAdmin"];
                if (loggetInn)
                {
                    var adminBll = new AdminBLL();
                    Admin enAdmin = adminBll.hentEnAdmin(id);
                    return View(enAdmin);
                }
            }
            ViewBag.AdminInnlogget = false;
            return RedirectToAction("AdminSide", "Admin");
        }

        //henter en Admin for å slette
        public ActionResult SlettEnAdmin(int id)
        {
            if (Session["LoggetAdmin"] != null)
            {
                bool loggetInn = (bool)Session["LoggetAdmin"];
                if (loggetInn)
                {
                    var adminBll = new AdminBLL();
                    Admin enAdmin = adminBll.hentEnAdmin(id);
                    return View(enAdmin);
                }
            }
            ViewBag.AdminInnlogget = false;
            return RedirectToAction("AdminSide", "Admin");
        }
        [HttpPost]
        public ActionResult SlettEnAdmin(int id, Admin slettAdmin)
        {
            var adminBll = new AdminBLL();
            bool slettOK = adminBll.slettAdmin(id);
            if(slettOK)
            {
                return RedirectToAction("AlleAdminer", "Admin");
            }
            return View();
        }
        // Logger ut
        
        public ActionResult LoggUt()
        {
            Session["InnLoggetAdmin"] = false;
            ViewBag.Innlogget = false;
            return RedirectToAction("Index", "Home");
        }
    }
}
