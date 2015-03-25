using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oblig3MVC.Model;
using Oblig3MVC.DAL;

namespace Oblig3MVC.BLL
{
    public class VareBLL
    {
        // Henter alle varer fra databasen
        public List<VareModel> hentAlleVarer()
        {
            var vareDal = new VareDAL();
            List<VareModel> alleVarer = vareDal.hentAlleVarer();
            return alleVarer;
        }

        //Setter en ny vare
        public bool settInnNyVare(VareModel nyVare)
        {
            var vareDal = new VareDAL();
            return vareDal.settInnNyVare(nyVare);
        }
        //Henter en vare
        public VareModel hentEnVare(int id)
        {
            var vareDal = new VareDAL();
            return vareDal.hentEnVare(id);
        }

        // Endrer informasjonen til en vare
        public bool endreVare(int id, VareModel innVare)
        {
            var vareDal = new VareDAL();
            return vareDal.endreVare(id, innVare);
        }

        // Viser info om en vare i Detaljer side
        public VareModel Detaljer(int id)
        {
            var vareDal = new VareDAL();
            return vareDal.Detaljer(id);
        }

        // Sletter en Vare
        public bool slettVare(int id)
        {
            var vareDal = new VareDAL();
            return vareDal.slettVare(id);
        }
    }
}
