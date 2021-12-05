using UnityEngine;

public class EnemyAttackStateModel : BaseEnemyStateModel
{
    public override void Execute(EnemyView enemy)
    {
        base.Execute(enemy);
        _dir = enemy.Context.DecidedDirection;
        _dir.y = 0.5f;
        _enemyTransform.rotation = Quaternion.Slerp(
            _enemyTransform.rotation,
            Quaternion.LookRotation(_dir), 
            Time.deltaTime * enemy.ViewParams.RotationSpeed);
        if ((_enemyTransform.position - _dir).magnitude > 4f)
        {
            _enemyTransform.position += _enemyTransform.forward * Time.deltaTime * enemy.ViewParams.MoveSpeed;
        }
        if (enemy.Context.Context.Decision.Values[2] < 0.7f)
        {
            enemy.State = EnemyState.Search;
        }
    }
}