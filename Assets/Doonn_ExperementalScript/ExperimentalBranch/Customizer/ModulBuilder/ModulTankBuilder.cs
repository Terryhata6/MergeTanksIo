using System.Collections.Generic;
using UnityEngine;

public class ModulTankBuilder : MonoBehaviour
{
    [SerializeField] private List<Transform> _transformOriginModulList = new List<Transform>();
    private List<ICommandBuilder> _commandsList = new List<ICommandBuilder>();
    private ModulTankSO[] _moduls;

    public void Init()
    {
        _moduls = LoadModulTank.AllLoadModulTank();
        Debug.Log(_moduls);
        if (_moduls == null) return;
        _commandsList.Add(new BaseConfgBuilder(_transformOriginModulList, _moduls));
        ExecuteBuilder();
    }
    public void Click(ModulTankSO modulTank)
    {
        foreach (var command in _commandsList)
        {
            command.CommandExecuteDoOnce(modulTank);
        }
    }

    private void ExecuteBuilder()
    {
        foreach (var command in _commandsList)
        {
            command.CommandExecute();
        }
    }

    private void SearchBaseOriginModule()
    {
        //TODO
    }
}