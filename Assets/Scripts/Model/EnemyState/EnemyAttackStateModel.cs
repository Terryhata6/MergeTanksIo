
public class EnemyAttackStateModel : BaseEnemyStateModel
{
    public override void Execute(EnemyView enemy)
    {
        base.Execute(enemy);
        
        enemy.GetAimDirect(out _dir);
        enemy.Move(_dir);
        
        if (enemy.AIMEnemyValue.Equals(0f))
        {
            enemy.TurnOnAllSeek();
            enemy.State = EnemyState.Search;
        }
    }
}