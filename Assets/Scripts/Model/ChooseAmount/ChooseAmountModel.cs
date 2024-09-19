using System;

namespace Model.ChooseAmount
{
    public class ChooseAmountModel
    {
        public ChooseAmountModel()
        {
            Amount = 0;
        }
        
        public float Amount { get; private set; }

        public void ChangeAmount(float amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException();
            Amount = amount;
        }
    }
}