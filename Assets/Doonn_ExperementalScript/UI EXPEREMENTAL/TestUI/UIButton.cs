using UnityEngine;
using UnityEngine.UI;

public class UIButton : UIAbstract
{
    [SerializeField] private Button _btn;
    [SerializeField] private Image _img;
    [SerializeField] private Text _text;

    private AbstractPerk _perk;

    //Test
    private PlayerView _view;
    //<<End
    private void TT()
    {
        _view = FindObjectOfType<PlayerView>();

        _btn.onClick.AddListener(OnClickButton);
    }

    private void OnClickButton()
    {
        Debug.Log("Button Click");
        Debug.Log(_perk);
        var instPerk = Instantiate(_perk);
        _view.PerkManager.AddPerk(instPerk);
    }

    public void SetPerk(AbstractPerk perk)
    {
        _perk = perk;
        SetImage(perk.PerkData.Sprite);
        SetText(perk.PerkData.Name);
    }

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