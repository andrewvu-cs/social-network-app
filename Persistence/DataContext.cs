using System;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    /*
    A DbContext instance represents a session with the database and 
    can be used to query and save instances of your entities. 
    DbContext is a combination of the Unit Of Work and Repository patterns.
    */
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {                
        }
        
        public DbSet<Value> Values { get; set; }
        public DbSet<Activity> Activities{ get; set; }

        // protected - accessible to the class that its defined and derived in
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Value>()
                .HasData(
                    new Value {Id = 1, Name = "Value 101"},
                    new Value {Id = 2, Name = "Value 102"},
                    new Value {Id = 3, Name = "Value 103"}
                );
        }
    }
}
