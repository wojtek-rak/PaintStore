using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace backEnd.Models
{
    public partial class PaintStoreContext : DbContext
    {
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<Images> Images { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public IConfiguration Configuration { get; }
        private string ConnString { get; set; }
        public PaintStoreContext(DbContextOptions<PaintStoreContext> options) : base(options)
        {
        }
        public PaintStoreContext(string connectionString)
        {
            ConnString = connectionString;
        }
        public PaintStoreContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(ConnString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comments>(entity =>
            {
                entity.ToTable("comments");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnName("content")
                    .HasColumnType("text");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.ImgLink)
                    .IsRequired()
                    .HasColumnName("img_link")
                    .HasColumnType("text");

                entity.Property(e => e.UserPath)
                    .IsRequired()
                    .HasColumnName("user_path")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Images>(entity =>
            {
                entity.ToTable("images");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("text");

                entity.Property(e => e.ImgLink)
                    .IsRequired()
                    .HasColumnName("img_link")
                    .HasColumnType("text");

                entity.Property(e => e.ImgSrc)
                    .IsRequired()
                    .HasColumnName("img_src")
                    .HasColumnType("text");

                entity.Property(e => e.OwnerPath)
                    .IsRequired()
                    .HasColumnName("owner_path")
                    .HasColumnType("text");

                entity.Property(e => e.Category_tool)
                    .IsRequired()
                    .HasColumnName("category_tool")
                    .HasColumnType("text");

                entity.Property(e => e.Category_type)
                    .IsRequired()
                    .HasColumnName("category_type")
                    .HasColumnType("text");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.About)
                    .IsRequired()
                    .HasColumnName("about")
                    .HasColumnType("text");

                entity.Property(e => e.AvatarSrc)
                    .IsRequired()
                    .HasColumnName("avatar_src")
                    .HasColumnType("text");

                entity.Property(e => e.BackgroundSrc)
                    .IsRequired()
                    .HasColumnName("background_src")
                    .HasColumnType("text");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("text");

                entity.Property(e => e.Link)
                    .IsRequired()
                    .HasColumnName("link")
                    .HasColumnType("text");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("text");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasColumnType("text");
            });
        }
    }
}
