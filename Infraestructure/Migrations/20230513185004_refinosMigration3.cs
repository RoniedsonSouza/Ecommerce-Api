using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    public partial class refinosMigration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batalha_TipoChaveBatalha_TipoChaveChave",
                table: "Batalha");

            migrationBuilder.DropIndex(
                name: "IX_Batalha_TipoChaveChave",
                table: "Batalha");

            migrationBuilder.DropColumn(
                name: "TipoChaveChave",
                table: "Batalha");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Batalha",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 13, 15, 41, 36, 289, DateTimeKind.Local).AddTicks(528));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 13, 15, 41, 36, 289, DateTimeKind.Local).AddTicks(344));

            migrationBuilder.CreateIndex(
                name: "IX_Batalha_Chave",
                table: "Batalha",
                column: "Chave");

            migrationBuilder.AddForeignKey(
                name: "FK_Batalha_TipoChaveBatalha_Chave",
                table: "Batalha",
                column: "Chave",
                principalTable: "TipoChaveBatalha",
                principalColumn: "Chave");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batalha_TipoChaveBatalha_Chave",
                table: "Batalha");

            migrationBuilder.DropIndex(
                name: "IX_Batalha_Chave",
                table: "Batalha");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Batalha",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 13, 15, 41, 36, 289, DateTimeKind.Local).AddTicks(528),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "TipoChaveChave",
                table: "Batalha",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 13, 15, 41, 36, 289, DateTimeKind.Local).AddTicks(344),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateIndex(
                name: "IX_Batalha_TipoChaveChave",
                table: "Batalha",
                column: "TipoChaveChave");

            migrationBuilder.AddForeignKey(
                name: "FK_Batalha_TipoChaveBatalha_TipoChaveChave",
                table: "Batalha",
                column: "TipoChaveChave",
                principalTable: "TipoChaveBatalha",
                principalColumn: "Chave",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
