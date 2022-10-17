using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class employeeFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Cafeterias_CafeteriaId",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Cities_CityId",
                table: "Packages");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Packages",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PickupTime",
                table: "Packages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Packages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "EighteenPlus",
                table: "Packages",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Packages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Category",
                table: "Packages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CafeteriaId",
                table: "Packages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "BestBeforeDate",
                table: "Packages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CafeteriaId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1,
                columns: new[] { "CafeteriaId", "CityId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2,
                columns: new[] { "CafeteriaId", "CityId" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 3,
                columns: new[] { "CafeteriaId", "CityId" },
                values: new object[] { 3, 3 });

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
                columns: new[] { "BestBeforeDate", "PickupTime" },
                values: new object[] { new DateTime(2022, 10, 17, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 10, 16, 0, 0, 0, 0, DateTimeKind.Local) });

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

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Cafeterias_CafeteriaId",
                table: "Packages",
                column: "CafeteriaId",
                principalTable: "Cafeterias",
                principalColumn: "CafeteriaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Cities_CityId",
                table: "Packages",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Cafeterias_CafeteriaId",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Cities_CityId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "CafeteriaId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Employees");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Packages",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PickupTime",
                table: "Packages",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Packages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "EighteenPlus",
                table: "Packages",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Packages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Category",
                table: "Packages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CafeteriaId",
                table: "Packages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BestBeforeDate",
                table: "Packages",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: 1,
                columns: new[] { "BestBeforeDate", "PickupTime" },
                values: new object[] { new DateTime(2022, 10, 14, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 10, 13, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: 2,
                columns: new[] { "BestBeforeDate", "PickupTime" },
                values: new object[] { new DateTime(2022, 10, 14, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 10, 13, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: 3,
                columns: new[] { "BestBeforeDate", "PickupTime" },
                values: new object[] { new DateTime(2022, 10, 14, 19, 5, 58, 795, DateTimeKind.Local).AddTicks(4982), new DateTime(2022, 10, 13, 19, 5, 58, 795, DateTimeKind.Local).AddTicks(4963) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: 4,
                columns: new[] { "BestBeforeDate", "PickupTime" },
                values: new object[] { new DateTime(2022, 10, 14, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 10, 13, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Cafeterias_CafeteriaId",
                table: "Packages",
                column: "CafeteriaId",
                principalTable: "Cafeterias",
                principalColumn: "CafeteriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Cities_CityId",
                table: "Packages",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "CityId");
        }
    }
}
