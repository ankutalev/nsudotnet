using Microsoft.EntityFrameworkCore;
using rabotyagiszavoda.Model;

namespace rabotyagiszavoda
{
    public class WorkersContext : DbContext
    {
        public WorkersContext()
        {
        }

        public WorkersContext(DbContextOptions<WorkersContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Projects> Projects { get; set; }
        public virtual DbSet<Workers> Workers { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Projects>(entity =>
            {
                entity.HasKey(e => e.ProjId)
                    .HasName("projects_pkey");

                entity.ToTable("projects");

                entity.Property(e => e.ProjId).HasColumnName("proj_id");

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(100);

                entity.Property(e => e.WorkerId).HasColumnName("worker_id");

                entity.HasOne(d => d.Worker)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.WorkerId)
                    .HasConstraintName("workers_for_proj");
            });

            modelBuilder.Entity<Workers>(entity =>
            {
                entity.HasKey(e => e.WorkerId)
                    .HasName("workers_pkey");

                entity.ToTable("workers");

                entity.Property(e => e.WorkerId).HasColumnName("worker_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100);
            });
        }
    }
}
