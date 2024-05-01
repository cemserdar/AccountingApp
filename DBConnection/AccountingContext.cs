using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using accountingWebSite.Models;
using Microsoft.EntityFrameworkCore;

namespace accountingWebSite.DBConnection
{
    public class AccountingContext : DbContext
    {
        public DbSet<AdminModel> adminModels { get; set; }
        public DbSet<CustomerModel> customerModels { get; set; }
        public DbSet<InformationModel> ınformationModels { get; set; }

         protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=accounting.db");
    }

    
}