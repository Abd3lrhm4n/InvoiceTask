using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseLayer.Migrations
{
    public partial class removeitemsunitsrelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemDetials_Units_UnitId",
                table: "ItemDetials");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Items_ItemId",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Units_ItemId",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Units");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_StoreId",
                table: "Invoices",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Stores_StoreId",
                table: "Invoices",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemDetials_Units_UnitId",
                table: "ItemDetials",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Stores_StoreId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemDetials_Units_UnitId",
                table: "ItemDetials");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_StoreId",
                table: "Invoices");

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "Units",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Units_ItemId",
                table: "Units",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemDetials_Units_UnitId",
                table: "ItemDetials",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Items_ItemId",
                table: "Units",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
