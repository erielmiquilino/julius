using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Julius.Domain.Contracts.Services;
using Julius.Domain.Domains;
using Julius.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Julius.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseService _service;

        public ExpenseController(IExpenseService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExpenseModel>>> GetExpenses()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok(await _service.GetAll());
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        public async Task<ActionResult<IEnumerable<MonthModel>>> GetMonthsWithRecords()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok(await _service.GetMonthsWithRecords());
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, ex);
            }
        }

    }
}
