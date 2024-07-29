using Views.Currency;

namespace Presenters.Currency
{
    public class Hamster : ICurrency
    {
        public float Amount { get; set; }
        public float Rate { get; set; }
        public float PerClick { get; set; }
        public float PerTime { get; set; }
        public float UpgradePerClickValue { get; set; }
        public float UpgradePerTimeValue { get; set; }
        public float UpgradePerClickPrice { get; set; }
        public float UpgradePerTimePrice { get; set; }
        public float TimeToAdding { get; set; }
        public float Timer { get; set; }
    }
}