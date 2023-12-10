using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutuppgift___Bibliotek.Models
{

    public  class Book
    {
       
        public int Id { get; set; } 
        public string? Title { get; set; }
        public Guid ISBN { get; set; } = Guid.NewGuid();
        public bool Availble { get; set; }
        public DateTime?  LoanTime { get; set; }
       public DateTime?  LastReturnDate { get; set; }
        public int  Grade { get; set; } =  new Random().Next(1 , 5);
        public int ReleaseYear { get; set; } = new Random().Next(1990 , 2023); 

        ICollection<Auther> Authers { get; set;}

        public int? LoanCardID { get; set; }
        public LoanCard? LoanCards { get; set; }

        



    }
}
