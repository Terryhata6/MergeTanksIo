using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseConfgBuilder : ICommandBuilder
{
    private List<GameObject> _gameObjectsList = new List<GameObject>();
    private List<MeshFilter> _meshFiltersList = new List<MeshFilter>();
    private List<MeshRenderer> _meshRenderersList = new List<MeshRenderer>();
    private List<Transform> _transformOriginModulList = new List<Transform>();
    private ModulTankSO[] _moduls;

    public BaseConfgBuilder(List<Transform> transformOrigin, ModulTankSO[] moduls)
    {
        _transformOriginModulList = transformOrigin;
        _moduls = moduls;
    }

    void ICommand.CommandExecute()
    {
        CreateBaseGameObject();
        Modul();
    }

    void ICommand.CommandExecuteDoOnce(int index)
    {
        DeffineModul(_moduls[index], _moduls[index].ModulType);
    }

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
            _gameObjectsList.Add(go);
        }
    }

    private void Modul()
    {
        foreach (var modul in _moduls)
        {
            DeffineModul(modul, modul.ModulType);
        }
    }

    private void DeffineModul(ModulTankSO modulTank, TypeModul typeModul)
    {
        switch (typeModul)
        {
            case TypeModul.Base:
                Debug.Log(typeModul);
                ChangeComponents(modulTank);
                break;
            case TypeModul.Weapon:
                Debug.Log(typeModul);
                ChangeComponents(modulTank);
                break;
            case TypeModul.Track:
                Debug.Log(typeModul);
                ChangeComponents(modulTank);
                break;
        }
    }

    private void ChangeComponents(ModulTankSO modulTank)
    {
        for (int i = 0; i < _transformOriginModulList.Count; i++)
        {
            var str = _transformOriginModulList[i].name;
            str = str.Replace("Module_", "");
            
            if (str == modulTank.ModulType.ToString())
            {
                _gameObjectsList[i].transform.SetPositionAndRotation(modulTank.Prefab.transform.position, modulTank.Prefab.transform.rotation);
                _gameObjectsList[i].transform.localScale = modulTank.Prefab.transform.lossyScale;
                var modulRenderer = modulTank.Prefab.GetComponent<MeshRenderer>();
                _meshRenderersList[i].material = modulRenderer.sharedMaterial;

                if (modulTank.Prefab.TryGetComponent(out MeshFilter modulMeshFilter))
                {
                    _meshFiltersList[i].mesh = modulMeshFilter.sharedMesh;
                }

            }
        }
    }
}