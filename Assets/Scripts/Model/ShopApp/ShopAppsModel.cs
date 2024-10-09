using System;
using System.Collections.Generic;
using System.Linq;
using CareBoo.Serially;
using UnityEngine;
using Utils.SerializableKeyValuePair;
using Views.Phone.Apps.ShopApp.RepairKitShop;

namespace Model.ShopApp
{
    public class ShopAppsModel
    {
        private readonly List<SerializableKeyValuePair<SerializableType, ShopView>> _shopViews;
        
        public ShopAppsModel(List<SerializableKeyValuePair<SerializableType, ShopView>> shopViews)
        {
            _shopViews = shopViews;
        }

        public event Action ScreenEnabled;

        public void EnableScreen(Type screenType)
        {
            foreach (var skvp in _shopViews)
            {
                Debug.Log(skvp.Key.Type.Name);
            }
            _shopViews.First(x => x.Key.Type == screenType).Value.gameObject.SetActive(true);
            ScreenEnabled?.Invoke();
        }

        public void DisableScreen()
        { 
            _shopViews.First(x => x.Value.gameObject.activeSelf == true).Value.gameObject.SetActive(false);
        }
    }
}