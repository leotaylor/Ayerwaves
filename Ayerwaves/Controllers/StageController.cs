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
    public class StageController : ControllerBase
    {
        private readonly StageStorage _storage;

        public StageController(IConfiguration config)
        {
            _storage = new StageStorage(config);
        }

        [HttpGet]
        public IActionResult GetAllStages()
        {
            var result = _storage.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetStageById(int id)
        {
            var result = _storage.GetById(id);
            return Ok(result);
        }

        [HttpPost, Authorize]
        public void AddGenre(Stage stage)
        {
            _storage.Add(stage);
        }

        [HttpPut("updateStage/{id}"), Authorize]
        public IActionResult UpdateTheStage(int id, Stage stage)
        {
            var result = _storage.UpdateStage(id, stage);
            return Ok(result);
        }

        [HttpDelete("deleteStage/{id}"), Authorize]
        public IActionResult DeleteStageById(int id)
        {
            var result = _storage.DeleteStage(id);
            return Ok(result);
        }
    }
}