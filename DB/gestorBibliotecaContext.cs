using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class gestorBibliotecaContext:DbContext
    {
        public gestorBibliotecaContext(DbContextOptions<gestorBibliotecaContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Accesos> Accesos { get; set; }
        public DbSet<Autores> Autores { get; set; }
        public DbSet<Rel_Autores_Libros> Rel_Autores_Libros { get; set; }
        public DbSet<Libros> Libros { get; set; }
        public DbSet<Editoriales> Editoriales { get; set; }
        public DbSet<Generos> Generos { get; set; }
        public DbSet<Colecciones> Colecciones { get; set; }
        public DbSet<Prestamos> Prestamos { get; set; }
        public DbSet<Estado_Prestamos> Estados_Prestamos { get; set; }

    }
}
