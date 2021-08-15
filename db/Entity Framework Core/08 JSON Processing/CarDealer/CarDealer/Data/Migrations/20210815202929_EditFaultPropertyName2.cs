using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class EditFaultPropertyName2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BithDate",
                table: "Customers",
                newName: "BirthDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "Customers",
                newName: "BithDate");
        }
    }
}
