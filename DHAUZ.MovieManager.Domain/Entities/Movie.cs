using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHAUZ.MovieManager.Domain.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string IdIMDB { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ReleaseDate { get; set; }
        public string Genre { get; set; }
        public bool Watched { get; set; }
        public double UserScore { get; set; }
        public DateTime Inserted { get; set; } = DateTime.Now;
        public DateTime? Updated { get; set; }
    }
}
