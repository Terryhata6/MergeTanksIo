
using UnityEditor;
using UnityEngine;
public class EnemyCollectStateModel : BaseEnemyStateModel
{
    public override void Execute(EnemyView enemy)
    {
        base.Execute(enemy);
        _dir = enemy.Context.DecidedDirection;
        _dir.y = 0f;
        enemy.transform.position += enemy.transform.forward * Time.deltaTime * 5f;
        enemy.transform.rotation = Quaternion.Slerp(
            enemy.transform.rotation,
            Quaternion.LookRotation(_dir), 
            Time.deltaTime * 3f);
        if (enemy.Context.Context.Decision.Values[2] > 0.4f || enemy.Context.Context.Decision.Values[0]== 0f)
        {
            enemy.State = EnemyState.Search;
        }
    }
}