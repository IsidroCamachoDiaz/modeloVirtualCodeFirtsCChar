using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{

    public class Autor
    {
        [Key]
        public long id_autor { get; set; }

        public string nombre_autor { get; set; }

        public string apellidos_autor { get; set; }

        public ICollection<Rel_Autores_Libros> rel_autores_libros { get; set; }
    }

    public class Rel_Autores_Libros
    {
        [Key]
        public long id_rel_autores_libros { get; set; }

        [ForeignKey("Autor")]
        public long id_autor { get; set; }

        [ForeignKey("Libro")]
        public long id_libro {  get; set; }

        public Autor autor { get; set; }

        public Libro libro { get; set; }
    }

    public class Libro
    {
        [Key]
        public long id_libro { get; set; }  

        public string isbn_libro { get; set; }

        public string titulo_libro { get; set; }

        public string edicion_libro { get; set; }

        [ForeignKey("Editorial")]
        public long id_editorial {  get; set; }

        [ForeignKey("Genero")]
        public long id_genero {  get; set; }

        [ForeignKey("Coleccion")]
        public long id_coleccion {  get; set; }

        public Editorial editorial { get; set; }
        public Genero genero { get; set; }
        public Coleccion coleccion { get; set; }

        public ICollection<Rel_Autores_Libros> rel_autores_libros { get; set; }
    }

    public class Editorial
    {
        [Key]
        public long id_editorial { get; set; }

        public string nombre_editorial { get; set; }

        public ICollection<Libro> libros { get; set; }
    }
    public class Genero
    {
        [Key]
        public long id_genero { get; set; }

        public string nombre_genero { get; set; }

        public string descripcion_genero { get; set; }

        public ICollection<Libro> libros { get; set; }
    }

    public class Coleccion
    {
        [Key]
        public long id_coleccion { get; set; }
        public string nombre_coleccion { get; set; }

        public ICollection<Libro> libros { get; set; }
    }
    public class Acceso
    {
        [Key]
        public long id_acceso { get; set; }
        public string codigo_acceso { get; set; }
        public string descipcion_acceso { get; set; }
        
        public ICollection<Usuario> usuarios { get; set; }
    }

    public class Usuario
    {
        [Key]
        public long id_usuario { get; set; }
        public string dni_usuario { get; set; }
        public string nombre_usuario { get; set; }
        public string apellidos_usuario { get; set; }
        public string tlf_usuario { get; set; }
        public string email_usuario { get; set; }
        public string clave_usuario { get; set; }

        [ForeignKey("Acceso")]
        public long id_acceso { get; set; }
        public bool estaBloqueado_usuario { get; set; }
        public DateTime fch_fin_bloqueo_usuario { get; set; }
        public DateTime fch_alta_usuario { get; set; }
        public  DateTime fch_baja_usuario { get; set; }

        public Acceso acceso { get; set; }

        public ICollection<Usuario> usuarios { get; set; }
    }
    public class Prestamo
    {
        [Key]
        public long id_prestamo { get; set; }

        [ForeignKey("Libro")]
        public long id_libro { get; set; }

        [ForeignKey("Usuario")]
        public long id_usuario { get; set; }

        public DateTime fch_inicio_prestamo { get; set; }
        public DateTime fch_fin_prestamo { get; set; }
        public DateTime fch_entrega_prestamo { get; set; }

        [ForeignKey("Estado_Prestamo")]
        public long id_estado_prestamo { get; set; }

        public Libro libro { get; set; }
        public Usuario usuario { get; set; }
        public Estado_Prestamo estado_prestamo { get; set; }
    }
    public class Estado_Prestamo
    {
        [Key]
        public long id_estado_prestamo { get; set; }
        public string codigo_estado_prestamo { get; set; }
        public string descripcion_estado_prestamo { get; set; }

        public ICollection<Estado_Prestamo> prestamos { get; set; }
    }
}
