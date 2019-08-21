using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyStore.Models;
using MyStore.ViewModel;


namespace MyStore.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Product> product { get; set; }
        public DbSet<Order> order { get; set; }
        public DbSet<MyStore.ViewModel.OrderViewModel> OrderViewModel { get; set; }
        public DbSet<MyStore.Models.ShippingDetails> ShippingDetails { get; set; }
        public DbSet<MyStore.ViewModel.OrderDetail> OrderDetail { get; set; }
        public DbSet<MyStore.ViewModel.CreateRoleViewModel> CreateRoleViewModel { get; set; }
        public DbSet<MyStore.ViewModel.UserRoleViewModel> UserRoleViewModel { get; set; }


    }
}
