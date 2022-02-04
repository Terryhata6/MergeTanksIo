using UnityEngine;

public class PlayerView : BasePersonView
{
    #region {Author:Doonn}
    [SerializeField] protected PerkManager _perkManager;
    public PerkManager PerkManager => _perkManager;

    [SerializeField] protected Shooter _shooter = new Shooter();
    #endregion

    [SerializeField] private PlayerState _state = PlayerState.Idle;

    public PlayerState State => _state;

    public void SetState(PlayerState state)
    {
        _state = state;
    }

    public override void Awake()
    {
        base.Awake();
        _shooter.Init(this);
        _perkManager = new PerkManager(_viewParams, _shooter);
    }

    private void OnEnable()
    {
        Debug.Log("Подписался");
        GameEvents.Current.OnSelectPerk += GivePerk;
    }

    public void OnDisable()
    {
        Debug.Log("Отписался");
        GameEvents.Current.OnSelectPerk -= GivePerk;
    }

    private void GivePerk(AbstractPerk perk)
    {
        if(perk == null) return;
        _perkManager.AddPerk(perk);
    }

    protected override void GetMerge()
    {
        base.GetMerge();
        _shooter.RecalcProjectileTransform();
    }

    public override void Attack()
    {
        base.Attack();
        if (_viewParams.IsDead().Equals(true))
        {
            return;
        }
        if (_shooter == null) return;
        _shooter.Shooting(_perkManager.OwnProjectileModList);
    }

    public override void IsDead()
    {
        if (ViewParams.IsDead())
        {
            GameEvents.Current.PlayerDead();
            LevelEvents.Current.LevelFailed();
        }
        base.IsDead();
    }

    //////////////////////////////////
    /////////////////////////////////////
    /// <summary>
    /// Test New PerkActionSystem
    /// </summary>
    // Тест Новой Системы Перков
    [SerializeField] private BlackRainbow.PerkManager.PerkManager _newPerkManager;
    public BlackRainbow.PerkManager.PerkManager NewPerkManager => _newPerkManager;

    /// <summary>
    /// Test New PerkActionSystem
    /// </summary>
    void Start()
    {
        _newPerkManager = new BlackRainbow.PerkManager.PerkManager(this);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var ss = Resources.Load<BlackRainbow.PerkSystem.AbstractPerkSO>("TestPerkSO/HealthRegenerationPerkSO");
            Debug.Log(ss);
            var inst = Instantiate(ss);
            _newPerkManager.AddPerk(inst);
        }
    }
}