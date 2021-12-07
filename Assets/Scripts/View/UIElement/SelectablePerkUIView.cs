using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Image))]
public class SelectablePerkUIView : MonoBehaviour
{
    [SerializeField] private Button _buttonSelect;

    private Sprite _defaultImage;
    private Image _image;
    private AbstractPerk _perk;


    private void Awake()
    {
        _image = GetComponent<Image>();
        _defaultImage = _image.sprite;
    }

    public void Setup(AbstractPerk perk)
    {
        _perk = perk;
        _image.sprite = _perk.PerkData.Sprite;
        _buttonSelect.onClick.AddListener(() => UIEvents.Current.ButtonSelectPerk(_perk));
    }

    public void ResetPerkUI()
    {
        _perk = null;
        _image.sprite = _defaultImage;
        _buttonSelect.onClick.RemoveAllListeners();
    }
}