using UnityEngine;

//Отталкивающие снаряды
[CreateAssetMenu(fileName = "RepulsiveProjectilesPerk", menuName = "ScriptableObjects/RepulsiveProjectiles", order = 1)]
public class RepulsiveProjectilesPerk : AbstractPerk
{
    [SerializeField] private float _distance;

    private RepulsiveProjectilesPerk()
    {
        _typePerk = PerkType.Offence;
        _onEnable = true;
        _distance = 1f;
        _fixedExecute = false;
        _priority = 0;
    }

    public override void Activate(Shooter shoot)
    {
        foreach (var projectile in shoot.ProjectileList)
        {
            //projectile.SetRepulsive (true, _distance);
            //Debug.Log("Repulsive");
            //var tt = Repulsive(projectile, target);
        }
    }
    public override void Deactivate(Shooter shoot)
    {
        foreach (var item in shoot.ProjectileList)
        {
            //item.SetRepulsive (false, _distance);
        }
    }

    public override void Activ(Projectile ownProjectile, GameObject target)
    {
        Debug.Log("Repulsive");
        Repulsive(ownProjectile, target);
    }


    // public override Projectile Active(Projectile projectile, GameObject target)
    // {
    //     SetProjectile(projectile);
    //     SetTarget(target);

    //     Repulsive(_wrappedProjectile, _wrappedTarget);
    //     return _wrappedProjectile;
    // }

    // protected override Projectile SetProjectile(Projectile projectile)
    // {
    //     return _wrappedProjectile = projectile;
    // }

    // protected override GameObject SetTarget(GameObject target)
    // {
    //     return _wrappedTarget = target;
    // }

    public Vector3 Repulsive(Projectile projectile, GameObject target)
    {
        return target.transform.position += projectile.transform.forward * _distance;
    }
}