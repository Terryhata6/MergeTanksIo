using System.Collections.Generic;
using UnityEngine;

public class ModulTankBuilder : MonoBehaviour
{
    //[SerializeField] private List<Transform> _transformOriginModulList = new List<Transform>();
    #region BaseModuls
    [SerializeField] private List<Transform> _transformPivotList = new List<Transform>();
    [SerializeField] private List<GameObject> _go;

    [SerializeField] private List<S_Modul> _modulPivotList;
    #endregion

    //[SerializeField] private List<Transform> _extractPivotList = new List<Transform>();
    private List<ICommandBuilder> _commandsList = new List<ICommandBuilder>();
    //private ModulTankSO[] _moduls;

    private GameObject _tempGo;

    // Исполняется когда Что то меняется в инспекторе >> OnValidate()
    // Не Даем Добавлять Больше Двух Элементов
    private void OnValidate()
    {
        if (_transformPivotList.Count > 4)
        {
            for (int i = 3; i < _transformPivotList.Count; i++)
            {
                _transformPivotList.RemoveAt(i);
            }
        }
    }
    //<<END

    public void Init()
    {
        if (_transformPivotList.Count <= 0 || _transformPivotList == null) return;

        // _moduls = LoadModulTank.AllLoadModulTank();
        // if (_moduls == null) return;

        //var extractPivot = _moduls[0].Prefab.transform.GetChild(0).transform.GetChild(0);// Спускаемся По Ирархии, DebugLog();
        //_extractPivotList.Add(extractPivot);
        //_commandsList.Add(new BaseConfgBuilder(_transformOriginModulList, baseModuls));
        _commandsList.Add(new ConstructorTank(_transformPivotList, _go, _modulPivotList));
        // ExecuteBuilder();
    }

    private void OnEnable()
    {
        UICustomizerEvent.Current.OnGetModulTank += Click;
    }
    private void OnDisable()
    {
        UICustomizerEvent.Current.OnGetModulTank -= Click;
    }

    public void Click(ModulTankSO modulTank)
    {
        foreach (var command in _commandsList)
        {
            command.CommandExecute(modulTank);
        }
    }

    private void ExecuteBuilder()
    {
        foreach (var command in _commandsList)
        {
            command.CommandInit();
        }
    }

    // private void SearchBaseOriginModule()
    // {
    //     //TODO
    // }

    // private void AddExtractPivot(Transform trans)
    // {
    //     if (!_extractPivotList.Contains(trans))
    //     {
    //         _extractPivotList.Add(trans);
    //     }
    // }
}