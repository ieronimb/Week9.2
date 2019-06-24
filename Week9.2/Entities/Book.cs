using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week9._2.DataAcces.Connection.SqlServer;
using Week9._2.Entities.Common;

namespace Week9._2.Entities
{ 

    public class Book : BaseEntity
    {      

        public int BookId { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public decimal Price { get; set; }


        public void PrintBook()
        {
            Console.WriteLine($"Title: {Title};\t\tPublisherId: {PublisherId};\t\tYear:{Year};\t\tPrice:{Price}");
        }

        public static implicit operator Book(NumberOfBooksPerPublisher v)
        {
            throw new NotImplementedException();
        }
    }

    
}
