namespace Game.Models
{
    public class Machine
    {

        private double _moneyCost;
        private double _sellPrice;
        private double _moneyGame;
        private int _spendTime;
        private bool _broken;
        private bool _full;

        public Machine(double moneyCost, double sellPrice, double moneyGame, int spendTime)
        {
            _moneyCost = moneyCost;
            _sellPrice = sellPrice;
            _moneyGame = moneyGame;
            _spendTime = spendTime;
            _broken = false;
            _full = false;
        }

        public double MoneyCost
        {
            get => _moneyCost;
            set => _moneyCost = value;
        }

        public double SellPrice
        {
            get => _sellPrice;
            set => _sellPrice = value;
        }

        public double MoneyGame
        {
            get => _moneyGame;
            set => _moneyGame = value;
        }

        public int SpendTime
        {
            get => _spendTime;
            set => _spendTime = value;
        }

        public bool Broken
        {
            get => _broken;
            set => _broken = value;
        }

        public bool Full
        {
            get => _full;
            set => _full = value;
        }
    }
}
