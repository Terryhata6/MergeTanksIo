using UnityEngine;
public class BaseEnemyStateModel : IEnemyState
{
    protected Vector3 _dir;
    protected Transform _enemyTransform;
    protected float _time;
    public virtual void Execute(EnemyView enemy)
    {
        _enemyTransform = enemy.transform;
    }
}