using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBase : UIAbstract
{
  [SerializeField] GameObject _buttonPrefab;

  private void Start()
  {
    var btn = _buttonPrefab.GetComponent<UIButton>();
    btn.InitButton();

    DoonnUI.UIEvents.CurrentUI.OnClickButton += Message;
  }

  private void Message()
  {
    Debug.Log("YEAP");
  }

  // public override void Execute()
  // {
  //   // TODO
  // }
}