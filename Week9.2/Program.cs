using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using Week9._2.DataAcces.Connection.SqlServer;
using Week9._2.Entities;
using Week9._2.DataAcces;
using System.Net;
using System.IO;
using System.Xml.Serialization;
using System.Xml;


namespace Week9._2{
    
    class Program
    {

        static void Main(string[] args)
        {
            var connection = ConnectionManager.GetConnection();

            ///*Insert Book*/
            //var insertBookRepository = new BookRepository(connection);
            //Book insertBook = new Book { Title = "1984", PublisherId = 2, Year = 2016, Price = 154 };
            //var insertId = insertBookRepository.Insert(insertBook);
            //Console.WriteLine($"New book inserted with book Id: {insertId}");
            //var savedBook = insertBookRepository.Read(insertId);
            //savedBook.PrintBook();

            ///*Delete Book*/
            //var deleteBookRepository = new BookRepository(connection);
            //Console.WriteLine("Enter the book's id you want to delete:");
            //int deleteId = Convert.ToInt32(Console.ReadLine());
            //deleteBookRepository.Delete(deleteId);  

            ///*Update book*/
            //var updateBookRepository = new BookRepository(connection);
            //Book updateBook = new Book { BookId = 2,Title ="Moglie",PublisherId =2, Year = 2016, Price = 125 };
            //var updateId = updateBookRepository.Update(updateBook);
            //var updatedBook = updateBookRepository.Read(updateId);
            //updatedBook.PrintBook();                   


            ///*3. Number of books and publisher name ( Create a class NumberOfBooksPerPublisher { NoOfBooks, PublisherName }, load the information into a List<NumberOfBooksPerPublisher > )*/
            //List<NumberOfBooksPerPublisher> List = new List<NumberOfBooksPerPublisher>();
            //var NewList = PublisherRepository.NumberOfBooks(connection);               
            //PublisherRepository.getTopTen(connection);

            List<Book> Book = new List<Book>();
            Book = BookRepository.LoadBook(connection);
            var book = SerializeObject(Book);


            Console.ReadKey();

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
