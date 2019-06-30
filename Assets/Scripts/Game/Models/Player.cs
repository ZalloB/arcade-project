namespace Game.Models
{
    public class Player
    {
        private string _companyName;

        private double _money;

        private Shop _shop;

        private string _currency;

        public Player(string companyName, double startMoney, Shop shop)
        {
            _companyName = companyName;
            _shop = shop;
            _money = startMoney;
            _currency = " €";
        }

        public string CompanyName
        {
            get => _companyName;
            set => _companyName = value;
        }

        public double Money
        {
            get => _money;
            set => _money = value;
        }

        public Shop Shop
        {
            get => _shop;
            set => _shop = value;
        }

        public string Currency
        {
            get => _currency;
            set => _currency = value;
        }
    }
}
