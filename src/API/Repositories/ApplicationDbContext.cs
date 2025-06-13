using API.Models;
using Microsoft.EntityFrameworkCore;
using Task = API.Models.Task;

namespace API.Repositories;

public class ApplicationDbContext : DbContext
{
    public DbSet<Language> Language { get; set; }
    public DbSet<Record> Record { get; set; }
    public DbSet<Student> Student { get; set; }
    public DbSet<Task> Task { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder
    // }
}