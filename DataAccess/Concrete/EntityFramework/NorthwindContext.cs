using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    // Context: Db tabloları ile proje classlarını bağlamak
    public class NorthwindContext : DbContext
    {
        // bu metod projenin hangi veritabanı ile ilişkili olduğunu belirteceğimiz yerdir.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // sql server kullanacağımızı belirtiyoruz. (baglanacagımızı)

            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=model;Trusted_Connection=true");
        }

        //Dbset baglama görevi görür!
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet <OperationClaim> OperationClaims { get; set; }
        public DbSet <User> Users { get; set; }
        public DbSet <UserOperationClaim> UserOperationClaims { get; set; }

    }
}

