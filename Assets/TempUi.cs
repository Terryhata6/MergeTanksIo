
using UnityEngine;
using UnityEngine.UI;

public class TempUi : MonoBehaviour
{
    [SerializeField] private Button _start;

    [SerializeField] private Button _next;
    void Start()
    {
        _start.onClick.AddListener(LevelEvents.Current.PlayerSelected);
        _start.onClick.AddListener(LevelEvents.Current.LevelStarted);
        _next.onClick.AddListener(LevelEvents.Current.LevelEnded);
    }


}
