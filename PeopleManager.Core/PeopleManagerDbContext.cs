using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PeopleManager.Core.Extensions;
using PeopleManager.Model;

namespace PeopleManager.Core
{
	public class PeopleManagerDbContext: DbContext
	{
        public PeopleManagerDbContext(DbContextOptions<PeopleManagerDbContext> options): base(options)
        {
            
        }

        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.RemovePluralizingNamingConvention();

            base.OnModelCreating(modelBuilder);
        }

        public void Seed()
		{
			People.AddRange(
                new List<Person>
                {
                	new() { FirstName = "Bavo", LastName = "Ketels", Email = "bavo.ketels@vives.be" },
                	new() { FirstName = "Dirk", LastName = "Hostens", Email = "dirk.hostens@vives.be" },
                	new() { FirstName = "Arne", LastName = "Vandenbussche", Email = "arne.vandenbussche@vives.be" },
                	new() { FirstName = "Emma", LastName = "Braeckman", Email = "emma.braeckman@vives.be" },
                	new() { FirstName = "Johan", LastName = "Cottyn", Email = "johan.cottyn@vives.be" }
                });

            base.SaveChanges();
        }
	}
}
