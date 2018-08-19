namespace WebBiotec.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelMantenedores : DbContext
    {
        public ModelMantenedores()
            : base("name=ModelMantenedores")
        {
        }

        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Config_ConceptosRetail> Config_ConceptosRetail { get; set; }
        public virtual DbSet<Config_PerfilRetail> Config_PerfilRetail { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoles>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Config_ConceptosRetail>()
                .Property(e => e.RUT)
                .IsUnicode(false);

            modelBuilder.Entity<Config_ConceptosRetail>()
                .Property(e => e.FICHA)
                .IsUnicode(false);

            modelBuilder.Entity<Config_ConceptosRetail>()
                .Property(e => e.COD_CONCEPTO)
                .IsUnicode(false);

            modelBuilder.Entity<Config_ConceptosRetail>()
                .Property(e => e.CONCEPTO)
                .IsUnicode(false);

            modelBuilder.Entity<Config_ConceptosRetail>()
                .Property(e => e.COD_CUENTA)
                .IsUnicode(false);

            modelBuilder.Entity<Config_ConceptosRetail>()
                .Property(e => e.TIPO_CALCULO)
                .IsUnicode(false);

            modelBuilder.Entity<Config_PerfilRetail>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Config_PerfilRetail>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Config_PerfilRetail>()
                .Property(e => e.codigoCanal)
                .IsUnicode(false);

            modelBuilder.Entity<Config_PerfilRetail>()
                .Property(e => e.canal)
                .IsUnicode(false);
        }
    }
}
