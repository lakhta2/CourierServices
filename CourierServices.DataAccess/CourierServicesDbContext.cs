using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourierServices.DataAccess.Entities;
using CourierServices.DataAccess.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace CourierServices.DataAccess
{
    public class CourierServicesDbContext : DbContext
    {
        public CourierServicesDbContext(DbContextOptions<CourierServicesDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<OrderEntities>().OwnsOne(o => o.DeliveryTime);
            builder.Entity<OrderEntities>().OwnsOne(o => o.Weight);
            builder.Entity<OrderEntities>().OwnsOne(o => o.District);

            builder.Entity<FinalOrders>().OwnsOne(o => o.DeliveryTime);
            builder.Entity<FinalOrders>().OwnsOne(o => o.Weight);
            builder.Entity<FinalOrders>().OwnsOne(o => o.District);
            base.OnModelCreating(builder);
        }
        public DbSet<OrderEntities> Orders { get; set; }
        public DbSet<FinalOrders> FinalOrders { get; set; }
        public DbSet<Logs> Logs { get; set; }

    }
}
