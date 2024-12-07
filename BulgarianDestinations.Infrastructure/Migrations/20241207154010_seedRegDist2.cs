using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulgarianDestinations.Infrastructure.Migrations
{
    public partial class seedRegDist2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Destination_DestinationId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_DestinationId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "DestinationId",
                table: "People");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Destination",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Destination_PersonId",
                table: "Destination",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Destination_People_PersonId",
                table: "Destination",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Destination_People_PersonId",
                table: "Destination");

            migrationBuilder.DropIndex(
                name: "IX_Destination_PersonId",
                table: "Destination");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Destination");

            migrationBuilder.AddColumn<int>(
                name: "DestinationId",
                table: "People",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_People_DestinationId",
                table: "People",
                column: "DestinationId");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Destination_DestinationId",
                table: "People",
                column: "DestinationId",
                principalTable: "Destination",
                principalColumn: "Id");
        }
    }
}
