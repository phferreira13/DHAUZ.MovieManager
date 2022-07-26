using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHAUZ.MovieManager.Domain.Shared.Model
{
    public class MovieUpdateModel
    {
        public int Id { get; set; }
        public bool Watched { get; set; }
        public double UserScore { get; set; }
    }
}
