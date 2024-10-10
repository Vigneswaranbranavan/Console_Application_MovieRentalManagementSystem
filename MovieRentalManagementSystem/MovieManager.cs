using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalManagementSystem
{
    public class MovieManager
    {
        public readonly string connectionString = "server=(localdb)\\MSSQLLocalDB;database=MovieManagementSystem;Integrated Security=true";

        public void CreateTable()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var Command = connection.CreateCommand();
                Command.CommandText = @"
                        IF NOT EXISTS(SELECT * from sys.tables where name = 'movies')
                            BEGIN  
                               CREATE TABLE movies(
                                          Id INT IDENTITY(1,1) PRIMARY KEY,
                                          Title VARCHAR(20),
                                          Director VARCHAR(20),
                                          RentalPrice DECIMAL
                               );
                            END
                ";
                Command.ExecuteNonQuery();
            }

        }



        public void CreateMovie(Movie movie)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"
                            INSERT INTO Movies(Title,Director,RentalPrice) 
                            Values(@Title,@Director,@RentalPrice);
                ";
                command.Parameters.AddWithValue("@Title", movie.Title);
                command.Parameters.AddWithValue("@Director", movie.Director);
                command.Parameters.AddWithValue("@RentalPrice", movie.RentalPrice);

                command.ExecuteNonQuery();
            }
            Console.WriteLine("Movie Added Successfully");
        }




        public void ReadMovies()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var data = new List<Movie>();
                var Command = connection.CreateCommand();
                Command.CommandText = @"
                      SELECT * FROM movies";
                using (var reader = Command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var obj = new Movie
                        {
                            MovieID = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            Director = reader.GetString(2),
                            RentalPrice = reader.GetDecimal(3)
                        };
                        data.Add(obj);
                        Console.WriteLine(obj.ToString());
                    }


                }
            }
        }



        public void UpdateMovie(int id, string newTitle, string newDirector, decimal newPrice)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"
                                        UPDATE Movies
                                        SET Title = @Title,
                                        Director = @Director,
                                        RentalPrice = @RentalPrice
                                        WHERE Id = @id
                                        ";

                command.Parameters.AddWithValue("@Title", newTitle);
                command.Parameters.AddWithValue("@Director", newDirector);
                command.Parameters.AddWithValue("@RentalPrice", newPrice);
                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();
            }
            Console.WriteLine("Movie Updated SuccessFully..");
        }



        public void DeleteMovie(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"
                                        DELETE Movies
                                        WHERE Id = @id
                                        ";
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
            Console.WriteLine("Deleted");

        }


        public decimal RentalPriceCheck(decimal data)
        {
            if (data > 0)
            {
                return data;
            }
            else
            {
                while (data <= 0)
                {
                    Console.WriteLine("RentalPrice must have Positive Value");
                    Console.Write("ReEnter Rental Price :");
                    data = Convert.ToDecimal(Console.ReadLine());
                }
                return data;
            }
        }
    }
}
