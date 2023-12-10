using Microsoft.EntityFrameworkCore;
using Slutuppgift___Bibliotek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Slutuppgift___Bibliotek.Data;
using Slutuppgift___Bibliotek.Models;

namespace Slutuppgift___Bibliotek.Data
{
    internal class Context : DbContext

    {
        public DbSet<Auther> Authers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<LoanCard> LoanCards { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server= localhost; Database=NewtonLibraryFrawsen; Trusted_Connection=True; Trust Server Certificate =Yes; User Id=NewtonLibraryFrawsen password=NewtonLibrary");
        }

    }
}
