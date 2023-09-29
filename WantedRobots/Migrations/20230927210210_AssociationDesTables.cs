using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WantedRobots.Migrations
{
    /// <inheritdoc />
    public partial class AssociationDesTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Commentaire",
                table: "Agents");

            migrationBuilder.AddColumn<int>(
                name: "AgentId",
                table: "Robots",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Commentaire",
                table: "Robots",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Continent",
                table: "Robots",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "Robots");

            migrationBuilder.DropColumn(
                name: "Commentaire",
                table: "Robots");

            migrationBuilder.DropColumn(
                name: "Continent",
                table: "Robots");

            migrationBuilder.AddColumn<string>(
                name: "Commentaire",
                table: "Agents",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
