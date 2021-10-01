using UnityEngine;

public class InputController : BaseController
{
    public InputController(MainController main) { }
    private Touch _currentTouch;
    
    public override void Initialize()
    {
    }

    public override void Execute()
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
}