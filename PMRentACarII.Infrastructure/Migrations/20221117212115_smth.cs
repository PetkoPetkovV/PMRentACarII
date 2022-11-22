using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PMRentACarII.Infrastructure.Migrations
{
    public partial class smth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Model",
                table: "Cars",
                newName: "CarModel");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c5093db2-ff4c-4eab-9a37-41d017416027", "AQAAAAEAACcQAAAAEDSwhDoFM+CnIrOiYZqS7RUiLNeR4UbPgDCbMnm8JX+MniFu5jztkXq1tqETLiSSDQ==", "46ca4012-6730-4c73-99c4-0873aa545526" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bd51a0b0-de9c-4a13-82a1-e75b4c0b05a9", "AQAAAAEAACcQAAAAEAA38fapfAfEqtMQPBqt1gVc8sRNq7ChF0tna9JSfJYRr7qtr4BslgQYm/ZBXjQqBQ==", "b9542e78-2949-4484-8e16-96cc16b87b11" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CarModel",
                table: "Cars",
                newName: "Model");

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
    }
}
