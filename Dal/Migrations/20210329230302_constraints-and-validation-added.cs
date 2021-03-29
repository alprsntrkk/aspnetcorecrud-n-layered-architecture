using Microsoft.EntityFrameworkCore.Migrations;

namespace Dal.Migrations
{
    public partial class constraintsandvalidationadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CtProduct_Code",
                table: "CtProduct",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CtProduct_Code",
                table: "CtProduct");
        }
    }
}
