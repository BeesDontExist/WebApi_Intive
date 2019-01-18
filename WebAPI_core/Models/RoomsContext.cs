using Microsoft.EntityFrameworkCore;

namespace WebAPI_core.Models
{
    public class RoomsContext : DbContext
    {
        public RoomsContext(DbContextOptions<RoomsContext> options)
            : base(options)
        {
        }

        public DbSet<Room> Rooms { get; set; }
    }
}
