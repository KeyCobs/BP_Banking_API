namespace BP_Banking_API.Models
{
    public class Bank
    {
        public Bank()
        {
            UserIdAndMoney = new Dictionary<int, int>();
        }
        public int ID { get; private set; }
        public string Name { get; set; }
        public Dictionary<int, int> UserIdAndMoney { get;  set; }
    }
}
