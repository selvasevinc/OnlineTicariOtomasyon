using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicari.Models.Siniflar
{
    public class Kategori
    {
        [Key]
        public int KategoriId { get; set; } // property

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string KategoriAd { get; set; }

        public ICollection<Urunler> Urunlers { get; set; } //veri tabanında tutulacağı tablo

    }
}