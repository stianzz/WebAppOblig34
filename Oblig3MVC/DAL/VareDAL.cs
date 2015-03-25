using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oblig3MVC.Model;

namespace Oblig3MVC.DAL
{
    public class VareDAL
    {

        // Henter alle varer fra databasen
        public List<VareModel> hentAlleVarer()
        {
            var db = new DrikkContext();
            List<VareModel> alleVarer = db.Varer.Select(k => new VareModel()
                                    {
                                        VareId = k.VareId,
                                        Navn = k.Navn,
                                        Pris = k.Pris,
                                        Antall = k.Antall,
                                        //Land = k.Land.Navn
                                    }).ToList();
            return alleVarer;
        }

        // Setter en ny vare i databasen
        public bool settInnNyVare(VareModel innVare)
        {
            var nyVare = new Vare()
            {
                Navn = innVare.Navn,
                //Land = innVare.Land,
                Pris = innVare.Pris,
                Antall = innVare.Antall,
                //Kategori = innVare.Kategori,
                VareArtUrl = innVare.VareArtUrl
            };
            var db = new DrikkContext();
            try
            {
                //var eksistererKategori = db.Kategorier.Find(innVare.KatId);
                Kategori eksistererKategori = db.Kategorier.FirstOrDefault(k => k.KatNavn == innVare.KatNavn);
                
                if (eksistererKategori == null)
                {
                    var nyKategori = new Kategori()
                    {
                        KatNavn = innVare.KatNavn
                    };
                    nyVare.Kategori = nyKategori;
                    //db.Kategorier.Add(nyKategori);
                }
                db.Varer.Add(nyVare);
                db.SaveChanges();
                return true;
            }
            catch (Exception feil)
            {
                return false;
            }
        }


        public VareModel hentEnVare(int id)
        {
            var db = new DrikkContext();
            {
                var dbVare = db.Varer.Find(id);
                if (dbVare != null)
                {
                    /*var enKategori = db.Kategorier.FirstOrDefault(k => k.KatId == dbVare.Kategori.KatId);
                    dbVare.Kategori.KatNavn = enKategori.KatNavn;

                    //var land = db.Lander.FirstOrDefault(l => l.Navn == dbVare.Land.Navn);
                    var land = db.Lander.FirstOrDefault(l => l.LandId == dbVare.Land.LandId);
                    dbVare.Land.Navn = land.Navn; */
                    
                    var vareInfo = new VareModel()
                    {
                        VareId = dbVare.VareId,
                        Navn = dbVare.Navn,
                        Pris = dbVare.Pris,
                        //KatNavn = dbVare.Kategori.KatNavn,
                        Antall = dbVare.Antall,
                        VareArtUrl = dbVare.VareArtUrl,
                        //Land = dbVare.Land.Navn
                    };
                    return vareInfo;
                }
                else
                    return null;
            }
        }

        // Endrer informasjonen til en vare
        public bool endreVare(int id, VareModel innVare)
        {
            var db = new DrikkContext();
            try
            {
                Vare endreVare = db.Varer.Find(id);
                endreVare.Navn = innVare.Navn;
                endreVare.Pris = innVare.Pris;
                endreVare.Antall = innVare.Antall;
                endreVare.VareArtUrl = innVare.VareArtUrl;
                /*if(endreVare.Kategori.KatNavn == innVare.KatNavn)
                {
                    endreVare.Kategori.KatNavn = innVare.KatNavn; // det ser ut at vi ikke trenger  dette
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    var eksisterendeKategori = db.Kategorier.FirstOrDefault(k => k.KatNavn == innVare.KatNavn);
                    if(eksisterendeKategori == null)
                    {
                        var nyKategori = new Kategori()
                        {
                            KatNavn = innVare.KatNavn
                        };
                        db.Kategorier.Add(nyKategori);
                    }
                }*/
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Viser info om en vare i Detaljer side
        public VareModel Detaljer(int id)
        {
            VareModel utVare = hentEnVare(id);
            return utVare;
        }

        // Sletter en Vare
        public bool slettVare(int id)
        {
            var db = new DrikkContext();
            try
            {
                Vare slettVare = db.Varer.Find(id);
                db.Varer.Remove(slettVare);
                db.SaveChanges();
                return true;
            }
            catch (Exception feil )
            {
                return false;
            }
        }


    }
}
