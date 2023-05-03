using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestEntityCoreAuthorsBooks.Data.Migrations
{
    /// <inheritdoc />
    public partial class Add_CustomIndentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OriginCountry",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OriginCountry",
                table: "AspNetUsers");
        }
    }
}
