using UnityEngine;
using UnityEngine.UI;

namespace Views.UI.ButtonUI
{
    [RequireComponent(typeof(Button))]
    public abstract class ButtonView : MonoBehaviour
    {
        private Button _button;
        
        protected virtual void Awake()
        {
            _button = GetComponent<Button>();
        }

        protected virtual void OnEnable()
        {
            _button.onClick.AddListener(ButtonClicked);
        }
        
        private void OnDisable()
        {
            _button.onClick.RemoveListener(ButtonClicked);
        }
        
        protected abstract void ButtonClicked();
    }
}