using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutuppgift___Bibliotek.Models
{
    internal class Auther
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }

       public ICollection<Book>? books { get; set; }


    }
}
