using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Web;
using System.Data.Entity.Core.EntityClient;
using System.Data.Common;

namespace Oblig3MVC.Models
{
    public class Faq
    {
        [Key]
        public int id { get; set; }
        public string problem { get; set; }
        public string losning { get; set; }
        public string katid { get; set; }
        

        public virtual Kategori kategori { get; set; }
    }

    public class Kategori
    {
        [Key]
        public string katid { get; set; }
        public string kategori { get; set; }

        public virtual List<Faq> kunder { get; set; }
    }

    public class  Spm
    {
        [Key]
        public int id { get; set; }
        public string innsendtespørsmål { get; set; }

       
    }

    public class KundeContext : DbContext
    {
        public KundeContext()
          : base("name=Faq")
        {
            Database.CreateIfNotExists();
        }

        // konstruktøren under brukes kun under test!
        public KundeContext(DbConnection connection)
                : base(connection,true)
        {
        }
      
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<Kategori> Kategorier { get; set; }
        public DbSet<Spm> Spms { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }


}