using UnityEngine;

public class EnemySearchStateModel : BaseEnemyStateModel
{

    public override void Execute(EnemyView enemy)
    {
        base.Execute(enemy);
        if (enemy.Context.Context.Decision.Values[2] > 0.2f) //если враг близко - запуск стейта на атаку врага
        {
            enemy.State = EnemyState.Attack;
            return;
        }

        if (enemy.Context.Context.Decision.Values[0] > 0f) //если валюта близко - запуск стейта для сбора валюты
        {
            enemy.State = EnemyState.Collect;
            return;
        }
        RandomMove(enemy);
    }

    private void RandomMove(EnemyView enemy)
    {
        _dir = Vector3.up - _enemyTransform.position;
        _enemyTransform.rotation = Quaternion.Slerp(
            enemy.transform.rotation,
            Quaternion.LookRotation(_dir), 
            Time.deltaTime * enemy.ViewParams.RotationSpeed);
        _enemyTransform.position += _enemyTransform.forward * Time.deltaTime * enemy.ViewParams.MoveSpeed;
    }

}