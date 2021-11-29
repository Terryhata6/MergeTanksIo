using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Разрывной снаряд (добавляет АО эффект)
[CreateAssetMenu(fileName = "ExplosiveProjectile", menuName = "ScriptableObjects/ExplosiveProjectile", order = 1)]
public class ExplosiveProjectilePerk : AbstractPerk
{
    [SerializeField] float _exsplosionRadius;


    public override void Activate(BaseProjectile baseProjectile)
    {
        base.Activate(baseProjectile);

        if (baseProjectile.Target == null) return;
        ExplosionDamage(baseProjectile.transform.position, _exsplosionRadius);
    }

    private void ExplosionDamage(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            var obj = hitColliders[i].gameObject;
            if (obj.TryGetComponent(out ITakeDamage iTakeDamage))
            {
                obj.GetComponent<ITakeDamage>().TakeDamage(10f);
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
        // TODO
    }

    protected override void InternalRemoveLevel()
    {
        //TODO
    }
}