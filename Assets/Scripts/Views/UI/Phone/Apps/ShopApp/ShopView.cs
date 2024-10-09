using Presenters.Phone.Apps.ShopApp.RepairKitShop;
using UnityEngine;
using Views.UI.Phone.Apps.HomeButton;
using Zenject;

namespace Views.Phone.Apps.ShopApp.RepairKitShop
{
    public abstract class ShopView : MonoBehaviour
    {
        [SerializeField] protected Transform ItemContainer;
        
        private HomeButtonView _homeButton;
        
        protected ShopPresenter Presenter;

        [Inject]
        public void Initialize(HomeButtonView homeButton)
        {
            _homeButton = homeButton;
        }

        protected virtual void Start()
        {
            Presenter.InitializeItems();
        }
        
        private void OnEnable()
        {
            Presenter.Enable();
            _homeButton.HomeButtonClicked += DisableScreen;
        }

        private void DisableScreen()
        {
            gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            Presenter.Disable();
            _homeButton.HomeButtonClicked -= DisableScreen;
        }
    }
}