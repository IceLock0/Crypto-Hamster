namespace Views.Currency
{
    public interface ICurrency
    {
        public float Rate { get; set; }
        public float AmountPerTime { get; set; }
    }
}