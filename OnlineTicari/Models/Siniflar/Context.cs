﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace OnlineTicari.Models.Siniflar
{
    public class Context: DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Cariler> Carilers { get; set; }
        public DbSet<Departman> Departmans { get; set; }
        public DbSet<Fatura_kalem> Fatura_kalems { get; set; }
        public DbSet<Fatura> Faturas { get; set; }
        public DbSet<Gider> Giders { get; set; }
        public DbSet<Kategori> Kategoris { get; set; }
        public DbSet<Personel> Personels { get; set; }
        public DbSet<SatisHareket> SatisHarekets { get; set; }
        public DbSet<Urunler> Urunlers { get; set; }
        public DbSet<Detay> Detays { get; set; }
        public DbSet<Yapilacak> Yapilacaks { get; set; }
        public DbSet<KargoDetay> KargoDetays { get; set; }
        public DbSet<KargoTakip> KargoTakips { get; set; }
        public DbSet<mesajlar> mesajlars { get; set; }

    }
}