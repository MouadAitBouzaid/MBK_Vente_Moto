using Handmade.Service.EmbroideryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Handmade.Service.EmbroideryAPI.DbContexts
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions options) : base(options)
		{


		}
		//cree products dans bdd
		public DbSet<Embroidery> Embroideries { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			// cree des produit statique avec modelbuilder 
			modelBuilder.Entity<Embroidery>().HasData(new Embroidery

			{
				EmbroideryId = 1,
				EmbroideryName = "ChaiseBoisMassif",
				Price = 15,
				CategoryName = "categorie1",
				ImageURL = "1.jpg"

			});
			modelBuilder.Entity<Embroidery>().HasData(new Embroidery

			{
				EmbroideryId = 2,
				EmbroideryName = "ChaiseBoisMassif",
				Price = 15,
				CategoryName = "categorie1",
				ImageURL = "1.jpg"

			});
		}

	}
}
