using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : Component
{
    private List<T> _objects;
    private List<T> _examples;
    private GameObject _parent;
    private T _temp;

    public ObjectPool()
    {
        _objects = new List<T>();
        _examples = new List<T>();
    }

    public void Initialize(List<T> examples, float size) //������������� �� ������� ������ ��������
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
    public void Initialize(T example, float size) // ������������� � ����� ��������
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

    private void FillPool(T example) //����� �������� � �������� ������� � ��� , ����� ������� ��������� � ������������ �������� 
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
        if (_objects.Count == 0 || _objects[0].gameObject.activeSelf)
        {
            if (GetRandomExample() == null) return null;
            FillPool(GetRandomExample());
            _objects.Add(_objects[0]);
            _objects[0] = _objects[_objects.Count - 2];
            _objects.RemoveAt(_objects.Count - 2);
        }
        _temp = _objects[0];
        _objects.RemoveAt(0);
        _objects.Add(_temp);
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
