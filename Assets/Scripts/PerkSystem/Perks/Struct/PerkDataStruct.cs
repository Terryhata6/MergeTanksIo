using UnityEngine;

[System.Serializable]
public struct PerkDataStruct
{
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private PerkType _typePerk;
    public PerkType TypePerk => _typePerk;
    [SerializeField] private int _priority;
    public int Priority => _priority;
    [SerializeField] private int _level;
    public int Level => _level;
    [SerializeField] private int _maxLevel;
    public int MaxLevel => _maxLevel;

    public void ChangeLevel(int level)
    {
        _level = level;
    }

    public void ChangeMaxLevel(int maxLevel)
    {
        _maxLevel = maxLevel;
    }
}