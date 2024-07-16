using Views.Currency;

namespace Presenters.Currency
{
    public class Cash : ICurrency
    {
        public float Rate { get; set; }
        
        public float AmountPerTime { get; set; }
    }
}