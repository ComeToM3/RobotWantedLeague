using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WantedRobots.Migrations
{
    /// <inheritdoc />
    public partial class AddAgentRelationshipToRobot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AgentId",
                table: "Robots",
                type: "int",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Robots_AgentRobots_AgentId",
                table: "Robots");

            migrationBuilder.DropIndex(
                name: "IX_Robots_AgentId",
                table: "Robots");

            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "Robots");
        }
    }
}
