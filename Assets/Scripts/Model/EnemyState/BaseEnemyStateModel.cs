using UnityEngine;
public class BaseEnemyStateModel : IEnemyState
{
    protected Vector3 _dir;
    protected Transform _enemyTransform;
    public virtual void Execute(EnemyView enemy)
    {
        _enemyTransform = enemy.transform;

    }
}