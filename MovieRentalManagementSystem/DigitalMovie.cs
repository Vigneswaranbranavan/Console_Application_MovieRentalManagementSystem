using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalManagementSystem
{
    public class DigitalMovie : Movie
    {
        public string Fileforamt { get; set; }
        public decimal duration { get; set; }

        public DigitalMovie(string title, string director, decimal rentalPrice, string fileformat, decimal duration) : base(title, director, rentalPrice)
        {
            this.Fileforamt = fileformat;
            this.duration = duration;
        }
    }
}
