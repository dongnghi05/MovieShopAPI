using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopAPI.Controllers
{
    //AttributeRouting
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // api/movies/3
        [Route("{id:int}")]
        [HttpGet]
        public async Task<IActionResult> GetMovie(int id)
        {
            var movie = await _movieService.GetMovieDetails(id);
            // return the data/json format
            // HTTP Status code, 200 OK
            // 404

            if (movie == null)
            {
                return NotFound( new { error = $"Movie Not Found for id: {id}" });
            }
            return Ok(movie);

            // in old .net for JSON serilization we used JSON.NET librray => very very popular
            // System.Text => 

        }

        [Route("top-rated")]
        [HttpGet]
        public async Task<IActionResult> GetTop30Rated()
        {
            var movie = await _movieService.GetTop30RatingMovies();
            return Ok(movie);
        }
        
        [Route("top-grossing")]
        [HttpGet]
        public async Task<IActionResult>GetTop30Grossing()
        {
            var movie = await _movieService.GetTop30GrossingMovies();
            return Ok(movie);
        }

        [HttpGet]
        public async Task<IActionResult> GetMovieDetails()
        {
            var movie = await _movieService.
        }

    }
}