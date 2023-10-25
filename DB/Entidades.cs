using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{

    public class Autores
    {
        [Key]
        public long id_autor { get; set; }
        public string nombre_autor { get; set; }

        public string apellidos_autor { get; set; }
    }

    public class Rel_Autores_Libros
    {
        [Key]
        public long id_rel_autores_libros { get; set; }
        [ForeignKey("Autores")]
        public Autores id_autor { get; set; }
        [ForeignKey("Libros")]
        public Libros id_libro {  get; set; }

    }

    public class Libros
    {
        [Key]
        public long id_libro { get; set; }  
        public string isbn_libro { get; set; }
        public string titulo_libro { get; set; }
        public string edicion_libro { get; set; }
        [ForeignKey("Editoriales")]
        public Editoriales id_editorial {  get; set; }
        [ForeignKey("Generos")]
        public Generos id_genero {  get; set; }
        [ForeignKey("Colecciones")]
        public Colecciones id_coleccion {  get; set; }
    }

    public class Editoriales
    {
        [Key]
        public long id_editorial { get; set; }
        public string nombre_editorial { get; set; }
    }
    public class Generos
    {
        [Key]
        public long id_genero { get; set; }
        public string nombre_genero { get; set; }
        public string descripcion_genero { get; set; }
    }

    public class Colecciones
    {
        [Key]
        public long id_coleccion { get; set; }
        public string nombre_coleccion { get; set; }
    }
    public class Accesos
    {
        [Key]
        public long id_acceso { get; set; }
        public string codigo_acceso { get; set; }
        public string descipcion_acceso { get; set; }
    }

    public class Usuarios
    {
        [Key]
        public long id_usuario { get; set; }
        public string dni_usuario { get; set; }
        public string nombre_usuario { get; set; }
        public string apellidos_usuario { get; set; }
        public string tlf_usuario { get; set; }
        public string email_usuario { get; set; }
        public string clave_usuario { get; set; }
        [ForeignKey("Accesos")]
        public Accesos id_acceso { get; set; }
        public bool estaBloqueado_usuario { get; set; }
        public DateTime fch_fin_bloqueo_usuario { get; set; }
        public DateTime fch_alta_usuario { get; set; }
        public  DateTime fch_baja_usuario { get; set; }
    }
    public class Prestamos
    {
        [Key]
        public long id_prestamo { get; set; }
        [ForeignKey("Libros")]
        public Libros id_libro { get; set; }
        [ForeignKey("Usuarios")]
        public Usuarios id_usuario { get; set; }
        public DateTime fch_inicio_prestamo { get; set; }
        public DateTime fch_fin_prestamo { get; set; }
        public DateTime fch_entrega_prestamo { get; set; }
        [ForeignKey("Estado_Prestamos")]
        public Estado_Prestamos id_estado_prestamo { get; set; }
    }
    public class Estado_Prestamos
    {
        [Key]
        public long id_estado_prestamo { get; set; }
        public string codigo_estado_prestamo { get; set; }
        public string descripcion_estado_prestamo { get; set; }
    }
}
