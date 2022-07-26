using DHAUZ.MovieManager.Domain.Shared.Configuration;
using DHAUZ.MovieManager.Domain.Shared.Model;
using DHAUZ.MovieManager.HTTPClient.Interface;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DHAUZ.MovieManager.HTTPClient.Clients
{
    public class OmdbHttpClient: IOmdbHttpClient
    {
        private HttpClient _httpClient;
        private readonly OmdbConfig omdbConfig;
        public OmdbHttpClient(IOptions<OmdbConfig> options)
        {
            omdbConfig = options.Value;
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(omdbConfig.BaseUrl)
            };
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
        }

        private T DeserializeResponse<T>(string jsonReturn)
        {
            return JsonSerializer.Deserialize<T>(jsonReturn, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        public async Task<OmdbMovieModel> GetMovieData(string imdbID)
        {
            try
            {
                var res = await _httpClient.GetAsync($"?i={imdbID}&apikey={omdbConfig.ApiKey}");
                var jsonResponse = await res.Content.ReadAsStringAsync();
                var movie = DeserializeResponse<OmdbMovieModel>(jsonResponse);
                return movie;
            }
            catch(Exception ex)
            {
                throw new Exception($"Erro ao tentar localizar o filme no OMDB. Erro: {ex.Message}");
            }
        }
    }
}
