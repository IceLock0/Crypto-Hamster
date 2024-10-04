using Presenters.Phone.Apps.ShopApp.RepairKitShop;
using UnityEngine;
using UnityEngine.UI;

namespace Views.Phone.Apps.ShopApp.RepairKitShop
{
    public abstract class ShopView : MonoBehaviour
    {
        [SerializeField] protected Transform ItemContainer;
        [SerializeField] private Button _homeButton;
        
        protected ShopPresenter Presenter;

        protected virtual void Start()
        {
            Presenter.InitializeItems();
        }
        
        private void OnEnable()
        {
            _homeButton.onClick.AddListener(() => gameObject.SetActive(false));
        }

        private void OnDisable()
        {
            _homeButton.onClick.RemoveListener(() => gameObject.SetActive(false));
        }
    }
}