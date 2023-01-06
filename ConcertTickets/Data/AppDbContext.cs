using Microsoft.EntityFrameworkCore;

namespace ConcertTickets
{
    public class AppDbContext : DbContext
    {
        public DbSet<Concert> Concerts { get; set; }
        public DbSet<ClassicalConcert> ClassicalConcerts { get; set; }
        public DbSet<OpenAirConcert> OpenAirConcerts { get; set; }
        public DbSet<PartyConcert> PartyConcerts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}
