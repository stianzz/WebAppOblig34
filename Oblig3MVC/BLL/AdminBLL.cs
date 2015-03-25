using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oblig3MVC.Model;
using Oblig3MVC.DAL;

namespace Oblig3MVC.BLL
{
    public class AdminBLL
    {
        public bool settInnNyAdmin(Admin nyAdmin)
        {
            var adminDal = new AdminDAL();
            return adminDal.settInnNyAdmin(nyAdmin);
        }

        public byte[] lagHash(string innPassord)
        {
            byte[] innData, utData;
            var algoritme = System.Security.Cryptography.SHA256.Create();
            innData = System.Text.Encoding.ASCII.GetBytes(innPassord);
            utData = algoritme.ComputeHash(innData);
            return utData;
        }

        public bool Admin_i_db(Admin innAdmin)
        {
            var adminDal = new AdminDAL();
            return adminDal.Admin_i_db(innAdmin);
        }

      
        // Henter alle Adminer
        public List<Admin> hentAlleAdminer()
        {
            var adminDal = new AdminDAL();
            List<Admin> alleAdmin= adminDal.hentAlleAdminer();
            return alleAdmin;
        }

        // Henter en Admin
        public Admin hentEnAdmin(int id)
        {
            var adminDal = new AdminDAL();
            return adminDal.hentEnAdmin(id);
        }

        // Endrer informasjonen til en Admin
        public bool endreAdmin( int id, Admin innAdmin)
        {
            var adminDal = new AdminDAL();
            return adminDal.endreAdmin(id, innAdmin);
        }

        // Fjerner en Admin
        public bool slettAdmin(int id)
        {
            var adminDal = new AdminDAL();
            return adminDal.slettAdmin(id);
        }
    }    
}
