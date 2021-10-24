using System;

public class EnemyView : BaseObjectView
{
    private EnemyState _state;
    public EnemyState State => _state;

    private void OnDestroy()
    {
        LevelEvents.Current.EnemyDead();
    }
}