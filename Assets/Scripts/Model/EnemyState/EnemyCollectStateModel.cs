
public class EnemyCollectStateModel : BaseEnemyStateModel
{
    public override void Execute(EnemyView enemy)
    {
        base.Execute(enemy);
        
        enemy.GetAimDirect(out _dir);
        enemy.Move(_dir);
        
        if (enemy.AIMEnemyValue > 0f)
        {
            enemy.State = EnemyState.Search;
        }
    }
}