using System;
using UnityEngine;
using UnityEngine.UI;

public class UIButton : UIAbstract
{
    [SerializeField] private Button _btn;
    [SerializeField] private Image _img;
    [SerializeField] private Text _text;

    // private AbstractPerk _perk;

    //Test
    //private PlayerView _view;
    //<<End
    public void InitButton()
    {
        Debug.Log("Init Button");
        _btn.onClick.AddListener(OnButton);
    }

    private void OnButton()
    {
        DoonnUI.UIEvents.CurrentUI.Click();
        Debug.Log("Click BUTTON");
        // Debug.Log("Button Click");
        // Debug.Log(_perk);
        // var instPerk = Instantiate(_perk);
        // _view.PerkManager.AddPerk(instPerk);
    }

    // public void SetPerk(AbstractPerk perk)
    // {
    //     _perk = perk;
    //     SetImage(perk.PerkData.Sprite);
    //     SetText(perk.PerkData.Name);
    // }

    public void SetImage(Sprite img)
    {
        _img.sprite = img;
    }

    public void SetText(string text)
    {
        _text.text = text;
    }

    // public static UIButton GetUIComponent()
    // {
    //     return new UIButton();
    // }
}