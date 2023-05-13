﻿// <auto-generated />
using System;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Domain.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230513055918_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Application.ADTO.Batalha", b =>
                {
                    b.Property<Guid>("IdBatalha")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("BatalhaPrivada")
                        .HasColumnType("bit");

                    b.Property<string>("Cep")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Chave")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataBatalha")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<int>("Edicao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<bool>("GerarQRCode")
                        .HasColumnType("bit");

                    b.Property<Guid>("IdOrganizacao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LatLong")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Likes")
                        .HasColumnType("int");

                    b.Property<int?>("Numero")
                        .HasColumnType("int");

                    b.Property<bool>("OcultarBatalha")
                        .HasColumnType("bit");

                    b.Property<string>("Referencia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("SorteioAutomatico")
                        .HasColumnType("bit");

                    b.Property<int>("TipoChaveChave")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdBatalha");

                    b.HasIndex("IdOrganizacao");

                    b.HasIndex("TipoChaveChave");

                    b.ToTable("Batalha");
                });

            modelBuilder.Entity("Application.ADTO.ConvidadosEvento", b =>
                {
                    b.Property<Guid>("IdConvidadoEvento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Apelido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("FotoConvidado")
                        .HasColumnType("varbinary(max)");

                    b.Property<Guid>("IdEvento")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdConvidadoEvento");

                    b.HasIndex("IdEvento");

                    b.HasIndex("IdUsuario");

                    b.ToTable("ConvidadosEvento");
                });

            modelBuilder.Entity("Application.ADTO.Evento", b =>
                {
                    b.Property<Guid>("IdEvento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BatalhaIdBatalha")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cep")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataEvento")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Edicao")
                        .HasColumnType("int");

                    b.Property<Guid?>("IdBatalha")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("Referencia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rua")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEvento");

                    b.HasIndex("BatalhaIdBatalha");

                    b.ToTable("Evento");
                });

            modelBuilder.Entity("Application.ADTO.ImagensBatalha", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BatalhaIdBatalha")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdBatalha")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("Imagem")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("BatalhaIdBatalha");

                    b.ToTable("ImagensBatalha");
                });

            modelBuilder.Entity("Application.ADTO.Organizacao", b =>
                {
                    b.Property<Guid>("IdOrganizacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CNPJ")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cep")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("LatLong")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Likes")
                        .HasColumnType("int");

                    b.Property<byte[]>("LogoOrganizacao")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("Referencia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rua")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Twitch")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Youtube")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdOrganizacao");

                    b.ToTable("Organizacao");
                });

            modelBuilder.Entity("Application.ADTO.ParticipantesBatalha", b =>
                {
                    b.Property<Guid>("IdParticipanteBatalha")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Apelido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("FotoParticipante")
                        .HasColumnType("varbinary(max)");

                    b.Property<Guid>("IdBatalha")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Ranking")
                        .HasColumnType("int");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.Property<int>("Votos")
                        .HasColumnType("int");

                    b.HasKey("IdParticipanteBatalha");

                    b.HasIndex("IdBatalha");

                    b.HasIndex("IdUsuario");

                    b.HasIndex("Tipo");

                    b.ToTable("ParticipantesBatalha");
                });

            modelBuilder.Entity("Application.ADTO.ParticipantesEvento", b =>
                {
                    b.Property<Guid>("IdParticipanteEvento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Apelido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("BatalhaIdEvento")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("FotoParticipante")
                        .HasColumnType("varbinary(max)");

                    b.Property<Guid>("IdEvento")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Ranking")
                        .HasColumnType("int");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.Property<int>("Votos")
                        .HasColumnType("int");

                    b.HasKey("IdParticipanteEvento");

                    b.HasIndex("BatalhaIdEvento");

                    b.HasIndex("IdUsuario");

                    b.HasIndex("Tipo");

                    b.ToTable("ParticipantesEvento");
                });

            modelBuilder.Entity("Application.ADTO.ParticipantesOrganizacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdOrganizacao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("IdUsuarioParticipante")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdOrganizacao");

                    b.HasIndex("IdUsuarioParticipante");

                    b.ToTable("ParticipantesOrganizacao");
                });

            modelBuilder.Entity("Application.ADTO.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Application.ADTO.TipoChaveBatalha", b =>
                {
                    b.Property<int>("Chave")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Chave"), 1L, 1);

                    b.Property<string>("TipoChave")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Chave");

                    b.ToTable("TipoChaveBatalha");

                    b.HasData(
                        new
                        {
                            Chave = 1,
                            TipoChave = "1x1"
                        },
                        new
                        {
                            Chave = 2,
                            TipoChave = "2x2"
                        },
                        new
                        {
                            Chave = 3,
                            TipoChave = "3x3"
                        },
                        new
                        {
                            Chave = 4,
                            TipoChave = "Frenética"
                        });
                });

            modelBuilder.Entity("Application.ADTO.TipoParticipanteBatalha", b =>
                {
                    b.Property<int>("Tipo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Tipo"), 1L, 1);

                    b.Property<string>("NomeTipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Tipo");

                    b.ToTable("TipoParticipanteBatalha");

                    b.HasData(
                        new
                        {
                            Tipo = 1,
                            NomeTipo = "Responsável"
                        },
                        new
                        {
                            Tipo = 2,
                            NomeTipo = "Jurados"
                        },
                        new
                        {
                            Tipo = 3,
                            NomeTipo = "Mcs"
                        },
                        new
                        {
                            Tipo = 4,
                            NomeTipo = "Djs"
                        });
                });

            modelBuilder.Entity("Application.ADTO.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Apelido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<byte[]>("FotoUsuario")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Application.ADTO.UsuarioRoles", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Application.ADTO.Batalha", b =>
                {
                    b.HasOne("Application.ADTO.Organizacao", "Organizacao")
                        .WithMany("Batalhas")
                        .HasForeignKey("IdOrganizacao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Application.ADTO.TipoChaveBatalha", "TipoChave")
                        .WithMany()
                        .HasForeignKey("TipoChaveChave")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organizacao");

                    b.Navigation("TipoChave");
                });

            modelBuilder.Entity("Application.ADTO.ConvidadosEvento", b =>
                {
                    b.HasOne("Application.ADTO.Evento", "Evento")
                        .WithMany("ConvidadosEvento")
                        .HasForeignKey("IdEvento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Application.ADTO.Usuario", "Usuario")
                        .WithMany("ConvidadosEvento")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evento");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Application.ADTO.Evento", b =>
                {
                    b.HasOne("Application.ADTO.Batalha", "Batalha")
                        .WithMany()
                        .HasForeignKey("BatalhaIdBatalha")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Batalha");
                });

            modelBuilder.Entity("Application.ADTO.ImagensBatalha", b =>
                {
                    b.HasOne("Application.ADTO.Batalha", null)
                        .WithMany("ImagensBatalha")
                        .HasForeignKey("BatalhaIdBatalha");
                });

            modelBuilder.Entity("Application.ADTO.ParticipantesBatalha", b =>
                {
                    b.HasOne("Application.ADTO.Batalha", "Batalha")
                        .WithMany("ParticipantesBatalha")
                        .HasForeignKey("IdBatalha")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Application.ADTO.Usuario", "Usuario")
                        .WithMany("ParticipantesBatalha")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Application.ADTO.TipoParticipanteBatalha", "TipoParticipante")
                        .WithMany("ParticipantesBatalha")
                        .HasForeignKey("Tipo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Batalha");

                    b.Navigation("TipoParticipante");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Application.ADTO.ParticipantesEvento", b =>
                {
                    b.HasOne("Application.ADTO.Evento", "Batalha")
                        .WithMany("ParticipantesEvento")
                        .HasForeignKey("BatalhaIdEvento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Application.ADTO.Usuario", "Usuario")
                        .WithMany("ParticipantesEvento")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Application.ADTO.TipoParticipanteBatalha", "TipoParticipante")
                        .WithMany("ParticipantesEvento")
                        .HasForeignKey("Tipo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Batalha");

                    b.Navigation("TipoParticipante");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Application.ADTO.ParticipantesOrganizacao", b =>
                {
                    b.HasOne("Application.ADTO.Organizacao", "Organizacao")
                        .WithMany("Participantes")
                        .HasForeignKey("IdOrganizacao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Application.ADTO.Usuario", "UsuarioParticipante")
                        .WithMany("ParticipantesOrganizacao")
                        .HasForeignKey("IdUsuarioParticipante")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organizacao");

                    b.Navigation("UsuarioParticipante");
                });

            modelBuilder.Entity("Application.ADTO.UsuarioRoles", b =>
                {
                    b.HasOne("Application.ADTO.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Application.ADTO.Usuario", "Usuario")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Application.ADTO.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("Application.ADTO.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Application.ADTO.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("Application.ADTO.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Application.ADTO.Batalha", b =>
                {
                    b.Navigation("ImagensBatalha");

                    b.Navigation("ParticipantesBatalha");
                });

            modelBuilder.Entity("Application.ADTO.Evento", b =>
                {
                    b.Navigation("ConvidadosEvento");

                    b.Navigation("ParticipantesEvento");
                });

            modelBuilder.Entity("Application.ADTO.Organizacao", b =>
                {
                    b.Navigation("Batalhas");

                    b.Navigation("Participantes");
                });

            modelBuilder.Entity("Application.ADTO.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Application.ADTO.TipoParticipanteBatalha", b =>
                {
                    b.Navigation("ParticipantesBatalha");

                    b.Navigation("ParticipantesEvento");
                });

            modelBuilder.Entity("Application.ADTO.Usuario", b =>
                {
                    b.Navigation("ConvidadosEvento");

                    b.Navigation("ParticipantesBatalha");

                    b.Navigation("ParticipantesEvento");

                    b.Navigation("ParticipantesOrganizacao");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
