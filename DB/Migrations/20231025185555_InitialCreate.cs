using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DB.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accesos",
                columns: table => new
                {
                    id_acceso = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    codigo_acceso = table.Column<string>(type: "text", nullable: false),
                    descipcion_acceso = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accesos", x => x.id_acceso);
                });

            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    id_autor = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    nombre_autor = table.Column<string>(type: "text", nullable: false),
                    apellidos_autor = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.id_autor);
                });

            migrationBuilder.CreateTable(
                name: "Colecciones",
                columns: table => new
                {
                    id_coleccion = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    nombre_coleccion = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colecciones", x => x.id_coleccion);
                });

            migrationBuilder.CreateTable(
                name: "Editoriales",
                columns: table => new
                {
                    id_editorial = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    nombre_editorial = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editoriales", x => x.id_editorial);
                });

            migrationBuilder.CreateTable(
                name: "Estados_Prestamos",
                columns: table => new
                {
                    id_estado_prestamo = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    codigo_estado_prestamo = table.Column<string>(type: "text", nullable: false),
                    descripcion_estado_prestamo = table.Column<string>(type: "text", nullable: false),
                    Estado_Prestamoid_estado_prestamo = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados_Prestamos", x => x.id_estado_prestamo);
                    table.ForeignKey(
                        name: "FK_Estados_Prestamos_Estados_Prestamos_Estado_Prestamoid_estad~",
                        column: x => x.Estado_Prestamoid_estado_prestamo,
                        principalTable: "Estados_Prestamos",
                        principalColumn: "id_estado_prestamo");
                });

            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    id_genero = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    nombre_genero = table.Column<string>(type: "text", nullable: false),
                    descripcion_genero = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.id_genero);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    id_usuario = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    dni_usuario = table.Column<string>(type: "text", nullable: false),
                    nombre_usuario = table.Column<string>(type: "text", nullable: false),
                    apellidos_usuario = table.Column<string>(type: "text", nullable: false),
                    tlf_usuario = table.Column<string>(type: "text", nullable: false),
                    email_usuario = table.Column<string>(type: "text", nullable: false),
                    clave_usuario = table.Column<string>(type: "text", nullable: false),
                    id_acceso = table.Column<long>(type: "bigint", nullable: false),
                    estaBloqueado_usuario = table.Column<bool>(type: "boolean", nullable: false),
                    fch_fin_bloqueo_usuario = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    fch_alta_usuario = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    fch_baja_usuario = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    accesoid_acceso = table.Column<long>(type: "bigint", nullable: false),
                    Usuarioid_usuario = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.id_usuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Accesos_accesoid_acceso",
                        column: x => x.accesoid_acceso,
                        principalTable: "Accesos",
                        principalColumn: "id_acceso",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuarios_Usuarios_Usuarioid_usuario",
                        column: x => x.Usuarioid_usuario,
                        principalTable: "Usuarios",
                        principalColumn: "id_usuario");
                });

            migrationBuilder.CreateTable(
                name: "Libros",
                columns: table => new
                {
                    id_libro = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    isbn_libro = table.Column<string>(type: "text", nullable: false),
                    titulo_libro = table.Column<string>(type: "text", nullable: false),
                    edicion_libro = table.Column<string>(type: "text", nullable: false),
                    id_editorial = table.Column<long>(type: "bigint", nullable: false),
                    id_genero = table.Column<long>(type: "bigint", nullable: false),
                    id_coleccion = table.Column<long>(type: "bigint", nullable: false),
                    editorialid_editorial = table.Column<long>(type: "bigint", nullable: false),
                    generoid_genero = table.Column<long>(type: "bigint", nullable: false),
                    coleccionid_coleccion = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libros", x => x.id_libro);
                    table.ForeignKey(
                        name: "FK_Libros_Colecciones_coleccionid_coleccion",
                        column: x => x.coleccionid_coleccion,
                        principalTable: "Colecciones",
                        principalColumn: "id_coleccion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Libros_Editoriales_editorialid_editorial",
                        column: x => x.editorialid_editorial,
                        principalTable: "Editoriales",
                        principalColumn: "id_editorial",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Libros_Generos_generoid_genero",
                        column: x => x.generoid_genero,
                        principalTable: "Generos",
                        principalColumn: "id_genero",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prestamos",
                columns: table => new
                {
                    id_prestamo = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    id_libro = table.Column<long>(type: "bigint", nullable: false),
                    id_usuario = table.Column<long>(type: "bigint", nullable: false),
                    fch_inicio_prestamo = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    fch_fin_prestamo = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    fch_entrega_prestamo = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    id_estado_prestamo = table.Column<long>(type: "bigint", nullable: false),
                    libroid_libro = table.Column<long>(type: "bigint", nullable: false),
                    usuarioid_usuario = table.Column<long>(type: "bigint", nullable: false),
                    estado_prestamoid_estado_prestamo = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamos", x => x.id_prestamo);
                    table.ForeignKey(
                        name: "FK_Prestamos_Estados_Prestamos_estado_prestamoid_estado_presta~",
                        column: x => x.estado_prestamoid_estado_prestamo,
                        principalTable: "Estados_Prestamos",
                        principalColumn: "id_estado_prestamo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prestamos_Libros_libroid_libro",
                        column: x => x.libroid_libro,
                        principalTable: "Libros",
                        principalColumn: "id_libro",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prestamos_Usuarios_usuarioid_usuario",
                        column: x => x.usuarioid_usuario,
                        principalTable: "Usuarios",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rel_Autores_Libros",
                columns: table => new
                {
                    id_rel_autores_libros = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    id_autor = table.Column<long>(type: "bigint", nullable: false),
                    id_libro = table.Column<long>(type: "bigint", nullable: false),
                    autorid_autor = table.Column<long>(type: "bigint", nullable: false),
                    libroid_libro = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rel_Autores_Libros", x => x.id_rel_autores_libros);
                    table.ForeignKey(
                        name: "FK_Rel_Autores_Libros_Autores_autorid_autor",
                        column: x => x.autorid_autor,
                        principalTable: "Autores",
                        principalColumn: "id_autor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rel_Autores_Libros_Libros_libroid_libro",
                        column: x => x.libroid_libro,
                        principalTable: "Libros",
                        principalColumn: "id_libro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estados_Prestamos_Estado_Prestamoid_estado_prestamo",
                table: "Estados_Prestamos",
                column: "Estado_Prestamoid_estado_prestamo");

            migrationBuilder.CreateIndex(
                name: "IX_Libros_coleccionid_coleccion",
                table: "Libros",
                column: "coleccionid_coleccion");

            migrationBuilder.CreateIndex(
                name: "IX_Libros_editorialid_editorial",
                table: "Libros",
                column: "editorialid_editorial");

            migrationBuilder.CreateIndex(
                name: "IX_Libros_generoid_genero",
                table: "Libros",
                column: "generoid_genero");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_estado_prestamoid_estado_prestamo",
                table: "Prestamos",
                column: "estado_prestamoid_estado_prestamo");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_libroid_libro",
                table: "Prestamos",
                column: "libroid_libro");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_usuarioid_usuario",
                table: "Prestamos",
                column: "usuarioid_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Rel_Autores_Libros_autorid_autor",
                table: "Rel_Autores_Libros",
                column: "autorid_autor");

            migrationBuilder.CreateIndex(
                name: "IX_Rel_Autores_Libros_libroid_libro",
                table: "Rel_Autores_Libros",
                column: "libroid_libro");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_accesoid_acceso",
                table: "Usuarios",
                column: "accesoid_acceso");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Usuarioid_usuario",
                table: "Usuarios",
                column: "Usuarioid_usuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prestamos");

            migrationBuilder.DropTable(
                name: "Rel_Autores_Libros");

            migrationBuilder.DropTable(
                name: "Estados_Prestamos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Autores");

            migrationBuilder.DropTable(
                name: "Libros");

            migrationBuilder.DropTable(
                name: "Accesos");

            migrationBuilder.DropTable(
                name: "Colecciones");

            migrationBuilder.DropTable(
                name: "Editoriales");

            migrationBuilder.DropTable(
                name: "Generos");
        }
    }
}
