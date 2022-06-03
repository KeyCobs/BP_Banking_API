using Microsoft.AspNetCore.Mvc;
using BP_Banking_API.Models;
using BP_Banking_API.Data;

namespace BP_Banking_API.Controllers
{
    [ApiController]
    [Route("Bank")]
    public class BankController : Controller
    {
        private IBankingContext _dataUser;
        public BankController(IBankingContext datauser)
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
        [HttpGet]
        [Route("bank/amountofbanks")]
        public ActionResult<int> GetNumberOfBanks()
        {
            return Ok(_dataUser.GetAmountOfBanks());
        }
        [HttpGet]
        [Route("bank/numberofusers")]
        public ActionResult<Bank> GetNumberofUsersInBank(int id)
        {
            return Ok(_dataUser.GetAmountOfUsersOfBankById(id));
        }

        [HttpPost]
        public ActionResult<Bank> Post(string name)
        {

            Bank bank = new Bank();
            bank.Name = name;
            _dataUser.AddBank(bank);
            return Ok(name + " was added");
        }
        [HttpPut]
        public ActionResult<Bank> Put(int sendId, int recieveId, int amount)
        {
            _dataUser.TransferMoney(sendId, recieveId, amount);
            return Ok("Money was transferd");
        }
        [HttpDelete]
        public ActionResult<Bank> Delete(int id)
        {
            Bank b = _dataUser.GetBankById(id);
            _dataUser.DeletebankById(id);
            return Ok(b.Name + " Was Deleted");
        }
    }
}
