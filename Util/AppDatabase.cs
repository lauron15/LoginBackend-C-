using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoLoguin.Model;
using System;
using System.Linq;

namespace ProjetoLoguin.Util
{
    public class AppDatabase : DbContext
    {
        public AppDatabase(DbContextOptions<AppDatabase> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }


        public DbSet<Funcionario> Funcionarios { get; set; }
        //public DbSet<Produtos> Produtos { get; set; }

        public DbSet<Usuario> Usuarios { get; set; } 
   

    }
}