using Microsoft.EntityFrameworkCore;

namespace HealthCatalystTest.Models
{
    public class PersonContext : DbContext
    {

        public PersonContext(DbContextOptions<PersonContext> options)
            : base(options)
        { }

        public DbSet<Person> People { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<PeopleInterestRelation> PeopleInterestRelation { get; set; }
    }
}
