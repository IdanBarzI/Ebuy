using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace EbuyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CasualCustomerController : Controller
    {
        ICasualCustomerService _casualCustomerService;
        public CasualCustomerController(ICasualCustomerService casualCustomerService)
        {
            _casualCustomerService = casualCustomerService;
        }
        [HttpPost("Register")]
        public async Task<ActionResult<CasualCustomer>> Register(CasualCustomer user)
        {
            try
            {
                var boolean =await _casualCustomerService.RegisterCasualCustomer(user);
                return Ok(boolean);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
