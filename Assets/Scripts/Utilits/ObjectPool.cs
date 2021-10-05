using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : Component
{
    private Queue<T> _objects = new Queue<T>();
    private GameObject _parent;
    private T _temp;

    public ObjectPool()
    {
        _parent = new GameObject($"{typeof(T)} Pool");
    }
    public void PutObjects(T prefab, float size)
    {
        for (int i=0; i< size; i++)
        {
            _temp = Object.Instantiate(prefab, _parent.transform);
            _temp.gameObject.SetActive(false);
            _objects.Enqueue(_temp);
        }
    }

    public T GetObject()
    {
        _temp = _objects.Dequeue();
        _objects.Enqueue(_temp);
        _temp.gameObject.SetActive(true);
        return _temp;
    }
    public void CleanPool()
    {
        for (int i = 0; i < _objects.Count; i++)
        {
            _temp = _objects.Dequeue();
            Object.Destroy(_temp);
        }
    }

    public void TurnOffObject(T obj)
    {
        obj.gameObject.SetActive(false);
    }
}
