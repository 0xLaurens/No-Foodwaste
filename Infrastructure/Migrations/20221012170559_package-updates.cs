using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class packageupdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: 3,
                columns: new[] { "BestBeforeDate", "PickupTime" },
                values: new object[] { new DateTime(2022, 10, 14, 19, 5, 58, 795, DateTimeKind.Local).AddTicks(4982), new DateTime(2022, 10, 13, 19, 5, 58, 795, DateTimeKind.Local).AddTicks(4963) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: 3,
                columns: new[] { "BestBeforeDate", "PickupTime" },
                values: new object[] { new DateTime(2022, 10, 14, 19, 2, 33, 986, DateTimeKind.Local).AddTicks(7009), new DateTime(2022, 10, 13, 19, 2, 33, 986, DateTimeKind.Local).AddTicks(6994) });
        }
    }
}
