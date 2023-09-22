using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseasyInfra.Migrations
{
    /// <inheritdoc />
    public partial class novodb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ocupação",
                table: "Users",
                newName: "Ocupacao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ocupacao",
                table: "Users",
                newName: "Ocupação");
        }
    }
}
