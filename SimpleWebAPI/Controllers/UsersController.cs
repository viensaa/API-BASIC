using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleWebAPI.Data.DAL;
using SampleWebAPI.Models;
using SampleWebAPI.Services;
using SimpleWebAPI.DTO;
using User = SampleWebAPI.Domain.User;

namespace SampleWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private readonly IUser _userDAL;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService,IMapper mapper,IUser UserDAL)
        {
            _userService = userService;
            _userDAL = UserDAL;
            _mapper = mapper;
        }

        [HttpPost("Login")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Login(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Post(RegisterDTO registerDTO)
        {
            try
            {
                var newUser = _mapper.Map<User>(registerDTO);
                var result = await _userDAL.Insert(newUser);
                //var Read = _mapper.Map<UserDTO>(result);
                return Ok("Data baru berhasil di tambahkan");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }



    }
}