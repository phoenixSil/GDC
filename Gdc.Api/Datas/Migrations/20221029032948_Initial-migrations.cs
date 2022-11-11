using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gdc.Api.Datas.Migrations
{
    public partial class Initialmigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoursGeneriques",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Designation = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateDerniereModification = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursGeneriques", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enseignants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nom = table.Column<string>(type: "TEXT", nullable: false),
                    Prenom = table.Column<string>(type: "TEXT", nullable: false),
                    NumeroExterne = table.Column<Guid>(type: "TEXT", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateDerniereModification = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enseignants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Niveaux",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ValeurCycle = table.Column<int>(type: "INTEGER", nullable: false),
                    Designation = table.Column<string>(type: "TEXT", nullable: false),
                    NumeroExterne = table.Column<Guid>(type: "TEXT", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateDerniereModification = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Niveaux", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Matieres",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    NbreHeureInitiale = table.Column<int>(type: "INTEGER", nullable: false),
                    CodeMatiere = table.Column<string>(type: "TEXT", nullable: false),
                    Designation = table.Column<string>(type: "TEXT", nullable: false),
                    NoteDeValidation = table.Column<double>(type: "REAL", nullable: false),
                    NiveauId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CoursGeneriqueId = table.Column<Guid>(type: "TEXT", nullable: false),
                    EnseignantId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateDerniereModification = table.Column<DateTime>(type: "TEXT", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Programmations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    NbreHeureProgrammer = table.Column<int>(type: "INTEGER", nullable: false),
                    DateDeDebut = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateDeFin = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MatiereId = table.Column<Guid>(type: "TEXT", nullable: false),
                    EnseignantId = table.Column<Guid>(type: "TEXT", nullable: true),
                    DateCreation = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateDerniereModification = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programmations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Programmations_Enseignants_EnseignantId",
                        column: x => x.EnseignantId,
                        principalTable: "Enseignants",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Programmations_Matieres_MatiereId",
                        column: x => x.MatiereId,
                        principalTable: "Matieres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SuivitMatieres",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Effectue = table.Column<bool>(type: "INTEGER", nullable: false),
                    RaisonDeLechec = table.Column<int>(type: "INTEGER", nullable: false),
                    Detail = table.Column<string>(type: "TEXT", nullable: false),
                    ProgrammationId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateDerniereModification = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuivitMatieres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SuivitMatieres_Programmations_ProgrammationId",
                        column: x => x.ProgrammationId,
                        principalTable: "Programmations",
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

            migrationBuilder.CreateIndex(
                name: "IX_Programmations_EnseignantId",
                table: "Programmations",
                column: "EnseignantId");

            migrationBuilder.CreateIndex(
                name: "IX_Programmations_MatiereId",
                table: "Programmations",
                column: "MatiereId");

            migrationBuilder.CreateIndex(
                name: "IX_SuivitMatieres_ProgrammationId",
                table: "SuivitMatieres",
                column: "ProgrammationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SuivitMatieres");

            migrationBuilder.DropTable(
                name: "Programmations");

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
