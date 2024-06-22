using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bokkingsystem.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 22, 13, 47, 19, 238, DateTimeKind.Local).AddTicks(9900));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 22, 13, 47, 19, 238, DateTimeKind.Local).AddTicks(9951));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 22, 13, 47, 19, 238, DateTimeKind.Local).AddTicks(9959));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 22, 13, 47, 19, 238, DateTimeKind.Local).AddTicks(9969));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 22, 13, 47, 19, 238, DateTimeKind.Local).AddTicks(9978));

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 1,
                columns: new[] { "Email", "Password", "Role" },
                values: new object[] { "company1@gmail.com", "Company@123", "Company" });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 2,
                columns: new[] { "Email", "Password", "Role" },
                values: new object[] { "company2@gmail.com", "Company@123", "Company" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                columns: new[] { "Email", "Role" },
                values: new object[] { "customer1@mail.se", "Customer" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                columns: new[] { "Email", "Role" },
                values: new object[] { "customer2@mail.se", "Customer" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3,
                columns: new[] { "Email", "Role" },
                values: new object[] { "customer3@mail.se", "Customer" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Companies");

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 25, 15, 24, 3, 710, DateTimeKind.Local).AddTicks(7375));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 25, 15, 24, 3, 710, DateTimeKind.Local).AddTicks(7428));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 25, 15, 24, 3, 710, DateTimeKind.Local).AddTicks(7437));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 25, 15, 24, 3, 710, DateTimeKind.Local).AddTicks(7446));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 25, 15, 24, 3, 710, DateTimeKind.Local).AddTicks(7454));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                column: "Email",
                value: "andre@mail.se");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                column: "Email",
                value: "benben@mail.se");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3,
                column: "Email",
                value: "carl@mail.se");
        }
    }
}
