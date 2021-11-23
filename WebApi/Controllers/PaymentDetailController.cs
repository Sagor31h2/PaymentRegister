using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentRegister_.net_core5_angular11.Models;
using WebApi.Data;
using WebApi.Repositories.IRepositories;

namespace PaymentRegister_.net_core5_angular11.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentDetailController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PaymentDetailController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/PaymentDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentDetails>>>
        AllpaymentDetails()
        {
            var allPayment =
                await _unitOfWork.paymentRepository.AllpaymentDetails();
            return Ok(allPayment);
        }

        // GET: api/PaymentDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentDetails>>
        GetPaymentDetails(int id)
        {
            var paymentDetails =
                await _unitOfWork.paymentRepository.GetPaymentDetails(id);

            if (paymentDetails == null)
            {
                return NotFound();
            }

            return Ok(paymentDetails);
        }

        // PUT: api/PaymentDetail/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult>
        PutPaymentDetails(int id, PaymentDetails paymentDetails)
        {
            if (id != paymentDetails.PaymentDetailsId)
            {
                return BadRequest();
            }

            await _unitOfWork
                .paymentRepository
                .PutPaymentDetails(paymentDetails);

            try
            {
                await _unitOfWork.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentDetailsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PaymentDetail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PaymentDetails>>
        PostPaymentDetails(PaymentDetails paymentDetails)
        {
            await _unitOfWork
                .paymentRepository
                .PostPaymentDetails(paymentDetails);
            await _unitOfWork.SaveAsync();

            return CreatedAtAction("GetPaymentDetails",
            new { id = paymentDetails.PaymentDetailsId },
            paymentDetails);
        }

        // DELETE: api/PaymentDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentDetails(int id)
        {
            _unitOfWork.paymentRepository.DeletePaymentDetails (id);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }

        private bool PaymentDetailsExists(int id)
        {
            return _unitOfWork.paymentRepository.PaymentDetailsExists(id);
        }
    }
}
