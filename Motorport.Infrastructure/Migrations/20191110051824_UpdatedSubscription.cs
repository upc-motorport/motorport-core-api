using Microsoft.EntityFrameworkCore.Migrations;

namespace Motorport.Infrastructure.Migrations
{
    public partial class UpdatedSubscription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_SubscriptionId",
                table: "Vehicles",
                column: "SubscriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Subscriptions_SubscriptionId",
                table: "Vehicles",
                column: "SubscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Subscriptions_SubscriptionId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_SubscriptionId",
                table: "Vehicles");
        }
    }
}
