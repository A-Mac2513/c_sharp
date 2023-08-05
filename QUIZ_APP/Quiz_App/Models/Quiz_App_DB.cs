using Microsoft.EntityFrameworkCore;

namespace Quiz_App.Models
{
    public class Quiz_App_DB : DbContext
    {
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Answers> Answers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "server=localhost;user=root;password=root;database=quiz_app";
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 11));
            optionsBuilder.UseMySql(connectionString, serverVersion);
        }

      /*  //Constructor      
        public Quiz_App_DB(DbContextOptions<Quiz_App_DB> options) : base(options) { }*/


        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //first call the base class version:
            base.OnModelCreating(modelBuilder);

            // Questions: set primary key 
            modelBuilder.Entity<Questions>().HasKey(q => new { q.id });

            // BookAuthor: set foreign keys           

            *//*// seed initial data
            modelBuilder.ApplyConfiguration(new SeedGenres());
            modelBuilder.ApplyConfiguration(new SeedBooks());
            modelBuilder.ApplyConfiguration(new SeedAuthors());
            modelBuilder.ApplyConfiguration(new SeedBookAuthors());*//*
        }*/

        //public DbSet<Answers> Answers { get; set; }
    }
}
