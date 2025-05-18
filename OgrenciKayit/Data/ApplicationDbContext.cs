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
        public ApplicationDbContext() : base("DefaultConnection") { }
        
        public DbSet<Ogrenci> Ogrenciler { get; set; }
    }
}