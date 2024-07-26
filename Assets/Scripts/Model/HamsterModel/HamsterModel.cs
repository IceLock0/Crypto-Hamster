namespace Model.HamsterModel
{
    public class HamsterModel
    {
        public double Money { get; private set; }
        public double MoneyPerClick { get; private set; }
        public double MoneyPerSecond { get; private set; }
        public float TimeToAddMoney { get; private set; }
        
        
        public HamsterModel()
        {
            Money = 0.0f;

            MoneyPerClick = 123.4567891011213f;

            MoneyPerSecond = 100.100100f;

            TimeToAddMoney = 1.0f;
        }
        
        public void SetMoney(double value)
        {
            Money = value;
        }

        public void SetMoneyPerSecond(double value)
        {
            MoneyPerSecond = value;
        }
    }
}