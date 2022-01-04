using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Button_ModulType: MonoBehaviour
{
    [SerializeField] private Button _btn;

    [SerializeField] private Sprite _btnSprite;

    private void OnValidate()
    {
        SetSprite(_btnSprite);
    }

    public void Init()
    {
        _btn.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        //TODO
        
    }

    public void SetSprite(Sprite sprite)
    {
        _btn.image.sprite = sprite;
    }
}