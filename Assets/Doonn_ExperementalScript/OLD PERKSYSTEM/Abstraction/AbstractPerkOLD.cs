// using UnityEngine;

// public enum PerkType
// {
//     Defence,
//     Offence
// }


// public abstract class AbstractPerkOLD : ScriptableObject, IPerk
// {

//     [SerializeField] protected bool _onEnable = false;
//     public bool OnEnable => _onEnable;


//     [SerializeField][Tooltip("Перк Срабатывает при FixedUpdate")] protected bool _fixedExecute;
//     public bool FixedExecute => _fixedExecute;

//     [SerializeField] protected PerkType _typePerk = PerkType.Defence;
//     public PerkType TypePerk => _typePerk;

//     protected int _priority;
//     public int Priority => _priority;

//     [SerializeField] protected int _level = 1;
//     public int Level => _level;

//     [SerializeField] protected int _maxLevel;
//     public int MaxLevel => _maxLevel;

//     protected PlayerView _ownPlayer;
//     protected Shooter _ownShooter;
//     protected Projectile _ownProjectile;

//     public virtual void Activate(PlayerView ownPlayer) { }
//     public virtual void Activate(Shooter ownShoot) { }

//     public virtual void Activate(Projectile ownProjectile, GameObject target) { }
//     public virtual void Activate(Projectile ownProjectile) { }

//     public virtual void Deactivate(PlayerView ownPlayer) { }
//     public virtual void Deactivate(Shooter ownShoot) { }
//     public virtual void Deactivate(Projectile ownProjectile) { }
//     public virtual void Deactivate(Projectile ownProjectile, GameObject target) { }





//     public virtual void AddLevel()
//     {
//         if (_level >= _maxLevel)
//         {
//             Debug.Log("Достигнут Максимальный Уровень Перка");
//         }
//         else
//         {
//             _level++;
//             InternalAddLevel();
//         }
//     }
//     protected abstract void InternalAddLevel();

//     public virtual void RemoveLevel() //<< На Данный Момент Не Используется
//     {
//         if (_level <= 0)
//         {
//             return;
//         }
//         else
//         {
//             _level--;
//             InternalRemoveLevel();
//         }
//     }
//     protected abstract void InternalRemoveLevel(); //<< На Данный Момент Не Используется
// }