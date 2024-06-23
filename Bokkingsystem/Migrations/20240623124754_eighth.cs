using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bokkingsystem.Migrations
{
    /// <inheritdoc />
    public partial class eighth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 23, 14, 47, 54, 131, DateTimeKind.Local).AddTicks(7392));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 23, 14, 47, 54, 131, DateTimeKind.Local).AddTicks(7608));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 23, 14, 47, 54, 131, DateTimeKind.Local).AddTicks(7650));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 23, 14, 47, 54, 131, DateTimeKind.Local).AddTicks(7700));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 23, 14, 47, 54, 131, DateTimeKind.Local).AddTicks(7716));

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$LLsh.nryAFGqLk9U37FUz.mMzOEzQWNhKHKMbm6P7uWQlSM4q/Ao6");

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$FVSchMRuG4l/qGx2NKBSnuhhfsPAxAbKsysh/HF2glWhrXaT/Mbsy");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$RLFLd7B2BjEL.Stav60WO.vmcalnATqnnYNnJokzKjn3bee0sE0im");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$nIR0dS8J9QUszPDZMrfy8ebVirL6Vg5.e1Wl3iwd9bLEmV0Qb0iXe");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$MLAWyuIhISJXgQWw.J8qu.1wbvMZaYNcAUfqrrGP5qMZo/hPfYpra");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 23, 14, 40, 31, 543, DateTimeKind.Local).AddTicks(8805));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 23, 14, 40, 31, 543, DateTimeKind.Local).AddTicks(8868));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 23, 14, 40, 31, 543, DateTimeKind.Local).AddTicks(8879));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 23, 14, 40, 31, 543, DateTimeKind.Local).AddTicks(8889));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 23, 14, 40, 31, 543, DateTimeKind.Local).AddTicks(8898));

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 1,
                column: "Password",
                value: "Password123");

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 2,
                column: "Password",
                value: "Password123");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                column: "Password",
                value: "Password123");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                column: "Password",
                value: "Password123");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3,
                column: "Password",
                value: "Password123");
        }
    }
}
