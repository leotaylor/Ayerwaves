using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ayerwaves.DBAccess;
using Ayerwaves.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Ayerwaves.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly ArtistStorage _storage;

        public ArtistController(IConfiguration config)
        {
            _storage = new ArtistStorage(config);
        }

        [HttpGet("artists")]
        public IActionResult GetAllArtists()
        {
            var result = _storage.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetArtistById(int id)
        {
            var result = _storage.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public void AddArtist(Artist artist)
        {
            _storage.Add(artist);
        }
    }
}