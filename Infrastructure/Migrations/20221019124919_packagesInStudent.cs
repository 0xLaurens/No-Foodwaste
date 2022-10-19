using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class packagesInStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Packages",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: 1,
                columns: new[] { "BestBeforeDate", "PickupTime" },
                values: new object[] { new DateTime(2022, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 10, 20, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: 2,
                columns: new[] { "BestBeforeDate", "PickupTime" },
                values: new object[] { new DateTime(2022, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 10, 20, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: 3,
                columns: new[] { "BestBeforeDate", "PickupTime" },
                values: new object[] { new DateTime(2022, 10, 21, 14, 49, 19, 26, DateTimeKind.Local).AddTicks(5766), new DateTime(2022, 10, 20, 14, 49, 19, 26, DateTimeKind.Local).AddTicks(5763) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: 4,
                columns: new[] { "BestBeforeDate", "PickupTime" },
                values: new object[] { new DateTime(2022, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 10, 20, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.CreateIndex(
                name: "IX_Packages_StudentId",
                table: "Packages",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Students_StudentId",
                table: "Packages",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Students_StudentId",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_StudentId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Packages");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: 1,
                columns: new[] { "BestBeforeDate", "PickupTime" },
                values: new object[] { new DateTime(2022, 10, 19, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 10, 18, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: 2,
                columns: new[] { "BestBeforeDate", "PickupTime" },
                values: new object[] { new DateTime(2022, 10, 19, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 10, 18, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: 3,
                columns: new[] { "BestBeforeDate", "PickupTime" },
                values: new object[] { new DateTime(2022, 10, 19, 14, 5, 41, 19, DateTimeKind.Local).AddTicks(9612), new DateTime(2022, 10, 18, 14, 5, 41, 19, DateTimeKind.Local).AddTicks(9609) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: 4,
                columns: new[] { "BestBeforeDate", "PickupTime" },
                values: new object[] { new DateTime(2022, 10, 19, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 10, 18, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "ContainsAlcohol", "Name", "Photo" },
                values: new object[] { 2, false, "Bread", "Image of Bread" });
        }
    }
}
