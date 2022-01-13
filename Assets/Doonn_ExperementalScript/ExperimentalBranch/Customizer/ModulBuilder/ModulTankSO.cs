using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Modul", menuName = "Customizer/Base/TankModul", order = 1)]
public class ModulTankSO : ScriptableObject
{
    [SerializeField] private TypeModul _typeModul;
    public TypeModul ModulType => _typeModul;
    [SerializeField] private string _name;
    public string Name => _name;
    [SerializeField] private string _description;
    public string Description => _description;
    [SerializeField] private Sprite _sprite;
    public Sprite Sprite => _sprite;
    [SerializeField] private GameObject _prefab;
    public GameObject Prefab => _prefab;

    public Transform PivotTransform => _prefab.transform.GetChild(0);

    // TODO Параметры Но Это Не Точно

    private void OnValidate()
    {
        _name = _prefab.name;
    }
}
