using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Motorport.Infrastructure.Migrations
{
    public partial class AddedLoginMockData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Subscriptions_SubscriptionId",
                table: "Vehicles");

            migrationBuilder.RenameColumn(
                name: "MyProperty",
                table: "Persons",
                newName: "LastName");

            migrationBuilder.AlterColumn<string>(
                name: "PlanType",
                table: "Plans",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Subscriptions_SubscriptionId",
                table: "Vehicles",
                column: "SubscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Active", "CreatedAt", "CreatedBy", "FirstName", "IdentificationNumber", "LastName", "ModifiedAt", "ModifiedBy", "ShortName", "UserId" },
                values: new object[] { 1, true, new DateTime(2019, 11, 15, 21, 58, 1, 193, DateTimeKind.Local).AddTicks(2847), null, "Manuel Augusto", "81058541", "Alvarado Estanga", new DateTime(2019, 11, 15, 21, 58, 1, 193, DateTimeKind.Local).AddTicks(2852), null, "Manuel Alvarado", 1 });

            migrationBuilder.InsertData(
                table: "Plans",
                columns: new[] { "Id", "Active", "Cost", "CreatedAt", "CreatedBy", "Description", "ModifiedAt", "ModifiedBy", "Name", "PlanType", "UsersLimit" },
                values: new object[] { 1, true, 0m, new DateTime(2019, 11, 15, 21, 58, 1, 53, DateTimeKind.Local).AddTicks(99), null, "Basic Plan", new DateTime(2019, 11, 15, 21, 58, 1, 53, DateTimeKind.Local).AddTicks(7078), null, "Basic", "Basic", 1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt", "Password" },
                values: new object[] { new DateTime(2019, 11, 15, 21, 58, 1, 192, DateTimeKind.Local).AddTicks(9627), new DateTime(2019, 11, 15, 21, 58, 1, 192, DateTimeKind.Local).AddTicks(9640), "$2b$10$hJILbCr7Ln08pcPXPGhWqOXrCu7KwfxOUWTQmtC4uY.Jnh0RSvWt2" });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "Active", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy", "PlanId" },
                values: new object[] { 1, true, new DateTime(2019, 11, 15, 21, 58, 1, 55, DateTimeKind.Local).AddTicks(7075), null, new DateTime(2019, 11, 15, 21, 58, 1, 55, DateTimeKind.Local).AddTicks(7080), null, 1 });

            migrationBuilder.InsertData(
                table: "Memberships",
                columns: new[] { "Id", "Active", "CreatedAt", "CreatedBy", "ExpirationDate", "ModifiedAt", "ModifiedBy", "Role", "StartDate", "SubscriptionId", "UserId" },
                values: new object[] { 1, true, new DateTime(2019, 11, 15, 21, 58, 1, 193, DateTimeKind.Local).AddTicks(4759), null, new DateTime(2020, 11, 15, 21, 58, 1, 193, DateTimeKind.Local).AddTicks(4748), new DateTime(2019, 11, 15, 21, 58, 1, 193, DateTimeKind.Local).AddTicks(4760), null, "Owner", new DateTime(2019, 11, 15, 21, 58, 1, 193, DateTimeKind.Local).AddTicks(4744), 1, 1 });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt", "SubscriptionId" },
                values: new object[] { new DateTime(2019, 11, 15, 21, 58, 1, 193, DateTimeKind.Local).AddTicks(6739), new DateTime(2019, 11, 15, 21, 58, 1, 193, DateTimeKind.Local).AddTicks(6742), 1 });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt", "SubscriptionId" },
                values: new object[] { new DateTime(2019, 11, 15, 21, 58, 1, 193, DateTimeKind.Local).AddTicks(8515), new DateTime(2019, 11, 15, 21, 58, 1, 193, DateTimeKind.Local).AddTicks(8521), 1 });

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Subscriptions_SubscriptionId",
                table: "Vehicles");

            migrationBuilder.DeleteData(
                table: "Memberships",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Plans",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Persons",
                newName: "MyProperty");

            migrationBuilder.AlterColumn<int>(
                name: "SubscriptionId",
                table: "Vehicles",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "PlanType",
                table: "Plans",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt", "Password" },
                values: new object[] { new DateTime(2019, 11, 15, 21, 40, 32, 801, DateTimeKind.Local).AddTicks(5357), new DateTime(2019, 11, 15, 21, 40, 32, 801, DateTimeKind.Local).AddTicks(5370), "$2b$10$P6SwjIhsPbAXvcdtCNX9PeOlCpy9SvCk/TyPXQ0EumsFUd3PiCkku" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt", "SubscriptionId" },
                values: new object[] { new DateTime(2019, 11, 15, 21, 40, 32, 654, DateTimeKind.Local).AddTicks(6239), new DateTime(2019, 11, 15, 21, 40, 32, 655, DateTimeKind.Local).AddTicks(7004), null });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt", "SubscriptionId" },
                values: new object[] { new DateTime(2019, 11, 15, 21, 40, 32, 656, DateTimeKind.Local).AddTicks(1044), new DateTime(2019, 11, 15, 21, 40, 32, 656, DateTimeKind.Local).AddTicks(1055), null });

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Subscriptions_SubscriptionId",
                table: "Vehicles",
                column: "SubscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
