namespace Presenters.Currency
{
    public interface IExchangeable
    {
        public float MinRate { get; set; }

        public float Rate { get; set; }

        public float MaxRate { get; set; }

        public float GetSellAmount();
        public void ChangeRate();
    }
}