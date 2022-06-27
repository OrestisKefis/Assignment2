using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Entities;
using ApplicationDatabase.Initializers;

namespace ApplicationDatabase
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("Production")
        {
            Database.SetInitializer<ApplicationDbContext>(new MockUpDbInitializer());
            Database.Initialize(false);
        }

        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
    }
}
