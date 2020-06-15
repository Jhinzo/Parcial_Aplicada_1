using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Parcial_Aplicada_1.Entidades;


namespace Parcial_Aplicada_1.DAL
{
    public class Contexto : DbContext
    {

        public DbSet<Articulos> Articulos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source= DATA\Articulos.db");
        }
    }
}