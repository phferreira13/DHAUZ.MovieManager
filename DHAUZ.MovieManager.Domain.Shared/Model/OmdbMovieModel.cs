using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHAUZ.MovieManager.Domain.Shared.Model
{
    public class OmdbMovieModel
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string Rated { get; set; }
        public string Released { get; set; }
        public string Genre { get; set; }
        public string Plot { get; set; }
        public List<MovieRatingModel> Ratings { get; set; } = new List<MovieRatingModel>();
        public string Metascore { get; set; }
        public string imdbRating { get; set; }
        public string imdbID { get; set; }

    }
}
