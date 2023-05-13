using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    Apelido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FotoUsuario = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organizacao",
                columns: table => new
                {
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoOrganizacao = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Rua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numero = table.Column<int>(type: "int", nullable: true),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Referencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LatLong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Youtube = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Twitch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CNPJ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Likes = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizacao", x => x.IdOrganizacao);
                });

            migrationBuilder.CreateTable(
                name: "TipoChaveBatalha",
                columns: table => new
                {
                    Chave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoChave = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoChaveBatalha", x => x.Chave);
                });

            migrationBuilder.CreateTable(
                name: "TipoParticipanteBatalha",
                columns: table => new
                {
                    Tipo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTipo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoParticipanteBatalha", x => x.Tipo);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParticipantesOrganizacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUsuarioParticipante = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipantesOrganizacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParticipantesOrganizacao_AspNetUsers_IdUsuarioParticipante",
                        column: x => x.IdUsuarioParticipante,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParticipantesOrganizacao_Organizacao_IdOrganizacao",
                        column: x => x.IdOrganizacao,
                        principalTable: "Organizacao",
                        principalColumn: "IdOrganizacao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Batalha",
                columns: table => new
                {
                    IdBatalha = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Edicao = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Rua = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: true),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Referencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LatLong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataBatalha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Chave = table.Column<int>(type: "int", nullable: true),
                    SorteioAutomatico = table.Column<bool>(type: "bit", nullable: false),
                    BatalhaPrivada = table.Column<bool>(type: "bit", nullable: false),
                    OcultarBatalha = table.Column<bool>(type: "bit", nullable: false),
                    GerarQRCode = table.Column<bool>(type: "bit", nullable: false),
                    Likes = table.Column<int>(type: "int", nullable: false),
                    TipoChaveChave = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batalha", x => x.IdBatalha);
                    table.ForeignKey(
                        name: "FK_Batalha_Organizacao_IdOrganizacao",
                        column: x => x.IdOrganizacao,
                        principalTable: "Organizacao",
                        principalColumn: "IdOrganizacao",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Batalha_TipoChaveBatalha_TipoChaveChave",
                        column: x => x.TipoChaveChave,
                        principalTable: "TipoChaveBatalha",
                        principalColumn: "Chave",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Evento",
                columns: table => new
                {
                    IdEvento = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdBatalha = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Edicao = table.Column<int>(type: "int", nullable: true),
                    DataEvento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numero = table.Column<int>(type: "int", nullable: true),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Referencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BatalhaIdBatalha = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evento", x => x.IdEvento);
                    table.ForeignKey(
                        name: "FK_Evento_Batalha_BatalhaIdBatalha",
                        column: x => x.BatalhaIdBatalha,
                        principalTable: "Batalha",
                        principalColumn: "IdBatalha",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImagensBatalha",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdBatalha = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Imagem = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    BatalhaIdBatalha = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagensBatalha", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImagensBatalha_Batalha_BatalhaIdBatalha",
                        column: x => x.BatalhaIdBatalha,
                        principalTable: "Batalha",
                        principalColumn: "IdBatalha");
                });

            migrationBuilder.CreateTable(
                name: "ParticipantesBatalha",
                columns: table => new
                {
                    IdParticipanteBatalha = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdBatalha = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apelido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FotoParticipante = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Ranking = table.Column<int>(type: "int", nullable: false),
                    Votos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipantesBatalha", x => x.IdParticipanteBatalha);
                    table.ForeignKey(
                        name: "FK_ParticipantesBatalha_AspNetUsers_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParticipantesBatalha_Batalha_IdBatalha",
                        column: x => x.IdBatalha,
                        principalTable: "Batalha",
                        principalColumn: "IdBatalha",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParticipantesBatalha_TipoParticipanteBatalha_Tipo",
                        column: x => x.Tipo,
                        principalTable: "TipoParticipanteBatalha",
                        principalColumn: "Tipo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConvidadosEvento",
                columns: table => new
                {
                    IdConvidadoEvento = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdEvento = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apelido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FotoConvidado = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConvidadosEvento", x => x.IdConvidadoEvento);
                    table.ForeignKey(
                        name: "FK_ConvidadosEvento_AspNetUsers_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConvidadosEvento_Evento_IdEvento",
                        column: x => x.IdEvento,
                        principalTable: "Evento",
                        principalColumn: "IdEvento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParticipantesEvento",
                columns: table => new
                {
                    IdParticipanteEvento = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdEvento = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apelido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FotoParticipante = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Ranking = table.Column<int>(type: "int", nullable: false),
                    Votos = table.Column<int>(type: "int", nullable: false),
                    BatalhaIdEvento = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipantesEvento", x => x.IdParticipanteEvento);
                    table.ForeignKey(
                        name: "FK_ParticipantesEvento_AspNetUsers_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParticipantesEvento_Evento_BatalhaIdEvento",
                        column: x => x.BatalhaIdEvento,
                        principalTable: "Evento",
                        principalColumn: "IdEvento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParticipantesEvento_TipoParticipanteBatalha_Tipo",
                        column: x => x.Tipo,
                        principalTable: "TipoParticipanteBatalha",
                        principalColumn: "Tipo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TipoChaveBatalha",
                columns: new[] { "Chave", "TipoChave" },
                values: new object[,]
                {
                    { 1, "1x1" },
                    { 2, "2x2" },
                    { 3, "3x3" },
                    { 4, "Frenética" }
                });

            migrationBuilder.InsertData(
                table: "TipoParticipanteBatalha",
                columns: new[] { "Tipo", "NomeTipo" },
                values: new object[,]
                {
                    { 1, "Responsável" },
                    { 2, "Jurados" },
                    { 3, "Mcs" },
                    { 4, "Djs" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Batalha_IdOrganizacao",
                table: "Batalha",
                column: "IdOrganizacao");

            migrationBuilder.CreateIndex(
                name: "IX_Batalha_TipoChaveChave",
                table: "Batalha",
                column: "TipoChaveChave");

            migrationBuilder.CreateIndex(
                name: "IX_ConvidadosEvento_IdEvento",
                table: "ConvidadosEvento",
                column: "IdEvento");

            migrationBuilder.CreateIndex(
                name: "IX_ConvidadosEvento_IdUsuario",
                table: "ConvidadosEvento",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Evento_BatalhaIdBatalha",
                table: "Evento",
                column: "BatalhaIdBatalha");

            migrationBuilder.CreateIndex(
                name: "IX_ImagensBatalha_BatalhaIdBatalha",
                table: "ImagensBatalha",
                column: "BatalhaIdBatalha");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantesBatalha_IdBatalha",
                table: "ParticipantesBatalha",
                column: "IdBatalha");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantesBatalha_IdUsuario",
                table: "ParticipantesBatalha",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantesBatalha_Tipo",
                table: "ParticipantesBatalha",
                column: "Tipo");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantesEvento_BatalhaIdEvento",
                table: "ParticipantesEvento",
                column: "BatalhaIdEvento");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantesEvento_IdUsuario",
                table: "ParticipantesEvento",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantesEvento_Tipo",
                table: "ParticipantesEvento",
                column: "Tipo");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantesOrganizacao_IdOrganizacao",
                table: "ParticipantesOrganizacao",
                column: "IdOrganizacao");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantesOrganizacao_IdUsuarioParticipante",
                table: "ParticipantesOrganizacao",
                column: "IdUsuarioParticipante");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ConvidadosEvento");

            migrationBuilder.DropTable(
                name: "ImagensBatalha");

            migrationBuilder.DropTable(
                name: "ParticipantesBatalha");

            migrationBuilder.DropTable(
                name: "ParticipantesEvento");

            migrationBuilder.DropTable(
                name: "ParticipantesOrganizacao");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Evento");

            migrationBuilder.DropTable(
                name: "TipoParticipanteBatalha");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Batalha");

            migrationBuilder.DropTable(
                name: "Organizacao");

            migrationBuilder.DropTable(
                name: "TipoChaveBatalha");
        }
    }
}
