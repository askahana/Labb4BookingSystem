using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bokkingsystem.Migrations
{
    /// <inheritdoc />
    public partial class ChangedDateFormat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 1,
                columns: new[] { "BookedDate", "CreatedDate" },
                values: new object[] { new DateTime(2024, 4, 23, 14, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 25, 15, 24, 3, 710, DateTimeKind.Local).AddTicks(7375) });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 2,
                columns: new[] { "BookedDate", "CreatedDate" },
                values: new object[] { new DateTime(2024, 4, 25, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 25, 15, 24, 3, 710, DateTimeKind.Local).AddTicks(7428) });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 3,
                columns: new[] { "BookedDate", "CreatedDate" },
                values: new object[] { new DateTime(2024, 4, 29, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 25, 15, 24, 3, 710, DateTimeKind.Local).AddTicks(7437) });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 4,
                columns: new[] { "BookedDate", "CreatedDate" },
                values: new object[] { new DateTime(2024, 5, 21, 14, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 25, 15, 24, 3, 710, DateTimeKind.Local).AddTicks(7446) });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 5,
                columns: new[] { "BookedDate", "CreatedDate" },
                values: new object[] { new DateTime(2024, 5, 22, 11, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 25, 15, 24, 3, 710, DateTimeKind.Local).AddTicks(7454) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 1,
                columns: new[] { "BookedDate", "CreatedDate" },
                values: new object[] { new DateTime(2024, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 25, 15, 13, 30, 292, DateTimeKind.Local).AddTicks(4908) });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 2,
                columns: new[] { "BookedDate", "CreatedDate" },
                values: new object[] { new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 25, 15, 13, 30, 292, DateTimeKind.Local).AddTicks(4955) });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 3,
                columns: new[] { "BookedDate", "CreatedDate" },
                values: new object[] { new DateTime(2024, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 25, 15, 13, 30, 292, DateTimeKind.Local).AddTicks(4964) });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 4,
                columns: new[] { "BookedDate", "CreatedDate" },
                values: new object[] { new DateTime(2024, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 25, 15, 13, 30, 292, DateTimeKind.Local).AddTicks(4987) });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 5,
                columns: new[] { "BookedDate", "CreatedDate" },
                values: new object[] { new DateTime(2024, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 25, 15, 13, 30, 292, DateTimeKind.Local).AddTicks(4996) });
        }
    }
}
