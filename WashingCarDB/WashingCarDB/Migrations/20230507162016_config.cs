using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WashingCarDB.Migrations
{
    /// <inheritdoc />
    public partial class config : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Vehicles_VehicleId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehiclesDetails_VehicleDetailsId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_VehicleDetailsId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Services_VehicleId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "VehicleDetailsId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "Services");

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryDate",
                table: "VehiclesDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<Guid>(
                name: "VehicleId",
                table: "VehiclesDetails",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ServiceId",
                table: "Vehicles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehiclesDetails_VehicleId",
                table: "VehiclesDetails",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ServiceId",
                table: "Vehicles",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Services_ServiceId",
                table: "Vehicles",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VehiclesDetails_Vehicles_VehicleId",
                table: "VehiclesDetails",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Services_ServiceId",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_VehiclesDetails_Vehicles_VehicleId",
                table: "VehiclesDetails");

            migrationBuilder.DropIndex(
                name: "IX_VehiclesDetails_VehicleId",
                table: "VehiclesDetails");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_ServiceId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "VehiclesDetails");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Vehicles");

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryDate",
                table: "VehiclesDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "VehicleDetailsId",
                table: "Vehicles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "VehicleId",
                table: "Services",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleDetailsId",
                table: "Vehicles",
                column: "VehicleDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_VehicleId",
                table: "Services",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Vehicles_VehicleId",
                table: "Services",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_VehiclesDetails_VehicleDetailsId",
                table: "Vehicles",
                column: "VehicleDetailsId",
                principalTable: "VehiclesDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
