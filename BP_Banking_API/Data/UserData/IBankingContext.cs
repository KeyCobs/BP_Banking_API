using BP_Banking_API.Models;

namespace BP_Banking_API.Data
{
    public interface IBankingContext
    {
        #region User
        #region Post
        void AddUser(User u)
        {
            throw new NotImplementedException();
        }

        #endregion
        #region Delete
        public void DeleteUserById(int id);
        #endregion
        #region Get
        public bool PasswordCheck(string password, string email);
        public int GetAmountOfUsers();
        User GetUserById(int id);
        IEnumerable<User> GetAllUsersWithAllInfo();
        #endregion
        #endregion
        #region Bank
        #region Post
        void AddBank(Bank b);
        #endregion
        #region Put
        void CreateUserAccount(int bankId, int userID);
        public void TransferMoney(int fromUserId, int toUserId, int amount);
        #endregion
        #region Get
        public int GetAmountOfUsersOfBankById(int id);
        public int GetAmountOfBanks();
        IEnumerable<Bank> GetBanks();
        Bank GetBankById(int id);
        #endregion
        #region Delete
        public void DeletebankById(int id);
        #endregion



        #endregion
    }
}
