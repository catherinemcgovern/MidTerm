using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using BookCatalogue.Models;

namespace BookCatalogue
{
    //here, we extend the DbContext class with our own class 'AppDbContext'
    public class AppDbContext : DbContext
    {
        //The connection string is used by the SQL Server database provider to find the database
        private const string ConnectionString = @"Data Source=BookEfCoreDb.db";

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            //Using the SQLite database provider’s UseSqlServer command sets up the options ready for creating the applications’s DBContext
            optionsBuilder.UseSqlite(ConnectionString); //#B
        }        

          public DbSet<Books> Books { get; set; }  

        public DbSet<Authors> Authors { get; set; }     
                  



    }    
}
