using Views.Currency;

namespace Presenters.Currency
{
    public class Ethereum : ICurrency, IExchangeable
    {
        public float Amount { get; set; }
        public float MinRate { get; set; }
        public float Rate { get; set; }
        public float MaxRate { get; set; }

        public float Exchange()
        {
            throw new System.NotImplementedException();
        }

        public void ChangeRate()
        {
            throw new System.NotImplementedException();
        }
        
    }
}