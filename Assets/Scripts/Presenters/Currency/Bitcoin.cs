using Views.Currency;

namespace Presenters.Currency
{
    public class Bitcoin : ICurrency, IExchangeable
    {
        public float Amount { get; set; }

        public float MinRate { get; set; }
        public float Rate { get; set; }
        public float MaxRate { get; set; }

        public float Exchange()
        {
            var targetAmount = Amount * Rate;
            Amount = 0;
            return targetAmount;
        }

        public void ChangeRate()
        {
            throw new System.NotImplementedException();
        }
    }
}