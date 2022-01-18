
public class EnemySearchStateModel : BaseEnemyStateModel
{
    public override void Execute(EnemyView enemy)
    {
        base.Execute(enemy);
        if (enemy.AIMEnemyValue > 0f) //если враг близко - запуск стейта на атаку врага
        {
            enemy.TurnOnSeek(SeekLabels.Enemy);
            enemy.State = EnemyState.Attack;
            enemy.CoolDown = 1f;
            return;
        }
        
        if (enemy.AIMMergeValue > 0f) //если враг близко - запуск стейта на атаку врага
        {
            enemy.TurnOnSeek(SeekLabels.Merge);
            enemy.State = EnemyState.Merge;
            enemy.CoolDown = 1f;
            return;
        }

        if (enemy.AIMCollectableValue > 0f) //если валюта близко - запуск стейта для сбора валюты
        {
            enemy.State = EnemyState.Collect;
            enemy.CoolDown = 1f;
            return;
        }

        if (enemy.OnBorderOfMap)
        {
            enemy.CoolDown *= 0.1f;
        }

        if (enemy.CoolDown <= 0f)
        {
            enemy.CoolDown = 7f;
            GetRandomDirection(out _dir);
        }

        enemy.CountReactionCooldown();
        enemy.Move(_dir);
    }
}