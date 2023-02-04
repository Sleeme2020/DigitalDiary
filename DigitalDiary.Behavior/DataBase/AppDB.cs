using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DigitalDiary.Behavior.DataBase
{
    public class AppDB : DbContext
    {
        //public DbSet<Castomer> Castomers { get; set; }
        //public DbSet<CountGoods> CountGoods { get; set; }
        //public DbSet<Goods> Goods { get; set; }
        //public DbSet<Manager> Managers { get; set; }
        //public DbSet<PriceGoods> PriceGoods { get; set; }
        //public DbSet<Sale> Sales { get; set; }
        //public DbSet<Sale_Goods> Sale_Goods { get; set; }
        //public DbSet<TypeGoods> TypeGoods { get; set; }



        public AppDB() => Database.Migrate();

        //public DbSet<TypeGoods> Goods { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=DidgitalDilary.db");            
        }
    }
}
