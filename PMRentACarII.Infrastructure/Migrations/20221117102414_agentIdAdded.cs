using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PMRentACarII.Infrastructure.Migrations
{
    public partial class agentIdAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AgentId",
                table: "Cars",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d0ca2b55-0332-44c5-94dc-a76c418ea5fe", "AQAAAAEAACcQAAAAEE+Xpab9Bc55btsLtj/A4hQXMjV+kEnsNe/YXONzTcZfEwOJdG9ho/+7zDsDN7dK4Q==", "eac425d2-ef2f-4d75-bb3c-50db6aef17ba" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "396ea52f-b663-4e78-a132-669da4a58d00", "AQAAAAEAACcQAAAAEG9aFlcXvZghztXJ2vO2ddLN8DW1URLYM303UxpwZz2WxQCGjAygDtYweagxN86vqg==", "a877234c-ff92-4956-a240-66dea23b0d32" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "Cars");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "95c4c541-4f1d-4f07-8b67-4f7eb2d1e279", "AQAAAAEAACcQAAAAEKTo8+rVCwwNzfb6GYTZeflbIlM3gMdQDfs6UqzKb8tskWGnQsFjGHv+lUvxCfQ4YQ==", "0621ea31-b67f-4da1-b0f7-50df6e1dec09" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6b2c46d6-ad0c-4e06-a8db-2ea973f70204", "AQAAAAEAACcQAAAAECdpCLjykAlC0n2whSpOiURHi4/AZssqZoY3DkG6fcLsJyMNL/LdUJFU8aXfRVWrIw==", "e1ca31c2-f035-464b-85a6-aaf5c3558df5" });
        }
    }
}
