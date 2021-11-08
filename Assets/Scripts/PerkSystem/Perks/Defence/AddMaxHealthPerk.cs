using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AddMaxHealth", menuName = "ScriptableObjects/AddMaxHealth", order = 1)]
public class AddMaxHealthPerk : AbstractPerk
{
    [SerializeField] private float _health = 50f;
    private PlayerView _player;
    private AddMaxHealthPerk()
    {
        _typePerk = PerkType.Defence;
        _level = 1;
        _maxLevel = 10;
        _health = 50f;
    }

    public override void Activate(PlayerView ownPlayer)
    {
        _player = ownPlayer;
        ownPlayer.SetMaxHealth(ownPlayer.MaxHealth + _health);
    }

    public override void Deactivate(PlayerView ownPlayer)
    {
        ownPlayer.SetMaxHealth(ownPlayer.MaxHealth - _health);
    }

    public override void AddLevel()
    {
        if (CheckLevelUp(_level))
        {
            Debug.Log("Достигнут Максимальный Уровень Перка");
        }
        else
        {
            _level++;
            _player.SetMaxHealth(_player.MaxHealth + _health);
        }
    }

    public override void RemoveLevel()
    {
        if (_level <= 0)
        {
            return;
        }
        else
        {
            _level--;
            _player.SetMaxHealth(_player.MaxHealth - _health);
        }
    }

    private bool CheckLevelUp(int level)
    {
        if (level >= _maxLevel)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}