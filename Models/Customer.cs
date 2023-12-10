using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutuppgift___Bibliotek.Models
{

    public class Customer
    {
        [Key]

        public int Id { get; set; }
        [MaxLength(100)]
        public string? FirstName { get; set; }
        [MaxLength(100)]
        public string? LastName { get; set; }


        public LoanCard? loanCard { get; set; }  


    }
   

}
