using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using apiBanking.Model;

namespace apiBanking.Model.DBModel
{
    public class BankingDbContext : DbContext
    {
       // public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }

        public BankingDbContext(DbContextOptions<BankingDbContext> options) : base(options) { }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //modelBuilder.Entity<User>().HasKey(u => u.Id);
        //    //modelBuilder.Entity<Account>().HasKey(a => a.Id);

        //    //modelBuilder.Entity<Account>()
        //    //    .HasOne(a => a.Id)
        //    //    .WithMany(u => u.Accounts)
        //    //    .HasForeignKey(a => a.UserId);

        //    //base.OnModelCreating(modelBuilder);


        //    modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");


        //    modelBuilder.Entity<Account>(entity =>
        //    {
        //        entity.ToTable("Accounts");
        //        entity.HasIndex(e => e.UserId, "UserId");

        //        entity.HasIndex(e => e.AccountNumber, "AccountNumber")
        //            .IsUnique();

        //        entity.Property(e => e.AccountNumber).HasDefaultValueSql("((0))");

        //        entity.Property(e => e.Balance).HasDefaultValueSql("((0))");
        //    });


        //}
    }
}


