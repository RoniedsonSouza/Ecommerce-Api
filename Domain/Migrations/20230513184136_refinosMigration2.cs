using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    public partial class refinosMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Batalha",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 13, 15, 41, 36, 289, DateTimeKind.Local).AddTicks(528),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 13, 15, 14, 6, 585, DateTimeKind.Local).AddTicks(6540));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 13, 15, 41, 36, 289, DateTimeKind.Local).AddTicks(344),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 13, 15, 14, 6, 585, DateTimeKind.Local).AddTicks(6344));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Batalha",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 13, 15, 14, 6, 585, DateTimeKind.Local).AddTicks(6540),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 13, 15, 41, 36, 289, DateTimeKind.Local).AddTicks(528));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 13, 15, 14, 6, 585, DateTimeKind.Local).AddTicks(6344),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 13, 15, 41, 36, 289, DateTimeKind.Local).AddTicks(344));
        }
    }
}
