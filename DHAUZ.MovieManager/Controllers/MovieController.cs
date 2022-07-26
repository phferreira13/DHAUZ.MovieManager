using DHAUZ.MovieManager.Domain.Entities;
using DHAUZ.MovieManager.Domain.Interface.Services;
using DHAUZ.MovieManager.Domain.Shared.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DHAUZ.MovieManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService movieService;

        public MovieController(IMovieService movieService)
        {
            this.movieService = movieService;
        }

        [HttpGet]
        public ActionResult<List<Movie>> GetAll()
        {
            try
            {
                var res = movieService.ListAll();
                return Ok(res);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPost]
        public async Task<Movie> InsertMovie([FromBody] MovieInsertModel insertModel)
        {
            var res = await movieService.Insert(insertModel);
            return res;
        }
        [HttpPut]
        public ActionResult<Movie> UpdateMovie([FromBody] MovieUpdateModel movie)
        {
            try
            {
                var res = movieService.Update(movie);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteMovie(int id)
        {
            try
            {
                movieService.Delete(id);
                return Ok("Removido com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("compare-with-imdb/{id}")]
        public async Task<MovieCompareModel> CompareWithImdb(int id)
        {
            return await movieService.GetMovieCompareModelAsync(id);
        }


    }
}
