using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PMRentACarII.Infrastructure.Migrations
{
    public partial class DriverCategoryAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4190db9d-e4b6-42bd-8b36-87073091c801", "AQAAAAEAACcQAAAAEMVg9/cI6hrQLgVwnL4wM4UM1nNsun7f5CiT6UXwqAsjh62YzZnAP/dAB41zvCghMA==", "6901d660-cf1c-43eb-9e42-f1c69d713953" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f3ea707f-b658-42e8-af63-282c6b8c43d0", "AQAAAAEAACcQAAAAELIsmq5ReF+ETyIsHto1mY1wTpzAsvmrKvSMW2WyPaBnpZ2P3cQa79kd7pvNA0wPYg==", "cc56d58e-9954-4f49-83f8-44f904eb1603" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
