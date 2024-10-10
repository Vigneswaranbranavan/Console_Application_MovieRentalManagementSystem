using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalManagementSystem
{
    public class Movie
    {
        public int MovieID { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public decimal RentalPrice { get; set; }


        public Movie(string title, string director, decimal rentalPrice)
        {
            Title = title;
            Director = director;
            RentalPrice = rentalPrice;
        }

        public Movie() { }

        public override string ToString()
        {
            return $"ID: {MovieID}, Title: {Title}, Director: {Director}, RentalPrice: ${RentalPrice}.00";
        }

        public virtual string displaymovieinfo()
        {
            return ToString();
        }
    }
}
