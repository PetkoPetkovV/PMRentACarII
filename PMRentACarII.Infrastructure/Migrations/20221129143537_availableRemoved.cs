using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PMRentACarII.Infrastructure.Migrations
{
    public partial class availableRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NotAvailable",
                table: "Cars");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f78ebd97-cdd4-40b9-bb07-8c2081ea4d80", "AQAAAAEAACcQAAAAEK1f8Md8qufynjCfCYYwGczXD0eLJd0SkHmohPzfPGy5eNg/5zPCfE/4MwcAFsstyg==", "350dbb2b-3310-44b0-a9d8-1b400ceee5d6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eed7d2aa-27e9-45b1-8559-384e75e3fcda", "AQAAAAEAACcQAAAAEH0QIJlLdWQ/4PqWjf2unc+HMSAZr6TV++je4XC8G/RY6RHqjdWA9RiLZdCeBihucQ==", "b1230e27-44d6-4a7b-9765-c8612db1be9a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "NotAvailable",
                table: "Cars",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b7f33e84-377b-4f8e-9308-258b1b453c9a", "AQAAAAEAACcQAAAAEPlnVOjW/rsN1vkFYDw9UpsotDPt5nLzJTxyjI8pzoqmbY8t7JLxb1TDgGWnoOHqQA==", "139a0780-e565-447d-8f2b-fbece967f033" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "94f31264-c732-4e03-9060-2999a4b8cf7b", "AQAAAAEAACcQAAAAENnrX2dVHqkBLs7xGrxlNGTeuEnpMuAF+rpKA6BgRnqhXk2v5+RftRD2/ZkSW3j82g==", "6e52da5a-a806-480c-a9e6-9b50ee842a41" });
        }
    }
}
