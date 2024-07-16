using Views.Currency;

namespace Presenters.Currency
{
    public class Ethereum : ICurrency
    {
        public float Rate { get; set; }
        public float AmountPerTime { get; set; }
    }
}