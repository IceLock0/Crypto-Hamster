using UnityEngine;
using UnityEngine.UI;

public class PhoneStaffButtonView : MonoBehaviour
{
    [SerializeField] private GameObject _staffPanelGO;
    
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(ChangeStaffPanelVisibility);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ChangeStaffPanelVisibility);
    }

    private void ChangeStaffPanelVisibility()
    {
        _staffPanelGO.SetActive(!_staffPanelGO.activeSelf);
    }
}
