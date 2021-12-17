using System.Collections.Generic;
using UnityEngine;
using Utilits;

public class ObjectPool<T> : Singleton<ObjectPool<T>>
    where T : Component
{
    private List<T> _objects;
    private List<T> _examples;
    private GameObject _parent;
    private T _temp;

    public ObjectPool()
    {
        _objects = new List<T>();
        _examples = new List<T>();
        Instance = this;
    }

    public void Initialize(List<T> examples, int size) 
    {
        CleanPool();
        if (examples.Count > 0)
        {
            _parent = new GameObject($"{typeof(T)} Pool");
            _examples = examples;
            for (int i = 0; i < size; i++)
            {
                FillPool(GetRandomExample());
            }
        }
    }
    public void Initialize(T example, int size) 
    {
        CleanPool();
        if (example)
        {
            _parent = new GameObject($"{typeof(T)} Pool");
            _examples.Add(example);
            for (int i = 0; i < size; i++)
            {
                FillPool(example);
            }
        }
    }

    private void FillPool(T example) 
    {
        _temp = GameObject.Instantiate(example, _parent.transform);
        _temp.gameObject.SetActive(false);
        _objects.Add(_temp);
    }

    private T GetRandomExample()
    {
        if (_examples.Count == 0)
        {
            return null;
        }
        return _examples[Random.Range(0, _examples.Count)];
    }

    public T GetObject()
    {
        return  GetObject(Vector3.up * 100f);
    }
    public T GetObject(Vector3 pos)
    {
        if (_objects.Count == 0 )
        {
            if (GetRandomExample() == null) return null;
            FillPool(GetRandomExample());
        }
        _temp = _objects[0];
        _objects.RemoveAt(0);
        _temp.transform.position = pos;
        _temp.gameObject.SetActive(true);
        return _temp;
    }

    public void AddObject(T obj)
    {
        _objects.Add(obj);
    }
    
    public void CleanPool()
    {
        if (_parent)
        {
            GameObject.Destroy(_parent);
        }
        _examples.Clear();
        _objects.Clear();
    }
}
