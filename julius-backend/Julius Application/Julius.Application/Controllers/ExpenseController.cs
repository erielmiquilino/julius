﻿using System;
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

        [HttpGet("GetExpensesBy/{periodId}")]
        public async Task<ActionResult<IEnumerable<ExpenseModel>>> GetExpensesBy(Guid periodId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok(await _service.GetExpensesByPeriodId(periodId));
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost("AddExpense")]
        public async Task<ActionResult<Expense>> PostExpense([FromBody] CreateExpenseModel createExpenseModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var expense = await _service.Post(createExpenseModel);

                if (expense != null)
                    return CreatedAtAction("GetExpense", new { id = expense.Id }, expense);

                return BadRequest();
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExpenseModel>> GetExpense(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok(await _service.Get(id));
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }


        [HttpPost("PaymentAction")]
        public async Task<ActionResult> PostPaymentAction([FromBody] PaymentActionModel paymentActionModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _service.SavePaymentAction(paymentActionModel);

                return Ok();
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteExpense(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _service.DeleteExpense(id);

                return Ok();
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpGet("GetTotalsBy/{periodId}")]
        public async Task<ActionResult> GetTotalsByMonthAndYear(Guid periodId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok(await _service.GetAmountByPeriodId(periodId));
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
