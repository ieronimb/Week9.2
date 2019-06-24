using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week9._2.DataAcces.Connection.SqlServer
{
    public class PublisherRepository
    {
        public static void numberOfBooks(SqlConnection connection)
        {
            using (connection)
            {

                using (SqlCommand command = new SqlCommand("select        p.Name, " +
                                                                        " count(b.BookId) as NumberofBooks" +
                                                                        " from Publisher p left join Book b on p.PublisherId = b.PublisherId" +
                                                                        " Group by p.Name", connection))
                {

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.HasRows)
                    {
                        Console.WriteLine("{0}\t\t{1}", reader.GetName(0), reader.GetName(1));

                        while (reader.Read())
                        {
                            Console.WriteLine("{0}\t\t{1}", reader.GetString(0), reader.GetInt32(1));
                        }
                        reader.NextResult();
                    }
                    reader.Close();
                }
            }
        }



        public static void BookCosts(SqlConnection connection)
        {
            using (connection)
            {

                using (SqlCommand command = new SqlCommand("select        p.Name, " +
                                                                        " sum(b.Price) as TotalPrice" +
                                                                        " from Publisher p left join Book b on p.PublisherId = b.PublisherId" +
                                                                        " Group by p.Name", connection))
                {

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.HasRows)
                    {
                        Console.WriteLine("{0}\t\t{1}", reader.GetName(0), reader.GetName(1));

                        while (reader.Read())
                        {
                            Console.WriteLine("{0}\t\t{1}", reader.GetString(0), reader.GetDecimal(1));
                        }
                        reader.NextResult();
                    }
                    reader.Close();
                }
            }
        }
               

        public static void getTopTen(SqlConnection connection)
        {

            using (SqlCommand command = new SqlCommand("select top 10 PublisherId, Name from Publisher", connection))
            {

                SqlDataReader reader = command.ExecuteReader();

                while (reader.HasRows)
                {
                    Console.WriteLine("{0}\t\t{1}", reader.GetName(0), reader.GetName(1));

                    while (reader.Read())
                    {
                        Console.WriteLine("{0}\t\t{1}", reader.GetInt32(0), reader.GetString(1));
                    }
                    reader.NextResult();
                }
                reader.Close();
            }

        }

        public static List <NumberOfBooksPerPublisher> NumberOfBooks(SqlConnection connection)
        {
            List<NumberOfBooksPerPublisher> ListBooks = new List<NumberOfBooksPerPublisher>();

            using (SqlCommand command = new SqlCommand("select  p.Name as PublisherName, " +
                                                                " count(b.PublisherId) as NoOfBooks" +
                                                                " from Publisher p left join Book b on b.PublisherId = p.PublisherId" +
                                                                " Group by p.Name", connection))
            {

                SqlDataReader reader = command.ExecuteReader();

                while (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var book = new NumberOfBooksPerPublisher();
                        book.NoOfBooks = (int)reader["NoOfBooks"];
                        book.PublisherName = reader["PublisherName"] as string;                       

                        ListBooks.Add(book);
                        Console.WriteLine($"Publihser name:{book.PublisherName}; Number of Books: {book.NoOfBooks}");
                    }                    
                }
                return ListBooks;
            }
        }
    }
}