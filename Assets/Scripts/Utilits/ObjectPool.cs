using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : Component
{
    private Queue<T> _objects;
    private List<T> _examples;
    private GameObject _parent;
    private T _temp;

    public void Initialize(List<T> examples, float size) //Инициализация со списком разных префабов
    {
        _parent = new GameObject($"{typeof(T)} Pool");
        _objects = new Queue<T>();
        CleanPool();
        _examples = examples;
        for (int i = 0; i < size; i++)
        {
            FillPool(GetRandomExample());
        }
    }
    public void Initialize(T example, float size) // Инициализация с одним префабом
    {
        _parent = new GameObject($"{typeof(T)} Pool");
        _objects = new Queue<T>();
        _examples = new List<T>();
        _examples.Add(example);
        CleanPool();
        for (int i = 0; i < size; i++)
        {
            FillPool(example);
        }
    }
    private void FillPool(T example) //Метод создания внесения префаба в пул , можно сделать публичным и использовать отдельно 
    {
        _temp = Object.Instantiate(example, _parent.transform);
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
    private void CleanPool()
    {
        for (int i = 0; i < _objects.Count; i++)
        {
            _temp = _objects.Dequeue();
            Object.Destroy(_temp);
        }
    }
}
