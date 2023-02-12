using System;
using Microsoft.EntityFrameworkCore;
using StudentService.Models;

namespace StudentService.DbContexts
{
	public class ApplicationDbContext:DbContext
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }


        public DbSet<Student> Students { get; set; }
       

	}
}

