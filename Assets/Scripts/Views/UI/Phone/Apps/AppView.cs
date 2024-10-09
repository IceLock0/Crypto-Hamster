using UnityEngine;
using Views.UI.Phone.Apps.HomeButton;
using Zenject;

namespace Views.UI.Phone.Apps
{
    public class AppView: MonoBehaviour
    {
        private HomeButtonView _homeButton;

        [Inject]
        public void Initialize(HomeButtonView homeButton)
        {
            _homeButton = homeButton;
        }
        
        private void OnEnable()
        {
            _homeButton.HomeButtonClicked += DisableScreen;
        }

        private void DisableScreen()
        {
            gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            _homeButton.HomeButtonClicked -= DisableScreen;
        }
    }
}