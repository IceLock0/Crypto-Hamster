using Presenters.UI.ComputerControlPanel.BuyButton;
using Views.UI.ButtonUI;

namespace Views.UI.ComputerControlPanel.BuyButton
{
    public class BuyButtonView : ButtonView
    {
        protected override void Awake()
        {
            base.Awake();
            BuyButtonPresenter = new BuyButtonPresenter();
        }
        
        public BuyButtonPresenter BuyButtonPresenter;

        protected override void ButtonClicked()
        {
            BuyButtonPresenter.BuyButtonClicked();
        }
    }
}