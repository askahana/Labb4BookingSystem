using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bokkingsystem.Migrations
{
    /// <inheritdoc />
    public partial class sixth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Customers",
                newName: "PasswordHash");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Companies",
                newName: "PasswordHash");

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 22, 23, 0, 44, 352, DateTimeKind.Local).AddTicks(2922));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 22, 23, 0, 44, 352, DateTimeKind.Local).AddTicks(2992));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 22, 23, 0, 44, 352, DateTimeKind.Local).AddTicks(3004));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 22, 23, 0, 44, 352, DateTimeKind.Local).AddTicks(3014));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 22, 23, 0, 44, 352, DateTimeKind.Local).AddTicks(3074));

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 1,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEFTObsf8QxNokt0g3NP5BKvhUMKsHsihfdg4c4tPK+SASVzL/TRVlAx2ggC5VVS6/w==");

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 2,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEFTObsf8QxNokt0g3NP5BKvhUMKsHsihfdg4c4tPK+SASVzL/TRVlAx2ggC5VVS6/w==");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEFD/Q0fua2yLhsjlvcmahEqaHixikZ0Sc1vwXb5zxd+FUG6Bc2Fhi6niiogGqmz9aQ==");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEFD/Q0fua2yLhsjlvcmahEqaHixikZ0Sc1vwXb5zxd+FUG6Bc2Fhi6niiogGqmz9aQ==");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEFD/Q0fua2yLhsjlvcmahEqaHixikZ0Sc1vwXb5zxd+FUG6Bc2Fhi6niiogGqmz9aQ==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "Customers",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "Companies",
                newName: "Password");

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 22, 19, 45, 56, 919, DateTimeKind.Local).AddTicks(8646));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 22, 19, 45, 56, 919, DateTimeKind.Local).AddTicks(8708));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 22, 19, 45, 56, 919, DateTimeKind.Local).AddTicks(8720));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 22, 19, 45, 56, 919, DateTimeKind.Local).AddTicks(8730));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 22, 19, 45, 56, 919, DateTimeKind.Local).AddTicks(8739));

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 1,
                column: "Password",
                value: "Company@123");

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 2,
                column: "Password",
                value: "Company@123");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                column: "Password",
                value: "1234");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                column: "Password",
                value: "1234");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3,
                column: "Password",
                value: "1234");
        }
    }
}
