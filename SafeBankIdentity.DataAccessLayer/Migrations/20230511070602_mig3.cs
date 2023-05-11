using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SafeBankIdentity.DataAccessLayer.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomerAccountId",
                table: "CustomerAccounts",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CustomerAccountProcessId",
                table: "CustomerAccountProcesses",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CustomerAccounts",
                newName: "CustomerAccountId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CustomerAccountProcesses",
                newName: "CustomerAccountProcessId");
        }
    }
}
