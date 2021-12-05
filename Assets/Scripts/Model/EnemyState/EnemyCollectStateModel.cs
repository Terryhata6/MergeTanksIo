
using UnityEngine;
public class EnemyCollectStateModel : BaseEnemyStateModel
{
    public override void Execute(EnemyView enemy)
    {
        base.Execute(enemy);
        _dir = enemy.Context.DecidedDirection;
        _dir.y = 0f;
        
        _enemyTransform.rotation = Quaternion.Slerp(
            _enemyTransform.rotation,
            Quaternion.LookRotation(_dir), 
            Time.deltaTime * 1.3f);
        _enemyTransform.position += _enemyTransform.forward * Time.deltaTime * enemy.ViewParams.MoveSpeed;
        
        if (enemy.Context.Context.Decision.Values[2] > 0.4f || enemy.Context.Context.Decision.Values[0]== 0f)
        {
            enemy.State = EnemyState.Search;
        }
    }
}