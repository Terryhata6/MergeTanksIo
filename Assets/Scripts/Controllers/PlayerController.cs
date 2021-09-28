using UnityEngine;

public class PlayerController : BaseController
{
    private PlayerView _player;
    
    
    public PlayerView Player => _player;
    private Vector2 _beganPosition;
    
    public override void Initialize()
    {
        _player = GameObject.FindObjectOfType<PlayerView>();
        if (_player != null)
        {
            Debug.Log(_player.gameObject.name);
        }
        else
        {
            Debug.Log("Не сработало");
        }

        InputEvents.Current.OnTouchBegan += SetBeganPosition;
    }

    private void SetBeganPosition(Vector2 position)
    {
        _beganPosition = position;
        Debug.Log("Нажалось");
    }

    public override void Execute()
    {
        
    }
}
