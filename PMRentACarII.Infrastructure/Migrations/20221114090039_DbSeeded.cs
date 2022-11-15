using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PMRentACarII.Infrastructure.Migrations
{
    public partial class DbSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agents_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    YearsOfExperience = table.Column<int>(type: "int", nullable: false),
                    DriverCategory = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DriverPrice = table.Column<decimal>(type: "money", nullable: false),
                    Available = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Make = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PricePerDay = table.Column<decimal>(type: "money", nullable: false),
                    SeatCapacity = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Available = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    DriverId = table.Column<int>(type: "int", nullable: true),
                    RenterId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_AspNetUsers_RenterId",
                        column: x => x.RenterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cars_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Rents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartingDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReturnDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    DriverId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rents_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rents_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UsersCars",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersCars", x => new { x.UserId, x.CarId });
                    table.ForeignKey(
                        name: "FK_UsersCars_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersCars_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, "95c4c541-4f1d-4f07-8b67-4f7eb2d1e279", "guest@mail.com", false, false, null, "guest@mail.com", "guest@mail.com", "AQAAAAEAACcQAAAAEKTo8+rVCwwNzfb6GYTZeflbIlM3gMdQDfs6UqzKb8tskWGnQsFjGHv+lUvxCfQ4YQ==", null, false, "0621ea31-b67f-4da1-b0f7-50df6e1dec09", false, "guest@mail.com" },
                    { "dea12856-c198-4129-b3f3-b893d8395082", 0, "6b2c46d6-ad0c-4e06-a8db-2ea973f70204", "agent@mail.com", false, false, null, "agent@mail.com", "agent@mail.com", "AQAAAAEAACcQAAAAECdpCLjykAlC0n2whSpOiURHi4/AZssqZoY3DkG6fcLsJyMNL/LdUJFU8aXfRVWrIw==", null, false, "e1ca31c2-f035-464b-85a6-aaf5c3558df5", false, "agent@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Hatchback" },
                    { 2, "Van" },
                    { 3, "Sedan" },
                    { 4, "Coupe" },
                    { 5, "SUV" }
                });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "Age", "Available", "DriverCategory", "DriverPrice", "Name", "YearsOfExperience" },
                values: new object[,]
                {
                    { 1, 30, true, "Expert", 30.00m, "Hose", 11 },
                    { 2, 32, true, "Professional Driver", 60.00m, "Peter", 11 },
                    { 3, 29, true, "Lad", 20.00m, "Mark", 7 }
                });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "Email", "PhoneNumber", "UserId" },
                values: new object[] { 1, "pts@gmail.com", "0884346362", "dea12856-c198-4129-b3f3-b893d8395082" });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Available", "CarNumber", "CategoryId", "Description", "DriverId", "ImageUrl", "Make", "Model", "PricePerDay", "RenterId", "SeatCapacity" },
                values: new object[] { 1, true, "A3200KC", 5, "A very comfortable and reliable car", 1, "https://imageio.forbes.com/specials-images/imageserve/6310cb2cbb908f077de4f565/0x0.jpg?format=jpg&width=1200", "Honda", "Accord", 30.00m, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 5 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Available", "CarNumber", "CategoryId", "Description", "DriverId", "ImageUrl", "Make", "Model", "PricePerDay", "RenterId", "SeatCapacity" },
                values: new object[] { 2, true, "A3201KC", 5, "Traditionally, sports sedans have been the vehicles that best projected the spirit of the BMW brand. Not so much anymore.", 2, "https://hips.hearstapps.com/hmg-prod/images/2022-bmw-x3-m40i-108-1650211641.jpg?crop=0.582xw:0.490xh;0.186xw,0.387xh&resize=1200:*", "BMW", "X3", 60.00m, null, 5 });

            migrationBuilder.InsertData(
                table: "Rents",
                columns: new[] { "Id", "CarId", "DriverId", "Rating", "ReturnDate", "StartingDate", "TotalPrice" },
                values: new object[] { 1, 1, 1, 5, "31.01.2022", "30.01.2022", 60m });

            migrationBuilder.CreateIndex(
                name: "IX_Agents_UserId",
                table: "Agents",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CategoryId",
                table: "Cars",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_DriverId",
                table: "Cars",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_RenterId",
                table: "Cars",
                column: "RenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_CarId",
                table: "Rents",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_DriverId",
                table: "Rents",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersCars_CarId",
                table: "UsersCars",
                column: "CarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agents");

            migrationBuilder.DropTable(
                name: "Rents");

            migrationBuilder.DropTable(
                name: "UsersCars");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e");
        }
    }
}
