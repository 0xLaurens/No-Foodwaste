using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class images : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Photo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ContainsAlcohol = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                    table.ForeignKey(
                        name: "FK_Locations_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId");
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailAddress = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Students_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId");
                });

            migrationBuilder.CreateTable(
                name: "Cafeterias",
                columns: table => new
                {
                    CafeteriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cafeterias", x => x.CafeteriaId);
                    table.ForeignKey(
                        name: "FK_Cafeterias_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId");
                    table.ForeignKey(
                        name: "FK_Cafeterias_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId");
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    CafeteriaId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId");
                });

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    PackageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Thumbnail = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ThumbnailFormat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    CafeteriaId = table.Column<int>(type: "int", nullable: false),
                    StartTimeSlot = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTimeSlot = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EighteenPlus = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<decimal>(type: "Decimal(3,2)", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.PackageId);
                    table.ForeignKey(
                        name: "FK_Packages_Cafeterias_CafeteriaId",
                        column: x => x.CafeteriaId,
                        principalTable: "Cafeterias",
                        principalColumn: "CafeteriaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Packages_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId");
                    table.ForeignKey(
                        name: "FK_Packages_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId");
                });

            migrationBuilder.CreateTable(
                name: "PackageProduct",
                columns: table => new
                {
                    PackagesPackageId = table.Column<int>(type: "int", nullable: false),
                    ProductsProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageProduct", x => new { x.PackagesPackageId, x.ProductsProductId });
                    table.ForeignKey(
                        name: "FK_PackageProduct_Packages_PackagesPackageId",
                        column: x => x.PackagesPackageId,
                        principalTable: "Packages",
                        principalColumn: "PackageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PackageProduct_Products_ProductsProductId",
                        column: x => x.ProductsProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "Name" },
                values: new object[,]
                {
                    { 1, "Breda" },
                    { 2, "Den Bosch" },
                    { 3, "Tilburg" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "ContainsAlcohol", "Name", "Photo" },
                values: new object[,]
                {
                    { 1, false, "Cheese slice", null },
                    { 2, false, "Ham", null },
                    { 3, false, "Banana", null },
                    { 4, false, "Orange", null },
                    { 5, false, "Chicken", null },
                    { 6, true, "Heineken beer", null },
                    { 7, false, "Pasta Bolognese", null },
                    { 8, false, "White Bread", null },
                    { 9, false, "Brown Bread", null },
                    { 10, false, "Paprika", null },
                    { 11, false, "Mayonnaise", null },
                    { 12, false, "Ketchup", null },
                    { 13, false, "Apple", null },
                    { 14, false, "Broccoli", null },
                    { 15, false, "Lettuce", null }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "CityId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "LA" },
                    { 2, 2, "LD" },
                    { 3, 3, "HL" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "CityId", "DateOfBirth", "EmailAddress", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2003, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "student@student.avans.nl", "06 58912302" },
                    { 2, 1, new DateTime(2001, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "L.pieters@student.avans.nl", "06 38912302" }
                });

            migrationBuilder.InsertData(
                table: "Cafeterias",
                columns: new[] { "CafeteriaId", "CityId", "LocationId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "CafeteriaId", "CityId", "Email", "LocationId", "Name" },
                values: new object[,]
                {
                    { 1, 1, 1, "admin@avans.nl", 1, "Admin" },
                    { 2, 2, 2, "h.strijder@avans.nl", 2, "Harry de Strijder" },
                    { 3, 3, 3, "a.Bloempot", 3, "Ankie Bloempot" }
                });

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "PackageId", "CafeteriaId", "Category", "CityId", "EighteenPlus", "EndTimeSlot", "Name", "Price", "StartTimeSlot", "StudentId", "Thumbnail", "ThumbnailFormat" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, false, new DateTime(2022, 10, 26, 17, 39, 19, 820, DateTimeKind.Local).AddTicks(6671), "Tosti ham 'n cheese", 1.99m, new DateTime(2022, 10, 26, 14, 39, 19, 820, DateTimeKind.Local).AddTicks(6657), 1, null, null },
                    { 2, 1, 1, 1, true, new DateTime(2022, 10, 26, 17, 39, 19, 820, DateTimeKind.Local).AddTicks(6728), "Beer and chicken", 2.99m, new DateTime(2022, 10, 26, 14, 39, 19, 820, DateTimeKind.Local).AddTicks(6709), null, null, null },
                    { 3, 2, 0, 1, false, new DateTime(2022, 10, 26, 17, 39, 19, 820, DateTimeKind.Local).AddTicks(6761), "Fruit bowl", 3.44m, new DateTime(2022, 10, 26, 14, 39, 19, 820, DateTimeKind.Local).AddTicks(6747), null, null, null },
                    { 4, 2, 5, 1, false, new DateTime(2022, 10, 26, 17, 39, 19, 820, DateTimeKind.Local).AddTicks(6799), "Vega delight", 1.99m, new DateTime(2022, 10, 26, 14, 39, 19, 820, DateTimeKind.Local).AddTicks(6780), null, null, null },
                    { 5, 3, 1, 1, false, new DateTime(2022, 10, 26, 17, 39, 19, 820, DateTimeKind.Local).AddTicks(6833), "Sloppy spaghetti sandwich", 2.49m, new DateTime(2022, 10, 26, 14, 39, 19, 820, DateTimeKind.Local).AddTicks(6818), null, null, null },
                    { 6, 3, 4, 1, true, new DateTime(2022, 10, 26, 17, 39, 19, 820, DateTimeKind.Local).AddTicks(6871), "Heineken Beer", 1m, new DateTime(2022, 10, 26, 14, 39, 19, 820, DateTimeKind.Local).AddTicks(6857), null, null, null }
                });

            migrationBuilder.InsertData(
                table: "PackageProduct",
                columns: new[] { "PackagesPackageId", "ProductsProductId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 8 },
                    { 1, 12 },
                    { 2, 5 },
                    { 2, 6 },
                    { 3, 3 },
                    { 3, 4 },
                    { 3, 13 },
                    { 4, 10 },
                    { 4, 14 },
                    { 4, 15 },
                    { 5, 7 },
                    { 5, 9 },
                    { 6, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cafeterias_CityId",
                table: "Cafeterias",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Cafeterias_LocationId",
                table: "Cafeterias",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_LocationId",
                table: "Employees",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_CityId",
                table: "Locations",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageProduct_ProductsProductId",
                table: "PackageProduct",
                column: "ProductsProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_CafeteriaId",
                table: "Packages",
                column: "CafeteriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_CityId",
                table: "Packages",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_Name",
                table: "Packages",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Packages_StudentId",
                table: "Packages",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name",
                table: "Products",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Students_CityId",
                table: "Students",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_EmailAddress",
                table: "Students",
                column: "EmailAddress",
                unique: true,
                filter: "[EmailAddress] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "PackageProduct");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Cafeterias");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
