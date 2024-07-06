using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Producto.Models;

public partial class ProductoContext : DbContext
{
    public ProductoContext()
    {
    }

    public ProductoContext(DbContextOptions<ProductoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Producto> Productos { get; set; }

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__Producto__07F4A132939C3F35");

            entity.ToTable("Producto");

            entity.Property(e => e.IdProducto).HasColumnName("idProducto");
            entity.Property(e => e.Almacenamiento)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("almacenamiento");
            entity.Property(e => e.Color)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("color");
            entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");
            entity.Property(e => e.Imagen)
                .HasColumnType("text")
                .HasColumnName("imagen");
            entity.Property(e => e.Modelo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("modelo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Procesador)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("procesador");
            entity.Property(e => e.Ram)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ram");
            entity.Property(e => e.Precio)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("precio");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
