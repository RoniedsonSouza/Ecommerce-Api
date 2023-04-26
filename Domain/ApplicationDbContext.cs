using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Application.ADTO;

namespace Domain
{
    public class ApplicationDbContext : IdentityDbContext<Usuario, Role, int,
        IdentityUserClaim<int>, UsuarioRoles, IdentityUserLogin<int>, IdentityRoleClaim<int>,
        IdentityUserToken<int>>
    {
        protected readonly IConfiguration Configuration;

        public ApplicationDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public DbSet<Produto> Produto { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<ImagensProdutos> ImagensProdutos { get; set; }

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

            builder.Entity<Categoria>()
                .HasMany(c => c.Produtos)
                .WithOne(p => p.Categoria)
                .HasForeignKey(p => p.CategoryId);

            builder.Entity<Produto>()
                .HasMany(c => c.Imagens)
                .WithOne(p => p.Produto)
                .HasForeignKey(p => p.ProdutoId);
        }
    }
}