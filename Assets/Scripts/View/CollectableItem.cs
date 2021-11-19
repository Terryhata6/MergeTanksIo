
using UnityEngine;

public class CollectableItem : MonoBehaviour, ICollectableItem
{
    private Transform _target;
    private int _points = 1;
    public int Points // Дописать логику занесения количества поинтов
    {
        get => _points;
        set => _points = value;
    } 
    public Transform Target
    {
        get => _target;
        set => _target = value;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer.Equals((int)Layer.Enemies) || other.gameObject.layer.Equals( (int)Layer.Players))
        {
            _target = other.transform; // когда игрок приближается к коину, он становится целью для коина, к которой он летит
            GameEvents.Current.ItemCollected(this);
        }
    }

    private void OnDisable()
    {
        Target = null;
        GameEvents.Current.CollectableDisable(this);
    }
    
}
