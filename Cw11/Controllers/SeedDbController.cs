using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Cw11.Models;
using Cw11.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cw11.Controllers
{
    [ApiController]
    [Route("seed")]
    public class SeedDbController : ControllerBase
    {
        private readonly ISeedDbService _service;
        public SeedDbController(ISeedDbService service)
        {
            _service = service;
        }
        [HttpPost]
        public IActionResult Seed()
        {
            return Created("", _service.Seed());
        }
    }
}