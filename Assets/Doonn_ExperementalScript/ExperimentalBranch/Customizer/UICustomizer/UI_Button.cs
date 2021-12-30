using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Button : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Image _image;
    [SerializeField] private Text _text;

    public int ID {get;set;}
    public TypeModul Type;

    public void BtnInit()
    {
        _button.onClick.AddListener(Click);
    }

    private void Click()
    {
        Debug.Log("SSS: " + ID);
        UICustomizerEvent.Current.OnClickBtn(ID, Type);
    }

    public void SetImage(Image image)
    {
        _image = image;
    }

    public void SetText(string text)
    {
        _text.text = text;
    }
}