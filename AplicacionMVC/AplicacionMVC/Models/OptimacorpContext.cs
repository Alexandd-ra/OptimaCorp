using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AplicacionMVC.Models;

public partial class OptimacorpContext : DbContext
{
    public OptimacorpContext()
    {
    }

    public OptimacorpContext(DbContextOptions<OptimacorpContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
            //      => optionsBuilder.UseSqlServer("server=DESKTOP-CI5O3EO; database=OPTIMACORP; User Id=sa; Password=root;Encrypt=false");
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DEPARTME__3214EC276A5FAEF9");

            entity.ToTable("DEPARTMENT");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAME");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EMPLOYEE__3214EC271B96F93E");

            entity.ToTable("EMPLOYEE");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.IdDeparmentFk).HasColumnName("ID_DEPARMENT_FK");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Salary).HasColumnName("SALARY");

            entity.HasOne(d => d.IdDeparmentFkNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.IdDeparmentFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("DEPARMENT_FK");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
