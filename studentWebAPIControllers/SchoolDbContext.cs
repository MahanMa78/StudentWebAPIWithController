using Microsoft.EntityFrameworkCore;
namespace studentWebAPIControllers;

public class SchoolDbContext : DbContext
{
    //public SchoolDbContext(){ }
    public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
        : base(options)
    {
    }
    public DbSet<Student> Students { get; set; }
    public DbSet<Grade> Grades { get; set; }

    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SchoolDb;Trusted_Connection=True;");
    }


    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{

    //    base.OnModelCreating(modelBuilder);
    //    modelBuilder.Entity<Student>()
    //        .HasOne(s => s.Grade)
    //        .WithOne(g => g.Students)
    //        .HasForeignKey<Grade>(g => g.StudentId)
    //        .OnDelete(DeleteBehavior.Cascade);
    //}
}
