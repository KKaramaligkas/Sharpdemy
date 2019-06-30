using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Ecourse.Models
{
    public partial class SharpdemyContext : DbContext
    {
        public SharpdemyContext()
        {
        }

        public SharpdemyContext(DbContextOptions<SharpdemyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Answers> Answers { get; set; }
        public virtual DbSet<Chapter> Chapter { get; set; }
        public virtual DbSet<Questions> Questions { get; set; }
        public virtual DbSet<TestResults> TestResults { get; set; }
        public virtual DbSet<Units> Units { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress;Database=Sharpdemy;user=Konstantine;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answers>(entity =>
            {
                entity.HasKey(e => e.AnswerId);

                entity.HasIndex(e => e.QuestionId)
                    .HasName("fkIdx_45");

                entity.HasIndex(e => e.UnitId)
                    .HasName("fkIdx_60");

                entity.HasIndex(e => e.UserId)
                    .HasName("fkIdx_50");

                entity.Property(e => e.AnswerId)
                    .HasColumnName("AnswerID")
                    .ValueGeneratedNever();

                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

                entity.Property(e => e.UnitId).HasColumnName("UnitID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_45");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_60");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_50");
            });

            modelBuilder.Entity<Chapter>(entity =>
            {
                entity.HasIndex(e => e.UnitId)
                    .HasName("fkIdx_21");

                entity.Property(e => e.ChapterId)
                    .HasColumnName("ChapterID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Content)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UnitId).HasColumnName("UnitID");

                entity.Property(e => e.Video)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.Chapter)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_21");
            });

            modelBuilder.Entity<Questions>(entity =>
            {
                entity.HasKey(e => e.QuestionId);

                entity.HasIndex(e => e.ChapterId)
                    .HasName("fkIdx_36");

                entity.Property(e => e.QuestionId)
                    .HasColumnName("QuestionID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ChapterId).HasColumnName("ChapterID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Option1)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Option2)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Option3)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Option4)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.Chapter)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.ChapterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_36");
            });

            modelBuilder.Entity<TestResults>(entity =>
            {
                entity.HasKey(e => e.TestId);

                entity.HasIndex(e => e.ChapterId)
                    .HasName("fkIdx_82");

                entity.HasIndex(e => e.UnitId)
                    .HasName("fkIdx_85");

                entity.Property(e => e.TestId).ValueGeneratedNever();

                entity.Property(e => e.ChapterId).HasColumnName("ChapterID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.UnitId).HasColumnName("UnitID");

                entity.HasOne(d => d.Chapter)
                    .WithMany(p => p.TestResults)
                    .HasForeignKey(d => d.ChapterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_82");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.TestResults)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_85");
            });

            modelBuilder.Entity<Units>(entity =>
            {
                entity.HasKey(e => e.UnitId);

                entity.Property(e => e.UnitId)
                    .HasColumnName("UnitID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
