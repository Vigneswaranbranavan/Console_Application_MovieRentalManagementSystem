using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MovieManager manager = new MovieManager();
            manager.CreateTable();
            while (true)
            {
                Console.WriteLine("Movie Rental Management System");
                Console.WriteLine("1. Add a Movie");
                Console.WriteLine("2. View All Movies");
                Console.WriteLine("3. Update a Movie");
                Console.WriteLine("4. Delete a Movie");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an Option: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.Write("Enter Movie Title: ");
                        string title = Console.ReadLine();
                        string capitalize = char.ToUpper(title[0]) + title.Substring(1);

                        Console.Write("Enter Movie Director: ");
                        string director = Console.ReadLine();

                        Console.Write("Enter Movie RentalPrice: ");
                        decimal rentalPrice = Convert.ToDecimal(Console.ReadLine());
                        var FinalRental = manager.RentalPriceCheck(rentalPrice);

                        manager.CreateMovie(new Movie(capitalize, director, FinalRental));
                        break;

                    case "2":
                        Console.WriteLine("Movies");
                        manager.ReadMovies();
                        break;

                    case "3":
                        Console.Write("Enter Movie Id: ");
                        int movieid = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Movie New Title: ");
                        string newtitle = Console.ReadLine();

                        Console.Write("Enter Movie New Director: ");
                        string newdirector = Console.ReadLine();

                        Console.Write("Enter Movie New RentalPrice: ");
                        decimal newrentalPrice = Convert.ToDecimal(Console.ReadLine());
                        manager.UpdateMovie(movieid, newtitle, newdirector, newrentalPrice);
                        break;

                    case "4":
                        Console.Write("Enter Movie Id to Delete: ");
                        int deleteId = Convert.ToInt32(Console.ReadLine());

                        manager.DeleteMovie(deleteId);
                        break;

                    case "5":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Exit");
                        break;

                }
            }
        }
    }
}
