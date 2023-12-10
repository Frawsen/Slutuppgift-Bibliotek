using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Slutuppgift___Bibliotek.Models;


namespace Slutuppgift___Bibliotek.Models
{

    public class LoanCard
    {

        public int ID { get; set; }

        public int PinCode  { get; set; } = new Random().Next(1000, 10000);


        public ICollection<Book>? Books { get; set; }



    }



}
