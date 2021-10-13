using UnityEngine;
using UnityEngine.UI;

public class WinMenuView : BaseMenuView
{
    [Header("Panel")]
    [SerializeField] private GameObject _panel;

    [Header("Elements")]
    [SerializeField] private Button _buttonNext;


    private void Awake()
    {
        _buttonNext.onClick.AddListener(UIEvents.Current.ButtonNextLevel);
    }


    public override void Hide()
    {
        if (!IsShow) return;
        _panel.gameObject.SetActive(false);
        IsShow = false;
    }

    public override void Show()
    {
        if (IsShow) return;
        _panel.gameObject.SetActive(true);
        IsShow = true;
    }

    private void OnDestroy()
    {
        _buttonNext.onClick.RemoveAllListeners();
    }
}