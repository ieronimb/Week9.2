using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week9._2.DataAcces.Connection.SqlServer;
using Week9._2.Entities;
using Week9._2.DataAcces;


namespace SummaryPublisherApp
{
    class SummaryPublisherApp
    {
        static void Main(string[] args)
        {
            var connection = ConnectionManager.GetConnection();
            /*2.Create a new console app named SummaryPublisherApp.Here print to console:
            Number of rows from the Publisher table(Execute scalar) ===> not done
            Top 10 publishers(Id, Name)(SQL Data Reader)*/            
            PublisherRepository.getTopTen(connection);
            /*Number of books for each publisher (Publiher Name, Number of Books)*/
            PublisherRepository.NumberOfBooks(connection);
            /*The total price for books for a publisher*/
            PublisherRepository.BookCosts(connection);

            /*3. Number of books and publisher name ( Create a class NumberOfBooksPerPublisher { NoOfBooks, PublisherName }, load the information into a List<NumberOfBooksPerPublisher > )*/
            List<NumberOfBooksPerPublisher> List = new List<NumberOfBooksPerPublisher>();
            var NewList = PublisherRepository.NumberOfBooks(connection);
            PublisherRepository.getTopTen(connection);

            /*4. Load data from a table (author, books, etc.) into a list (List<Book> or List<Author) and serialize all lines from that table in xml and json into two files.
            Example: books.xml and books.json*/
            /*a. books.xml serialisation - Nu cred ca am facut bine deloc*/
            List<Book> Book = new List<Book>();
            Book = BookRepository.LoadBook(connection);
            var book = SerializeObject(Book);

        }

        public static string SerializeObject(object obj)
        {
            System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(obj.GetType());
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                serializer.Serialize(ms, obj);
                ms.Position = 0;
                xmlDoc.Load(ms);
                return xmlDoc.InnerXml;
            }
        }

    }
}
