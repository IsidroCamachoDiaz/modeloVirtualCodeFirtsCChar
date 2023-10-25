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
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Acceso> Accesos { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Rel_Autores_Libros> Rel_Autores_Libros { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Editorial> Editoriales { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Coleccion> Colecciones { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<Estado_Prestamo> Estados_Prestamos { get; set; }

    }
}
