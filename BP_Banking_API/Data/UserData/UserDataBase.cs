using BP_Banking_API.Models;
using LiteDB;
using System.Collections.Generic;

namespace BP_Banking_API.Data
{
    public class UserDataBase : IUserDataContext
    {
        public LiteDatabase dbUser = new LiteDatabase(@"DataBase/userDB.db");
        public LiteDatabase dbBank = new LiteDatabase(@"DataBase/dbBank.db");
        

        #region Post
        public void AddUser(User u)
        {
            dbUser.GetCollection<User>("Users").Insert(u);
            User user = dbUser.GetCollection<User>("Users").FindOne(item => item.Email.Contains(u.Email));
            CreateUserAccount(u.BankID,user.ID);
        }
        #endregion

        #region Get
        public User GetUserInfo(int id)
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
        public void CreateUserAccount(int bankId, int userID)
        {
            Bank b = dbBank.GetCollection<Bank>("Banks").FindById(bankId);
            b.UserIdAndMoney.Add(userID,0);
            dbBank.GetCollection<Bank>("Banks").Update(bankId, b);
           
        }
        #endregion
        #endregion
    }

}
