using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PMRentACarII.Infrastructure.Migrations
{
    public partial class InitialMigratioNs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f41c5eb7-a56d-4c8f-a256-c87c2d360fb5", "AQAAAAEAACcQAAAAEC8SDOGwDcOTqGyjfLBJbJ0eNHHYR6+PoI10/k8JIV20vA0pUIntkW1y9Qp+yk9GkQ==", "6442b14a-844d-4fd0-ae41-8a85109efe34" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6ce13e1f-d6f3-42c2-9984-4761aec5cd40", "AQAAAAEAACcQAAAAEJmqzCy6T1hTq1g7W99Dv4plWncYx+1NNn8ntwS7iAaWoIyYGrNE9Gk3WBlIeZSWGw==", "44f8db03-cd42-4974-841f-df3b7fc85b11" });
        }
    }
}
