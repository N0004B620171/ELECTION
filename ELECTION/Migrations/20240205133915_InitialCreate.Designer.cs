﻿// <auto-generated />
using System;
using ELECTION.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ELECTION.Migrations
{
    [DbContext(typeof(ELECTIONContext))]
    [Migration("20240205133915_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ELECTION.Models.BureauDeVote", b =>
                {
                    b.Property<int>("BureauID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BureauID"));

                    b.Property<string>("Emplacement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RegionID")
                        .HasColumnType("int");

                    b.Property<string>("Responsable")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BureauID");

                    b.HasIndex("RegionID");

                    b.ToTable("BureauDeVote");
                });

            modelBuilder.Entity("ELECTION.Models.Candidat", b =>
                {
                    b.Property<int>("CandidatID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CandidatID"));

                    b.Property<DateTime>("DateNaissance")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PartiPolitique")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CandidatID");

                    b.ToTable("Candidat");
                });

            modelBuilder.Entity("ELECTION.Models.Electeur", b =>
                {
                    b.Property<int>("ElecteurID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ElecteurID"));

                    b.Property<string>("Adresse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateNaissance")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroIdentification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ElecteurID");

                    b.ToTable("Electeur");
                });

            modelBuilder.Entity("ELECTION.Models.Region", b =>
                {
                    b.Property<int>("RegionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RegionID"));

                    b.Property<string>("NomRegion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RegionID");

                    b.ToTable("Region");
                });

            modelBuilder.Entity("ELECTION.Models.Vote", b =>
                {
                    b.Property<int>("VoteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VoteID"));

                    b.Property<int>("BureauDeVoteBureauID")
                        .HasColumnType("int");

                    b.Property<int>("BureauID")
                        .HasColumnType("int");

                    b.Property<int>("CandidatID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateVote")
                        .HasColumnType("datetime2");

                    b.Property<int>("ElecteurID")
                        .HasColumnType("int");

                    b.HasKey("VoteID");

                    b.HasIndex("BureauDeVoteBureauID");

                    b.HasIndex("CandidatID");

                    b.HasIndex("ElecteurID");

                    b.ToTable("Vote");
                });

            modelBuilder.Entity("ELECTION.Models.BureauDeVote", b =>
                {
                    b.HasOne("ELECTION.Models.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Region");
                });

            modelBuilder.Entity("ELECTION.Models.Vote", b =>
                {
                    b.HasOne("ELECTION.Models.BureauDeVote", "BureauDeVote")
                        .WithMany()
                        .HasForeignKey("BureauDeVoteBureauID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ELECTION.Models.Candidat", "Candidat")
                        .WithMany()
                        .HasForeignKey("CandidatID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ELECTION.Models.Electeur", "Electeur")
                        .WithMany()
                        .HasForeignKey("ElecteurID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BureauDeVote");

                    b.Navigation("Candidat");

                    b.Navigation("Electeur");
                });
#pragma warning restore 612, 618
        }
    }
}
