using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHAUZ.MovieManager.Domain.Shared.Model
{
    public class MovieCompareModel
    {
        public string IdIMDB { get; set; }
        public string Name { get; set; }
        public double UserScore { get; set; }
        public string imdbRating { get; set; }
        public List<MovieRatingModel> Ratings { get; set; } = new List<MovieRatingModel>();
    }
}
