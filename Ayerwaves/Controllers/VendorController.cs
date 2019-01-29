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

        [HttpGet("{id}")]
        public IActionResult GetVendorById(int id)
        {
            var result = _storage.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public void AddVendor(Vendor vendor)
        {
            _storage.Add(vendor);
        }

        [HttpPut("updateVendor/{id}")]
        public IActionResult UpdateTheVendor(int id, Vendor vendor)
        {
            var result = _storage.UpdateVendor(id, vendor);
            return Ok(result);
        }

        [HttpDelete("deleteVendor/{id}")]
        public IActionResult DeleteVendorById(int id)
        {
            var result = _storage.DeleteVendor(id);
            return Ok(result);
        }
    }
}