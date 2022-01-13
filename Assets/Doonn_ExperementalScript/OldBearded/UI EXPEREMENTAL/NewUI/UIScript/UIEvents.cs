using System;

namespace DoonnUI
{
    public class UIEvents
    {
        public static UIEvents CurrentUI = new UIEvents();

        public event Action OnClickButton;
        public void Click()
        {
            OnClickButton?.Invoke();
        }
    }
}