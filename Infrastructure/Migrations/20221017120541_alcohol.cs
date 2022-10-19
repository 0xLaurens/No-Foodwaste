using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class alcohol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ContainsAlcohol",
                table: "Products",
                type: "bit",
                nullable: true);

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
                columns: new[] { "BestBeforeDate", "PickupTime", "Price" },
                values: new object[] { new DateTime(2022, 10, 19, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 10, 18, 0, 0, 0, 0, DateTimeKind.Local), 2.99m });

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

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "ContainsAlcohol",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "ContainsAlcohol",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "ContainsAlcohol",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                column: "ContainsAlcohol",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5,
                column: "ContainsAlcohol",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6,
                column: "ContainsAlcohol",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7,
                column: "ContainsAlcohol",
                value: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8,
                column: "ContainsAlcohol",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9,
                column: "ContainsAlcohol",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 10,
                column: "ContainsAlcohol",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 11,
                column: "ContainsAlcohol",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 12,
                column: "ContainsAlcohol",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 13,
                column: "ContainsAlcohol",
                value: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContainsAlcohol",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: 1,
                columns: new[] { "BestBeforeDate", "PickupTime" },
                values: new object[] { new DateTime(2022, 10, 17, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 10, 16, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: 2,
                columns: new[] { "BestBeforeDate", "PickupTime", "Price" },
                values: new object[] { new DateTime(2022, 10, 17, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 10, 16, 0, 0, 0, 0, DateTimeKind.Local), 20.99m });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: 3,
                columns: new[] { "BestBeforeDate", "PickupTime" },
                values: new object[] { new DateTime(2022, 10, 17, 10, 3, 27, 400, DateTimeKind.Local).AddTicks(5431), new DateTime(2022, 10, 16, 10, 3, 27, 400, DateTimeKind.Local).AddTicks(5427) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: 4,
                columns: new[] { "BestBeforeDate", "PickupTime" },
                values: new object[] { new DateTime(2022, 10, 17, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 10, 16, 0, 0, 0, 0, DateTimeKind.Local) });
        }
    }
}
