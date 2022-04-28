using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderService.Migrations
{
    public partial class updatedb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_inVoices_InVoiceId",
                table: "products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_products",
                table: "products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_inVoices",
                table: "inVoices");

            migrationBuilder.DropColumn(
                name: "OrderStatus",
                table: "inVoices");

            migrationBuilder.RenameTable(
                name: "products",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "inVoices",
                newName: "InVoices");

            migrationBuilder.RenameIndex(
                name: "IX_products_InVoiceId",
                table: "Products",
                newName: "IX_Products_InVoiceId");

            migrationBuilder.RenameColumn(
                name: "CodeInvoice",
                table: "InVoices",
                newName: "CodeInVoice");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "InVoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InVoices",
                table: "InVoices",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_InVoices_InVoiceId",
                table: "Products",
                column: "InVoiceId",
                principalTable: "InVoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_InVoices_InVoiceId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InVoices",
                table: "InVoices");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "InVoices");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "products");

            migrationBuilder.RenameTable(
                name: "InVoices",
                newName: "inVoices");

            migrationBuilder.RenameIndex(
                name: "IX_Products_InVoiceId",
                table: "products",
                newName: "IX_products_InVoiceId");

            migrationBuilder.RenameColumn(
                name: "CodeInVoice",
                table: "inVoices",
                newName: "CodeInvoice");

            migrationBuilder.AddColumn<string>(
                name: "OrderStatus",
                table: "inVoices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_products",
                table: "products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_inVoices",
                table: "inVoices",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_products_inVoices_InVoiceId",
                table: "products",
                column: "InVoiceId",
                principalTable: "inVoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
