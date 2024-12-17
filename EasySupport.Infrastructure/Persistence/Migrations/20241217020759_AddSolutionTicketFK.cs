using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasySupport.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddSolutionTicketFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SolutionTicketId",
                table: "TicketInteractions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TicketInteractions_SolutionTicketId",
                table: "TicketInteractions",
                column: "SolutionTicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketInteractions_SolutionTickets_SolutionTicketId",
                table: "TicketInteractions",
                column: "SolutionTicketId",
                principalTable: "SolutionTickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketInteractions_SolutionTickets_SolutionTicketId",
                table: "TicketInteractions");

            migrationBuilder.DropIndex(
                name: "IX_TicketInteractions_SolutionTicketId",
                table: "TicketInteractions");

            migrationBuilder.DropColumn(
                name: "SolutionTicketId",
                table: "TicketInteractions");
        }
    }
}
