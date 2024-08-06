using HMS.Model.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace HMS.Model.Entity;
public class ApplicationDbContext : IdentityDbContext<User>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Amenity> Amenities { get; set; }
    public DbSet<RoomAmenity> RoomAmenities { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<CustomerReview> CustomerReviews { get; set; }
}
