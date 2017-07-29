using System;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using AutoMapper;
using Diligent.API.Dtos;
using Diligent.BLL;
using Diligent.BOL;

namespace Diligent.API.Controllers
{
    [EnableCors("http://localhost:11932", "*", "*")]
    public class UserController : ApiController
    {
        private readonly UserBs _userBs;

        public UserController(UserBs userBs)
        {
            _userBs = userBs;
        }

        [ResponseType(typeof(User))]
        [HttpGet]
        public IHttpActionResult GetUserById(int id)
        {
            var userInDb = _userBs.GetUserById(id);

            if (userInDb == null) return NotFound();

            return Ok(userInDb);
        }

        [ResponseType(typeof(UserDto))]
        [HttpPost]
        public IHttpActionResult CreateUser(UserDto userDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = Mapper.Map<UserDto, User>(userDto);

            if (_userBs.CreateUser(user))
            {
                userDto.Id = user.Id;
                return Created(new Uri(Request.RequestUri + "/" + userDto.Id), userDto);
            }

            foreach (var error in _userBs.ErrorList)
            {
                ModelState.AddModelError("", error);
            }
            return BadRequest(ModelState);
        }
    }
}
