using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using OgrenciKayit.Models;

namespace OgrenciKayit.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("OgrenciKayitDb") { }
        
        public DbSet<Ogrenci> Ogrencis { get; set; }
    }
}