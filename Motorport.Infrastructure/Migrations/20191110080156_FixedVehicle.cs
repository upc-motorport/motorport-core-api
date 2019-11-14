using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Motorport.Infrastructure.Migrations
{
    public partial class FixedVehicle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Subscriptions_SubscriptionId",
                table: "Vehicles");

            migrationBuilder.AlterColumn<int>(
                name: "Year",
                table: "Vehicles",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "SubscriptionId",
                table: "Vehicles",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "Kilometers",
                table: "Vehicles",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Active", "Brand", "CreatedAt", "CreatedBy", "ImageUrl", "Kilometers", "Model", "ModifiedAt", "ModifiedBy", "RegistrationPlate", "SubscriptionId", "Type", "Year" },
                values: new object[] { 1, true, "Chevrolet", new DateTime(2019, 11, 10, 3, 1, 55, 239, DateTimeKind.Local).AddTicks(539), null, null, 0, "Camaro", new DateTime(2019, 11, 10, 3, 1, 55, 239, DateTimeKind.Local).AddTicks(6142), null, "ABC123", null, "Car", 2014 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Active", "Brand", "CreatedAt", "CreatedBy", "ImageUrl", "Kilometers", "Model", "ModifiedAt", "ModifiedBy", "RegistrationPlate", "SubscriptionId", "Type", "Year" },
                values: new object[] { 2, true, "Chevrolet", new DateTime(2019, 11, 10, 3, 1, 55, 239, DateTimeKind.Local).AddTicks(8279), null, null, 0, "Bolt", new DateTime(2019, 11, 10, 3, 1, 55, 239, DateTimeKind.Local).AddTicks(8281), null, "DCE321", null, "Car", 2014 });

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Subscriptions_SubscriptionId",
                table: "Vehicles",
                column: "SubscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Subscriptions_SubscriptionId",
                table: "Vehicles");

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "Year",
                table: "Vehicles",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SubscriptionId",
                table: "Vehicles",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Kilometers",
                table: "Vehicles",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Subscriptions_SubscriptionId",
                table: "Vehicles",
                column: "SubscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
