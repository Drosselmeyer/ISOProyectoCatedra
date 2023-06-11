using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Confecciones.Models;

#nullable disable

namespace Confecciones.Data
{
    public partial class confeccionesContext : DbContext
    {
        public confeccionesContext()
        {
        }

        public confeccionesContext(DbContextOptions<confeccionesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Confeccion> Confeccions { get; set; }
        public virtual DbSet<ConfeccionTela> ConfeccionTelas { get; set; }
        public virtual DbSet<Estilo> Estilos { get; set; }
        public virtual DbSet<MetodoPago> MetodoPagos { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }
        public virtual DbSet<Tela> Telas { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=confecciones;Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Confeccion>(entity =>
            {
                entity.HasKey(e => e.CodConfeccion)
                    .HasName("PK__Confecci__3FE72601FFCE7B28");

                entity.Property(e => e.Medidas).IsUnicode(false);

                entity.HasOne(d => d.CodEstiloNavigation)
                    .WithMany(p => p.Confeccions)
                    .HasForeignKey(d => d.CodEstilo)
                    .HasConstraintName("FK__Confeccio__codEs__2A4B4B5E");
            });

            modelBuilder.Entity<ConfeccionTela>(entity =>
            {
                entity.HasKey(e => new { e.CodTela, e.CodConfeccion })
                    .HasName("PK__Confecci__4633040AE9594B1E");

                entity.HasOne(d => d.CodConfeccionNavigation)
                    .WithMany(p => p.ConfeccionTelas)
                    .HasForeignKey(d => d.CodConfeccion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Confeccio__codCo__2E1BDC42");

                entity.HasOne(d => d.CodTelaNavigation)
                    .WithMany(p => p.ConfeccionTelas)
                    .HasForeignKey(d => d.CodTela)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Confeccio__codTe__2D27B809");
            });

            modelBuilder.Entity<Estilo>(entity =>
            {
                entity.HasKey(e => e.CodEstilo)
                    .HasName("PK__Estilo__BBC88C7C779BF874");

                entity.Property(e => e.DetalleEstilo).IsUnicode(false);
            });

            modelBuilder.Entity<MetodoPago>(entity =>
            {
                entity.HasKey(e => e.CodMetodoPago)
                    .HasName("PK__MetodoPa__89B9383C4BCCF27B");

                entity.Property(e => e.MetodoPago1).IsUnicode(false);
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.CodPedido)
                    .HasName("PK__Pedido__A0902DBDE1FB915E");

                entity.Property(e => e.Comentarios).IsUnicode(false);

                entity.HasOne(d => d.CodConfeccionNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.CodConfeccion)
                    .HasConstraintName("FK__Pedido__codConfe__33D4B598");

                entity.HasOne(d => d.CodMetodoPagoNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.CodMetodoPago)
                    .HasConstraintName("FK__Pedido__codMetod__34C8D9D1");

                entity.HasOne(d => d.CodUsuarioNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.CodUsuario)
                    .HasConstraintName("FK__Pedido__codUsuar__32E0915F");
            });

            modelBuilder.Entity<Tela>(entity =>
            {
                entity.HasKey(e => e.CodTela)
                    .HasName("PK__Tela__45CD766A31B72C51");

                entity.Property(e => e.DetalleTela).IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.CodUsuario)
                    .HasName("PK__Usuario__52198B99229AC67F");

                entity.Property(e => e.Apellido).IsUnicode(false);

                entity.Property(e => e.Nombre).IsUnicode(false);

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.Usuario1).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
