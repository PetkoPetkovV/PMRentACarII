using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PMRentACarII.Infrastructure.Migrations
{
    public partial class AvailableTrue2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Available",
                table: "Cars",
                newName: "NotAvailable");

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

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "NotAvailable",
                value: false);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "NotAvailable",
                value: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NotAvailable",
                table: "Cars",
                newName: "Available");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4bd2d36b-bd89-4a3d-beb4-e24b51c84e37", "AQAAAAEAACcQAAAAEB3ItHh4sEjWCNAGJXK94WfWR2wexvqeSyothNOMFvrx1dsCD4DpsqdKvjvu63bVNw==", "05cb5d99-f9d0-4bae-af72-97b82f81ff06" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d5929534-b21c-4ac3-bfbe-9d38c24c6395", "AQAAAAEAACcQAAAAEJUgxM4iJ+w5uQQJ9bLVM84Hi3+ExBukA3Jf81dBhBjJGErkH1m9yE+WIwwLv2XXSg==", "90296209-d8a0-4442-a6ca-b976ad988714" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "Available",
                value: true);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "Available",
                value: true);
        }
    }
}
