using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System;
using Bieralia.Entities;

namespace Bieralia
{
    public class BieraliaDBContext : DbContext
    {
        public virtual DbSet<UserEntity> User { get; set; }
        public virtual DbSet<AdminEntity> Admin { get; set; }
        public virtual DbSet<BookEntity> Book { get; set; }
        public virtual DbSet<TransactionEntity> Transaction { get; set; }
        public virtual DbSet<TransactionDetailEntity> TransactionDetail { get; set; }
        public BieraliaDBContext(DbContextOptions<BieraliaDBContext> options)
         : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ini buat nge-scan Assembly 
            // untuk apply konfigurasi IEntityTypeConfiguration<T>
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
