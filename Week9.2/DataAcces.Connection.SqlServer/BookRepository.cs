using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week9._2.DataAccess;
using Week9._2.Entities;

namespace Week9._2.DataAcces.Connection.SqlServer
{
    public class BookRepository : BaseRepository
    {
        public BookRepository(SqlConnection connection) : base(connection)
        {

        }

        public int Insert(Book book)
        {
            const string query = "insert into Book (Title, PublisherId, Year, Price) values (@Title, @PublisherId, @Year, @Price); select cast(scope_identity() as int);";

            SqlParameter Title = new SqlParameter("@Title", System.Data.DbType.String)
            {
                Value = book.Title
            };

            SqlParameter Year = new SqlParameter("@Year", System.Data.DbType.Int32)
            {
                Value = book.Year
            };

            SqlParameter PublisherId = new SqlParameter("@PublisherId", System.Data.DbType.Int32)
            {
                Value = book.PublisherId
            };
            SqlParameter Price = new SqlParameter("@Price", System.Data.DbType.Int32)
            {
                Value = book.Price
            };


            var command = new SqlCommand
            {
                CommandText = query,
                Connection = Connection
            };

            command.Parameters.Add(Title);
            command.Parameters.Add(PublisherId);
            command.Parameters.Add(Year);
            command.Parameters.Add(Price);

            return (int)command.ExecuteScalar();
        }



        public Book Read(int id)
        {
            string query = $"select * from book where Year = @id";

            SqlParameter idParam = new SqlParameter("@id", System.Data.DbType.Int32)
            {
                Value = id
            };

            var command = new SqlCommand
            {
                CommandText = query,
                Connection = Connection
            };

            command.Parameters.Add(idParam);

            var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();

                // todo check for null
                var Title = reader["Title"] as string;
                var PublisherId = (reader["PublisherId"] as int?) ?? 0;
                var Year = (reader["Year"] as int?) ?? 0;
                var Price = (reader["Price"] as decimal?) ?? 0;

                return new Book
                {                   
                    Title = Title,
                    PublisherId = PublisherId,
                    Year = Year,
                    Price = Price
                };
            }
            else
            {
                throw new InvalidOperationException($"Book with year 2010 {id} does not exits!");
            }
        }



        public int Update(Book book)
        {
            
            
                const string query = "UPDATE Book SET Title=@Title, PublisherId=@PublisherId, " +
                                                                "Year=@Year, Price=@Price Where BookId = @BookId; select cast(scope_identity() as int);";

                SqlParameter BookId = new SqlParameter("@BookId", System.Data.DbType.Int32)
                {
                    Value = book.BookId
                };

                SqlParameter Title = new SqlParameter("@Title", System.Data.DbType.String)
                {
                    Value = book.Title
                };

                SqlParameter Year = new SqlParameter("@Year", System.Data.DbType.Int32)
                {
                    Value = book.Year
                };

                SqlParameter PublisherId = new SqlParameter("@PublisherId", System.Data.DbType.Int32)
                {
                    Value = book.PublisherId
                };
                SqlParameter Price = new SqlParameter("@Price", System.Data.DbType.Decimal)
                {
                    Value = book.Price
                };

                var command = new SqlCommand
                {
                    CommandText = query,
                    Connection = Connection
                };

                command.Parameters.AddWithValue("@Title", Title);
                command.Parameters.AddWithValue("@PublisherId", PublisherId);
                command.Parameters.AddWithValue("@Year", Year);
                command.Parameters.AddWithValue("@Price", Price);               

                /*Number of rows*/
                return (int)command.ExecuteNonQuery();              
            
                     
        }


        public void Delete(int BookId)
        {
          
            try
            {
                const string query = "DELETE FROM  Book Where BookId = @BookId; select cast(scope_identity() as int); ";              


                SqlParameter bookId = new SqlParameter("@BookId", System.Data.DbType.Int32)
                {
                    Value = BookId
                };


                var command = new SqlCommand
                {
                    CommandText = query,
                    Connection = Connection
                };

                command.Parameters.AddWithValue("@BookId", BookId);


                int rows = Convert.ToInt32(command.ExecuteNonQuery());
                Console.WriteLine($"Total rows deleted:{rows}"); 

            }

            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine($"Book with ID {BookId} was deleted.");
            }
        }
    }
}
