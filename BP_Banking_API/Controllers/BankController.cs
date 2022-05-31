using Microsoft.AspNetCore.Mvc;
using BP_Banking_API.Models;
using BP_Banking_API.Data;

namespace BP_Banking_API.Controllers
{
    [ApiController]
    [Route("Bank")]
    public class BankController : Controller
    {
        private IUserDataContext _dataUser;
        public BankController(IUserDataContext datauser)
        {
            _dataUser = datauser;

        }

        [HttpGet]
        public ActionResult<IEnumerable<Bank>> Get()
        {
            return Ok(_dataUser.GetBanks());
        }
        [HttpGet("{id}")]
        public ActionResult<Bank> Get(int id)
        {
            return Ok(_dataUser.GetBankById(id));
        }
        [HttpPost]
        public ActionResult<Bank> Post(string n)
        {

            Bank bank = new Bank();
            bank.Name = n;
            _dataUser.AddBank(bank);
            return Ok(n + " was added");
        }
    }
}
