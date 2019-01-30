using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ayerwaves.DBAccess;
using Ayerwaves.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Ayerwaves.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly GenreStorage _storage;

        public GenreController(IConfiguration config)
        {
            _storage = new GenreStorage(config);
        }

        [HttpGet]
        public IActionResult GetAllGenres()
        {
            var result = _storage.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetGenreById(int id)
        {
            var result = _storage.GetById(id);
            return Ok(result);
        }

        [HttpPost, Authorize]
        public void AddGenre(Genre genre)
        {
            _storage.Add(genre);
        }

        [HttpPut("updateGenre/{id}"), Authorize]
        public IActionResult UpdateTheArtist(int id, Genre genre)
        {
            var result = _storage.UpdateGenre(id, genre);
            return Ok(result);
        }

        [HttpDelete("deleteGenre/{id}"), Authorize]
        public IActionResult DeleteGenreById(int id)
        {
            var result = _storage.DeleteGenre(id);
            return Ok(result);
        }
    }
}