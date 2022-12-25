using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gdc.Data.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoursGeneriques",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateDerniereModification = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursGeneriques", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enseignants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroExterne = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Specialite = table.Column<int>(type: "int", nullable: false),
                    Niveau = table.Column<int>(type: "int", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateDerniereModification = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enseignants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Niveaux",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ValeurCycle = table.Column<int>(type: "int", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroExterne = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DesignationFiliere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DesignationCycle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateDerniereModification = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Niveaux", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Matieres",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NbreHeureInitiale = table.Column<int>(type: "int", nullable: false),
                    CodeMatiere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoteDeValidation = table.Column<double>(type: "float", nullable: false),
                    NiveauId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoursGeneriqueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EnseignantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateDerniereModification = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matieres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matieres_CoursGeneriques_CoursGeneriqueId",
                        column: x => x.CoursGeneriqueId,
                        principalTable: "CoursGeneriques",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matieres_Enseignants_EnseignantId",
                        column: x => x.EnseignantId,
                        principalTable: "Enseignants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matieres_Niveaux_NiveauId",
                        column: x => x.NiveauId,
                        principalTable: "Niveaux",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matieres_CoursGeneriqueId",
                table: "Matieres",
                column: "CoursGeneriqueId");

            migrationBuilder.CreateIndex(
                name: "IX_Matieres_EnseignantId",
                table: "Matieres",
                column: "EnseignantId");

            migrationBuilder.CreateIndex(
                name: "IX_Matieres_NiveauId",
                table: "Matieres",
                column: "NiveauId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matieres");

            migrationBuilder.DropTable(
                name: "CoursGeneriques");

            migrationBuilder.DropTable(
                name: "Enseignants");

            migrationBuilder.DropTable(
                name: "Niveaux");
        }
    }
}
