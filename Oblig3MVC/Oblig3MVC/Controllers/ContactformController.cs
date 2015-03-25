using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Oblig3MVC.Models;
using System.Net.Mail;
using System.Threading;
using System.Text;
using System.Net;
using Oblig3MVC;

namespace Oblig3MVC.Controllers
{
    public class ContactformController : Controller
    {

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }
        

        // GET: Contactform
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(Bruker bruker)
        {
           
                if (ModelState.IsValid)
                {
                                         
                    try
                    {
                        //Mail funksjon
                        MailMessage msg = new MailMessage();
   
                        msg.To.Add("webapplikasjoners189113@gmail.com");
   
                        MailAddress address = new MailAddress(bruker.Email);
                        msg.From = address;
  
                        msg.Subject = "Spørsmål , Drink.no";
                        msg.Body = bruker.Fornavn + " " + bruker.Etternavn + " " + bruker.Telefon + " " + bruker.Email + " " + bruker.Spørsmål; 
    

 
 
                        SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                        client.EnableSsl = true; 
   
                        NetworkCredential credentials = new NetworkCredential("webapplikasjoners189113@gmail.com", "webapplikasjoner");
                        client.Credentials = credentials;
 
    
                        client.Send(msg);

                        // Lagre Spørsmål i databasen.

                        var kundeDb = new KundeDB();
                       bool ok = kundeDb.lagreSpm(bruker.Spørsmål);  


                        return View("Success");
                                }                        
                                catch (Exception )
                                {                 
                                 
                                    
                                    return View("Error"); 
                                }
                            }
            return View();    
        }


        public ActionResult Spm()
        {
            var db = new Models.KundeContext();
            List<Models.Spm> listeAvSpørsmål = db.Spms.ToList();
            ViewData.Model = listeAvSpørsmål;

            return View();
        }
    }
}
