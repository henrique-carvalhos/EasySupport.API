using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasySupport.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddAttedantTicket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AttendantId",
                table: "Tickets",
                type: "int",
                nullable: true,
                defaultValue: null);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_AttendantId",
                table: "Tickets",
                column: "AttendantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Users_AttendantId",
                table: "Tickets",
                column: "AttendantId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Users_AttendantId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_AttendantId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "AttendantId",
                table: "Tickets");
        }
    }
}
