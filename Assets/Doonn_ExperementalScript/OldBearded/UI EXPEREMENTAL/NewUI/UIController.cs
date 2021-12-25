using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoonnUI
{
    public class UIController
    {
        private List<UIAbstract> _uiList;
        
        private void Execute()
        {
            foreach (var ui in _uiList)
            {
                //ui.Execute();
            }
        }
    }
}