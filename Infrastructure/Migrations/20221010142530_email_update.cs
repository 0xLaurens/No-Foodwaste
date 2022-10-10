using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class email_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: 1,
                columns: new[] { "BestBeforeDate", "PickupTime" },
                values: new object[] { new DateTime(2022, 10, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 10, 11, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: 2,
                columns: new[] { "BestBeforeDate", "PickupTime" },
                values: new object[] { new DateTime(2022, 10, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 10, 11, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1,
                column: "EmailAddress",
                value: "student@student.avans.nl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: 1,
                columns: new[] { "BestBeforeDate", "PickupTime" },
                values: new object[] { new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 10, 9, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: 2,
                columns: new[] { "BestBeforeDate", "PickupTime" },
                values: new object[] { new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 10, 9, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1,
                column: "EmailAddress",
                value: "Lhh.weterings@student.avans.nl");
        }
    }
}
