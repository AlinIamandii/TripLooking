using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TripLooking.Database.Models
{
    public partial class TripLookingContext : DbContext
    {
        public TripLookingContext()
        {
        }

        public TripLookingContext(DbContextOptions<TripLookingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Authorization> Authorization { get; set; }
        public virtual DbSet<Faculty> Faculty { get; set; }
        public virtual DbSet<Image> Image { get; set; }
        public virtual DbSet<Notification> Notification { get; set; }
        public virtual DbSet<Place> Place { get; set; }
        public virtual DbSet<PlaceComment> PlaceComment { get; set; }
        public virtual DbSet<RoleAuthorization> RoleAuthorization { get; set; }
        public virtual DbSet<Specialization> Specialization { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Trip> Trip { get; set; }
        public virtual DbSet<TripComment> TripComment { get; set; }
        public virtual DbSet<TripPlace> TripPlace { get; set; }
        public virtual DbSet<University> University { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserPlace> UserPlace { get; set; }
        public virtual DbSet<UserTrip> UserTrip { get; set; }
        public virtual DbSet<UserType> UserType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=TripLooking;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Authorization>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(70);
            });

            modelBuilder.Entity<Faculty>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdUniversityNavigation)
                    .WithMany(p => p.Faculty)
                    .HasForeignKey(d => d.IdUniversity)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Faculty_University");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdTripNavigation)
                    .WithMany(p => p.Notification)
                    .HasForeignKey(d => d.IdTrip)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Notification_Trip");
            });

            modelBuilder.Entity<Place>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdImageNavigation)
                    .WithMany(p => p.Place)
                    .HasForeignKey(d => d.IdImage)
                    .HasConstraintName("FK_Place_Image");
            });

            modelBuilder.Entity<PlaceComment>(entity =>
            {
                entity.Property(e => e.Comment).HasMaxLength(250);

                entity.Property(e => e.Review).HasMaxLength(250);

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.PlaceComment)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlaceComment_User");
            });

            modelBuilder.Entity<RoleAuthorization>(entity =>
            {
                entity.HasOne(d => d.IdAuthorizationNavigation)
                    .WithMany(p => p.RoleAuthorization)
                    .HasForeignKey(d => d.IdAuthorization)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoleAuthorization_Authorization");
            });

            modelBuilder.Entity<Specialization>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(70);

                entity.HasOne(d => d.IdFacultyNavigation)
                    .WithMany(p => p.Specialization)
                    .HasForeignKey(d => d.IdFaculty)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Specialization_Faculty");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.Age).HasColumnType("numeric(2, 0)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(70);

                entity.Property(e => e.PhoneMobile).HasColumnType("numeric(10, 0)");

                entity.Property(e => e.Year).HasColumnType("numeric(4, 0)");

                entity.HasOne(d => d.IdSpecializationNavigation)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.IdSpecialization)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_Specialization");
            });

            modelBuilder.Entity<Trip>(entity =>
            {
                entity.Property(e => e.Capacity).HasColumnType("numeric(3, 0)");

                entity.Property(e => e.DateEnd).HasColumnType("date");

                entity.Property(e => e.DateStart).HasColumnType("date");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Image).HasColumnType("image");

                entity.Property(e => e.Link).HasMaxLength(150);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(70);

                entity.Property(e => e.Notes).HasMaxLength(250);

                entity.Property(e => e.Price).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<TripComment>(entity =>
            {
                entity.Property(e => e.Comment)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Review)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.IdTripNavigation)
                    .WithMany(p => p.TripComment)
                    .HasForeignKey(d => d.IdTrip)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TripComment_Trip");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.TripComment)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TripComment_User");
            });

            modelBuilder.Entity<TripPlace>(entity =>
            {
                entity.HasOne(d => d.IdPlaceNavigation)
                    .WithMany(p => p.TripPlace)
                    .HasForeignKey(d => d.IdPlace)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TripPlace_Place");

                entity.HasOne(d => d.IdTripNavigation)
                    .WithMany(p => p.TripPlace)
                    .HasForeignKey(d => d.IdTrip)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TripPlace_Trip1");
            });

            modelBuilder.Entity<University>(entity =>
            {
                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(70);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdStudentNavigation)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.IdStudent)
                    .HasConstraintName("FK_User_Student");

                entity.HasOne(d => d.IdUserTypeNavigation)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.IdUserType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_UserType");
            });

            modelBuilder.Entity<UserPlace>(entity =>
            {
                entity.HasOne(d => d.IdTripPlaceNavigation)
                    .WithMany(p => p.UserPlace)
                    .HasForeignKey(d => d.IdTripPlace)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserPlace_TripPlace");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.UserPlace)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserPlace_User");
            });

            modelBuilder.Entity<UserTrip>(entity =>
            {
                entity.HasOne(d => d.IdTripNavigation)
                    .WithMany(p => p.UserTrip)
                    .HasForeignKey(d => d.IdTrip)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserTrip_Trip1");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.UserTrip)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserTrip_User");
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
