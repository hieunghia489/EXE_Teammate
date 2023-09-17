using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Domain.Models
{
    public partial class TeammateEXEContext : DbContext
    {
        public TeammateEXEContext()
        {
        }

        public TeammateEXEContext(DbContextOptions<TeammateEXEContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Feedback> Feedbacks { get; set; } = null!;
        public virtual DbSet<Grade> Grades { get; set; } = null!;
        public virtual DbSet<Major> Majors { get; set; } = null!;
        public virtual DbSet<Semester> Semesters { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<StudentInCourse> StudentInCourses { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;
        public virtual DbSet<Task> Tasks { get; set; } = null!;
        public virtual DbSet<TaskParticipant> TaskParticipants { get; set; } = null!;
        public virtual DbSet<Team> Teams { get; set; } = null!;
        public virtual DbSet<Teammate> Teammates { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=SAVOY\\MSSQLSERVER01;uid=sa;password=123456;Database=TeammateEXE;Trusted_Connection=true;Encrypt=false");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.HasIndex(e => e.CourseCode, "UQ__Course__FC00E0003CD227A0")
                    .IsUnique();

                entity.Property(e => e.CourseCode).HasMaxLength(255);

                entity.Property(e => e.CourseEndDate).HasColumnType("date");

                entity.Property(e => e.CourseStartDate).HasColumnType("date");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.HasOne(d => d.Semester)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.SemesterId)
                    .HasConstraintName("FK__Course__Semester__4CA06362");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK__Course__SubjectI__4BAC3F29");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("Feedback");

                entity.Property(e => e.Comment).HasMaxLength(255);

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.TeammateFeedbackId).HasMaxLength(255);

                entity.Property(e => e.TeammateId).HasMaxLength(255);

                entity.HasOne(d => d.Teammate)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.TeammateId)
                    .HasConstraintName("FK__Feedback__Teamma__59FA5E80");
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.ToTable("Grade");

                entity.HasIndex(e => e.GradeCode, "UQ__Grade__B1E0A18650CFF281")
                    .IsUnique();

                entity.Property(e => e.GradeCode).HasMaxLength(255);

                entity.Property(e => e.GradeDescription).HasMaxLength(255);

                entity.Property(e => e.GradeEndDate).HasColumnType("date");

                entity.Property(e => e.GradeStartDate).HasColumnType("date");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            });

            modelBuilder.Entity<Major>(entity =>
            {
                entity.ToTable("Major");

                entity.HasIndex(e => e.MajorName, "UQ__Major__5FF4A37B2AAE9E09")
                    .IsUnique();

                entity.HasIndex(e => e.MajorCode, "UQ__Major__64E58F94780BF6A2")
                    .IsUnique();

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.MajorCode).HasMaxLength(255);

                entity.Property(e => e.MajorDescription).HasMaxLength(255);

                entity.Property(e => e.MajorName).HasMaxLength(255);
            });

            modelBuilder.Entity<Semester>(entity =>
            {
                entity.ToTable("Semester");

                entity.HasIndex(e => e.SemesterCode, "UQ__Semester__513151C946139D5A")
                    .IsUnique();

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.SemesterCode).HasMaxLength(255);

                entity.Property(e => e.SemesterDescription).HasMaxLength(255);

                entity.Property(e => e.SemesterEndDate).HasColumnType("date");

                entity.Property(e => e.SemesterStartDate).HasColumnType("date");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.HasIndex(e => e.StudentPhone, "UQ__Student__2EB4F8B32275A295")
                    .IsUnique();

                entity.HasIndex(e => e.StudentId, "UQ__Student__32C52B9895AE7B4D")
                    .IsUnique();

                entity.HasIndex(e => e.StudentEmail, "UQ__Student__3569CFDB6C346AEB")
                    .IsUnique();

                entity.Property(e => e.StudentId).HasMaxLength(255);

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.StudentEmail).HasMaxLength(255);

                entity.Property(e => e.StudentFullName).HasMaxLength(255);

                entity.HasOne(d => d.Grade)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.GradeId)
                    .HasConstraintName("FK__Student__GradeId__4222D4EF");

                entity.HasOne(d => d.Major)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.MajorId)
                    .HasConstraintName("FK__Student__MajorId__412EB0B6");
            });

            modelBuilder.Entity<StudentInCourse>(entity =>
            {
                entity.HasKey(e => e.Sicid);

                entity.ToTable("StudentInCourse");

                entity.Property(e => e.Sicid)
                    .HasMaxLength(255)
                    .HasColumnName("SICId");

                entity.Property(e => e.CourseCode).HasMaxLength(255);

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.IsInTeam).HasColumnName("isInTeam");

                entity.HasOne(d => d.CourseCodeNavigation)
                    .WithMany(p => p.StudentInCourses)
                    .HasPrincipalKey(p => p.CourseCode)
                    .HasForeignKey(d => d.CourseCode)
                    .HasConstraintName("FK__StudentIn__Cours__5070F446");

                entity.HasOne(d => d.Sic)
                    .WithOne(p => p.StudentInCourse)
                    .HasForeignKey<StudentInCourse>(d => d.Sicid)
                    .HasConstraintName("FK__StudentIn__SICId__4F7CD00D");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("Subject");

                entity.HasIndex(e => e.SubjectCode, "UQ__Subject__9F7CE1A9624C934F")
                    .IsUnique();

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.SubjectCode).HasMaxLength(255);

                entity.Property(e => e.SubjectDescription).HasMaxLength(255);
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.ToTable("Task");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.ProductLink).HasMaxLength(255);

                entity.Property(e => e.TaskDescription).HasMaxLength(255);

                entity.Property(e => e.TaskEndDate).HasColumnType("datetime");

                entity.Property(e => e.TaskName).HasMaxLength(255);

                entity.Property(e => e.TaskStartDate).HasColumnType("datetime");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK__Task__TeamId__5CD6CB2B");
            });

            modelBuilder.Entity<TaskParticipant>(entity =>
            {
                entity.HasKey(e => e.Tpid)
                    .HasName("PK_TaskPariticipant");

                entity.ToTable("TaskParticipant");

                entity.Property(e => e.Tpid).HasColumnName("TPId");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.TeammateId).HasMaxLength(255);

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.TaskParticipants)
                    .HasForeignKey(d => d.TaskId)
                    .HasConstraintName("FK__TaskParti__TaskI__60A75C0F");

                entity.HasOne(d => d.Teammate)
                    .WithMany(p => p.TaskParticipants)
                    .HasForeignKey(d => d.TeammateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TaskParti__Teamm__5FB337D6");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.ToTable("Team");

                entity.HasIndex(e => e.TeamName, "UQ__Team__4E21CAACBD4B7C54")
                    .IsUnique();

                entity.Property(e => e.CreateDate).HasColumnType("date");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.TeamName).HasMaxLength(255);
            });

            modelBuilder.Entity<Teammate>(entity =>
            {
                entity.ToTable("Teammate");

                entity.Property(e => e.TeammateId).HasMaxLength(255);

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.TeammateJoinDate).HasColumnType("date");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Teammates)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK__Teammate__TeamId__571DF1D5");

                entity.HasOne(d => d.TeammateNavigation)
                    .WithOne(p => p.Teammate)
                    .HasForeignKey<Teammate>(d => d.TeammateId)
                    .HasConstraintName("FK__Teammate__Teamma__5629CD9C");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
