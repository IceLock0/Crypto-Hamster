using Views.Currency;

namespace Presenters.Currency
{
    public class Solana : ICurrency
    {
        public float Rate { get; set; }
        public float AmountPerTime { get; set; }
    }
}