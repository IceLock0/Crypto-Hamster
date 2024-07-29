using Views.Currency;

namespace Presenters.Currency
{
    public class Ethereum : ICurrency
    {
        public float Amount { get; set; }
        public float Rate { get; set; }
        public float PerTime { get; set; } = 100f;
        public float TimeToAdding { get; set; } = 1.0f;
        public float Timer { get; set; } = 0.0f;
    }
}