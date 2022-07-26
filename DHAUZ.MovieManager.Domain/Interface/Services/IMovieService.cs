using DHAUZ.MovieManager.Domain.Entities;
using DHAUZ.MovieManager.Domain.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHAUZ.MovieManager.Domain.Interface.Services
{
    public interface IMovieService
    {
        List<Movie> ListAll();
        Movie GetMovieById(int Id);
        Task<Movie> Insert(MovieInsertModel insertModel);
        void Delete(int Id);
        Movie Update(MovieUpdateModel movie);
        Task<MovieCompareModel> GetMovieCompareModelAsync(int Id);
    }
}
