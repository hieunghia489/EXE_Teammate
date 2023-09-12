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
                entity.HasKey(e => e.CourseCode);

                entity.ToTable("Course");

                entity.HasIndex(e => e.CourseCode, "UQ__Course__FC00E00058ED99EA")
                    .IsUnique();

                entity.Property(e => e.CourseCode).HasMaxLength(255);

                entity.Property(e => e.CourseEndDate).HasColumnType("date");

                entity.Property(e => e.CourseStartDate).HasColumnType("date");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.SemesterCode).HasMaxLength(255);

                entity.Property(e => e.SubjectCode).HasMaxLength(255);

                entity.HasOne(d => d.SemesterCodeNavigation)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.SemesterCode)
                    .HasConstraintName("FK__Course__Semester__4CA06362");

                entity.HasOne(d => d.SubjectCodeNavigation)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.SubjectCode)
                    .HasConstraintName("FK__Course__SubjectC__4BAC3F29");
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
                entity.HasKey(e => e.GradeCode);

                entity.ToTable("Grade");

                entity.HasIndex(e => e.GradeCode, "UQ__Grade__B1E0A186869DFE80")
                    .IsUnique();

                entity.Property(e => e.GradeCode).HasMaxLength(255);

                entity.Property(e => e.GradeDescription).HasMaxLength(255);

                entity.Property(e => e.GradeEndDate).HasColumnType("date");

                entity.Property(e => e.GradeStartDate).HasColumnType("date");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            });

            modelBuilder.Entity<Major>(entity =>
            {
                entity.HasKey(e => e.MajorCode);

                entity.ToTable("Major");

                entity.HasIndex(e => e.MajorName, "UQ__Major__5FF4A37BCB1E7480")
                    .IsUnique();

                entity.HasIndex(e => e.MajorCode, "UQ__Major__64E58F94CE2A585A")
                    .IsUnique();

                entity.Property(e => e.MajorCode).HasMaxLength(255);

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.MajorDescription).HasMaxLength(255);

                entity.Property(e => e.MajorName).HasMaxLength(255);
            });

            modelBuilder.Entity<Semester>(entity =>
            {
                entity.HasKey(e => e.SemesterCode);

                entity.ToTable("Semester");

                entity.HasIndex(e => e.SemesterCode, "UQ__Semester__513151C96B67B063")
                    .IsUnique();

                entity.Property(e => e.SemesterCode).HasMaxLength(255);

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.SemesterDescription).HasMaxLength(255);

                entity.Property(e => e.SemesterEndDate).HasColumnType("date");

                entity.Property(e => e.SemesterStartDate).HasColumnType("date");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.HasIndex(e => e.StudentPhone, "UQ__Student__2EB4F8B3A4DA6906")
                    .IsUnique();

                entity.HasIndex(e => e.StudentId, "UQ__Student__32C52B98DF174DC2")
                    .IsUnique();

                entity.HasIndex(e => e.StudentEmail, "UQ__Student__3569CFDBDEDE0479")
                    .IsUnique();

                entity.Property(e => e.StudentId).HasMaxLength(255);

                entity.Property(e => e.GradeCode).HasMaxLength(255);

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.MajorCode).HasMaxLength(255);

                entity.Property(e => e.StudentEmail).HasMaxLength(255);

                entity.Property(e => e.StudentFullName).HasMaxLength(255);

                entity.HasOne(d => d.GradeCodeNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.GradeCode)
                    .HasConstraintName("FK__Student__GradeCo__4222D4EF");

                entity.HasOne(d => d.MajorCodeNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.MajorCode)
                    .HasConstraintName("FK__Student__MajorCo__412EB0B6");
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
                    .HasForeignKey(d => d.CourseCode)
                    .HasConstraintName("FK__StudentIn__Cours__5070F446");

                entity.HasOne(d => d.Sic)
                    .WithOne(p => p.StudentInCourse)
                    .HasForeignKey<StudentInCourse>(d => d.Sicid)
                    .HasConstraintName("FK__StudentIn__SICId__4F7CD00D");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasKey(e => e.SubjectCode);

                entity.ToTable("Subject");

                entity.HasIndex(e => e.SubjectCode, "UQ__Subject__9F7CE1A926AD4DBD")
                    .IsUnique();

                entity.Property(e => e.SubjectCode).HasMaxLength(255);

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

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

                entity.Property(e => e.TeamName).HasMaxLength(255);

                entity.HasOne(d => d.TeamNameNavigation)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.TeamName)
                    .HasConstraintName("FK__Task__TeamName__5CD6CB2B");
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
                entity.HasKey(e => e.TeamName);

                entity.ToTable("Team");

                entity.HasIndex(e => e.TeamName, "UQ__Team__4E21CAAC98F99EEE")
                    .IsUnique();

                entity.Property(e => e.TeamName).HasMaxLength(255);

                entity.Property(e => e.CreateDate).HasColumnType("date");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            });

            modelBuilder.Entity<Teammate>(entity =>
            {
                entity.ToTable("Teammate");

                entity.Property(e => e.TeammateId).HasMaxLength(255);

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.TeamName).HasMaxLength(255);

                entity.Property(e => e.TeammateJoinDate).HasColumnType("date");

                entity.HasOne(d => d.TeamNameNavigation)
                    .WithMany(p => p.Teammates)
                    .HasForeignKey(d => d.TeamName)
                    .HasConstraintName("FK__Teammate__TeamNa__571DF1D5");

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
