using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Motorport.Infrastructure.Migrations
{
    public partial class MembershipRoleConversion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Memberships",
                nullable: false,
                oldClrType: typeof(int));

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
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2019, 11, 15, 21, 40, 32, 654, DateTimeKind.Local).AddTicks(6239), new DateTime(2019, 11, 15, 21, 40, 32, 655, DateTimeKind.Local).AddTicks(7004) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2019, 11, 15, 21, 40, 32, 656, DateTimeKind.Local).AddTicks(1044), new DateTime(2019, 11, 15, 21, 40, 32, 656, DateTimeKind.Local).AddTicks(1055) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Role",
                table: "Memberships",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt", "Password" },
                values: new object[] { new DateTime(2019, 11, 15, 20, 44, 30, 97, DateTimeKind.Local).AddTicks(3201), new DateTime(2019, 11, 15, 20, 44, 30, 97, DateTimeKind.Local).AddTicks(3207), "$2b$10$PrFBaB84nSKFpCjYlWmkKetCcxMoLmSllO1cz0K3vDcmGc0097aUO" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2019, 11, 15, 20, 44, 29, 989, DateTimeKind.Local).AddTicks(7961), new DateTime(2019, 11, 15, 20, 44, 29, 990, DateTimeKind.Local).AddTicks(3949) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2019, 11, 15, 20, 44, 29, 990, DateTimeKind.Local).AddTicks(5618), new DateTime(2019, 11, 15, 20, 44, 29, 990, DateTimeKind.Local).AddTicks(5621) });
        }
    }
}
