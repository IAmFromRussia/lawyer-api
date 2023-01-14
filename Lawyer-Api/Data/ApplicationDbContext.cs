using Lawyer_Api.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lawyer_Api.Data;

public class ApplicationDbContext : DbContext
{
	public DbSet<Document> Documents { get; set; }

	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
	{
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.LogTo(Console.WriteLine);
		optionsBuilder.EnableSensitiveDataLogging();
		base.OnConfiguring(optionsBuilder);
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
	}
}