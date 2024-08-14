using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsumerMessage.Migrations
{
    /// <inheritdoc />
    public partial class attMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "uf",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "uf",
                table: "Clientes");
        }
    }
}
