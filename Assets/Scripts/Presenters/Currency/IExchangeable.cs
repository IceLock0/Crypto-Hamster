namespace Presenters.Currency
{
    public interface IExchangeable
    {
        public float MinRate { get; set; }

        public float Rate { get; set; }

        public float MaxRate { get; set; }

        public float Sell();
        public void Buy(float amount);
        public void ChangeRate();
    }
}