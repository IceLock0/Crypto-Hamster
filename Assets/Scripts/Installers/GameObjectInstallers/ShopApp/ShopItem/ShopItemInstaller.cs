using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Installers.GameObjectInstallers.ShopApp.ShopItem
{
    public class ShopItemInstaller : MonoInstaller<ShopItemInstaller>
    {
        [SerializeField] private Button _buyButton;
        [SerializeField] private TMP_Text _itemName;
        [SerializeField] private Image _itemImage;
        
        public override void InstallBindings()
        {
            BindBuyButton();
            BindItemName();
            BindItemImage();
        }

        private void BindItemImage()
        {
            Container.Bind<Image>()
                .FromInstance(_itemImage)
                .AsSingle()
                .NonLazy();
        }

        private void BindItemName()
        {
            Container.Bind<TMP_Text>()
                .FromInstance(_itemName)
                .AsSingle()
                .NonLazy();
        }

        private void BindBuyButton()
        {
            Container.Bind<Button>()
                .FromInstance(_buyButton)
                .AsSingle()
                .NonLazy();
        }
    }
}