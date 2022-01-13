using UnityEngine;

// Разрывной снаряд (добавляет АО эффект)
[CreateAssetMenu(fileName = "ExplosiveProjectile", menuName = "Perks/Projectile/ExplosiveProjectile", order = 1)]
public class ExplosiveProjectilePerk : AbstractPerk
{
    [SerializeField] float _exsplosionRadius;
    [SerializeField] float _exsplosionRadiusPerLevel;

    private ExplosiveProjectilePerk()
    {
        _perkData.SetModBelongs(PerkType.ProjectileMod);
        _perkData.SetTypePerk(PerkType.Offence);
        _modificationType = TypeModification.Modification;
    }

    public override void ActivateModification(BaseProjectile baseProjectile)
    {
        base.ActivateModification(baseProjectile);
        if (baseProjectile.Target == null) return;
        ExplosionDamage(baseProjectile.transform.position, _exsplosionRadius);
    }

    private void ExplosionDamage(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            var obj = hitColliders[i].gameObject;
            if (obj.TryGetComponent(out IApplyDamage iTakeDamage))
            {
                obj.GetComponent<IApplyDamage>().TakeDamage(10f);
            }
        }
        //DebugExsplosionRadius(center, radius);
    }

    void DebugExsplosionRadius(Vector3 center, float radius)
    {
        var mySphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        Destroy(mySphere.GetComponent<Collider>()); 
        mySphere.transform.position = center;
        mySphere.transform.localScale *= radius;
    }


    protected override void InternalAddLevel()
    {
        _exsplosionRadius += _exsplosionRadiusPerLevel;
    }

    protected override void InternalRemoveLevel()
    {
        //TODO
    }
}