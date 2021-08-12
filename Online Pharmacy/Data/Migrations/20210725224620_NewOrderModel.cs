using Microsoft.EntityFrameworkCore.Migrations;

namespace Online_Pharmacy.Data.Migrations
{
    public partial class NewOrderModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalSupplies_Orders_OrderId",
                table: "MedicalSupplies");

            migrationBuilder.DropIndex(
                name: "IX_MedicalSupplies_OrderId",
                table: "MedicalSupplies");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "MedicalSupplies");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Orders",
                newName: "UserName");

            migrationBuilder.AddColumn<string>(
                name: "MedicalSupplyName",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MedicalSupplyName",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Orders",
                newName: "UserID");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "MedicalSupplies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicalSupplies_OrderId",
                table: "MedicalSupplies",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalSupplies_Orders_OrderId",
                table: "MedicalSupplies",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
