using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PMRentACarII.Infrastructure.Migrations
{
    public partial class driverUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DriversCategory",
                table: "Drivers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8159498a-e08d-4521-969c-b0e52dc84786", "AQAAAAEAACcQAAAAEErsSi42o0LEhRqkNz4eiGStVLq7jcqPFoAHMwxIJxOyE9cSVfEx7QfOYLc9kUPiAw==", "8bec8f6c-64c1-496c-8939-5156900d685d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e2812d74-a97a-4160-84f3-4c9b59865d67", "AQAAAAEAACcQAAAAEKCYMXyZEHjywdal0/CXXzGdoZPcs30s2VsXB1Ek8gCXUkFdf8D5uu474j4HkYGLMA==", "9e2a185c-1e08-474d-9306-9cd327a172d0" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DriversCategory",
                table: "Drivers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9840054b-d8a8-4e2a-8713-9e4c66d31198", "AQAAAAEAACcQAAAAEJftJOFiUKbRbh21SbiLg30ZqonAYGANnGtAB+SLn9G9+6aqK1nZ8cZxEXXsTLYoYw==", "87b166e7-ec8d-46fe-921e-4ee12a41afd9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "db895209-6a1c-424a-9220-76dddd99c859", "AQAAAAEAACcQAAAAEKrfWgh7d1XAu80bjtenniFyMNx6WZ+qzIw2KlhXDRU7PvJvCXHUhhG5bRNAiMdFlw==", "38f0b631-00a1-471b-9745-da66ee4dce8c" });
        }
    }
}
