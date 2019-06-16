using Random = UnityEngine.Random;

namespace Game.Models
{
    public class Client
    {
        private double _money;
        private string _type;
        private bool _busy;

        #region needs

        //basic needs for the clients
        private double _hungry;
        private double _bath;

        #endregion

        public Client()
        {
            _money = Random.Range(40, 150);
            _hungry = 100;
            _bath = 100;
            _busy = false;
        }

        public double Money
        {
            get => _money;
            set => _money = value;
        }

        public string Type
        {
            get => _type;
            set => _type = value;
        }

        public double Hungry
        {
            get => _hungry;
            set => _hungry = value;
        }

        public double Bath
        {
            get => _bath;
            set => _bath = value;
        }

        public bool Busy
        {
            get => _busy;
            set => _busy = value;
        }
    }
}
