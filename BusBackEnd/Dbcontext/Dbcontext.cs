using System;
using DotNet.Table;
using Microsoft.EntityFrameworkCore;
using Table;

namespace DotNet.Dbcontext;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

    public DbSet<CustomerTable> Customer { get; set; }
    public DbSet<BusTable> Bus { get; set; }

    public DbSet<SeatTable> Seat { get; set; }
    public DbSet<BookingRecordsTable> BookingRecords { get; set; }
    public DbSet<DiscountOfferTable> Discount { get; set; }
    public DbSet<BookedSeatsTable> Booked { get; set; }
    public DbSet<RouteTable> Route { get; set; }
    public DbSet<BoardingPointTable> BoardingPoint { get; set; }
    public DbSet<DropPointTable> DropPoint { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerTable>(entity =>
        {
            entity.ToTable("Customer");
            entity.HasKey(c => c.Id);
        });
        modelBuilder.Entity<SeatTable>(entity =>
        {
            entity.ToTable("Seat");
            entity.HasNoKey();
        });
        modelBuilder.Entity<BusTable>(entity =>
        {
            entity.ToTable("Bus");
            entity.HasNoKey();
        });
        modelBuilder.Entity<BookingRecordsTable>(entity =>
        {
            entity.ToTable("BookingRecords");
            entity.HasKey(c => c.RecordId);
        });
        modelBuilder.Entity<DiscountOfferTable>(entity =>
        {
            entity.ToTable("Discount");
            entity.HasNoKey();
        });
        modelBuilder.Entity<BookedSeatsTable>(entity =>
        {
            entity.ToTable("Booked");
            entity.HasKey(c => c.BookedId);
        });
        modelBuilder.Entity<RouteTable>(entity =>
        {
            entity.ToTable("Route");
            entity.HasKey(c => c.RouteId);
        });
        modelBuilder.Entity<BoardingPointTable>(entity =>
        {
            entity.ToTable("BoardingPoint");
            entity.HasKey(c => c.BoardingPointId);
        });
        modelBuilder.Entity<DropPointTable>(entity =>
        {
            entity.ToTable("DropPoint");
            entity.HasKey(c => c.DropPointId);
        });

    }

}
