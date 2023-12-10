using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Slutuppgift___Bibliotek.Models;
using Helpers;
using System.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Slutuppgift___Bibliotek.Data
{
    public class DataAccess
    {

        public enum BookTitles
        {
            Aftonbladet, [Description("harry potter")] HarryP, [Description("Sagan om ringen")] SMR,

            Expressen, [Description("Game Of Thrones")] GMT, MARVEL, Vikings, Batman, Superman, Onepieace, Avatar, Dragonboll, Animalworld, Systrarna, bröderna, Spiderman,
        }


        public csSeedGenerator rnd = new csSeedGenerator();

        public void seed()
        {
            using (var context = new Context())
            {
                for (var i = 0; i <= 10; i++)
                {
                    Customer customer = new Customer();
                    Auther author = new Auther();
                    Book book = new Book();
                    LoanCard loanCard = new LoanCard();

                    customer.FirstName = rnd.FirstName;
                    customer.LastName = rnd.LastName;
                    author.Name = rnd.FullName;

                    book.Title = GetEnumDescription(rnd.FromEnum<BookTitles>());

                    context.Books.Add(book);
                    context.Customers.Add(customer);
                    context.Authers.Add(author);
                    context.LoanCards.Add(loanCard);


                }
                context.SaveChanges();
            }


        }
        private string GetEnumDescription(Enum value)
        {
            var field = value.GetType().GetField(value.ToString());

            if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
            {
                return attribute.Description;
            }

            return value.ToString();
        }


        public void NotLoanedBook(int BookId)
        {
            using (var context = new Context())
            {
                var book = context.Books.Include(b => b.LoanCards).FirstOrDefault(b => b.Id == BookId);

                if (book != null && book.LoanCards != null)
                {
                    book.LoanCards.Books.Remove(book);
                    book.LoanTime = null;
                    book.LastReturnDate = null;
                    book.Availble = true; // Sätt tillgänglig igen
                    context.SaveChanges();
                }
                // Annars, boken eller lånekortet saknas

            }
        }


        public void BookLoaned(int bookId, int PersonId)
        {
            using (var context = new Context())
            {
                //Hämta kunden och lånekort från databasen.
                var customer = context.Customers.Include(b => b.loanCard).FirstOrDefault(b => b.Id == PersonId);

                // Kontrollera om kunden inte hittades.
                if (customer == null)
                {
                    return;


                }

                // Kontrollera om kunden inte har några lånekort.
                if (customer.loanCard == null)
                {

                    Console.WriteLine("Person cannot find Loancard! ");
                    return;
                }

                // Hämta boken från databasen med bookId.
                var book = context.Books.Find(bookId);

                // Kontrollera om boken hittades
                if (book != null)
                {
                    book.LoanCardID = customer.loanCard.ID;
                    book.Availble = false;
                    book.LoanTime = DateTime.Now;
                    book.LastReturnDate = DateTime.Now;
                    context.SaveChanges();

                }

                else
                {
                    Console.WriteLine("Book ID cannot found! ");
                }



            }



        }



        public void GetCustomerLoancard(int Customer)
        {
            using (var context = new Context())
            {

                var FoundCustomer = context.Customers.FirstOrDefault(b => b.Id == Customer);
                if (FoundCustomer == null)
                {

                    return;
                }
                LoanCard LoanCard = new LoanCard();
                FoundCustomer.loanCard = LoanCard;
                context.SaveChanges();

            }



        }



      
        public void Clear()
        {
            using (var context = new Context())
            {
                var allCustomers = context.Customers.ToList();
                context.Customers.RemoveRange(allCustomers);
                var allBooks = context.Books.ToList();
                context.Books.RemoveRange(allBooks);
                var allAuthers = context.Authers.ToList();
                context.Authers.RemoveRange(allAuthers);
                var allLoanCards = context.LoanCards.ToList();
                context.RemoveRange(allLoanCards);

                context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Customers', RESEED, 0)");
                context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Books', RESEED, 0)");
                context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Authers', RESEED, 0)");
                context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('LoanCards', RESEED, 0)");

                context.SaveChanges();
            }
        }

        public void addAuther()
        {
            using (var context = new Context())
            {


                var auther = new Auther()
                {
                    Name = rnd.FullName

                };


                context.Authers.Add(auther);

                context.SaveChanges();
            }

        }
        public void addBook()
        {

            using (var context = new Context())
            {



                var book = new Book()
                {
                    Title = GetEnumDescription(rnd.FromEnum<BookTitles>()),
                    Availble = true


                };
                context.Books.Add(book);

                context.SaveChanges();

            }





        }

        public void AddCustomer(string firstName, string lastName)
        {
            using (var context = new Context())
            {
                var person = new Customer
                {
                    FirstName = firstName,
                    LastName = lastName
                };

                context.Customers.Add(person);
                context.SaveChanges();
            }
        }


        public void RemoveAuther(int AutherId)
        {

            using (var context = new Context())
            {
                var auther = context.Authers.FirstOrDefault(x => x.Id == AutherId);
                context.Authers.RemoveRange(auther);
                context.SaveChanges();


            }

        }


        public void RemoveBook(int BookId)
        {
            using (var context = new Context())
            {
                var book = context.Books.FirstOrDefault(x => x.Id == BookId);

                if (book != null)
                {
                    context.Books.Remove(book);
                    context.SaveChanges();
                }
            }
        }



        public void RemoveCustomer(int CustomerId)
        {

            using (var context = new Context())
            {

                var customer = context.Customers.FirstOrDefault(x => x.Id == CustomerId);
                context.Customers.RemoveRange(customer);
                context.SaveChanges();

            }



        }

    }
}
