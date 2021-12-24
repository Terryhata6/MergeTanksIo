using UnityEngine;
public class BaseEnemyStateModel : IEnemyState
{
    protected Vector3 _dir;
    protected Transform _enemyTransform;
    protected float _time;
    public virtual void Execute(EnemyView enemy)
    {
        _enemyTransform = enemy.transform;

        //>> Doonn
        /*
        Я думаю надо добавить EnemyState.Dead.
        что бы была проверка стоит ли апдейтить ну это не точно
        Пример:
        if(!enemy.state == EnemyState.Dead)
        {
          enemy.UpdateDebuff();
        }
        */
        enemy.UpdateDebuff();
        //<<END
    }
}