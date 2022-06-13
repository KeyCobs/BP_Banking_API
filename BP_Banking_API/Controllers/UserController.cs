using Microsoft.AspNetCore.Mvc;
using BP_Banking_API.Data;
using BP_Banking_API.Models;

namespace BP_Banking_API.Controllers
{
    [ApiController]
    [Route("User")]
    public class UserController : Controller
    {
        private IBankingContext _dataUser;
        public UserController(IBankingContext datauser)
        {
            _dataUser = datauser;
            
        }

        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            return Ok(_dataUser.GetUserById(id));
        }
        [HttpGet]
        [Route("Users/NumberOfUsers")]
        public ActionResult<int> GetTotalUsers()
        {
            return Ok(_dataUser.GetAmountOfUsers());
        }
        [HttpGet]
        [Route("UserInfo")]
        public ActionResult<IEnumerable<User>> Get()
        {
            return Ok(_dataUser.GetAllUsersWithAllInfo());
            
        }
        [HttpGet]
        [Route("passwordCheck")]
        public ActionResult<bool> Get(string p, string e)
        {
            return Ok(_dataUser.PasswordCheck(p,e));

        }
        [HttpPost]
        [Route("AddUser")]
        public ActionResult<User> Post([FromBody] User u)
        {
            _dataUser.AddUser(u);
            return Ok(u.FullName + " is added");
        }
        [HttpDelete]
        [Route("DeleteUser")]
        public ActionResult<User> Delete(int id)
        {
            User u = _dataUser.GetUserById(id);
            _dataUser.DeleteUserById(id);
            return Ok(u.FullName + " was deleted");
        }
    }
}
