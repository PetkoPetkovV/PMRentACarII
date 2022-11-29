using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PMRentACarII.Infrastructure.Migrations
{
    public partial class CarIsActiveAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Cars",
                type: "bit",
                nullable: false,
                defaultValue: false);

            //migrationBuilder.UpdateData(
            //    table: "AspNetUsers",
            //    keyColumn: "Id",
            //    keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
            //    columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
            //    values: new object[] { "b793b31b-d372-4f01-9e2f-ff4cc518742e", "AQAAAAEAACcQAAAAEO7bLMxIYWlM5YIynMPJONEC5SCCKm8hkaVQYnSIwIPnBc4DNVkGGkRNgH1nqIvCug==", "c2b13778-4c4e-49e1-b955-cfb85d02684b" });

            //migrationBuilder.UpdateData(
            //    table: "AspNetUsers",
            //    keyColumn: "Id",
            //    keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
            //    columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
            //    values: new object[] { "6fb4e95f-1adb-48cb-b0ca-d8f35ddbeaa8", "AQAAAAEAACcQAAAAEC4YABp+95T2GlORQ1axwrFybPaCnNzcBBvbEOSDk72BvFJsDf4zxMTLDpnOR7qUMQ==", "800df633-56f8-4b3d-bb86-9c2ebb8c356c" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsActive",
                value: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_AgentId",
                table: "Cars",
                column: "AgentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Agents_AgentId",
                table: "Cars",
                column: "AgentId",
                principalTable: "Agents",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Agents_AgentId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_AgentId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Cars");

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
    }
}
