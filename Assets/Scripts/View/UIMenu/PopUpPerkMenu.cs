using System.Collections.Generic;
using UnityEngine;


public class PopUpPerkMenu : BaseMenuView
{
    [Header("Panel")]
    [SerializeField] private GameObject _panel;

    [Header("Elements")]
    [SerializeField] private GameObject _perksParent;

    private List<SelectablePerkUIView> _perksUI = new List<SelectablePerkUIView>();
    private SelectablePerkUIView _tempPerkUI;
    private AbstractPerk _tempPerk;
    private string _perkUIPath = "UI/Perk";


    public override void Hide()
    {
        if (!IsShow) return;
        _panel.gameObject.SetActive(false);
        IsShow = false;
        ResetPerks();
    }

    public override void Show()
    {
        if (IsShow) return;
        _panel.gameObject.SetActive(true);
        IsShow = true;
    }

    public void SetupPerks(List<AbstractPerk> perks)
    {
        if (perks.Count != _perksUI.Count)
        {
            if (perks.Count > _perksUI.Count)
            {
                var diff = perks.Count - _perksUI.Count;

                for (int i = 0; i < diff; i++)
                {
                    _tempPerkUI = Instantiate(Resources.Load<SelectablePerkUIView>(_perkUIPath));
                    _tempPerkUI.gameObject.transform.parent = _perksParent.transform;
                    _perksUI.Add(_tempPerkUI);
                    Debug.Log($"√¿Àﬂ, Œ“Ã≈Õ¿ {i}!");
                }
            }
            else
            {
                for (int i = 0; i < (_perksUI.Count - perks.Count); i++)
                {
                    _perksUI.Remove(_perksUI[i]);
                }
            }
        }

        for (int i = 0; i < perks.Count; i++)
        {
            _tempPerk = Instantiate(perks[i]);
            _perksUI[i].Setup(_tempPerk);
        }
    }

    private void ResetPerks()
    {
        for (int i = 0; i < _perksUI.Count; i++)
        {
            _perksUI[i].ResetPerkUI();
        }
    }
}