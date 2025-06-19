using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Domain.Entities;
using Tam.Infrastructure.Extensions;

namespace Tam.Persistence.Context
{
    public class TamDbContext : DbContext
    {
        public TamDbContext(DbContextOptions<TamDbContext> options):base(options)
        {
            
        }

        public DbSet<ActionLog> ActionLogs { get; set; }
        public DbSet<AffiliatePartner> AffiliatePartners { get; set; }
        public DbSet<AffiliateTourSale> AffiliateTourSales { get; set; }
        public DbSet<AffiliateTransferSale> AffiliateTransferSales { get; set; }
        public DbSet<Apprantee> Apprantees { get; set; }
        public DbSet<AuditTrail> AuditTrails { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Discount> Discounts{ get; set; }
        public DbSet<Driver> Drivers{ get; set; }
        public DbSet<DriverLocation> DriverLocations{ get; set; }
        public DbSet<DriverTransfer> DriverTransfers{ get; set; }
        public DbSet<Facility> Facilities{ get; set; }
        public DbSet<FileAttachment> FileAttachments{ get; set; }
        public DbSet<Guide> Guides{ get; set; }
        public DbSet<GuideLanguage> GuideLanguages{ get; set; }
        public DbSet<GuideLocation> GuideLocations{ get; set; }
        public DbSet<GuideRegion> GuideRegions{ get; set; }
        public DbSet<Hotel> Hotels{ get; set; }
        public DbSet<HotelFacility> HotelFacilities{ get; set; }
        public DbSet<HotelPurchase> HotelPurchases{ get; set; }
        public DbSet<HotelReservation> HotelReservations{ get; set; }
        public DbSet<Invoice> Invoices{ get; set; }
        public DbSet<Language> Languages{ get; set; }
        public DbSet<Location> Locations{ get; set; }
        public DbSet<Notification> Notifications{ get; set; }
        public DbSet<Payment> Payments{ get; set; }
        public DbSet<PaymentMethod> PaymentMethods{ get; set; }
        public DbSet<Region> Regions{ get; set; }
        public DbSet<Role> Roles{ get; set; }
        public DbSet<Route> Routes{ get; set; }
        public DbSet<RouteStop> RouteStops{ get; set; }
        public DbSet<Supplier> Suppliers{ get; set; }
        public DbSet<TaxDetail> TaxDetails{ get; set; }
        public DbSet<Tour> Tours{ get; set; }
        public DbSet<TourDriver> TourDrivers{ get; set; }
        public DbSet<TourHotel> TourHotels{ get; set; }
        public DbSet<TourRegion> TourRegions{ get; set; }
        public DbSet<TourReservation> TourReservations{ get; set; }
        public DbSet<TourVehicle> TourVehicles{ get; set; }
        public DbSet<Transfer> Transfers{ get; set; }
        public DbSet<TransferReservation> TransferReservations{ get; set; }
        public DbSet<User> Users{ get; set; }
        public DbSet<UserRole> UserRoles{ get; set; }
        public DbSet<Vehicle> Vehicles{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TamDbContext).Assembly);
            modelBuilder
       .HasDbFunction(typeof(PgExtensions)
       .GetMethod(nameof(PgExtensions.Unaccent), new[] { typeof(string) }))
       .HasName("unaccent")          // PostgreSQL fonksiyon adı
       .IsBuiltIn();                 // Schema belirtmeye gerek yok

        }

    }
}
