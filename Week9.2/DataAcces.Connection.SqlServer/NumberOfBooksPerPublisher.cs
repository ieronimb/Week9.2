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
        public void numberOfBooks(SqlConnection connection)
        {
            using (connection)
            {
                List<Book> list = new List<Book>();

                using (SqlCommand command = new SqlCommand("select        p.Name, " +
                                                                        " count(b.BookId) as NumberofBooks" +
                                                                        " from Publisher p left join Book b on p.PublisherId = b.PublisherId" +
                                                                        " Group by p.Name", connection))
                {

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.HasRows)
                    {
                        while (reader.Read())
                        {



                            int BookId = (int)reader["bookId"];
                            string Title = reader["Title"] as string;
                            int PublisherId = (int)reader["PublisherId"];

                            Book b = new Book(BookId, Title, PublisherId,Year, Price);

                            list.Add(b);

                            foreach (var item in list)
                            {
                                Console.WriteLine(item.Title);
                            }

                        }
                        reader.NextResult();
                    }
                    reader.Close();
                }



            }
        }
    }
}
