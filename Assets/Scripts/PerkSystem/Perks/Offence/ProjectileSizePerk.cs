using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileSize", menuName = "ScriptableObjects/ProjectileSize", order = 1)]
public class ProjectileSizePerk : AbstractPerk
{
    [SerializeField] float _size;


    private ProjectileSizePerk()
    {
        _onEnable = true;
        _typePerk = PerkType.Offence;
        _size = 0.1f;

        _level = 1;
        _maxLevel = 5;
    }

    public override void Activ(Projectile projectile)
    {
        projectile.gameObject.transform.localScale += new Vector3(_size, _size, _size);
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
            _size += 0.1f;
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
            _size -= 0.1f;
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