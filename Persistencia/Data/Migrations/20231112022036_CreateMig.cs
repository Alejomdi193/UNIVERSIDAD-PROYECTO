using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CursoEscolar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AñoInicial = table.Column<int>(type: "int", nullable: false),
                    AñoFinal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursoEscolar", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Departamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamento", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Grado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grado", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nif = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nombre = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Apellido1 = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Apellido2 = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ciudad = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Direccion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Fecha_Nacimiento = table.Column<DateTime>(type: "Date", nullable: false),
                    Genero = table.Column<string>(type: "varchar(1)", maxLength: 1, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoPersona = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Profesor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdProfesorFk = table.Column<int>(type: "int", nullable: false),
                    IdDepartamentoFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profesor_Departamento_IdDepartamentoFk",
                        column: x => x.IdDepartamentoFk,
                        principalTable: "Departamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Profesor_Persona_IdProfesorFk",
                        column: x => x.IdProfesorFk,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Asignatura",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Creditos = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    Tipo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cursos = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    Cuatrimestre = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    IdProfesorFk = table.Column<int>(type: "int", nullable: false),
                    IdGradoFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asignatura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Asignatura_Grado_IdGradoFk",
                        column: x => x.IdGradoFk,
                        principalTable: "Grado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Asignatura_Profesor_IdProfesorFk",
                        column: x => x.IdProfesorFk,
                        principalTable: "Profesor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Alumno_Se_Matricula_Asignatura",
                columns: table => new
                {
                    IdAlumnoFk = table.Column<int>(type: "int", nullable: false),
                    IdAsignaturaFk = table.Column<int>(type: "int", nullable: false),
                    IdCursoEscolarFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumno_Se_Matricula_Asignatura", x => new { x.IdAsignaturaFk, x.IdAlumnoFk, x.IdCursoEscolarFk });
                    table.ForeignKey(
                        name: "FK_Alumno_Se_Matricula_Asignatura_Asignatura_IdAsignaturaFk",
                        column: x => x.IdAsignaturaFk,
                        principalTable: "Asignatura",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alumno_Se_Matricula_Asignatura_CursoEscolar_IdCursoEscolarFk",
                        column: x => x.IdCursoEscolarFk,
                        principalTable: "CursoEscolar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alumno_Se_Matricula_Asignatura_Persona_IdAlumnoFk",
                        column: x => x.IdAlumnoFk,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Alumno_Se_Matricula_Asignatura_IdAlumnoFk",
                table: "Alumno_Se_Matricula_Asignatura",
                column: "IdAlumnoFk");

            migrationBuilder.CreateIndex(
                name: "IX_Alumno_Se_Matricula_Asignatura_IdCursoEscolarFk",
                table: "Alumno_Se_Matricula_Asignatura",
                column: "IdCursoEscolarFk");

            migrationBuilder.CreateIndex(
                name: "IX_Asignatura_IdGradoFk",
                table: "Asignatura",
                column: "IdGradoFk");

            migrationBuilder.CreateIndex(
                name: "IX_Asignatura_IdProfesorFk",
                table: "Asignatura",
                column: "IdProfesorFk");

            migrationBuilder.CreateIndex(
                name: "IX_Profesor_IdDepartamentoFk",
                table: "Profesor",
                column: "IdDepartamentoFk");

            migrationBuilder.CreateIndex(
                name: "IX_Profesor_IdProfesorFk",
                table: "Profesor",
                column: "IdProfesorFk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alumno_Se_Matricula_Asignatura");

            migrationBuilder.DropTable(
                name: "Asignatura");

            migrationBuilder.DropTable(
                name: "CursoEscolar");

            migrationBuilder.DropTable(
                name: "Grado");

            migrationBuilder.DropTable(
                name: "Profesor");

            migrationBuilder.DropTable(
                name: "Departamento");

            migrationBuilder.DropTable(
                name: "Persona");
        }
    }
}
