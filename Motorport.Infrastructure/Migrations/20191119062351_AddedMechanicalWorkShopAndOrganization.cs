using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Motorport.Infrastructure.Migrations
{
    public partial class AddedMechanicalWorkShopAndOrganization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Subscriptions_SubscriptionId",
                table: "Vehicles");

            migrationBuilder.AlterColumn<int>(
                name: "SubscriptionId",
                table: "Vehicles",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<double>(
                name: "Longitude",
                table: "MechanicalWorkshops",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<double>(
                name: "Latitude",
                table: "MechanicalWorkshops",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.UpdateData(
                table: "Memberships",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ExpirationDate", "ModifiedAt", "StartDate" },
                values: new object[] { new DateTime(2019, 11, 19, 1, 23, 50, 858, DateTimeKind.Local).AddTicks(4642), new DateTime(2020, 11, 19, 1, 23, 50, 858, DateTimeKind.Local).AddTicks(4633), new DateTime(2019, 11, 19, 1, 23, 50, 858, DateTimeKind.Local).AddTicks(4643), new DateTime(2019, 11, 19, 1, 23, 50, 858, DateTimeKind.Local).AddTicks(4631) });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "Active", "BussinessName", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy", "Ruc", "ThumbnailImage" },
                values: new object[] { 1, true, "MotorPort SAC", new DateTime(2019, 11, 19, 1, 23, 50, 858, DateTimeKind.Local).AddTicks(9133), null, new DateTime(2019, 11, 19, 1, 23, 50, 858, DateTimeKind.Local).AddTicks(9134), null, "1002419", null });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2019, 11, 19, 1, 23, 50, 858, DateTimeKind.Local).AddTicks(2618), new DateTime(2019, 11, 19, 1, 23, 50, 858, DateTimeKind.Local).AddTicks(2623) });

            migrationBuilder.UpdateData(
                table: "Plans",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2019, 11, 19, 1, 23, 50, 745, DateTimeKind.Local).AddTicks(1149), new DateTime(2019, 11, 19, 1, 23, 50, 745, DateTimeKind.Local).AddTicks(7919) });

            migrationBuilder.UpdateData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2019, 11, 19, 1, 23, 50, 747, DateTimeKind.Local).AddTicks(7939), new DateTime(2019, 11, 19, 1, 23, 50, 747, DateTimeKind.Local).AddTicks(7942) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt", "Password" },
                values: new object[] { new DateTime(2019, 11, 19, 1, 23, 50, 857, DateTimeKind.Local).AddTicks(9298), new DateTime(2019, 11, 19, 1, 23, 50, 857, DateTimeKind.Local).AddTicks(9308), "$2b$10$7jeTV90lNzw8zrQJ3hKi1ORqOKDbtl8mh64ssmMEBZxFfO/YJSCc." });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2019, 11, 19, 1, 23, 50, 858, DateTimeKind.Local).AddTicks(7009), new DateTime(2019, 11, 19, 1, 23, 50, 858, DateTimeKind.Local).AddTicks(7013) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2019, 11, 19, 1, 23, 50, 858, DateTimeKind.Local).AddTicks(8855), new DateTime(2019, 11, 19, 1, 23, 50, 858, DateTimeKind.Local).AddTicks(8859) });

            migrationBuilder.InsertData(
                table: "MechanicalWorkshops",
                columns: new[] { "Id", "Active", "AverageRate", "City", "Country", "CreatedAt", "CreatedBy", "Department", "ImageUrl", "Latitude", "Longitude", "ModifiedAt", "ModifiedBy", "Name", "OrganizationId", "Street", "StreetNumber", "ZipCode" },
                values: new object[] { 1, true, 4.0, "Lima", "Peru", new DateTime(2019, 11, 19, 1, 23, 50, 859, DateTimeKind.Local).AddTicks(2051), null, "Santiago de Surco", null, null, null, new DateTime(2019, 11, 19, 1, 23, 50, 859, DateTimeKind.Local).AddTicks(2054), null, "AutoData S.A.C", 1, "Las Casuarinas", "231", "15023" });

            migrationBuilder.InsertData(
                table: "MechanicalWorkshops",
                columns: new[] { "Id", "Active", "AverageRate", "City", "Country", "CreatedAt", "CreatedBy", "Department", "ImageUrl", "Latitude", "Longitude", "ModifiedAt", "ModifiedBy", "Name", "OrganizationId", "Street", "StreetNumber", "ZipCode" },
                values: new object[] { 2, true, 4.5, "Lima", "Peru", new DateTime(2019, 11, 19, 1, 23, 50, 859, DateTimeKind.Local).AddTicks(4326), null, "Santiago de Surco", null, null, null, new DateTime(2019, 11, 19, 1, 23, 50, 859, DateTimeKind.Local).AddTicks(4329), null, "AutoSolution", 1, "Mariano Eduardo de Rivero y Ustariz", "123", "15023" });

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
                table: "MechanicalWorkshops",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MechanicalWorkshops",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "SubscriptionId",
                table: "Vehicles",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Longitude",
                table: "MechanicalWorkshops",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Latitude",
                table: "MechanicalWorkshops",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Memberships",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ExpirationDate", "ModifiedAt", "StartDate" },
                values: new object[] { new DateTime(2019, 11, 15, 21, 58, 1, 193, DateTimeKind.Local).AddTicks(4759), new DateTime(2020, 11, 15, 21, 58, 1, 193, DateTimeKind.Local).AddTicks(4748), new DateTime(2019, 11, 15, 21, 58, 1, 193, DateTimeKind.Local).AddTicks(4760), new DateTime(2019, 11, 15, 21, 58, 1, 193, DateTimeKind.Local).AddTicks(4744) });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2019, 11, 15, 21, 58, 1, 193, DateTimeKind.Local).AddTicks(2847), new DateTime(2019, 11, 15, 21, 58, 1, 193, DateTimeKind.Local).AddTicks(2852) });

            migrationBuilder.UpdateData(
                table: "Plans",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2019, 11, 15, 21, 58, 1, 53, DateTimeKind.Local).AddTicks(99), new DateTime(2019, 11, 15, 21, 58, 1, 53, DateTimeKind.Local).AddTicks(7078) });

            migrationBuilder.UpdateData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2019, 11, 15, 21, 58, 1, 55, DateTimeKind.Local).AddTicks(7075), new DateTime(2019, 11, 15, 21, 58, 1, 55, DateTimeKind.Local).AddTicks(7080) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt", "Password" },
                values: new object[] { new DateTime(2019, 11, 15, 21, 58, 1, 192, DateTimeKind.Local).AddTicks(9627), new DateTime(2019, 11, 15, 21, 58, 1, 192, DateTimeKind.Local).AddTicks(9640), "$2b$10$hJILbCr7Ln08pcPXPGhWqOXrCu7KwfxOUWTQmtC4uY.Jnh0RSvWt2" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2019, 11, 15, 21, 58, 1, 193, DateTimeKind.Local).AddTicks(6739), new DateTime(2019, 11, 15, 21, 58, 1, 193, DateTimeKind.Local).AddTicks(6742) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2019, 11, 15, 21, 58, 1, 193, DateTimeKind.Local).AddTicks(8515), new DateTime(2019, 11, 15, 21, 58, 1, 193, DateTimeKind.Local).AddTicks(8521) });

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
