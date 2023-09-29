using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WantedRobots.Migrations
{
    /// <inheritdoc />
    public partial class nouveauNomDeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Robots_AgentRobots_AgentId",
                table: "Robots");

            migrationBuilder.DropTable(
                name: "AgentRobots");

            migrationBuilder.DropIndex(
                name: "IX_Robots_AgentId",
                table: "Robots");

            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "Robots");

            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NomAgent = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Identification = table.Column<double>(type: "double", nullable: false),
                    Continent = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Commentaire = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agents");

            migrationBuilder.AddColumn<int>(
                name: "AgentId",
                table: "Robots",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AgentRobots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Commentaire = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Continent = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Identification = table.Column<double>(type: "double", nullable: false),
                    NomAgent = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentRobots", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Robots_AgentId",
                table: "Robots",
                column: "AgentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Robots_AgentRobots_AgentId",
                table: "Robots",
                column: "AgentId",
                principalTable: "AgentRobots",
                principalColumn: "Id");
        }
    }
}
