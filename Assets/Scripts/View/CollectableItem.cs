
using UnityEngine;

public class CollectableItem : MonoBehaviour, ICollectableItem
{
    private Transform _target;
    public int Points { get; set; }
    public Transform Target
    {
        get => _target;
        set => _target = value;
    }
}
