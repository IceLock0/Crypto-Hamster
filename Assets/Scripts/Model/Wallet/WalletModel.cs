namespace Model.Wallet
{
    public class WalletModel
    {
        public float Amount { get; private set; }

        public WalletModel()
        {
            Amount = 10;
        }

        public void SetAmount(float amount)
        {
            Amount = amount;
        }
    }
}