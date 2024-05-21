using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace candidateapi.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueConstraintToEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Candidats_Email",
                table: "Candidats",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Candidats_Email",
                table: "Candidats");
        }
    }
}
