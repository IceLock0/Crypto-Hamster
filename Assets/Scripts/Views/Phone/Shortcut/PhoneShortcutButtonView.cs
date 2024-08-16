using System;
using UnityEngine;
using UnityEngine.UI;

public class PhoneShortcutButtonView : MonoBehaviour
{
    [SerializeField] private GameObject _phoneGO;
    
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(ChangePhoneVisibility);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ChangePhoneVisibility);
    }

    private void ChangePhoneVisibility()
    {
        _phoneGO.SetActive(!_phoneGO.activeSelf);
    }
}
