using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestEntityCoreAuthorsBooks.Data.Migrations
{
    /// <inheritdoc />
    public partial class Update_Person_Entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDay",
                table: "Persons");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Persons");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDay",
                table: "Persons",
                type: "datetime2",
                nullable: true);
        }
    }
}
