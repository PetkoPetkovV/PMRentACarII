using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PMRentACarII.Infrastructure.Migrations
{
    public partial class AvailableTrue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b793b31b-d372-4f01-9e2f-ff4cc518742e", "AQAAAAEAACcQAAAAEO7bLMxIYWlM5YIynMPJONEC5SCCKm8hkaVQYnSIwIPnBc4DNVkGGkRNgH1nqIvCug==", "c2b13778-4c4e-49e1-b955-cfb85d02684b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6fb4e95f-1adb-48cb-b0ca-d8f35ddbeaa8", "AQAAAAEAACcQAAAAEC4YABp+95T2GlORQ1axwrFybPaCnNzcBBvbEOSDk72BvFJsDf4zxMTLDpnOR7qUMQ==", "800df633-56f8-4b3d-bb86-9c2ebb8c356c" });
        }
    }
}
