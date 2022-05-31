using BP_Banking_API.Models;

namespace BP_Banking_API.Data
{
    public interface IUserDataContext
    {
        #region Post
        void AddUser(User u)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Get
        User GetUserInfo(int id);
        IEnumerable<User> GetAllUsersWithAllInfo();
        #endregion

        #region Bank
        void AddBank(Bank b);
        IEnumerable<Bank> GetBanks();
        Bank GetBankById(int id);
        void CreateUserAccount(int bankId, int userID);
        #endregion
    }
}
