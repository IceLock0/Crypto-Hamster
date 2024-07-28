using Views.Currency;

namespace Presenters.Currency
{
    public class Hamster : ICurrency
    {
        public float Amount { get; set; }
        public float Rate { get; set; }
        public float AmountPerClick { get; set; }
        public float AmountPerTime { get; set; }
        public float AmountOfIncreaseMoneyPerClick { get; set; }
        public float AmountOfIncreaseMoneyPerTime { get; set; }
        public float TimeToAdding { get; set; }
        public float Timer { get; set; }
    }
}