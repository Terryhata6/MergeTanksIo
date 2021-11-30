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
        _dir = _direction;
        enemy.transform.position += enemy.transform.forward * Time.deltaTime * 5f;
        enemy.transform.rotation = Quaternion.Slerp(
            enemy.transform.rotation,
            Quaternion.LookRotation(_dir - enemy.transform.position), 
            Time.deltaTime * 3f);
    }

    private void GetRandomDirection(Vector3 position)
    {
        if ((position - _direction).magnitude < 2f || _direction.Equals(Vector3.zero))
        {
            position.x += Random.Range(-40f, 40f);
            position.z += Random.Range(-40f, 40f);
            _direction = position;
        }
    }

}