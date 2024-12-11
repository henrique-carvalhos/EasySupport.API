using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasySupport.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateForeignKeyAttendantId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Users_AttendantId",
                table: "Tickets");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Users_AttendantId",
                table: "Tickets",
                column: "AttendantId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Users_AttendantId",
                table: "Tickets");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Users_AttendantId",
                table: "Tickets",
                column: "AttendantId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
