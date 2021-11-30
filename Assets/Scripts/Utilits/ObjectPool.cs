using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : Component
{
    private Queue<T> _objects;
    private List<T> _examples;
    private GameObject _parent;
    private T _temp;

    public ObjectPool()
    {
        _objects = new Queue<T>();
        _examples = new List<T>();
    }

    public void Initialize(List<T> examples, float size) //Инициализация со списком разных префабов
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
    public void Initialize(T example, float size) // Инициализация с одним префабом
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

    private void FillPool(T example) //Метод создания и внесения префаба в пул , можно сделать публичным и использовать отдельно 
    {
        _temp = GameObject.Instantiate(example, _parent.transform);
        _temp.gameObject.SetActive(false);
        _objects.Enqueue(_temp);
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
        if (_objects.Count == 0)
        {
            if (GetRandomExample() == null) return null;
            FillPool(GetRandomExample());
        }
        _temp = _objects.Dequeue();
        _objects.Enqueue(_temp);
        _temp.gameObject.SetActive(true);
        return _temp;
    }
    public T GetObject(Vector3 pos)
    {
        if (_objects.Count == 0)
        {
            if (GetRandomExample() == null) return null;
            FillPool(GetRandomExample());
        }
        _temp = _objects.Dequeue();
        _objects.Enqueue(_temp);
        _temp.transform.position = pos;
        _temp.gameObject.SetActive(true);
        return _temp;
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
