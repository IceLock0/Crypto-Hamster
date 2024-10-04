using TMPro;
using UnityEngine;

namespace Views.Hamster
{
    public class HamsterTextComponent : MonoBehaviour
    {
        [SerializeField] private HamsterTextType _textType;
        [SerializeField] private TextMeshProUGUI _text;

        public HamsterTextType TextType => _textType;

        public void SetText(float value)
        {
            switch (_textType)
            {
                case HamsterTextType.Amount:
                    _text.text = $"{value:f8}";
                    break;
                case HamsterTextType.PerClick:
                    _text.text = $"{value:f5}";
                    break;
                case HamsterTextType.PerTime:
                    _text.text = $"{value:f5}";
                    break;
                case HamsterTextType.PerClickPrice:
                    _text.text = $"{value:f4}";
                    break;
                case HamsterTextType.PerTimePrice:
                    _text.text = $"{value:f4}";
                    break;
                case HamsterTextType.Rate:
                    _text.text = $"{value:f7}";
                    break;
            }
        }
    }
}