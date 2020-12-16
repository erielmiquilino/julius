using Julius.Domain.Contracts.Services;
using Julius.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Julius.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeriodController : ControllerBase
    {
        private readonly IPeriodService _service;

        public PeriodController(IPeriodService service)
        {
            _service = service;
        }

        [HttpGet("GetPeriods")]
        public async Task<ActionResult<IEnumerable<PeriodModel>>> GetMonthsWithRecords()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok(await _service.GetPeriodsWithRecords());
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
