using UnityEngine;

//Отталкивающие снаряды
[CreateAssetMenu(fileName = "RepulsiveProjectiles", menuName = "Perks/Projectile/RepulsiveProjectiles", order = 1)]
public class RepulsiveProjectilesPerk : AbstractPerk
{
  [SerializeField] private float _distance;

  private Vector3 _startPos;
  private Vector3 _endPos;
  private float _passetDistance;

  public override void ActivateModification(BaseProjectile ownProjectile)
  {
    if (ownProjectile.Target == null) return;
    base.ActivateModification(ownProjectile);
    _target = ownProjectile.Target;
    _startPos = _ownProjectile.transform.position;
    _endPos = _ownProjectile.transform.forward * _distance;
    _endPos = _endPos - _startPos;
  }
  public override void ExecuteDebuff(IStatusEffect basePersonView)
  {
    base.ExecuteDebuff(basePersonView);
    if (_target == null) return;
    _target.transform.position += _ownProjectile.transform.forward * _distance * Time.deltaTime;
    _passetDistance = FitRange(_target.transform.position.sqrMagnitude, _startPos.sqrMagnitude, _endPos.sqrMagnitude, 0, 100);
    Debug.Log("REPULSIVE : " + _passetDistance);
  }

  public override bool RemoveDebuff()
  {
    base.RemoveDebuff();
    if (2 > 22)
    {
      _passetDistance = 0;
      return true;
    }
    else
    {
      return false;
    }

  }

  private float FitRange(float current, float inMin, float inMax, float outMin, float outMax)
  {
    return (current - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
  }

  // public override void Activate(BaseProjectile ownProjectile)
  // {
  //   if(ownProjectile.Target == null) return;

  //   Repulsive(ownProjectile, ownProjectile.Target);
  // }

  // private Vector3 Repulsive(BaseProjectile projectile, GameObject target)
  // {
  //   return target.transform.position += (projectile.transform.forward * _distance * Time.deltaTime);
  // }

  // public override void Deactivate(BaseProjectile ownProjectile)
  // {
  //   // TODO
  // }

  protected override void InternalAddLevel()
  {
    _distance++;
  }

  protected override void InternalRemoveLevel()
  {
    // TODO
  }
}