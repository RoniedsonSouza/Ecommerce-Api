using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    public partial class refinosMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batalha_Organizacao_IdOrganizacao",
                table: "Batalha");

            migrationBuilder.AlterColumn<int>(
                name: "Votos",
                table: "ParticipantesBatalha",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Ranking",
                table: "ParticipantesBatalha",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Grupo",
                table: "ParticipantesBatalha",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Posicao",
                table: "ParticipantesBatalha",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Vencedor",
                table: "ParticipantesBatalha",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<Guid>(
                name: "IdOrganizacao",
                table: "Batalha",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Batalha",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 13, 15, 14, 6, 585, DateTimeKind.Local).AddTicks(6540),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<byte[]>(
                name: "FotoUsuario",
                table: "AspNetUsers",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 13, 15, 14, 6, 585, DateTimeKind.Local).AddTicks(6344),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddForeignKey(
                name: "FK_Batalha_Organizacao_IdOrganizacao",
                table: "Batalha",
                column: "IdOrganizacao",
                principalTable: "Organizacao",
                principalColumn: "IdOrganizacao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batalha_Organizacao_IdOrganizacao",
                table: "Batalha");

            migrationBuilder.DropColumn(
                name: "Grupo",
                table: "ParticipantesBatalha");

            migrationBuilder.DropColumn(
                name: "Posicao",
                table: "ParticipantesBatalha");

            migrationBuilder.DropColumn(
                name: "Vencedor",
                table: "ParticipantesBatalha");

            migrationBuilder.AlterColumn<int>(
                name: "Votos",
                table: "ParticipantesBatalha",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Ranking",
                table: "ParticipantesBatalha",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<Guid>(
                name: "IdOrganizacao",
                table: "Batalha",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Batalha",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 13, 15, 14, 6, 585, DateTimeKind.Local).AddTicks(6540));

            migrationBuilder.AlterColumn<byte[]>(
                name: "FotoUsuario",
                table: "AspNetUsers",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 13, 15, 14, 6, 585, DateTimeKind.Local).AddTicks(6344));

            migrationBuilder.AddForeignKey(
                name: "FK_Batalha_Organizacao_IdOrganizacao",
                table: "Batalha",
                column: "IdOrganizacao",
                principalTable: "Organizacao",
                principalColumn: "IdOrganizacao",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
