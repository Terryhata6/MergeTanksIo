using UnityEngine;

public class EnemyAttackStateModel : BaseEnemyStateModel
{
    public override void Execute(EnemyView enemy)
    {
        base.Execute(enemy);
        Debug.Log("attak");
        if (enemy.Context.Context.Decision.Values[2] < 0.7f)
        {
            enemy.State = EnemyState.Search;
        }
    }
}