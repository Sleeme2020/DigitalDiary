using DigitalDiary.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DigitalDiary.Behavior.DataBase
{
    public class AppDB : DbContext
    {
        
        public DbSet<ClassWork> ClassWorks { get; set; }
        public DbSet<Group>  Groups{ get; set; }
        public DbSet<HomeWork> HomeWorks  { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<PairWork>  PairWorks{ get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Presence> Presences { get; set; }
        public DbSet<Student> Students  { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers{ get; set; }
        public DbSet<User> Users{ get; set; }
        public DbSet<Work> Work{ get; set; }



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
