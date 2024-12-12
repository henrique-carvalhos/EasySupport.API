using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasySupport.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusTicketIdFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AttendantId",
                table: "Tickets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "StatusTicketId",
                table: "TicketInteractions",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_TicketInteractions_StatusTicketId",
                table: "TicketInteractions",
                column: "StatusTicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketInteractions_StatusTickets_StatusTicketId",
                table: "TicketInteractions",
                column: "StatusTicketId",
                principalTable: "StatusTickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketInteractions_StatusTickets_StatusTicketId",
                table: "TicketInteractions");

            migrationBuilder.DropIndex(
                name: "IX_TicketInteractions_StatusTicketId",
                table: "TicketInteractions");

            migrationBuilder.DropColumn(
                name: "StatusTicketId",
                table: "TicketInteractions");

            migrationBuilder.AlterColumn<int>(
                name: "AttendantId",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
