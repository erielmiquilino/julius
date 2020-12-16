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
    public class IncomeController : ControllerBase
    {
        private readonly IIncomeService _service;

        public IncomeController(IIncomeService service)
        {
            _service = service;
        }

        [HttpGet("GetIncomesBy/{periodId}")]
        public async Task<ActionResult<IEnumerable<IncomeModel>>> GetExpensesBy(Guid periodId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok(await _service.GetIncomesByPeriodId(periodId));
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
