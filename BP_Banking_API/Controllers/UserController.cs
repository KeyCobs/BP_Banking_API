using Microsoft.AspNetCore.Mvc;
using BP_Banking_API.Data;
using BP_Banking_API.Models;

namespace BP_Banking_API.Controllers
{
    [ApiController]
    [Route("User")]
    public class UserController : Controller
    {
        private IUserDataContext _dataUser;
        public UserController(IUserDataContext datauser)
        {
            _dataUser = datauser;
            
        }

        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            return Ok(_dataUser.GetUserInfo(id));
        }
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return Ok(_dataUser.GetAllUsersWithAllInfo());
            
        }
        [HttpPost]
        public ActionResult<User> Post([FromBody] User u)
        {
            _dataUser.AddUser(u);
            return Ok(u.FullName + " is added");
        }
    }
}
