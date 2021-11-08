using UnityEngine;

public class EnemySearchStateModel : BaseEnemyStateModel
{
    private Vector3 _direction;

    public override void Execute(EnemyView enemy)
    {
        base.Execute(enemy);
        if (enemy.Context.Context.Decision.Values[2] > 0.7f) //если враг близко - запуск стейта на атаку врага
        {
            enemy.State = EnemyState.Attack;
            return;
        }

        if (enemy.Context.Context.Decision.Values[0] > 0f) //если валюта близко - запуск стейта для сбора валюты
        {
            enemy.State = EnemyState.Collect;
            return;
        }

        RandomMove(enemy.transform);

    }

    private void RandomMove(Transform enemy)
    {
        GetRandomDirection(enemy.position);
        enemy.position = Vector3.MoveTowards(enemy.position, _direction, Time.deltaTime * 5f);
    }

    private void GetRandomDirection(Vector3 position)
    {
        if ((position - _direction).magnitude < 2f || _direction == Vector3.zero)
        {
            position.x += Random.Range(-40f, 40f);
            position.z += Random.Range(-40f, 40f);
            _direction = position;
        }
    }

}