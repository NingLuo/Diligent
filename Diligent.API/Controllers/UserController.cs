using System;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
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

        [ResponseType(typeof(User))]
        [HttpPost]
        public IHttpActionResult CreateUser(User user)
        {
            if (!ModelState.IsValid) return BadRequest();

            if (_userBs.CreateUser(user)) return Created(new Uri(Request.RequestUri + "/" + user.Id), user);

            foreach (var error in _userBs.ErrorList)
            {
                ModelState.AddModelError("", error);
            }
            return BadRequest(ModelState);
        }
    }
}
