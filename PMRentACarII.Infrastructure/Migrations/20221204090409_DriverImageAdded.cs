using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PMRentACarII.Infrastructure.Migrations
{
    public partial class DriverImageAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Drivers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6d2a7550-cd3f-4104-bd03-5209755b5e3e", "AQAAAAEAACcQAAAAELdHIhI3uHfV4fOG8H/FIBcubwuTip2rf5JdE3R9aYo4Fz9oMUXuogn7Vy61l5wubQ==", "a4b8a68b-2aca-47eb-a447-06c1c6dd0d26" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b87547eb-7c54-4a1c-999a-312e39dd0517", "AQAAAAEAACcQAAAAEGY2/3NOhMmlxSpvr+rKZFCNRl8PUK4gyrdOZpks+yweAK7Y2lsisPd1i0JYJG8wmQ==", "448794f8-a698-4ee4-be2a-1578be09e74a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Drivers");

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
    }
}
