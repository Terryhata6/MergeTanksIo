using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEvent
{
    public static UIEvent CurrentUI = new UIEvent();

    public event Action OnClickButton;
    public void Click()
    {
        OnClickButton?.Invoke();
    }
}