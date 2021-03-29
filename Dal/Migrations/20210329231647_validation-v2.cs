using Microsoft.EntityFrameworkCore.Migrations;

namespace Dal.Migrations
{
    public partial class validationv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CtProduct_Code",
                table: "CtProduct");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CtProduct",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "CtProduct",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CtProduct_Code",
                table: "CtProduct",
                column: "Code",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CtProduct_Code",
                table: "CtProduct");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CtProduct",
                type: "nvarchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "CtProduct",
                type: "nvarchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            migrationBuilder.CreateIndex(
                name: "IX_CtProduct_Code",
                table: "CtProduct",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");
        }
    }
}
