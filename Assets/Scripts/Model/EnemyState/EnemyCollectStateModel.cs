using Polarith.AI.Move;
using UnityEngine;
public class EnemyCollectStateModel : BaseEnemyStateModel
{
    public override void Execute(EnemyView enemy)
    {
        base.Execute(enemy);
        enemy.transform.position += enemy.Context.DecidedDirection * Time.deltaTime * 5f;
        enemy.transform.rotation = Quaternion.LookRotation(enemy.Context.DecidedDirection);
        if (enemy.Context.Context.Decision.Values[2] > 0.4f || enemy.Context.Context.Decision.Values[0]== 0f)
        {
            enemy.State = EnemyState.Search;
        }
    }
}