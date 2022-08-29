using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using RestSharp;

namespace EbuyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubMemberController : ControllerBase
    {
        private IClubMemberService _clubMemberService;
        public ClubMemberController(IClubMemberService clubMemberService)
        {
            _clubMemberService = clubMemberService;
        }
        [HttpPost("Login")]
        public async Task<ActionResult<ClubMember>> Login(string userName, string passwrod)
        {
            try
            {
                var boolean = await _clubMemberService.LoginClubMembers(userName, passwrod);
                return Ok(boolean);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPost("Register")]
        public async Task<ActionResult<bool>> Register(ClubMember user)
        {
            try
            {
                var boolean = _clubMemberService.RegisterClubMembers(user);
                return Ok(boolean.Result);
                //return Ok(true);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPost("AddBogoProductTocart")]
        public async Task<ActionResult<List<Product>>> AddBogoProductTocart(ClubMember user) // include checking if he deserved it and if not return empty cart
        {
            try
            {
                var res = await _clubMemberService.GetBogoProducts(user);
                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<List<ClubMember>>> GetAllUsers()
        {
            try
            {
                var res = await _clubMemberService.GetAllClubMembers();
                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
