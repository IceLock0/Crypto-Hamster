using Views.Currency;

namespace Presenters.Currency
{
    public class Cash : ICurrency
    {
        public float Rate { get; set; }
    }
}