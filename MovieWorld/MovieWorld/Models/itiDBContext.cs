using Microsoft.EntityFrameworkCore;

namespace MovieWorld.Models
{
    public class itiDBContext : DbContext
    {
        public itiDBContext()
        {
        }

        public itiDBContext(DbContextOptions<itiDBContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=MovieLand;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }
       



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie_User>().HasKey(u => new
            {
                u.UID,
                u.MID
            });
            modelBuilder.Entity<Movie_User>().HasOne(m => m.Movie).WithMany(u => u.movie_Users).
                HasForeignKey(m => m.MID);
            modelBuilder.Entity<Movie_User>().HasOne(m => m.User).WithMany(u => u.movie_users).
               HasForeignKey(m => m.UID);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }

        public DbSet<Movie_User> Movie_Users { get; set; }


    }
}
