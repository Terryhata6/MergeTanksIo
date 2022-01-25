using UnityEngine;
public class BaseEnemyStateModel : IEnemyState
{
    protected Vector3 _dir;
    public virtual void Execute(EnemyView enemy)
    {
        enemy.UpdateDebuff();
    }

    protected void GetRandomDirection(out Vector3 dir)
    {
        dir = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
    }

    protected void CountTime(ref float timer)
    {
        timer -= Time.deltaTime;
    }
}