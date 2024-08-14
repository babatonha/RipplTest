using Microsoft.AspNetCore.Mvc;
using Rippl.BusinessLayer.Interfaces.Services;
using Rippl.DataLayer.Models;

namespace Rippl.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VoucherController : ControllerBase
    {
        private readonly IVoucherService _voucherService;
        public VoucherController(IVoucherService voucherService)
        {
            _voucherService = voucherService;
        }

        [HttpGet("ListVouchers")]
        public async Task<ActionResult<IEnumerable<Voucher>>>ListVouchers()
        {
            var results = await _voucherService.ListVouchers();

            if(!results.Any())
            {
                return NotFound();
            }

            return Ok(results);
        }

        [HttpGet("SelectVoucherAndAmount/{id}")]
        public async Task<ActionResult<Voucher>> SelectVoucherAndAmount(int id)
        {
            var results = await _voucherService.SelectVoucherAndAmount(id);

            if (results == null)
            {
                return NotFound();
            }

            return Ok(results);
        }
    }
}
