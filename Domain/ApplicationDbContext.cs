using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Application.ADTO;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Domain
{
    public class ApplicationDbContext : IdentityDbContext<Usuario, Role, int,
        IdentityUserClaim<int>, UsuarioRoles, IdentityUserLogin<int>, IdentityRoleClaim<int>,
        IdentityUserToken<int>>
    {
        protected readonly IConfiguration Configuration;
        public readonly IDbConnection _connect;
        private IDbTransaction _dbTransaction;

        public IDbConnection Connection { get { return _connect; } }
        public IDbTransaction Transaction { get { return _dbTransaction; } }

        public ApplicationDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
            this._connect = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        public void RequiredTransaction()
        {
            if (this.Connection.State == ConnectionState.Closed)
                this.Connection.Open();

            _dbTransaction = this.Connection.BeginTransaction();
        }

        public DbSet<Organizacao> Organizacao { get; set; }
        public DbSet<ParticipantesOrganizacao> ParticipantesOrganizacao { get; set; }
        public DbSet<Batalha> Batalha { get; set; }
        public DbSet<ParticipantesBatalha> ParticipantesBatalha { get; set; }
        public DbSet<TipoParticipanteBatalha> TipoParticipanteBatalha { get; set; }
        public DbSet<TipoChaveBatalha> TipoChaveBatalha { get; set; }
        public DbSet<Evento> Evento { get; set; }
        public DbSet<ParticipantesEvento> ParticipantesEvento { get; set; }
        public DbSet<ConvidadosEvento> ConvidadosEvento { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<UsuarioRoles>(userRole =>
            {
                userRole.HasKey(x => new { x.UserId, x.RoleId });

                userRole.HasOne(x => x.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(x => x.RoleId)
                    .IsRequired();

                userRole.HasOne(x => x.Usuario)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(x => x.UserId)
                    .IsRequired();
            });

            builder.Entity<Batalha>(batalha =>
            {
                batalha.Property(e => e.Edicao).HasDefaultValue(0);
                batalha.Property(e => e.Edicao).ValueGeneratedOnAdd();
            });

            builder.Entity<Batalha>()
                .HasOne(c => c.Organizacao)
                .WithMany(a => a.Batalhas)
                .HasForeignKey(b => b.IdOrganizacao);

            builder.Entity<ParticipantesOrganizacao>()
                .HasOne(c => c.Organizacao)
                .WithMany(a => a.Participantes)
                .HasForeignKey(b => b.IdOrganizacao);

            builder.Entity<ParticipantesOrganizacao>()
                .HasOne(c => c.UsuarioParticipante)
                .WithMany(a => a.ParticipantesOrganizacao)
                .HasForeignKey(b => b.IdUsuarioParticipante);

            builder.Entity<ParticipantesBatalha>()
                .HasOne(c => c.Batalha)
                .WithMany(a => a.ParticipantesBatalha)
                .HasForeignKey(b => b.IdBatalha);

            builder.Entity<ParticipantesBatalha>()
                 .HasOne(c => c.Usuario)
                 .WithMany(a => a.ParticipantesBatalha)
                 .HasForeignKey(b => b.IdUsuario);

            builder.Entity<ParticipantesBatalha>()
                 .HasOne(c => c.TipoParticipante)
                 .WithMany(a => a.ParticipantesBatalha)
                 .HasForeignKey(b => b.Tipo);

            builder.Entity<Batalha>()
                .HasOne(b => b.TipoChave);

            builder.Entity<Evento>()
                .HasOne(b => b.Batalha);

            builder.Entity<ParticipantesEvento>()
                 .HasOne(c => c.Usuario)
                 .WithMany(a => a.ParticipantesEvento)
                 .HasForeignKey(b => b.IdUsuario);

            builder.Entity<ParticipantesEvento>()
                 .HasOne(c => c.TipoParticipante)
                 .WithMany(a => a.ParticipantesEvento)
                 .HasForeignKey(b => b.Tipo);

            builder.Entity<ConvidadosEvento>()
                 .HasOne(c => c.Usuario)
                 .WithMany(a => a.ConvidadosEvento)
                 .HasForeignKey(b => b.IdUsuario);

            builder.Entity<ConvidadosEvento>()
                .HasOne(c => c.Evento)
                .WithMany(a => a.ConvidadosEvento)
                .HasForeignKey(b => b.IdEvento);


            builder.Entity<TipoParticipanteBatalha>().HasData(new TipoParticipanteBatalha()
            {
                NomeTipo = "Responsável",
                Tipo = 1
            }, new TipoParticipanteBatalha()
            {
                NomeTipo = "Jurados",
                Tipo = 2
            },
            new TipoParticipanteBatalha()
            {
                NomeTipo = "Mcs",
                Tipo = 3
            },
            new TipoParticipanteBatalha()
            {
                NomeTipo = "Djs",
                Tipo = 4
            });

            builder.Entity<TipoChaveBatalha>().HasData(new TipoChaveBatalha()
            {
                Chave = 1,
                TipoChave = "1x1"
            }, new TipoChaveBatalha()
            {
                Chave = 2,
                TipoChave = "2x2"
            },
            new TipoChaveBatalha()
            {
                Chave = 3,
                TipoChave = "3x3"
            },
            new TipoChaveBatalha()
            {
                Chave = 4,
                TipoChave = "Frenética"
            });
        }
    }
}