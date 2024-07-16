using Views.Currency;

namespace Presenters.Currency
{
    public class Bitcoin : ICurrency
    {
        public float Rate { get; set; }
        public float AmountPerTime { get; set; }
    }
}