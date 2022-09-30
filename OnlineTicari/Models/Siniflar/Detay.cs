using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineTicari.Models.Siniflar
{
    public class Detay
    {
        [Key]
        public int DetayID { get; set; }

        [Column(TypeName ="Varchar")]
        [StringLength(30)]
        public string urunad { get; set; }

        [Column(TypeName ="Varchar")]
        [StringLength(2000)]
        public string urunbilgi { get; set; }
    }
}