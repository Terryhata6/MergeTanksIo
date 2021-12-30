using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructorTank : ICommandBuilder
{
    // private List<Transform> _pivotList = new List<Transform>();
    // private List<GameObject> _gos;
    // private List<MeshFilter> _meshFilterList = new List<MeshFilter>();
    // private List<MeshRenderer> _meshRenderList = new List<MeshRenderer>();

    private Dictionary<TypeModul, GameObject> _dict = new Dictionary<TypeModul, GameObject>();
    private List<S_Modul> _pivotModulList;
    //private ModulTankSO _tempModul;
    //private GameObject _tempGameObject;

    public ConstructorTank(List<Transform> pivots, List<GameObject> gos, List<S_Modul> pivotModulList)
    {
        // _pivotList = pivots;
        // _gos = gos;
        _pivotModulList = pivotModulList;

        //HardCode
        // for (int i = 0; i < gos.Count; i++)
        // {
        //     _meshFilterList.Add(gos[i].GetComponent<MeshFilter>());
        //     _meshRenderList.Add(gos[i].GetComponent<MeshRenderer>());
        // }

        // _dict.Add(TypeModul.Base, _gos[0]);
        // _dict.Add(TypeModul.Weapon, _gos[1]);
        // _dict.Add(TypeModul.Track, _gos[2]);
        //<<END Быстро Блиять Переделал
    }

    public void CommandExecute(ModulTankSO modulTank)
    {
        DefineModulType(modulTank);
    }

    private void DefineModulType(ModulTankSO modulTank)
    {
        switch (modulTank.ModulType)
        {
            case TypeModul.Base:
                ExtractModulPivot(modulTank);
                break;
            case TypeModul.Weapon:
                ChangeComponentGameObject(modulTank.ModulType, modulTank.Prefab);
                break;
            case TypeModul.Track:
                Debug.Log("TRACK: >> " + modulTank.Prefab);
                ChangeComponentGameObject(modulTank.ModulType, modulTank.Prefab);
                break;
        }
    }

    private void ExtractModulPivot(ModulTankSO modulTank)
    {
        // Hard Code
        foreach (var pivot in _pivotModulList)
        {
            if (pivot.Pivot.transform.name == "Pivot_Base") continue;

            if (pivot.Pivot.transform.name == modulTank.PivotTransform.transform.GetChild(0).name)
            {
                pivot.Pivot.position = modulTank.PivotTransform.transform.GetChild(0).transform.position;
                pivot.Pivot.rotation = modulTank.PivotTransform.transform.GetChild(0).transform.rotation;
            }
            if (pivot.Pivot.transform.name == modulTank.PivotTransform.transform.GetChild(1).name)
            {
                pivot.Pivot.position = modulTank.PivotTransform.transform.GetChild(1).transform.position;
                pivot.Pivot.rotation = modulTank.PivotTransform.transform.GetChild(1).transform.rotation;

            }
            if (pivot.Pivot.transform.name == modulTank.PivotTransform.transform.GetChild(2).name)
            {
                pivot.Pivot.position = modulTank.PivotTransform.transform.GetChild(2).transform.position;
                pivot.Pivot.rotation = modulTank.PivotTransform.transform.GetChild(2).transform.rotation;
            }

        }
        //<<END Переделать Блиять Быстро Нахуй

        ChangeComponentGameObject(modulTank.ModulType, modulTank.Prefab.transform.GetChild(0).gameObject);
    }

    private void ChangeComponentGameObject(TypeModul modulType, GameObject modulPrefab)
    {

        if (modulType == TypeModul.Track)
        {
            TT(modulType, modulPrefab);
            return;
        }

        for (int i = 0; i < _pivotModulList.Count; i++)
        {
            if (_pivotModulList[i].ModulType == modulType)
            {
                if (modulPrefab.TryGetComponent(out MeshFilter meshFilter))
                {
                    _pivotModulList[i].RefGameObject.GetComponent<MeshFilter>().mesh = meshFilter.sharedMesh;
                }
                if (modulPrefab.TryGetComponent(out MeshRenderer renderMesh))
                {
                    _pivotModulList[i].RefGameObject.GetComponent<MeshRenderer>().material = renderMesh.sharedMaterial;
                }
            }
        }

        // GameObject val;
        // if (_dict.TryGetValue(modulType, out val))
        // {
        //     if (modulPrefab.TryGetComponent(out MeshFilter meshFilter))
        //     {
        //         val.GetComponent<MeshFilter>().mesh = meshFilter.sharedMesh;
        //     }
        //     if (modulPrefab.TryGetComponent(out MeshRenderer renderMesh))
        //     {
        //         val.GetComponent<MeshRenderer>().material = renderMesh.sharedMaterial;
        //     }
        // }
    }

    public void TT(TypeModul modulType, GameObject modulPrefab)
    {
        for (int i = 0; i < _pivotModulList.Count; i++)
        {
            if (_pivotModulList[i].ModulType == modulType)
            {
                for (int t = 0; t < modulPrefab.transform.childCount; t++)
                {
                    if (modulPrefab.transform.GetChild(t).TryGetComponent(out MeshFilter meshFilter))
                    {
                        _pivotModulList[i].RefGameObject.GetComponent<MeshFilter>().mesh = meshFilter.sharedMesh;
                    }
                    if (modulPrefab.transform.GetChild(t).TryGetComponent(out MeshRenderer renderMesh))
                    {
                        _pivotModulList[i].RefGameObject.GetComponent<MeshRenderer>().material = renderMesh.sharedMaterial;
                    }
                }
            }

            // Debug.Log("ASDASDASDAD");
            // GameObject val;
            // if (_dict.TryGetValue(modulType, out val))
            // {
            //     if (modulPrefab.transform.GetChild(i).TryGetComponent(out MeshFilter meshFilter))
            //     {
            //         val.GetComponent<MeshFilter>().mesh = meshFilter.sharedMesh;
            //     }
            //     if (modulPrefab.transform.GetChild(i).TryGetComponent(out MeshRenderer renderMesh))
            //     {
            //         val.GetComponent<MeshRenderer>().material = renderMesh.sharedMaterial;
            //     }
            // }
        }
    }

    public void CommandInit()
    {
        //throw new System.NotImplementedException();
    }
}