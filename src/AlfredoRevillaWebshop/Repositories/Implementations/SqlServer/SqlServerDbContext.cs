using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlfredoRevillaWebshop.Repositories.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace AlfredoRevillaWebshop.Repositories.Implementations.SqlServer
{
    public sealed class SqlServerDbContext : DbContext
    {
        private string _connectionString;

        public SqlServerDbContext(string connectionString)
        {
            this._connectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this._connectionString);

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<ProductRepositoryModel> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var productModelBuilder = modelBuilder.Entity<ProductRepositoryModel>().ForSqlServerToTable("webshop_product");
            productModelBuilder.HasKey(o => o.Id);
            productModelBuilder.Property(o => o.Id).ForSqlServerHasColumnName("productId");
            productModelBuilder.Property(o => o.MPN).IsRequired().HasMaxLength(20);
            productModelBuilder.Property(o => o.Price).IsRequired();
            productModelBuilder.Property(o => o.Title).IsRequired().HasMaxLength(100);

            base.OnModelCreating(modelBuilder);
        }
    }
}