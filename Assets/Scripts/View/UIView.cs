using UnityEngine;

public class UIView : BaseObjectView
{
    [Header("Menues")]
    [SerializeField] private BaseMenuView[] _menues;

    [Header("Pop-Ups")]
    [SerializeField] private PopUpPerkMenu _perksPopUp;

    public BaseMenuView[] Menues => _menues;
    public PopUpPerkMenu PerksPopUp => _perksPopUp;
}