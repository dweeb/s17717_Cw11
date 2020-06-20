using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw11.Models;
using Cw11.Requests;
using Cw11.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cw11.Controllers
{
    [ApiController]
    [Route("api/doctors")]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorsDbService _service;
        public DoctorsController(IDoctorsDbService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult GetDoctors()
        {
            return Ok(_service.GetDoctors());
        }
        [HttpGet, Route("{id}")]
        public IActionResult GetDoctor(int id)
        {
            var doc = _service.GetDoctor(id);
            if (doc == null)
                return NotFound();
            return Ok(doc);
        }
        [HttpDelete, Route("{id}")]
        public IActionResult DeleteDoctor(int id)
        {
            if (_service.RemoveDoctor(id))
                return NoContent();
            return NotFound();
        }
        [HttpPatch, Route("{id}")]
        public IActionResult ModifyDoctor(int id, ModifyDoctorRequest req)
        {
            var doc = _service.ModifyDoctor(id, req);
            if (doc == null)
                return NotFound();
            return Ok(doc);
        }
        [HttpPost]
        public IActionResult CreateDoctor(Doctor req)
        {
            var doc = _service.AddDoctor(req);
            return Created("api/doctors" + doc.IdDoctor, doc);
        }
    }
}
