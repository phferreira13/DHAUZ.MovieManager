using DHAUZ.MovieManager.Domain.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHAUZ.MovieManager.HTTPClient.Interface
{
    public interface IOmdbHttpClient
    {
        Task<OmdbMovieModel> GetMovieData(string imdbID);
    }
}
