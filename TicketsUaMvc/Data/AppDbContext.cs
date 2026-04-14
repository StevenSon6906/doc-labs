using Microsoft.EntityFrameworkCore;
using TicketsUaMvc.Models;

namespace TicketsUaMvc.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Ticket> Tickets { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}