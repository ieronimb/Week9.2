using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Week9._2.Entities;

namespace Week9._2.DataAcces.Connection.SqlServer
{
    public class NumberOfBooksPerPublisher
    {
        public int NoOfBooks { get;set;}
        public string PublisherName { get; set; }                        
    }   
 }
