using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oblig3MVC.Model;

namespace Oblig3MVC.DAL
{
    public class AdminDAL
    {
        public bool settInnNyAdmin(Admin innAdmin)
        {
            var nyAdmin = new Adminer()
            {
                Fornavn = innAdmin.Fornavn,
                Etternavn = innAdmin.Etternavn,
                Adresse = innAdmin.Adresse,
                Epost = innAdmin.Epost,
                Postnr = innAdmin.Postnr,
                Rolle = innAdmin.Rolle,
                Passord = lagHash(innAdmin.Passord)
            };
            var db = new DrikkContext();
            try
            {
                var eksistererPostnr = db.Poststeder.Find(innAdmin.Postnr);
                if (eksistererPostnr == null)
                {
                    var nyttPoststed = new Poststeder()
                    {
                        Postnr = innAdmin.Postnr,
                        Poststed = innAdmin.Poststed
                    };
                    nyAdmin.Poststeder = nyttPoststed;
                }
                db.Adminer.Add(nyAdmin);
                db.SaveChanges();
                return true;
            }
            catch (Exception feil)
            {
                return false;
            }
        }

        public bool Admin_i_db(Admin innAdmin)
        {
            using (var db = new DrikkContext())
            {
                byte[] passordDB = lagHash(innAdmin.Passord);
                Adminer funnetAdmin = db.Adminer.FirstOrDefault(b => b.Passord == passordDB && b.Epost == innAdmin.Epost);
                if (funnetAdmin == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }


        public byte[] lagHash(string innPassord)
        {
            byte[] innData, utData;
            var algoritme = System.Security.Cryptography.SHA256.Create();
            innData = System.Text.Encoding.ASCII.GetBytes(innPassord);
            utData = algoritme.ComputeHash(innData);
            return utData;
        }

        
        

        

        // Henter alle Adminer
        public List<Admin> hentAlleAdminer()
        {
            var db = new DrikkContext();
            List<Admin> alleAdmin = db.Adminer.Select(a => new Admin()
                                    {
                                        Aid = a.Aid,
                                        Fornavn = a.Fornavn,
                                        Etternavn = a.Etternavn,
                                        Epost = a.Epost,
                                        Rolle = a.Rolle,
                                        Adresse = a.Adresse,
                                        Postnr = a.Postnr,
                                        Poststed = a.Poststeder.Poststed                
                                    }).ToList();
            return alleAdmin;
        }

        // Henter en Admin
        public Admin hentEnAdmin( int id)
        {
            var db = new DrikkContext();
            var enDbAdmin = db.Adminer.Find(id);
            if (enDbAdmin != null)
            {
                var utAdmin = new Admin()
                {
                    Aid = enDbAdmin.Aid,
                    Fornavn = enDbAdmin.Fornavn,
                    Etternavn = enDbAdmin.Etternavn,
                    Epost = enDbAdmin.Epost,
                    Adresse = enDbAdmin.Adresse,
                    Postnr = enDbAdmin.Postnr,
                    Poststed = enDbAdmin.Poststeder.Poststed,
                    Rolle = enDbAdmin.Rolle
                };
                return utAdmin;
            }
            else
                return null;
        }

        // Endrer info om en Admin
        public bool endreAdmin(int id, Admin innAdmin)
        {
            var db = new DrikkContext();
            try
            {
                Adminer endreAdmin = db.Adminer.Find(id);
                endreAdmin.Fornavn = innAdmin.Fornavn;
                endreAdmin.Etternavn = innAdmin.Etternavn;
                endreAdmin.Adresse = innAdmin.Adresse;
                endreAdmin.Epost = innAdmin.Epost;
                if (endreAdmin.Postnr != innAdmin.Postnr)
                {
                    Poststeder eksisterendePoststed = db.Poststeder.FirstOrDefault(p => p.Postnr == innAdmin.Postnr);
                    if (eksisterendePoststed == null)
                    {
                        var nyttPoststed = new Poststeder()
                        {
                            Postnr = innAdmin.Postnr,
                            Poststed = innAdmin.Poststed
                        };
                        db.Poststeder.Add(nyttPoststed);
                    }
                    else
                    {
                        endreAdmin.Postnr = innAdmin.Postnr;
                    }
                };
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Fjerner en Admin fra databasen
        public bool slettAdmin(int id)
        {
            var db = new DrikkContext();
            try
            {
                Adminer slettAdmin = db.Adminer.Find(id);
                db.Adminer.Remove(slettAdmin);
                db.SaveChanges();
                return true;
            }
            catch (Exception feil)
            {
                return false;
            }
        }

    }
}