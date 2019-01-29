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
    public class VendorTypeController : ControllerBase
    {
        private readonly VendorTypeStorage _storage;

        public VendorTypeController(IConfiguration config)
        {
            _storage = new VendorTypeStorage(config);
        }

        [HttpGet]
        public IActionResult GetAllVendorTypes()
        {
            var result = _storage.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetVendorTypeById(int id)
        {
            var result = _storage.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public void AddVendorType(VendorTypeModel vendorType)
        {
            _storage.Add(vendorType);
        }

        [HttpPut("updateVendorType/{id}")]
        public IActionResult UpdateTheVendorType(int id, VendorTypeModel vendorType)
        {
            var result = _storage.UpdateVendorType(id, vendorType);
            return Ok(result);
        }

        [HttpDelete("deleteVendorType/{id}")]
        public IActionResult DeleteVendorTypeById(int id)
        {
            var result = _storage.DeleteVendorType(id);
            return Ok(result);
        }
    }
}