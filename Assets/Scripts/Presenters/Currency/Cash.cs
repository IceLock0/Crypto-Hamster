using Views.Currency;

namespace Presenters.Currency
{
    public class Cash : ICurrency
    {
        public float Amount { get; set; }
        public float Rate { get; set; }

        public float AmountPerTime { get; set; } = 0.25f;
        public float TimeToAdding { get; set; } = 1.0f;
        public float Timer { get; set; } = 0.0f;
    }
}