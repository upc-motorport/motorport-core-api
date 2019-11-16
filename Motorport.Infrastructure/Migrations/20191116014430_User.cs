using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Motorport.Infrastructure.Migrations
{
    public partial class User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "CreatedAt", "CreatedBy", "Email", "ModifiedAt", "ModifiedBy", "Password" },
                values: new object[] { 1, true, new DateTime(2019, 11, 15, 20, 44, 30, 97, DateTimeKind.Local).AddTicks(3201), null, "alvarado.manuel@live.com", new DateTime(2019, 11, 15, 20, 44, 30, 97, DateTimeKind.Local).AddTicks(3207), null, "$2b$10$PrFBaB84nSKFpCjYlWmkKetCcxMoLmSllO1cz0K3vDcmGc0097aUO" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2019, 11, 10, 3, 1, 55, 239, DateTimeKind.Local).AddTicks(539), new DateTime(2019, 11, 10, 3, 1, 55, 239, DateTimeKind.Local).AddTicks(6142) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2019, 11, 10, 3, 1, 55, 239, DateTimeKind.Local).AddTicks(8279), new DateTime(2019, 11, 10, 3, 1, 55, 239, DateTimeKind.Local).AddTicks(8281) });
        }
    }
}
