using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ayerwaves.DBAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Ayerwaves.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private readonly VendorStorage _storage;

        public VendorController(IConfiguration config)
        {
            _storage = new VendorStorage(config);
        }

        [HttpGet]
        public IActionResult GetAllArtists()
        {
            var result = _storage.GetAll();
            return Ok(result);
        }
    }
}