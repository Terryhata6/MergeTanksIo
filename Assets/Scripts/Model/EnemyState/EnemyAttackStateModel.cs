using UnityEngine;

public class EnemyAttackStateModel : BaseEnemyStateModel
{
    public override void Execute(EnemyView enemy)
    {
        base.Execute(enemy);
        Debug.Log("attak");
        enemy.transform.position += enemy.Context.DecidedDirection * Time.deltaTime * 5f;
        enemy.transform.rotation = Quaternion.LookRotation(enemy.Context.DecidedDirection);
        if (enemy.Context.Context.Decision.Values[2] < 0.7f)
        {
            enemy.State = EnemyState.Search;
        }
    }
}