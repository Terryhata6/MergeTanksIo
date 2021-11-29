
using UnityEngine;

public class CollectableItem : MonoBehaviour, ICollectableItem
{
    private Transform _target;
    private int _points = 1;
    public int Points // �������� ������ ��������� ���������� �������
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
        if (other.gameObject.layer.Equals(Layers.Enemies) || other.gameObject.layer.Equals(Layers.Players))
        {
            _target = other.transform; // ����� ����� ������������ � �����, �� ���������� ����� ��� �����, � ������� �� �����
            GameEvents.Current.ItemCollected(this);
        }
    }

    private void OnDisable()
    {
        Target = null;
        GameEvents.Current.CollectableDisable(this);
    }
    
}
