using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Labb3Högstadieskolan.Models;

public partial class HögstadieskolaContext : DbContext
{
    public HögstadieskolaContext()
    {
    }

    public HögstadieskolaContext(DbContextOptions<HögstadieskolaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<Gradetype> Gradetypes { get; set; }

    public virtual DbSet<Personal> Personals { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;Database=HÖGSTADIESKOLA;Integrated Security=True;Trust Server Certificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.Classid).HasName("PK__CLASSES__96D40B6CEF603568");

            entity.ToTable("CLASSES");

            entity.Property(e => e.Classid).HasColumnName("CLASSID")
            .ValueGeneratedOnAdd();

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Teacherid).HasColumnName("TEACHERID");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Classes)
                .HasForeignKey(d => d.Teacherid)
                .HasConstraintName("FK__CLASSES__TEACHER__4316F928");
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.Gradeid)
            .HasName("PK__GRADES__D761B57E4D9CC1CF");
            
            entity.ToTable("GRADES");

            entity.Property(e => e.Gradeid).HasColumnName("GRADEID");
            entity.Property(e => e.Date).HasColumnName("DATE");
            entity.Property(e => e.Graderid).HasColumnName("GRADERID");
            entity.Property(e => e.Gradetypeid).HasColumnName("GRADETYPEID");
            entity.Property(e => e.Studentid).HasColumnName("STUDENTID");
            entity.Property(e => e.Subjectid).HasColumnName("SUBJECTID");
            entity.Property(e => e.Teacherid).HasColumnName("TEACHERID");

            entity.HasOne(d => d.Grader).WithMany(p => p.GradeGraders)
                .HasForeignKey(d => d.Graderid)
                .HasConstraintName("FK__GRADES__GRADERID__4CA06362");

            entity.HasOne(d => d.Gradetype).WithMany(p => p.Grades)
                .HasForeignKey(d => d.Gradetypeid)
                .HasConstraintName("FK__GRADES__GRADETYP__4D94879B");

            entity.HasOne(d => d.Student).WithMany(p => p.Grades)
                .HasForeignKey(d => d.Studentid)
                .HasConstraintName("FK__GRADES__STUDENTI__45F365D3");

            entity.HasOne(d => d.Subject).WithMany(p => p.Grades)
                .HasForeignKey(d => d.Subjectid)
                .HasConstraintName("FK__GRADES__SUBJECTI__44FF419A");

            entity.HasOne(d => d.Teacher).WithMany(p => p.GradeTeachers)
                .HasForeignKey(d => d.Teacherid)
                .HasConstraintName("FK__GRADES__TEACHERI__440B1D61");
        });

        modelBuilder.Entity<Gradetype>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GRADETYP__3214EC27CB4A089D");

            entity.ToTable("GRADETYPE");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Grade)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("GRADE");
        });

        modelBuilder.Entity<Personal>(entity =>
        {
            entity.HasKey(e => e.Personalid).HasName("PK__PERSONAL__D9BB07840B060E2E");

            entity.ToTable("PERSONAL");

            entity.Property(e => e.Personalid).HasColumnName("PERSONALID");
            entity.Property(e => e.Epost)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EPOST");
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LASTNAME");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Number)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NUMBER");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("POSITIONS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Position1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("POSITION");

            entity.HasOne(d => d.IdNavigation).WithMany()
                .HasForeignKey(d => d.Id)
                .HasConstraintName("FK__POSITIONS__ID__46E78A0C");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Studentid).HasName("PK__STUDENTS__495196F0063CF063");

            entity.ToTable("STUDENTS");

            entity.Property(e => e.Studentid).HasColumnName("STUDENTID");
            entity.Property(e => e.Classid).HasColumnName("CLASSID");
            entity.Property(e => e.Epost)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EPOST");
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LASTNAME");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Personumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PERSONUMBER");

            entity.HasOne(d => d.Class).WithMany(p => p.Students)
                .HasForeignKey(d => d.Classid)
                .HasConstraintName("FK__STUDENTS__CLASSI__47DBAE45");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.Subjectid).HasName("PK__SUBJECTS__C97AA6F5E74AF1E0");

            entity.ToTable("SUBJECTS");

            entity.Property(e => e.Subjectid).HasColumnName("SUBJECTID");
            entity.Property(e => e.Subjects)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SUBJECTS");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
