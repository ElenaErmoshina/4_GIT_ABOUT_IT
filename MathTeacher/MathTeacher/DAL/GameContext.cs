using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using MathTeacher.Models;


namespace MathTeacher.DAL
{
    public class GameContext : DbContext
    {

        public GameContext(): base("GameDb")
        {
            Database.SetInitializer<GameContext>(null);
        }
   

        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public static GameContext Create()
        {
            return new GameContext();
        }
    }
}
