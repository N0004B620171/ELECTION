using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ELECTION.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidat",
                columns: table => new
                {
                    CandidatID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateNaissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PartiPolitique = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidat", x => x.CandidatID);
                });

            migrationBuilder.CreateTable(
                name: "Electeur",
                columns: table => new
                {
                    ElecteurID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateNaissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroIdentification = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Electeur", x => x.ElecteurID);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    RegionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomRegion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.RegionID);
                });

            migrationBuilder.CreateTable(
                name: "BureauDeVote",
                columns: table => new
                {
                    BureauID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emplacement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Responsable = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BureauDeVote", x => x.BureauID);
                    table.ForeignKey(
                        name: "FK_BureauDeVote_Region_RegionID",
                        column: x => x.RegionID,
                        principalTable: "Region",
                        principalColumn: "RegionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vote",
                columns: table => new
                {
                    VoteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ElecteurID = table.Column<int>(type: "int", nullable: false),
                    CandidatID = table.Column<int>(type: "int", nullable: false),
                    BureauID = table.Column<int>(type: "int", nullable: false),
                    DateVote = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BureauDeVoteBureauID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vote", x => x.VoteID);
                    table.ForeignKey(
                        name: "FK_Vote_BureauDeVote_BureauDeVoteBureauID",
                        column: x => x.BureauDeVoteBureauID,
                        principalTable: "BureauDeVote",
                        principalColumn: "BureauID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vote_Candidat_CandidatID",
                        column: x => x.CandidatID,
                        principalTable: "Candidat",
                        principalColumn: "CandidatID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vote_Electeur_ElecteurID",
                        column: x => x.ElecteurID,
                        principalTable: "Electeur",
                        principalColumn: "ElecteurID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BureauDeVote_RegionID",
                table: "BureauDeVote",
                column: "RegionID");

            migrationBuilder.CreateIndex(
                name: "IX_Vote_BureauDeVoteBureauID",
                table: "Vote",
                column: "BureauDeVoteBureauID");

            migrationBuilder.CreateIndex(
                name: "IX_Vote_CandidatID",
                table: "Vote",
                column: "CandidatID");

            migrationBuilder.CreateIndex(
                name: "IX_Vote_ElecteurID",
                table: "Vote",
                column: "ElecteurID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vote");

            migrationBuilder.DropTable(
                name: "BureauDeVote");

            migrationBuilder.DropTable(
                name: "Candidat");

            migrationBuilder.DropTable(
                name: "Electeur");

            migrationBuilder.DropTable(
                name: "Region");
        }
    }
}
