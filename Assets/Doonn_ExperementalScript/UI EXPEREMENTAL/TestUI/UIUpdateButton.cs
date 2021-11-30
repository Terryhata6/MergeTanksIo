using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUpdateButton : UIAbstract
{

    [SerializeField] public Button _button;
    public List<AbstractPerk> Perks = new List<AbstractPerk>();

    void Start()
    {
        _button.onClick.AddListener(OnClickButton);
    }


    private void OnClickButton()
    {
        Perks = LoadPerksSystem.GetRandomPerkList(3);
        UIEvent.CurrentUI.Click();
    }
}