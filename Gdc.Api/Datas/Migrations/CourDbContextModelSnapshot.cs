﻿// <auto-generated />
using System;
using GDE.Api.Datas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Gdc.Api.Datas.Migrations
{
    [DbContext(typeof(CourDbContext))]
    partial class CourDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

            modelBuilder.Entity("Gdc.Api.Modeles.CoursGenerique", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateDerniereModification")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("CoursGeneriques");
                });

            modelBuilder.Entity("Gdc.Api.Modeles.Enseignant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateDerniereModification")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("NumeroExterne")
                        .HasColumnType("TEXT");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Enseignants");
                });

            modelBuilder.Entity("Gdc.Api.Modeles.Matiere", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("CodeMatiere")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CoursGeneriqueId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateDerniereModification")
                        .HasColumnType("TEXT");

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("EnseignantId")
                        .HasColumnType("TEXT");

                    b.Property<int>("NbreHeureInitiale")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("NiveauId")
                        .HasColumnType("TEXT");

                    b.Property<double>("NoteDeValidation")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("CoursGeneriqueId");

                    b.HasIndex("EnseignantId");

                    b.HasIndex("NiveauId");

                    b.ToTable("Matieres");
                });

            modelBuilder.Entity("Gdc.Api.Modeles.Niveau", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateDerniereModification")
                        .HasColumnType("TEXT");

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("NumeroExterne")
                        .HasColumnType("TEXT");

                    b.Property<int>("ValeurCycle")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Niveaux");
                });

            modelBuilder.Entity("Gdc.Api.Modeles.Programmation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateDeDebut")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateDeFin")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateDerniereModification")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("EnseignantId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("MatiereId")
                        .HasColumnType("TEXT");

                    b.Property<int>("NbreHeureProgrammer")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("EnseignantId");

                    b.HasIndex("MatiereId");

                    b.ToTable("Programmations");
                });

            modelBuilder.Entity("Gdc.Api.Modeles.SuivitMatiere", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateDerniereModification")
                        .HasColumnType("TEXT");

                    b.Property<string>("Detail")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Effectue")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("ProgrammationId")
                        .HasColumnType("TEXT");

                    b.Property<int>("RaisonDeLechec")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProgrammationId");

                    b.ToTable("SuivitMatieres");
                });

            modelBuilder.Entity("Gdc.Api.Modeles.Matiere", b =>
                {
                    b.HasOne("Gdc.Api.Modeles.CoursGenerique", "CoursGenerique")
                        .WithMany("Matieres")
                        .HasForeignKey("CoursGeneriqueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gdc.Api.Modeles.Enseignant", "Enseignant")
                        .WithMany("Matieres")
                        .HasForeignKey("EnseignantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gdc.Api.Modeles.Niveau", "Niveau")
                        .WithMany("Matieres")
                        .HasForeignKey("NiveauId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CoursGenerique");

                    b.Navigation("Enseignant");

                    b.Navigation("Niveau");
                });

            modelBuilder.Entity("Gdc.Api.Modeles.Programmation", b =>
                {
                    b.HasOne("Gdc.Api.Modeles.Enseignant", null)
                        .WithMany("Programmations")
                        .HasForeignKey("EnseignantId");

                    b.HasOne("Gdc.Api.Modeles.Matiere", "Matiere")
                        .WithMany("Programmations")
                        .HasForeignKey("MatiereId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Matiere");
                });

            modelBuilder.Entity("Gdc.Api.Modeles.SuivitMatiere", b =>
                {
                    b.HasOne("Gdc.Api.Modeles.Programmation", "Programmation")
                        .WithMany()
                        .HasForeignKey("ProgrammationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Programmation");
                });

            modelBuilder.Entity("Gdc.Api.Modeles.CoursGenerique", b =>
                {
                    b.Navigation("Matieres");
                });

            modelBuilder.Entity("Gdc.Api.Modeles.Enseignant", b =>
                {
                    b.Navigation("Matieres");

                    b.Navigation("Programmations");
                });

            modelBuilder.Entity("Gdc.Api.Modeles.Matiere", b =>
                {
                    b.Navigation("Programmations");
                });

            modelBuilder.Entity("Gdc.Api.Modeles.Niveau", b =>
                {
                    b.Navigation("Matieres");
                });
#pragma warning restore 612, 618
        }
    }
}
