using System.Collections.Generic;
using UnityEngine;

public class PlayerView : BasePersonView, ITransaction
{
    [SerializeField] private PlayerState _state = PlayerState.Idle;

    public PlayerState State => _state;

    public void SetState(PlayerState state)
    {
        _state = state;
    }

    public override void IsDead()
    {
        base.IsDead();
        GameEvents.Current.PlayerDead();
        LevelEvents.Current.LevelFailed();
    }

    public void CompleteTransaction(Transaction transaction)
    {
        _points = transaction.Value;
        PerkManager.AddPerk(transaction._perk);
    }

    /// <summary>
    /// Test UI PERK
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameEvents.Current.SetSelectPerks(LoadPerksSystem.GetRandomPerkList(3));
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            GameEvents.Current.OnSelectPerk += Perk;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            var ss = LoadPerksSystem.GetOnePerkByName("ExplosiveProjectile");
            var inst = Instantiate(ss);
            PerkManager.AddPerk(inst);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            var ss = LoadPerksSystem.GetOnePerkByName("PenetrationShoot");
            var inst = Instantiate(ss);
            PerkManager.AddPerk(inst);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            var ss = LoadPerksSystem.GetOnePerkByName("PoisonProjectile");
            var inst = Instantiate(ss);
            PerkManager.AddPerk(inst);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            var ss = LoadPerksSystem.GetOnePerkByName("ProjectileSize");
            var inst = Instantiate(ss);
            PerkManager.AddPerk(inst);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            var ss = LoadPerksSystem.GetOnePerkByName("RepulsiveProjectilesPerk");
            var inst = Instantiate(ss);
            PerkManager.AddPerk(inst);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            var ss = LoadPerksSystem.GetOnePerkByName("RicochetPerk");
            var inst = Instantiate(ss);
            PerkManager.AddPerk(inst);
        }
    }

    void Perk(AbstractPerk perk)
    {
        Debug.Log("Get UI PERK: " + perk);
    }
}