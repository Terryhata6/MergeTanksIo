using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Debuff
{
  public float Duration { get; set; }
  public float Damage { get; set; }
  private float _tempTime;

  private BasePersonView _basePersonView;

  public void Apply(BasePersonView basePersonView)
  {
    _basePersonView = basePersonView;
    basePersonView.AddDebuff(this);
  }

  public void Remove()
  {
    _basePersonView.RemoveDebuff(this);
  }

  public virtual void Tick()
  {
    _tempTime += Time.deltaTime;

    if (_tempTime <= Duration)
    {
      Remove();
    }
    Debug.Log("TICK DEBUFF");
  }
}