using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class updatedModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cafeterias_Cities_CityId",
                table: "Cafeterias");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Cities_CityId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_CityId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Cafeterias_CityId",
                table: "Cafeterias");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: 1,
                columns: new[] { "EndTimeSlot", "StartTimeSlot" },
                values: new object[] { new DateTime(2022, 10, 27, 20, 3, 17, 214, DateTimeKind.Local).AddTicks(9384), new DateTime(2022, 10, 27, 17, 3, 17, 214, DateTimeKind.Local).AddTicks(9370) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: 2,
                columns: new[] { "EndTimeSlot", "StartTimeSlot" },
                values: new object[] { new DateTime(2022, 10, 27, 20, 3, 17, 214, DateTimeKind.Local).AddTicks(9446), new DateTime(2022, 10, 27, 17, 3, 17, 214, DateTimeKind.Local).AddTicks(9426) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: 3,
                columns: new[] { "EndTimeSlot", "StartTimeSlot" },
                values: new object[] { new DateTime(2022, 10, 27, 20, 3, 17, 214, DateTimeKind.Local).AddTicks(9478), new DateTime(2022, 10, 27, 17, 3, 17, 214, DateTimeKind.Local).AddTicks(9464) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: 4,
                columns: new[] { "EndTimeSlot", "StartTimeSlot" },
                values: new object[] { new DateTime(2022, 10, 27, 20, 3, 17, 214, DateTimeKind.Local).AddTicks(9511), new DateTime(2022, 10, 27, 17, 3, 17, 214, DateTimeKind.Local).AddTicks(9497) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: 5,
                columns: new[] { "EndTimeSlot", "StartTimeSlot" },
                values: new object[] { new DateTime(2022, 10, 27, 20, 3, 17, 214, DateTimeKind.Local).AddTicks(9544), new DateTime(2022, 10, 27, 17, 3, 17, 214, DateTimeKind.Local).AddTicks(9530) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: 6,
                columns: new[] { "EndTimeSlot", "StartTimeSlot" },
                values: new object[] { new DateTime(2022, 10, 27, 20, 3, 17, 214, DateTimeKind.Local).AddTicks(9579), new DateTime(2022, 10, 27, 17, 3, 17, 214, DateTimeKind.Local).AddTicks(9564) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: 1,
                columns: new[] { "EndTimeSlot", "StartTimeSlot" },
                values: new object[] { new DateTime(2022, 10, 26, 17, 39, 19, 820, DateTimeKind.Local).AddTicks(6671), new DateTime(2022, 10, 26, 14, 39, 19, 820, DateTimeKind.Local).AddTicks(6657) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: 2,
                columns: new[] { "EndTimeSlot", "StartTimeSlot" },
                values: new object[] { new DateTime(2022, 10, 26, 17, 39, 19, 820, DateTimeKind.Local).AddTicks(6728), new DateTime(2022, 10, 26, 14, 39, 19, 820, DateTimeKind.Local).AddTicks(6709) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: 3,
                columns: new[] { "EndTimeSlot", "StartTimeSlot" },
                values: new object[] { new DateTime(2022, 10, 26, 17, 39, 19, 820, DateTimeKind.Local).AddTicks(6761), new DateTime(2022, 10, 26, 14, 39, 19, 820, DateTimeKind.Local).AddTicks(6747) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: 4,
                columns: new[] { "EndTimeSlot", "StartTimeSlot" },
                values: new object[] { new DateTime(2022, 10, 26, 17, 39, 19, 820, DateTimeKind.Local).AddTicks(6799), new DateTime(2022, 10, 26, 14, 39, 19, 820, DateTimeKind.Local).AddTicks(6780) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: 5,
                columns: new[] { "EndTimeSlot", "StartTimeSlot" },
                values: new object[] { new DateTime(2022, 10, 26, 17, 39, 19, 820, DateTimeKind.Local).AddTicks(6833), new DateTime(2022, 10, 26, 14, 39, 19, 820, DateTimeKind.Local).AddTicks(6818) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: 6,
                columns: new[] { "EndTimeSlot", "StartTimeSlot" },
                values: new object[] { new DateTime(2022, 10, 26, 17, 39, 19, 820, DateTimeKind.Local).AddTicks(6871), new DateTime(2022, 10, 26, 14, 39, 19, 820, DateTimeKind.Local).AddTicks(6857) });

            migrationBuilder.CreateIndex(
                name: "IX_Students_CityId",
                table: "Students",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Cafeterias_CityId",
                table: "Cafeterias",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cafeterias_Cities_CityId",
                table: "Cafeterias",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Cities_CityId",
                table: "Students",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "CityId");
        }
    }
}
