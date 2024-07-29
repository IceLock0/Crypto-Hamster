using Views.Currency;

namespace Presenters.Currency
{
    public class Solana : ICurrency
    {
        public float Amount { get; set; }
        public float Rate { get; set; }
        public float PerTime { get; set; } = 10.001f;
        public float TimeToAdding { get; set; } = 1.0f;
        public float Timer { get; set; } = 0.0f;
    }
}