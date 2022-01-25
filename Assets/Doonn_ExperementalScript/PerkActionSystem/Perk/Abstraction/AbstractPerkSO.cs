using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlackRainbow.PerkSystem
{
    public abstract class AbstractPerkSO : ScriptableObject
    {
        #region DataPerk
        public enum TypePerk
        {
            PlayerModification,
            WeaponModification,
            ProjectileModification,
        }

        [SerializeField] private string _name;
        [SerializeField] private string _description;
        [SerializeField] private TypePerk _typePerk;
        public TypePerk PerkType => _typePerk;

        [SerializeField] private int _level = 1;
        public int Level => _level;
        [SerializeField] private int _maxLevel = 3;
        public int MaxLevel => _maxLevel;
        #endregion

        [SerializeField] protected AbstractActionPerkSO[] _actions;

        public virtual void ActivatePerkPlayer(BasePersonView playerView)
        {

        }

        public virtual void UpdateOverTime(BasePersonView playerView)
        {

        }

        public AbstractActionPerkSO[] GetActions()
        {
            return _actions;
        }











        #region Default Recommended
        public void AddLevel()
        {
            if (_level >= _maxLevel)
            {
                Debug.Log("Достигнут Максимальный Уровень Перка");
            }
            else
            {
                _level++;
                InternalAddLevel();
            }
        }
        protected abstract void InternalAddLevel();

       /*  public void RemoveLevel() //<< На Данный Момент Не Используется
        {
            if (_perkData.Level <= 0)
            {
                return;
            }
            else
            {
                _perkData.ChangeLevel(_perkData.Level - 1);
                InternalRemoveLevel();
            }
        }
        protected abstract void InternalRemoveLevel(); //<< На Данный Момент Не Используется */
        #endregion
    }
}