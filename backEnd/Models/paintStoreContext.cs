using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace backEnd.Models
{
    public interface IDBContextCreate
    {
        PaintStoreContext CreateContext();
    }

    public class DBContextCreate : IDBContextCreate
    {
        public PaintStoreContext CreateContext()
        {
            return new PaintStoreContext();
        }
    }
    public partial class PaintStoreContext : DbContext
    {
        public virtual DbSet<Accounts> Accounts { get; set; }
        public virtual DbSet<CategoryTools> CategoryTools { get; set; }
        public virtual DbSet<CategoryTypes> CategoryTypes { get; set; }
        public virtual DbSet<CommentLikes> CommentLikes { get; set; }
        public virtual DbSet<PostComments> PostComments { get; set; }
        public virtual DbSet<PostLikes> PostLikes { get; set; }
        public virtual DbSet<Posts> Posts { get; set; }
        public virtual DbSet<PostTags> PostTags { get; set; }
        public virtual DbSet<Tags> Tags { get; set; }
        public virtual DbSet<UserFollowers> UserFollowers { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public IConfiguration Configuration { get; }
        private string ConnString { get; set; }
        public PaintStoreContext(DbContextOptions<PaintStoreContext> options) : base(options)
        {
        }
        //public PaintStoreContext(string connectionString)
        //{
        //    ConnString = connectionString;
        //}
        public PaintStoreContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer(ConnString);
                optionsBuilder.UseSqlite("Data Source=PaintStore.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accounts>(entity =>
            {
                entity.Property(e => e.CreationDate).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CategoryTools>(entity =>
            {
                entity.HasIndex(e => e.ToolName)
                    .HasName("UQ__Category__006DA271C21386E2")
                    .IsUnique();

                entity.Property(e => e.ToolName)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CategoryTypes>(entity =>
            {
                entity.HasIndex(e => e.TypeName)
                    .HasName("UQ__Category__D4E7DFA8627FF10C")
                    .IsUnique();

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PostComments>(entity =>
            {
                entity.Property(e => e.Content)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate).HasColumnType("date");

                entity.Property(e => e.Edited).HasDefaultValueSql("('0')");

                entity.Property(e => e.LikeCount).HasDefaultValueSql("('0')");
            });

            modelBuilder.Entity<Posts>(entity =>
            {
                entity.Property(e => e.CommentsCount).HasDefaultValueSql("('0')");

                entity.Property(e => e.CreationDate).HasColumnType("date");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Edited).HasDefaultValueSql("('0')");

                entity.Property(e => e.ImgLink)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.LikeCount).HasDefaultValueSql("('0')");

                entity.Property(e => e.MixedActivity).HasDefaultValueSql("('0')");

                entity.Property(e => e.NewestActivity).HasDefaultValueSql("('0')");

                entity.Property(e => e.PopularActivity).HasDefaultValueSql("('0')");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.UserOwnerName)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ViewCount).HasDefaultValueSql("('0')");
            });

            modelBuilder.Entity<Tags>(entity =>
            {
                entity.HasIndex(e => e.TagName)
                    .HasName("UQ__Tags__BDE0FD1D5942FE60")
                    .IsUnique();

                entity.Property(e => e.TagName)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasIndex(e => e.AccountId)
                    .HasName("UQ__Users__349DA5A79015285E")
                    .IsUnique();

                entity.Property(e => e.About)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.AvatarImgLink).IsUnicode(false);

                entity.Property(e => e.BackgroundImgLink).IsUnicode(false);

                entity.Property(e => e.FollowedCount).HasDefaultValueSql("('0')");

                entity.Property(e => e.FollowingCount).HasDefaultValueSql("('0')");

                entity.Property(e => e.Link)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.PostsCount).HasDefaultValueSql("('0')");
            });
        }
    }
}
