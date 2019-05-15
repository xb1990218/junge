using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace netcore生成实体.Models
{
    public partial class blogcoreContext : DbContext
    {
        public blogcoreContext()
        {
        }

        public blogcoreContext(DbContextOptions<blogcoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Blog> Blog { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=.;database=blogcore;uid=sa;pwd=123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity<Blog>(entity =>
            {
                entity.Property(e => e.Body).HasColumnType("text");

                entity.Property(e => e.BodyMd)
                    .HasColumnName("Body_md")
                    .HasMaxLength(1000);

                entity.Property(e => e.CaBh).HasMaxLength(50);

                entity.Property(e => e.CaName).HasMaxLength(50);

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Remark).HasMaxLength(50);

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
