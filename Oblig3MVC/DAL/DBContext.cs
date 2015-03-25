using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Oblig3MVC.Model;


namespace Oblig3MVC.DAL
{
    public class Kunder
    {
        [Key]
        public int Kid { get; set; }
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        public string Adresse { get; set; }
        public string Epost { get; set; }
        public string Postnr { get; set; }
        public byte[] Passord { get; set; }

        public virtual Poststeder Poststeder { get; set; }
        public virtual List<Bestilling> Bestillinger { get; set; }

    }

    public class Poststeder
    {
        [Key]
        public string Postnr { get; set; }
        public string Poststed { get; set; }
        public virtual List<Kunder> Kunder { get; set; }
        public virtual List<Adminer> Adminer { get; set; }
    }

    public class Vare
    {
        [Key]
        public int VareId { get; set; }
        public string Navn { get; set; }
        public decimal Pris { get; set; }
        public int Antall { get; set; }
        public string VareArtUrl { get; set; }
        //public string KatId { get; set; }
        public Kategori Kategori { get; set; }
        public Land Land { get; set; }
        public virtual List<Bestilling> Bestillinger { get; set; }
    }

    public class Land
    {
        [Key]
        public int LandId { get; set; }
        public string Navn { get; set; }
    }


    public class Bestilling
    {
        [Key]
        public int Bid { get; set; }
        public decimal Belop { get; set;}
        public System.DateTime OrdreDato { get; set; }
        public virtual List<Vare> Varer { get; set; }
        
    }


    public class Kategori
    {
        [Key]
        public int KatId { get; set; }
        public string KatNavn { get; set; }
        public virtual List<Vare> Varer { get; set; }
    }

   

    public class Adminer
    {
        [Key]
        public int Aid { get; set; }
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        public string Adresse { get; set; }
        public string Postnr { get; set; }
        public string Epost { get; set; }
        public string Rolle { get; set; }
        public byte[] Passord { get; set; }
        public virtual Poststeder Poststeder { get; set; }

        public string Poststed { get; set; }
    }

    public class DrikkContext : DbContext
    {
        public DrikkContext()
            : base("name=Drink")
        {
            Database.CreateIfNotExists();
        }
        public DbSet<Kunder> Kunder { get; set; }
        public DbSet<Poststeder> Poststeder { get; set; }
        public DbSet<Bestilling> Bestillinger { get; set; }
        public DbSet<Vare> Varer { get; set; }
        public DbSet<Adminer> Adminer { get; set; }
        public DbSet<Kategori> Kategorier { get; set; }
        public DbSet<Land> Lander{ get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Poststeder>().HasKey(p => p.Postnr);
            modelBuilder.Entity<Kategori>().HasKey(p => p.KatId);
            modelBuilder.Entity<Vare>().HasKey(p => p.VareId);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
