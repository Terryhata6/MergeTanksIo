using System;
using UnityEngine;

public class InputEvents
{
  public static InputEvents Current = new InputEvents();

  public event Action<Vector2> OnTouchBegan;

  public void TouchBegan(Vector2 position)
  {
    OnTouchBegan?.Invoke(position);
  }

  public event Action<Vector2> OnTouchMoved;
  public void TouchMoved(Vector2 position)
  {
    OnTouchMoved?.Invoke(position);
  }

  public event Action<Vector2> OnTouchEnded;
  public void TouchEnded(Vector2 position)
  {
    OnTouchEnded?.Invoke(position);

  }
  public event Action<Vector2> OnTouchStationary;
  public void TouchStationary(Vector2 position)
  {
    OnTouchStationary?.Invoke(position);
  }

}