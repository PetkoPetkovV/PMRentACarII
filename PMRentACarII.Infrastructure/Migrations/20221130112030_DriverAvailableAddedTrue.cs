using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PMRentACarII.Infrastructure.Migrations
{
    public partial class DriverAvailableAddedTrue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "47aef1eb-d309-413b-a97d-951b872acac2", "AQAAAAEAACcQAAAAEF/vx1wX36Nx+TAC8pha0bXEvswNkfKhS0HJ1FjcEushKNRhQmqrYEfFxR9VThA3/w==", "f636ae9f-bf28-4b78-bc16-b498ebc0f78d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6f85dbbf-8700-4171-8354-6f34bcd39a74", "AQAAAAEAACcQAAAAEIEEJ033ccDZjhp1mjsvOgjuejbk4XFhpDX+0C4+k6SNSrTtbTY7XWbcMBHaLqhEQg==", "f0c77410-3879-4c3e-b8cf-1a6b9c13e462" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
