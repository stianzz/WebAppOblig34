using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using Oblig3MVC.Models;

namespace Oblig3MVC
{
    public class KundeDB
    {
        KundeContext db = new KundeContext();
        
        
        
        public List<faq> hentAlleKunder()
        {
            List<faq> alleKunder = db.Faqs.Select(k=> new faq()
                                      {
                                          id = k.id,
                                          problem = k.problem,
                                          losning = k.losning,
                                          katid = k.katid

                                      }).ToList();
            return alleKunder;
        }
        
         public List<faq> hentAlleKategorier()
        {
            List<faq> alleKunder = db.Kategorier.Select(k=> new faq()
                                      {
                                          katid = k.katid,
                                          kategori = k.kategori
                                         


                                      }).ToList();
            return alleKunder;
        }
        
        
        
        public Faq hentEnKunde(int id)
        {
            Faq enDBKunde = db.Faqs.Find(id); 

            var enKunde = new Faq()
            {
                id = enDBKunde.id,
               problem = enDBKunde.problem,
               losning = enDBKunde.losning,
               katid = enDBKunde.katid
            };
            return enKunde;
        }

        public bool lagreSpm(string innSpm)
        {
                var nySpm = new Spm
                {
                    innsendtespørsmål = innSpm

                };
                try
                {
                    // lagre kunden
                    db.Spms.Add(nySpm);
                    db.SaveChanges();
                }
                catch (Exception feil)
                {
                    return false;
                }
                return true;


            }
    }
}