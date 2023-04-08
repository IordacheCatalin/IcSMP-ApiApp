using IcSMP_ApiApp.DTOs;
using Microsoft.EntityFrameworkCore;

namespace IcSMP_ApiApp.DataContext
{
    public class IcSMPDataContext : DbContext
    {
        public IcSMPDataContext(DbContextOptions<IcSMPDataContext> options) : base(options) { }

        public DbSet<Category> Category { get; set; }

        //public DbSet<ClientModel> Client { get; set; }


        //public DbSet<CourierModel> Courier { get; set; }

        ////public DbSet<OrderModel> Orders { get; set; }

        //public DbSet<ProductModel> Product { get; set; }

        //public DbSet<SupplierModel> Supplier { get; set; }
    }
}
