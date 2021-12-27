using System;
using UnityEngine;

public class UICustomizerEvent : MonoBehaviour
{
    public static UICustomizerEvent Current = new UICustomizerEvent();

    public event Action<int> OnBtnClick;
    public void OnClickBtn(int Id)
    {
        OnBtnClick?.Invoke(Id);
    }

    public event Action<ModulTankSO> OnGetModulTank;
    public void GetModulTank(ModulTankSO modulTank)
    {
        OnGetModulTank?.Invoke(modulTank);
    }


}