using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using REMIwebApi.Models;

namespace REMIwebApi.Datos;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<categoria> categorias { get; set; }

    public virtual DbSet<cliente> clientes { get; set; }

    public virtual DbSet<metodo_de_pago> metodo_de_pagos { get; set; }

    public virtual DbSet<movimientos_stock> movimientos_stocks { get; set; }

    public virtual DbSet<persona> personas { get; set; }

    public virtual DbSet<producto> productos { get; set; }

    public virtual DbSet<proveedore> proveedores { get; set; }

    public virtual DbSet<recibo_pago> recibo_pagos { get; set; }

    public virtual DbSet<recibo_pago_has_metodo> recibo_pago_has_metodos { get; set; }

    public virtual DbSet<recibo_producto> recibo_productos { get; set; }

    public virtual DbSet<role> roles { get; set; }

    public virtual DbSet<stock> stocks { get; set; }

    public virtual DbSet<subcategoria> subcategorias { get; set; }

    public virtual DbSet<tipo_documento> tipo_documentos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-JJ0QICE\\SQLEXPRESS;Initial Catalog=ProyectoRemi;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<categoria>(entity =>
        {
            entity.HasKey(e => e.Id_categoria).HasName("PK__categori__4A033A93BC4D705C");
        });

        modelBuilder.Entity<cliente>(entity =>
        {
            entity.HasKey(e => e.Id_cliente).HasName("PK__cliente__FCE039921AECE439");
        });

        modelBuilder.Entity<metodo_de_pago>(entity =>
        {
            entity.HasKey(e => e.Id_metodo).HasName("PK__metodo_d__AB62E2F2894D648B");
        });

        modelBuilder.Entity<movimientos_stock>(entity =>
        {
            entity.HasKey(e => e.Id_movimiento).HasName("PK__movimien__7B67F72A8EA7C94E");

            entity.Property(e => e.Id_movimiento).ValueGeneratedNever();

            entity.HasOne(d => d.StockNavigation).WithMany(p => p.movimientos_stocks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__movimient__Stock__4F7CD00D");
        });

        modelBuilder.Entity<persona>(entity =>
        {
            entity.HasKey(e => e.Id_Persona).HasName("PK__persona__C95634AFE6B01855");

            entity.Property(e => e.Id_Persona).ValueGeneratedNever();

            entity.HasOne(d => d.tipoDocNavigation).WithMany(p => p.personas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__persona__tipoDoc__3B75D760");

            entity.HasMany(d => d.roles_Id_Rols).WithMany(p => p.persona_Id_Personas)
                .UsingEntity<Dictionary<string, object>>(
                    "persona_has_role",
                    r => r.HasOne<role>().WithMany()
                        .HasForeignKey("roles_Id_Rol")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__persona_h__roles__3F466844"),
                    l => l.HasOne<persona>().WithMany()
                        .HasForeignKey("persona_Id_Persona")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__persona_h__perso__3E52440B"),
                    j =>
                    {
                        j.HasKey("persona_Id_Persona", "roles_Id_Rol").HasName("PK__persona___44FBF1518E916752");
                        j.ToTable("persona_has_roles");
                    });
        });

        modelBuilder.Entity<producto>(entity =>
        {
            entity.HasKey(e => e.cod_Producto).HasName("PK__producto__C6B2843F231FCCB1");

            entity.HasOne(d => d.ProveedorNavigation).WithMany(p => p.productos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__productos__Prove__49C3F6B7");

            entity.HasOne(d => d.SubcategoriaNavigation).WithMany(p => p.productos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__productos__Subca__48CFD27E");
        });

        modelBuilder.Entity<proveedore>(entity =>
        {
            entity.HasKey(e => e.Id_Proveedor).HasName("PK__proveedo__477B858ED1A07C53");
        });

        modelBuilder.Entity<recibo_pago>(entity =>
        {
            entity.HasKey(e => e.Id_recibo).HasName("PK__recibo_p__64A18CFCAA026CAC");

            entity.Property(e => e.Id_recibo).ValueGeneratedNever();

            entity.HasOne(d => d.Id_clienteNavigation).WithMany(p => p.recibo_pagos).HasConstraintName("FK__recibo_pa__Id_cl__5535A963");

            entity.HasOne(d => d.PersonaNavigation).WithMany(p => p.recibo_pagos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__recibo_pa__Perso__5441852A");
        });

        modelBuilder.Entity<recibo_pago_has_metodo>(entity =>
        {
            entity.HasKey(e => new { e.recibo_pago_Id_recibo, e.recibo_pago_Persona, e.metodo_de_pago_Id_metodo }).HasName("PK__recibo_p__10972F1BA096082F");

            entity.HasOne(d => d.metodo_de_pago_Id_metodoNavigation).WithMany(p => p.recibo_pago_has_metodos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__recibo_pa__metod__5FB337D6");

            entity.HasOne(d => d.recibo_pago_Id_reciboNavigation).WithMany(p => p.recibo_pago_has_metodos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__recibo_pa__recib__5DCAEF64");

            entity.HasOne(d => d.recibo_pago_PersonaNavigation).WithMany(p => p.recibo_pago_has_metodos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__recibo_pa__recib__5EBF139D");
        });

        modelBuilder.Entity<recibo_producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__recibo_p__3214EC071095D27E");

            entity.HasOne(d => d.ProductoNavigation).WithMany(p => p.recibo_productos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__recibo_pr__Produ__59063A47");

            entity.HasOne(d => d.reciboPagoNavigation).WithMany(p => p.recibo_productos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__recibo_pr__recib__5812160E");
        });

        modelBuilder.Entity<role>(entity =>
        {
            entity.HasKey(e => e.Id_Rol).HasName("PK__roles__55932E861BDE0F82");

            entity.Property(e => e.Id_Rol).ValueGeneratedNever();
        });

        modelBuilder.Entity<stock>(entity =>
        {
            entity.HasKey(e => e.Id_stock).HasName("PK__stock__89C929197FF27049");

            entity.Property(e => e.Id_stock).ValueGeneratedNever();

            entity.HasOne(d => d.productoStockNavigation).WithMany(p => p.stocks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__stock__productoS__4CA06362");
        });

        modelBuilder.Entity<subcategoria>(entity =>
        {
            entity.HasKey(e => e.Id_subcategoria).HasName("PK__subcateg__5C3FC4A02D40F64A");

            entity.HasOne(d => d.CategoriaNavigation).WithMany(p => p.subcategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__subcatego__Categ__45F365D3");
        });

        modelBuilder.Entity<tipo_documento>(entity =>
        {
            entity.HasKey(e => e.Id_tdoc).HasName("PK__tipo_doc__717EF98083B9F9C0");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
