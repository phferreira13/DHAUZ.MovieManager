using DHAUZ.MovieManager.Domain.Entities;
using DHAUZ.MovieManager.Domain.Interface.Repositories;
using DHAUZ.MovieManager.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHAUZ.MovieManager.Infra.Repositories
{
    public class MovieRepository: IMovieRepository
    {
        private readonly ProjectContext _context;
        private readonly DbSet<Movie> dBSet;

        public MovieRepository(ProjectContext context)
        {
            _context = context;
            dBSet = _context.Set<Movie>();
        }

        public List<Movie> ListAll()
        {
            return dBSet
                    .AsNoTracking()
                    .ToList();
        }

        public Movie GetMovieById(int Id, bool forUpdate = true)
        {
            var res = dBSet.Where(m => m.Id.Equals(Id));
            if(!forUpdate)
                res = res.AsNoTracking();
            return res.FirstOrDefault();
        }

        public void Insert(Movie movie)
        {
            try
            {
                var movies = dBSet.Where(m => m.IdIMDB.Equals(movie.IdIMDB)).ToList();
                if (movies.Any())
                    throw new Exception($"O filme {movie.Name}, com o IdIMDB: {movie.IdIMDB} já se encontra cadastrado!");

                dBSet.Add(movie);
                _context.SaveChanges();

            }
            catch(Exception ex)
            {
                throw new Exception($"Erro ao inserir registro: {ex.Message}");
            }
        }

        public void Delete(int Id)
        {
            try
            {
                var movie = GetMovieById(Id);
                if (movie == null)
                    throw new Exception($"Não foi possível localizar o filme com o Id: {Id}");

                dBSet.Remove(movie);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao remover registro: {ex.Message}");
            }
        }

        public void Update(Movie movie)
        {
            try
            {
                movie.Updated = DateTime.Now;
                dBSet.Update(movie);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar registro: {ex.Message}");
            }
        }
        
    }
}
