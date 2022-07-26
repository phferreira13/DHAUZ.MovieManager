using DHAUZ.MovieManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHAUZ.MovieManager.Domain.Interface.Repositories
{
    public interface IMovieRepository
    {
        List<Movie> ListAll();
        Movie GetMovieById(int Id, bool forUpdate = true);
        void Insert(Movie movie);
        void Delete(int Id);
        void Update(Movie movie);
    }
}
