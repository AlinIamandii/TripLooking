using Microsoft.EntityFrameworkCore.Migrations;

namespace TripLooking.Persistence.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Trips_TripId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Trips_TripId",
                table: "Photo");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Trips_TripId",
                table: "Comment",
                column: "TripId",
                principalTable: "Trips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_Trips_TripId",
                table: "Photo",
                column: "TripId",
                principalTable: "Trips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Trips_TripId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Trips_TripId",
                table: "Photo");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Trips_TripId",
                table: "Comment",
                column: "TripId",
                principalTable: "Trips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_Trips_TripId",
                table: "Photo",
                column: "TripId",
                principalTable: "Trips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
