using UnityEngine;

[System.Serializable]
public struct PerkDataStruct
{
    public enum PerkEffect
    {
        Buff,
        Debuff,
        ProjectileModification,
    }
    [SerializeField] private string _name;
    public string Name => _name;
    [SerializeField] private string _description;
    [SerializeField] private Sprite _sprite;
    public Sprite Sprite => _sprite;
    private PerkType _typePerk;
    public PerkType TypePerk => _typePerk;

    private PerkType _modBelongs;
    public PerkType ModBelongs => _modBelongs;
    private PerkEffect _perkEffect;
    public PerkEffect EffectPerk => _perkEffect;
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

    public void SetTypePerk(PerkType perkType)
    {
        _typePerk = perkType;
    }

    public void SetPerkEffect(PerkEffect perkEffect)
    {
        _perkEffect = perkEffect;
    }

    ///<summary>
    /// PerkType
    ///</summary>
    public void SetModBelongs(PerkType perkType)
    {
        _modBelongs = perkType;
    }
}