using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class PackageCityNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: 1,
                columns: new[] { "EndTimeSlot", "StartTimeSlot" },
                values: new object[] { new DateTime(2022, 10, 21, 19, 53, 12, 356, DateTimeKind.Local).AddTicks(6720), new DateTime(2022, 10, 21, 16, 53, 12, 356, DateTimeKind.Local).AddTicks(6683) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: 2,
                columns: new[] { "EndTimeSlot", "StartTimeSlot" },
                values: new object[] { new DateTime(2022, 10, 21, 19, 53, 12, 356, DateTimeKind.Local).AddTicks(6743), new DateTime(2022, 10, 21, 16, 53, 12, 356, DateTimeKind.Local).AddTicks(6741) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: 3,
                columns: new[] { "EndTimeSlot", "StartTimeSlot" },
                values: new object[] { new DateTime(2022, 10, 21, 19, 53, 12, 356, DateTimeKind.Local).AddTicks(6749), new DateTime(2022, 10, 21, 16, 53, 12, 356, DateTimeKind.Local).AddTicks(6747) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: 4,
                columns: new[] { "EndTimeSlot", "StartTimeSlot" },
                values: new object[] { new DateTime(2022, 10, 21, 19, 53, 12, 356, DateTimeKind.Local).AddTicks(6755), new DateTime(2022, 10, 21, 16, 53, 12, 356, DateTimeKind.Local).AddTicks(6753) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: 1,
                columns: new[] { "EndTimeSlot", "StartTimeSlot" },
                values: new object[] { new DateTime(2022, 10, 21, 12, 59, 18, 975, DateTimeKind.Local).AddTicks(8028), new DateTime(2022, 10, 21, 9, 59, 18, 975, DateTimeKind.Local).AddTicks(7991) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: 2,
                columns: new[] { "EndTimeSlot", "StartTimeSlot" },
                values: new object[] { new DateTime(2022, 10, 21, 12, 59, 18, 975, DateTimeKind.Local).AddTicks(8064), new DateTime(2022, 10, 21, 9, 59, 18, 975, DateTimeKind.Local).AddTicks(8060) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: 3,
                columns: new[] { "EndTimeSlot", "StartTimeSlot" },
                values: new object[] { new DateTime(2022, 10, 21, 12, 59, 18, 975, DateTimeKind.Local).AddTicks(8073), new DateTime(2022, 10, 21, 9, 59, 18, 975, DateTimeKind.Local).AddTicks(8070) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: 4,
                columns: new[] { "EndTimeSlot", "StartTimeSlot" },
                values: new object[] { new DateTime(2022, 10, 21, 12, 59, 18, 975, DateTimeKind.Local).AddTicks(8083), new DateTime(2022, 10, 21, 9, 59, 18, 975, DateTimeKind.Local).AddTicks(8080) });
        }
    }
}
