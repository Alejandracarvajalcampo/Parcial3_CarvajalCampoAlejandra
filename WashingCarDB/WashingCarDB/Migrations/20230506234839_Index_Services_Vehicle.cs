using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WashingCarDB.Migrations
{
    /// <inheritdoc />
    public partial class Index_Services_Vehicle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Countries_Name",
                table: "Countries",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_NumberPlate",
                table: "Categories",
                column: "NumberPlate",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Countries_Name",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Categories_NumberPlate",
                table: "Categories");
        }
    }
}
