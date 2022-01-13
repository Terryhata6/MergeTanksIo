using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LoadModulTank
{
    private static readonly string _path = "ModulSO";
    private static  GameObject _go;

    private static ModulTankSO[] _modulTankSO;
    
    public static ModulTankSO[] AllLoadModulTank()
    {
        var ss = Resources.LoadAll<ModulTankSO>(_path);
        if(ss == null || ss.Length <= 0) return null;
        var count = ss.Length;

        _modulTankSO = new ModulTankSO[count];
        for (int i = 0; i < _modulTankSO.Length; i++)
        {
            _modulTankSO[i] = ss[i];
        }
        return _modulTankSO;
    }
    
}
