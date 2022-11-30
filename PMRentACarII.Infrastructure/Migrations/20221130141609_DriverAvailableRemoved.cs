using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PMRentACarII.Infrastructure.Migrations
{
    public partial class DriverAvailableRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Available",
                table: "Drivers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "87462914-2f37-4ab9-8bed-188e2187e6d1", "AQAAAAEAACcQAAAAEOWV76mROQ8aMaMK2sAcbMDl4JRlO6MSPOQpbB3Kb4sT5+ahJY8U3NMszwMgZb0qdg==", "462de149-14fa-4b9c-82ac-331fb81da22e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3bfbecae-9ef5-4d37-8337-5ce1f095cba6", "AQAAAAEAACcQAAAAEPgR2wikeK6vpljDvuhGBXfHBlFf7xE25zH3lJqjEusAAyggELdm/Lueg5XDwQxw9A==", "af4ae051-99a5-4588-9686-f79139511a05" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Available",
                table: "Drivers",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Available",
                value: true);

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Available",
                value: true);

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 3,
                column: "Available",
                value: true);
        }
    }
}
