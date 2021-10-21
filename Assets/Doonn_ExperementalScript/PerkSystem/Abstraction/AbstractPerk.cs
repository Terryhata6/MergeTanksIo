using UnityEngine;
public enum PerkType
{
   Defence,
   Offence
}


public abstract class AbstractPerk : ScriptableObject
{
   [SerializeField] private string _name;
   [SerializeField] private string _description;

   [SerializeField] private PerkType _typePerk;
   public PerkType TypePerk => _typePerk;
   
   [SerializeField] private int _perkID;
   public int PerkID => _perkID;
   
   public virtual void Activate (PlayerView ownPerk) { }
   public virtual void Activate (Shooter ownShoot) { }
}