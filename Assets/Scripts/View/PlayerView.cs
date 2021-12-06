using UnityEngine;


public class PlayerView : BasePersonView
{
    [SerializeField] private PlayerState _state = PlayerState.Idle;

    public PlayerState State => _state;

    public void SetState(PlayerState state)
    {
        _state = state;
    }

    /// <summary>
    /// Test Perks
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            var perk = LoadPerksSystem.GetOnePerkByName("CircularProjectile");
            var instPerk = Instantiate(perk);
            _perkManager.AddPerk(instPerk);
        }
    }
}