using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace backEnd.Models
{
    public partial class PaintStoreContext : DbContext
    {
        public virtual DbSet<Accounts> Accounts { get; set; }
        public virtual DbSet<CategoryTools> CategoryTools { get; set; }
        public virtual DbSet<CategoryTypes> CategoryTypes { get; set; }
        public virtual DbSet<CommentLikes> CommentLikes { get; set; }
        public virtual DbSet<PostComments> PostComments { get; set; }
        public virtual DbSet<PostLikes> PostLikes { get; set; }
        public virtual DbSet<Posts> Posts { get; set; }
        public virtual DbSet<UserFollowers> UserFollowers { get; set; }
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
                    .HasName("UQ__Category__006DA271FD08A9C0")
                    .IsUnique();

                entity.Property(e => e.ToolName)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CategoryTypes>(entity =>
            {
                entity.HasIndex(e => e.TypeName)
                    .HasName("UQ__Category__D4E7DFA8DA52CB97")
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
            });

            modelBuilder.Entity<Posts>(entity =>
            {
                entity.Property(e => e.CommentsCount).HasDefaultValueSql("('0')");

                entity.Property(e => e.CreationDate).HasColumnType("date");

                entity.Property(e => e.Description).IsUnicode(false);

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

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasIndex(e => e.AccountId)
                    .HasName("UQ__Users__349DA5A78780EEA4")
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
            });
        }
    }
}
