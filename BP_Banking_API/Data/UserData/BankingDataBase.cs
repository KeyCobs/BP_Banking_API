using BP_Banking_API.Models;
using LiteDB;

namespace BP_Banking_API.Data
{
    public class BankingDataBase : IBankingContext
    {
        public LiteDatabase dbUser = new LiteDatabase(@"DataBase/userDB.db");
        public LiteDatabase dbBank = new LiteDatabase(@"DataBase/dbBank.db");

        #region User
        #region Post
        public void AddUser(User u)
        {
            dbUser.GetCollection<User>("Users").Insert(u);
            User user = dbUser.GetCollection<User>("Users").FindOne(item => item.Email.Contains(u.Email));
            CreateUserAccount(u.BankID,user.ID);
        }
        #endregion
        #region Get
        public int GetAmountOfUsers()
        {
            return dbUser.GetCollection<User>("Users").FindAll().Count();
        }
        public User GetUserById(int id)
        {
            User temp = dbUser.GetCollection<User>("Users").FindById(id);
            temp.Password = "";
            //Get BankName
            return temp;
        }
        public IEnumerable<User> GetAllUsersWithAllInfo()
        {
            //For testing only
            
            return dbUser.GetCollection<User>("Users").FindAll();
        }
        #endregion
        #region Delete
        public void DeleteUserById(int id)
        {
            dbUser.GetCollection<User>("Users").Delete(id);
        }
        #endregion
        #endregion
        #region Bank
        #region Post
        public void AddBank(Bank b)
        {
            // b.UserIdAndMoney = new Dictionary<int, int>();
            dbBank.GetCollection<Bank>("Banks").Insert(b);
        }
        #endregion
        #region Get
        public IEnumerable<Bank> GetBanks()
        {

            return dbBank.GetCollection<Bank>("Banks").FindAll();
        }
        public Bank GetBankById(int id)
        {
            return dbBank.GetCollection<Bank>("Banks").FindById(id);
        }

        public void AddUserToBank(int userId, int bankId, int userMoney = 0)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Put
        public int GetAmountOfBanks()
        {
            return dbBank.GetCollection<Bank>("Banks").FindAll().Count();
        }
        public int GetAmountOfUsersOfBankById(int id)
        {
            Bank b = dbBank.GetCollection<Bank>("Banks").FindById(id);
            return b.UserIdAndMoney.Count();
        }
        public void TransferMoney(int fromUserId, int toUserId, int amount)
        {
            Bank fub = GetBankById(GetUserById(fromUserId).BankID);
            Bank tub = GetBankById(GetUserById(toUserId).BankID);
            fub.UserIdAndMoney[fromUserId] -= amount;
            tub.UserIdAndMoney[toUserId] += amount;
            dbBank.GetCollection<Bank>("Banks").Update(fub);
            dbBank.GetCollection<Bank>("Banks").Update(tub);
        }
        public void CreateUserAccount(int bankId, int userID)
        {
            Random rand = new Random();
            Bank b = dbBank.GetCollection<Bank>("Banks").FindById(bankId);
            b.UserIdAndMoney.Add(userID,rand.Next(100000));
            dbBank.GetCollection<Bank>("Banks").Update(bankId, b);
           
        }
        #endregion
        #region Delete
        public void DeletebankById(int id)
        {
            dbBank.GetCollection<Bank>("Banks").Delete(id);
        }
        #endregion
        #endregion
    }

}
