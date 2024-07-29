namespace Views.Currency
{
    public interface ICurrency
    {
        public float Amount { get; set; }
        public float Rate { get; set; }
        public float PerTime { get; set; }
        public float TimeToAdding { get; set; }
        public float Timer { get; set; }
    }
}