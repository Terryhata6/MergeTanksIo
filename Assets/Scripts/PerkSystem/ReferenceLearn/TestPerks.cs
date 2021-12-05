
using UnityEngine;

public class TestPerks : MonoBehaviour
{
    private PlayerView _player;
    private Shooter _shooter;
    private PerkManager _perkManager;
    private void Start()
    {
        _player = GetComponent<PlayerView>();
        _shooter = GetComponent<Shooter>();
        _perkManager = _player.PerkManager;

        //var perk = LoadPerksSystem.GetOnePerkByName("CircularProjectile");
        //var instPerk = Instantiate(perk);
        //_perkManager.AddPerk(instPerk);
    }

    private void Update()
    {
        //     _perkManager = _player.PerkManager;

        //     if (Input.GetKeyDown(KeyCode.Space))
        //     {
        //         int lastIndex = _perkManager.OwnPlayerPerkList.Count - 1;
        //         AbstractPerk newPerk = _perkManager.OwnPlayerPerkList[lastIndex];
        //         _perkManager.RemovePlayerPerk(newPerk);
        //         // _viewParams = _perkManager.UpdateViewParamsStruct();
        //     }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            var perk = LoadPerksSystem.GetOnePerkByName("CircularProjectile");
            var instPerk = Instantiate(perk);
            _perkManager.AddPerk(instPerk);
        }
        //     if (Input.GetKeyDown(KeyCode.W))
        //     {

        //         var perk = LoadSystem.LoadPerk("AttackSpeed");
        //         var instPerk = Instantiate(perk);
        //         _perkManager.AddPerk(instPerk);
        //         // _viewParams = _perkManager.UpdateViewParamsStruct();
        //     }
        //     if (Input.GetKeyDown(KeyCode.E))
        //     {
        //         var perk = LoadSystem.LoadPerk("MoveSpeed");
        //         var instPerk = Instantiate(perk);
        //         _perkManager.AddPerk(instPerk);
        //         // _viewParams = _perkManager.UpdateViewParamsStruct();

        //     }
        //     if (Input.GetKeyDown(KeyCode.R))
        //     {
        //         // _perkManager.AddPerk(ScriptableObject.CreateInstance<MoveSpeedPerk>());
        //         var perk = LoadSystem.LoadPerk("RicochetPerk");
        //         var instPerk = Instantiate(perk);
        //         _perkManager.AddPerk(instPerk);

        //     }
        //     if (Input.GetKeyDown(KeyCode.A))
        //     {
        //         var perk = LoadSystem.LoadPerk("ProjectileSize");
        //         var instPerk = Instantiate(perk);
        //         _perkManager.AddPerk(instPerk);
        //         // _viewParams = _perkManager.UpdateViewParamsStruct();
        //     }
        //     if (Input.GetKeyDown(KeyCode.S))
        //     {
        //         // _perkManager.AddPerk(ScriptableObject.CreateInstance<ProjectileSizePerk>());

        //         //_perkManager.AddPerk(inst);
        //     } //
        //     if (Input.GetKeyDown(KeyCode.D))
        //     {
        //         // _perkManager.AddPerk(ScriptableObject.CreateInstance<RicochetPerk>());
        //     }
        //     if (Input.GetKeyDown(KeyCode.F))
        //     {
        //         // _perkManager.AddPerk(ScriptableObject.CreateInstance<RepulsiveProjectilesPerk>());
        //         var perk = LoadSystem.LoadPerk("RepulsiveProjectilesPerk");
        //         var instPerk = Instantiate(perk);
        //         _perkManager.AddPerk(instPerk);
        //     }
        //     if (Input.GetKeyDown(KeyCode.Z))
        //     {
        //         //_perkManager.AddPerk(ScriptableObject.CreateInstance<CircularProjectilePerk>());

        //         // _perkManager.AddPerk(inst);
        //     }
        //     if (Input.GetKeyDown(KeyCode.X))
        //     {
        //         var perk = LoadSystem.LoadPerk("PenetrationShoot");
        //         var instPerk = Instantiate(perk);
        //         _perkManager.AddPerk(instPerk);
        //     }
    }
}