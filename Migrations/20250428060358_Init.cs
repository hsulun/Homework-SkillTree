using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Homework_SkillTree.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ledger",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LedgerCategory = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    LedgerAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LedgerNote = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    LedgerDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ledger", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ledger");
        }
    }
}
