using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseConfgBuilder : ICommandBuilder
{
    private List<GameObject> _baseGameObjectsList = new List<GameObject>(); // Сюда Записываются Компоненты и тд
    private List<MeshFilter> _meshFiltersList = new List<MeshFilter>();
    private List<MeshRenderer> _meshRenderersList = new List<MeshRenderer>();
    private List<Transform> _transformOriginModulList = new List<Transform>();
    private ModulTankSO[] _moduls;

    public BaseConfgBuilder(List<Transform> transformOrigin, ModulTankSO[] moduls)
    {
        _transformOriginModulList = transformOrigin;
        _moduls = moduls;
    }

    // Выполняется При Инициализации
    void ICommand.CommandExecute()
    {
        CreateBaseGameObject();
        DefaultModul();
    }

    // Выполняется При Нажатии На Кнопу UI
    void ICommand.CommandExecuteDoOnce(ModulTankSO modulTank)
    {
        DeffineModul(modulTank, modulTank.ModulType);
    }

    // Создаем Пустые Обьекты и делаем дочерними, позиционируем, и добовляем компоненты
    private void CreateBaseGameObject()
    {
        foreach (var origin in _transformOriginModulList)
        {
            var go = new GameObject();
            go.transform.parent = origin;
            go.transform.position = origin.position;
            var meshFilter = go.AddComponent<MeshFilter>();
            _meshFiltersList.Add(meshFilter);
            var meshRenderer = go.AddComponent<MeshRenderer>();
            _meshRenderersList.Add(meshRenderer);
            _baseGameObjectsList.Add(go);
        }
    }
    //<<END

    // Ставим Модули По Умолчанию << Исполняем 1 раз при инициализации
    private void DefaultModul()
    {
        foreach (var modul in _moduls)
        {
            DeffineModul(modul, modul.ModulType);
        }
    }
    //<<END

    // Узнайем Какой Тип Модуля И Распределяем туды сюды и тд
    private void DeffineModul(ModulTankSO modulTank, TypeModul typeModul)
    {
        switch (typeModul)
        {
            case TypeModul.Base:
                Debug.Log(typeModul);
                //ChangeComponents(modulTank);
                break;
            case TypeModul.Weapon:
                Debug.Log(typeModul);
                ChangingComponentsTheBaseGameObject(modulTank);
                //SearchOriginModulAndCorrectPosition(modulTank);
                //ChangeComponents(modulTank);
                break;
            case TypeModul.Track:
                Debug.Log(typeModul);
                ChangingComponentsTheBaseGameObject(modulTank);
                //SearchOriginModulAndCorrectPosition(modulTank);
                //ChangeComponents(modulTank);
                break;
        }
    }
    //<<END

    // Добовляем Все Компоненты из базы в наш _baseGameObjectsList
    private void ChangingComponentsTheBaseGameObject(ModulTankSO modulTank)
    {
        GameObject tempBaseGameObject = null;
        Transform tempTransformOrigin = null;
        ModulTankSO tempModulTank;

        for (int i = 0; i < _transformOriginModulList.Count; i++)
        {
            var str = _transformOriginModulList[i].name;
            str = str.Replace("Module_", "");
            if (str == modulTank.ModulType.ToString())
            {
                var modulRenderer = modulTank.Prefab.GetComponent<MeshRenderer>();
                _meshRenderersList[i].material = modulRenderer.sharedMaterial;

                if (modulTank.Prefab.TryGetComponent(out MeshFilter modulMeshFilter))
                {
                    _meshFiltersList[i].mesh = modulMeshFilter.sharedMesh;
                    tempBaseGameObject = _baseGameObjectsList[i];
                    tempTransformOrigin = _transformOriginModulList[i];
                    tempModulTank = modulTank;
                    break;
                }
            }
        }

        if (tempBaseGameObject == null || tempTransformOrigin == null) return;

        SearchOriginModulAndCorrectPosition(tempBaseGameObject, tempTransformOrigin);
    }
    //<<END

    // Поикс Центр Масс (Origin подругому Pivot) И Корректируем позицию Правильно (относительно Позиции _transformOriginModulList)
    private void SearchOriginModulAndCorrectPosition(GameObject baseGameObject, Transform transformOrigin)
    {
        var meshFilter = baseGameObject.GetComponent<MeshFilter>();
        var bound = meshFilter.sharedMesh.bounds;

        var position = new Vector3(0, transformOrigin.position.y - bound.size.y, 0);
        baseGameObject.transform.position = position;

        if(bound.min.y < 0)
        {
            Debug.Log("Да Меньше Епта");
            var pos = baseGameObject.transform.position;
            var r = bound.size.y;
            r = 0f;
            pos.y = r;
            baseGameObject.transform.position = pos;
        }
    }
    //<<END

    private float _boundMinY;
    // private void SearchOriginModulAndCorrectPosition(ModulTankSO modulTank)
    // {
    //     var meshFilter = modulTank.Prefab.GetComponent<MeshFilter>();
    //     var bound = meshFilter.sharedMesh.bounds;
    //     var maxY = bound.max.y;
    //     var minY = bound.min.y;
    //     var ss = bound.size.y;
    //     _boundMinY = ss;
    //     _baseGameObjectsList[1].transform.position = new Vector3(0, _transformOriginModulList[1].position.y - _boundMinY, 0);
    // }

    // private void ChangeComponents(ModulTankSO modulTank)
    // {
    //     for (int i = 0; i < _transformOriginModulList.Count; i++)
    //     {
    //         var str = _transformOriginModulList[i].name;
    //         str = str.Replace("Module_", "");

    //         if (str == modulTank.ModulType.ToString())
    //         {
    //             _baseGameObjectsList[i].transform.SetPositionAndRotation(modulTank.Prefab.transform.position, modulTank.Prefab.transform.rotation);
    //             _baseGameObjectsList[i].transform.position = new Vector3(0, _transformOriginModulList[i].position.y - _boundMinY, 0);
    //             Debug.Log("AAAAAAAAAAAA" + (_transformOriginModulList[i].position.y - _boundMinY));

    //             _baseGameObjectsList[i].transform.localScale = modulTank.Prefab.transform.lossyScale;
    //             var modulRenderer = modulTank.Prefab.GetComponent<MeshRenderer>();
    //             _meshRenderersList[i].material = modulRenderer.sharedMaterial;

    //             if (modulTank.Prefab.TryGetComponent(out MeshFilter modulMeshFilter))
    //             {
    //                 _meshFiltersList[i].mesh = modulMeshFilter.sharedMesh;
    //             }

    //         }
    //     }
    // }

    public void CommandExecuteDoOnce(int index)
    {
        throw new System.NotImplementedException();
    }
}