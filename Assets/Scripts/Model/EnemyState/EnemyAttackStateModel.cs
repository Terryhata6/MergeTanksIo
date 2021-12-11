using UnityEngine;

public class EnemyAttackStateModel : BaseEnemyStateModel
{
    public override void Execute(EnemyView enemy)
    {
        base.Execute(enemy);
        // if (_time <= 0)
        // {
        //     _dir = enemy.Context.DecidedDirection;
        //     _dir.y = 0f;
        //     _time = 1f;
        // }
        // _time -= Time.deltaTime;
        _dir = enemy.Context.DecidedDirection; 
        _dir.y = 0f;
        _enemyTransform.rotation = Quaternion.Slerp(
            _enemyTransform.rotation,
            Quaternion.LookRotation(_dir), 
            Time.deltaTime * enemy.ViewParams.RotationSpeed); 
        _enemyTransform.position += _enemyTransform.forward * Time.deltaTime * enemy.ViewParams.MoveSpeed;
        
        if (enemy.Context.Context.Decision.Values[2] < 0.4f)
        {
            enemy.State = EnemyState.Search;
        }
    }
}