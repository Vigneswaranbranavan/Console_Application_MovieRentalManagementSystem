using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalManagementSystem
{
    public class DvdMovie : Movie
    {
        public decimal diskweight { get; set; }
        public decimal duration { get; set; }

        public DvdMovie(string title, string director, decimal rentalPrice, decimal diskweidht, decimal duration) : base(title, director, rentalPrice)
        {
            this.diskweight = diskweidht;
            this.duration = duration;
        }

        public override string displaymovieinfo()
        {
            return $"{base.displaymovieinfo()},DISKWEIGHT:{diskweight},DURATION:{duration}";
        }
    }
}
