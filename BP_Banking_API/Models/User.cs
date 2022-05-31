namespace BP_Banking_API.Models
{
    public class User
    {
        public int ID { get; private set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public int BankID { get; set; }
        public string Email { get; set; }

    }
}
