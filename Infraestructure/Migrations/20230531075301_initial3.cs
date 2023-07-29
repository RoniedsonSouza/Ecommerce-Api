using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    public partial class initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImagensBatalha_Batalha_BatalhaIdBatalha",
                table: "ImagensBatalha");

            migrationBuilder.DropIndex(
                name: "IX_ImagensBatalha_BatalhaIdBatalha",
                table: "ImagensBatalha");

            migrationBuilder.DropColumn(
                name: "BatalhaIdBatalha",
                table: "ImagensBatalha");

            migrationBuilder.CreateIndex(
                name: "IX_ImagensBatalha_IdBatalha",
                table: "ImagensBatalha",
                column: "IdBatalha");

            migrationBuilder.AddForeignKey(
                name: "FK_ImagensBatalha_Batalha_IdBatalha",
                table: "ImagensBatalha",
                column: "IdBatalha",
                principalTable: "Batalha",
                principalColumn: "IdBatalha",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImagensBatalha_Batalha_IdBatalha",
                table: "ImagensBatalha");

            migrationBuilder.DropIndex(
                name: "IX_ImagensBatalha_IdBatalha",
                table: "ImagensBatalha");

            migrationBuilder.AddColumn<Guid>(
                name: "BatalhaIdBatalha",
                table: "ImagensBatalha",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImagensBatalha_BatalhaIdBatalha",
                table: "ImagensBatalha",
                column: "BatalhaIdBatalha");

            migrationBuilder.AddForeignKey(
                name: "FK_ImagensBatalha_Batalha_BatalhaIdBatalha",
                table: "ImagensBatalha",
                column: "BatalhaIdBatalha",
                principalTable: "Batalha",
                principalColumn: "IdBatalha");
        }
    }
}
