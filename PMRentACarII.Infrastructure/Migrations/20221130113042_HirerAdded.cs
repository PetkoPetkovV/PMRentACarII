using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PMRentACarII.Infrastructure.Migrations
{
    public partial class HirerAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HirerId",
                table: "Drivers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "82f28480-488d-4e85-808a-7ec4bf27252c", "AQAAAAEAACcQAAAAEBG7Hn39177VGgPE3BCzI0y8kViReYfjSCFX2nnRwEQlDvMIt3KJlMtuuQ164Ifzqw==", "43de798d-677c-4f55-af9b-2d052e31c593" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6978c05a-2c48-40f5-81e7-00b3f5ee21e3", "AQAAAAEAACcQAAAAEKRxDPqhRehdfmLg5MOxWZduMKH3hnI1cnYDKGT6zVaLkow/avdOtJmaL0/B4clAeQ==", "c51ece9b-670a-461a-a5ea-e2d0e0145442" });

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_HirerId",
                table: "Drivers",
                column: "HirerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drivers_AspNetUsers_HirerId",
                table: "Drivers",
                column: "HirerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_AspNetUsers_HirerId",
                table: "Drivers");

            migrationBuilder.DropIndex(
                name: "IX_Drivers_HirerId",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "HirerId",
                table: "Drivers");

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
    }
}
