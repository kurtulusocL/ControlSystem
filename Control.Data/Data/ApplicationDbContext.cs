using Control.Data.Identity;
using Control.Entities.Models.Entites;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control.Data.Data
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext():base("DefaultConnection")
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Communicate> Communicates { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<FromWhere> FromWheres { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<ToWhere> ToWheres { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<CustomerInfo> CustomerInfos { get; set; }
        public DbSet<EmployeeInfo> EmployeeInfos { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Departmant> Departmants { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
    }
}
