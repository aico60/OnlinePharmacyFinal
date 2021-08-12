using Microsoft.EntityFrameworkCore.Migrations;

namespace Online_Pharmacy.Data.Migrations
{
    public partial class OrdersEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MedicineId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PrescriptionId",
                table: "Orders");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "MedicineId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PrescriptionId",
                table: "Orders",
                type: "int",
                nullable: true);
        }
    }
}
