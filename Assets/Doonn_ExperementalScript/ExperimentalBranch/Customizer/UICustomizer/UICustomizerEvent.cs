using System;
using UnityEngine;

public class UICustomizerEvent : MonoBehaviour
{
    public static UICustomizerEvent Current = new UICustomizerEvent();

    public event Action<int, TypeModul> OnBtnClick;
    public void OnClickBtn(int Id, TypeModul modulType)
    {
        OnBtnClick?.Invoke(Id, modulType);
    }

    public event Action<ModulTankSO> OnGetModulTank;
    public void GetModulTank(ModulTankSO modulTank)
    {
        OnGetModulTank?.Invoke(modulTank);
    }
}