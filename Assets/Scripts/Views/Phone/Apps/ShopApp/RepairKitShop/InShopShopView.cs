using System;
using UnityEngine;
using UnityEngine.UI;

namespace Views.Phone.Apps.ShopApp.RepairKitShop
{
    public class InShopShopView : MonoBehaviour
    {
        [SerializeField] private Button _homeButton;

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