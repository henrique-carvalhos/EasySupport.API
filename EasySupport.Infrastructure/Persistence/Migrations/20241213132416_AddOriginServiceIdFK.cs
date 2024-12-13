using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasySupport.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddOriginServiceIdFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OriginServiceId",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_OriginServiceId",
                table: "Tickets",
                column: "OriginServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_OriginServices_OriginServiceId",
                table: "Tickets",
                column: "OriginServiceId",
                principalTable: "OriginServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_OriginServices_OriginServiceId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_OriginServiceId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "OriginServiceId",
                table: "Tickets");
        }
    }
}
