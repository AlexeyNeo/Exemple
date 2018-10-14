using System.Data.Entity;
using Exemple.DAL.EF.Seeds;
using Exemple.DAL.Entities;

namespace Exemple.DAL.EF
{
    public class MobileContext : DbContext
    {
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Order> Orders { get; set; }

        static MobileContext()
        {
            Database.SetInitializer<MobileContext>(new StoreDbInitializer());
        }

        public MobileContext(string connectionString)
            : base(connectionString)
        {
        }
    }
}ghjcn j