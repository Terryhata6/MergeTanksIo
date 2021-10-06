using UnityEngine;

public class InputController : BaseController
{
    private MainController _main;
    private Touch _currentTouch;
    private bool _mouseCLickedPreviousFrame;
    private Vector3 _mousePosition;
    private Vector3 _mouseOldPosition;

    public override void Initialize()
    {
    }

    public InputController SetMainController(MainController main)
    {
        _main = main;
        return this;
    }

    public override void Execute()
    {
        if (!_main.UseMouse)
        {
            if (Input.touchCount > 0)
            {
                _currentTouch = Input.GetTouch(0);
                switch (_currentTouch.phase)
                {
                    case TouchPhase.Began:
                    {
                        InputEvents.Current.TouchBegan(_currentTouch.position);
                        break;
                    }

                    case TouchPhase.Ended:
                    {
                        InputEvents.Current.TouchEnded(_currentTouch.position);
                        break;
                    }
                    case TouchPhase.Moved:
                    {
                        InputEvents.Current.TouchMoved(_currentTouch.position);
                        break;
                    }
                    case TouchPhase.Stationary:
                    {
                        InputEvents.Current.TouchStationary(_currentTouch.position);
                        break;
                    }
                    default: break;
                }
            }
        }
        else
        {
            if (_mouseCLickedPreviousFrame)
            {
                if (Input.GetMouseButton(0))
                {
                    _mousePosition = Input.mousePosition;
                    if (_mousePosition == _mouseOldPosition)
                    {
                        InputEvents.Current.TouchStationary(_mousePosition);
                        //Debug.Log("Cтационарно");
                    }
                    else
                    {
                        InputEvents.Current.TouchMoved(_mousePosition);
                        //Debug.Log("Мувд");
                    }
                }
                else
                {
                    _mousePosition = Input.mousePosition;
                    InputEvents.Current.TouchEnded(_mousePosition);
                    //Debug.Log("Енд");
                    _mouseCLickedPreviousFrame = false;
                }
            }
            else
            {
                if (Input.GetMouseButton(0))
                {
                    _mouseCLickedPreviousFrame = true;
                    InputEvents.Current.TouchBegan(Input.mousePosition);
                    //Debug.Log("Старт");
                }
            }

            _mouseOldPosition = _mousePosition;
        }
    }
}