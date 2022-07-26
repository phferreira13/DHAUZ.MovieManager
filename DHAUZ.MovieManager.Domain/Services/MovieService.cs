using DHAUZ.MovieManager.Domain.Entities;
using DHAUZ.MovieManager.Domain.Interface.Repositories;
using DHAUZ.MovieManager.Domain.Interface.Services;
using DHAUZ.MovieManager.Domain.Shared.Model;
using DHAUZ.MovieManager.HTTPClient.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHAUZ.MovieManager.Domain.Services
{
    public class MovieService: IMovieService
    {
        private readonly IMovieRepository movieRepository;
        private readonly IOmdbHttpClient httpClient;

        public MovieService(IMovieRepository movieRepository, IOmdbHttpClient httpClient)
        {
            this.movieRepository = movieRepository;
            this.httpClient = httpClient;
        }

        public List<Movie> ListAll()
        {
            return movieRepository.ListAll();
        }

        public Movie GetMovieById(int Id)
        {
            return movieRepository.GetMovieById(Id);
        }

        public async Task<Movie> Insert(MovieInsertModel insertModel)
        {
            var movieOmdb = await httpClient.GetMovieData(insertModel.IdIMDB);
            var movie = new Movie
            {
                Description = movieOmdb.Plot,
                IdIMDB = insertModel.IdIMDB,
                Genre = movieOmdb.Genre,
                Name = movieOmdb.Title,
                ReleaseDate = movieOmdb.Released,
                Watched = insertModel.Watched,
                UserScore = insertModel.UserScore,
            };
            movieRepository.Insert(movie);
            return movie;
        }

        public void Delete(int Id)
        {
            movieRepository.Delete(Id);
        }

        public Movie Update(MovieUpdateModel movie)
        {
            var movieToUpdate = movieRepository.GetMovieById(movie.Id);
            movieToUpdate.Watched = movie.Watched;
            movieToUpdate.UserScore = movie.UserScore;

            movieRepository.Update(movieToUpdate);
            return movieToUpdate;
        }

        public async Task<MovieCompareModel> GetMovieCompareModelAsync(int Id)
        {
            var movieLocal = movieRepository.GetMovieById(Id, false);
            var movieOmdb = await httpClient.GetMovieData(movieLocal.IdIMDB);
            var res = new MovieCompareModel
            {
                IdIMDB = movieLocal.IdIMDB,
                Name = movieLocal.Name,
                UserScore = movieLocal.UserScore,
                imdbRating = movieOmdb.imdbRating,
                Ratings = movieOmdb.Ratings
            };

            return res;
        }
    }
}
