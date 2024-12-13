using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasySupport.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddSolutionTicket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SolutionTicketId",
                table: "Tickets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SolutionTickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolutionTickets", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_SolutionTicketId",
                table: "Tickets",
                column: "SolutionTicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_SolutionTickets_SolutionTicketId",
                table: "Tickets",
                column: "SolutionTicketId",
                principalTable: "SolutionTickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_SolutionTickets_SolutionTicketId",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "SolutionTickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_SolutionTicketId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "SolutionTicketId",
                table: "Tickets");
        }
    }
}
