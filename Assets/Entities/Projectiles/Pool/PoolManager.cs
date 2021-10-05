using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager<T> where T : MonoBehaviour
{
    
    public T Prefab { get; }
    public bool AutoExpand { get; set; }
    public Transform Container { get; }
    private List<T> _pool;

    public PoolManager (T prefab, int count)
    {
        Prefab = prefab;

        CreatePool (count);
    }

    public PoolManager (T prefab, int count, Transform container)
    {
        Prefab = prefab;
        if (Prefab == null)
        {
            throw new System.Exception ($"Пулл не установлен {typeof(T)}: Тобишь на прифабе {typeof(GameObject)} Должен Висеть Скрипт {typeof(T)}"); 
        }
        Container = container;
        CreatePool (count);
    }

    private void CreatePool (int count)
    {
        _pool = new List<T> ();

        for (int i = 0; i < count; i++)
        {
            CreateObjects();
        }
    }

    private T CreateObjects (bool isActiveDefault = false)
    {
        var createObject = Object.Instantiate(Prefab, Container);
        createObject.gameObject.SetActive(isActiveDefault);

        _pool.Add(createObject);
        return createObject;
    }

    public bool HasFreeObject(out T elem)
    {
        foreach (var item in _pool)
        {
            if(!item.gameObject.activeInHierarchy)
            {
                elem = item;
                item.gameObject.SetActive(true);
                return true;
            }
        }
        elem = null;
        return false;
    }

    public T GetFreeObject()
    {
        if(HasFreeObject(out var elem))
        {
            return elem;
        }

        if(AutoExpand) return CreateObjects(true);

        throw new System.Exception($"Нету Свободных Элементов{typeof(T)}");
    }
}
