using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ELECTION.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vote_BureauDeVote_BureauDeVoteBureauID",
                table: "Vote");

            migrationBuilder.DropIndex(
                name: "IX_Vote_BureauDeVoteBureauID",
                table: "Vote");

            migrationBuilder.DropColumn(
                name: "BureauDeVoteBureauID",
                table: "Vote");

            migrationBuilder.RenameColumn(
                name: "BureauID",
                table: "Vote",
                newName: "BureauDeVoteID");

            migrationBuilder.CreateIndex(
                name: "IX_Vote_BureauDeVoteID",
                table: "Vote",
                column: "BureauDeVoteID");

            migrationBuilder.AddForeignKey(
                name: "FK_Vote_BureauDeVote_BureauDeVoteID",
                table: "Vote",
                column: "BureauDeVoteID",
                principalTable: "BureauDeVote",
                principalColumn: "BureauID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vote_BureauDeVote_BureauDeVoteID",
                table: "Vote");

            migrationBuilder.DropIndex(
                name: "IX_Vote_BureauDeVoteID",
                table: "Vote");

            migrationBuilder.RenameColumn(
                name: "BureauDeVoteID",
                table: "Vote",
                newName: "BureauID");

            migrationBuilder.AddColumn<int>(
                name: "BureauDeVoteBureauID",
                table: "Vote",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Vote_BureauDeVoteBureauID",
                table: "Vote",
                column: "BureauDeVoteBureauID");

            migrationBuilder.AddForeignKey(
                name: "FK_Vote_BureauDeVote_BureauDeVoteBureauID",
                table: "Vote",
                column: "BureauDeVoteBureauID",
                principalTable: "BureauDeVote",
                principalColumn: "BureauID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
