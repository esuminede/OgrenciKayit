using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace OgrenciKayit.Models
{
    public class Ogrenci
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OgrenciNo { get; set; }

        [Required]
        public string Sinif { get; set; }

        [Required]
        public string Isim { get; set; }

        [Required]
        public string Soyisim { get; set; }
    }
}