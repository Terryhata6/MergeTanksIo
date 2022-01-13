using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "InputController", menuName = "Input/InputController", order = 1)]
public class InputControllerSO : BaseControllerSO
{
    private Touch _currentTouch;
    private bool _mouseCLickedPreviousFrame;
    private Vector3 _mousePosition;
    private Vector3 _mouseOldPosition;

    public event Action<Vector2> OnMouseBegan;
    private void MouseBegan(Vector2 v2)
    {
        OnMouseBegan?.Invoke(v2);
    }

    public event Action<Vector2> OnMouseMove; //= delegate { };
    private void MouseMove(Vector2 v2)
    {
        OnMouseMove?.Invoke(v2);
        // if (context.phase == InputActionPhase.Canceled)
        //     DisableMouseControlCameraEvent.Invoke();
    }

    public event Action<Vector2> OnMouseEnd;
    private void MouseEnd(Vector2 v2)
    {
        OnMouseEnd?.Invoke(v2);
    }

    public event Action<Vector2> OnMouseStationary;

    private void MouseStationary(Vector2 v2)
    {
        OnMouseStationary?.Invoke(v2);
    }

    public override void Execute()
    {
        //if (!_main.UseMouse)
        //{
        // if (Input.touchCount > 0)
        // {
        //     _currentTouch = Input.GetTouch(0);
        //     switch (_currentTouch.phase)
        //     {
        //         case TouchPhase.Began:
        //             {
        //                 InputEvents.Current.TouchBegan(_currentTouch.position);
        //                 break;
        //             }

        //         case TouchPhase.Ended:
        //             {
        //                 InputEvents.Current.TouchEnded(_currentTouch.position);
        //                 break;
        //             }
        //         case TouchPhase.Moved:
        //             {
        //                 InputEvents.Current.TouchMoved(_currentTouch.position);
        //                 break;
        //             }
        //         case TouchPhase.Stationary:
        //             {
        //                 InputEvents.Current.TouchStationary(_currentTouch.position);
        //                 break;
        //             }
        //         default:
        //             break;
        //     }
        // }
        // }
        //else
        {
            if (_mouseCLickedPreviousFrame)
            {
                if (Input.GetMouseButton(0))
                {
                    _mousePosition = Input.mousePosition;
                    if (_mousePosition == _mouseOldPosition)
                    {
                        MouseStationary(_mousePosition);
                        //Debug.Log("Cтационарно");
                    }
                    else
                    {
                        MouseMove(_mousePosition);
                        //Debug.Log("Мувд");
                    }
                }
                else
                {
                    _mousePosition = Input.mousePosition;
                    MouseEnd(_mousePosition);
                    //Debug.Log("Енд");
                    _mouseCLickedPreviousFrame = false;
                }
            }
            else
            {
                if (Input.GetMouseButton(0))
                {
                    _mouseCLickedPreviousFrame = true;
                    MouseBegan(Input.mousePosition);
                    //Debug.Log("Старт");
                }
            }

            _mouseOldPosition = _mousePosition;
        }
    }
}