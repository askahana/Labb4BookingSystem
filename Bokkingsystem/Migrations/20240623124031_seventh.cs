using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bokkingsystem.Migrations
{
    /// <inheritdoc />
    public partial class seventh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_AspNetUsers_AppUserId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AspNetUsers_AppUserId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_AppUserId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Companies_AppUserId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Companies");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "Customers",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "Companies",
                newName: "Password");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId1",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId1",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

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
                columns: new[] { "Password", "Role" },
                values: new object[] { "Password123", "company" });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 2,
                columns: new[] { "Password", "Role" },
                values: new object[] { "Password123", "company" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                columns: new[] { "Password", "Role" },
                values: new object[] { "Password123", "customer" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                columns: new[] { "Password", "Role" },
                values: new object[] { "Password123", "customer" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3,
                columns: new[] { "Password", "Role" },
                values: new object[] { "Password123", "customer" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CompanyId1",
                table: "AspNetUsers",
                column: "CompanyId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CustomerId1",
                table: "AspNetUsers",
                column: "CustomerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Companies_CompanyId1",
                table: "AspNetUsers",
                column: "CompanyId1",
                principalTable: "Companies",
                principalColumn: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Customers_CustomerId1",
                table: "AspNetUsers",
                column: "CustomerId1",
                principalTable: "Customers",
                principalColumn: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Companies_CompanyId1",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Customers_CustomerId1",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CompanyId1",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CustomerId1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CompanyId1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CustomerId1",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Customers",
                newName: "PasswordHash");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Companies",
                newName: "PasswordHash");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Customers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Companies",
                type: "nvarchar(450)",
                nullable: true);

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
                columns: new[] { "AppUserId", "PasswordHash", "Role" },
                values: new object[] { null, "AQAAAAIAAYagAAAAEFTObsf8QxNokt0g3NP5BKvhUMKsHsihfdg4c4tPK+SASVzL/TRVlAx2ggC5VVS6/w==", "Company" });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 2,
                columns: new[] { "AppUserId", "PasswordHash", "Role" },
                values: new object[] { null, "AQAAAAIAAYagAAAAEFTObsf8QxNokt0g3NP5BKvhUMKsHsihfdg4c4tPK+SASVzL/TRVlAx2ggC5VVS6/w==", "Company" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                columns: new[] { "AppUserId", "PasswordHash", "Role" },
                values: new object[] { null, "AQAAAAIAAYagAAAAEFD/Q0fua2yLhsjlvcmahEqaHixikZ0Sc1vwXb5zxd+FUG6Bc2Fhi6niiogGqmz9aQ==", "Customer" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                columns: new[] { "AppUserId", "PasswordHash", "Role" },
                values: new object[] { null, "AQAAAAIAAYagAAAAEFD/Q0fua2yLhsjlvcmahEqaHixikZ0Sc1vwXb5zxd+FUG6Bc2Fhi6niiogGqmz9aQ==", "Customer" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3,
                columns: new[] { "AppUserId", "PasswordHash", "Role" },
                values: new object[] { null, "AQAAAAIAAYagAAAAEFD/Q0fua2yLhsjlvcmahEqaHixikZ0Sc1vwXb5zxd+FUG6Bc2Fhi6niiogGqmz9aQ==", "Customer" });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AppUserId",
                table: "Customers",
                column: "AppUserId",
                unique: true,
                filter: "[AppUserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_AppUserId",
                table: "Companies",
                column: "AppUserId",
                unique: true,
                filter: "[AppUserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_AspNetUsers_AppUserId",
                table: "Companies",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_AspNetUsers_AppUserId",
                table: "Customers",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
