using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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

    }

    private void Update()
    {
        _perkManager = _player.PerkManager;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            int lastIndex = _perkManager.OwnPlayerPerkList.Count - 1;
            AbstractPerk newPerk = _perkManager.OwnPlayerPerkList[lastIndex];
            _perkManager.RemovePlayerPerk(newPerk);
            // _viewParams = _perkManager.UpdateViewParamsStruct();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            var perk = AssetDatabase.LoadAssetAtPath<AbstractPerk>("Assets/scripts/PerkSystem/ScriptablePerks/AddHealth.asset");
            var inst = Instantiate(perk);
            _perkManager.AddPerk(inst);
            // _viewParams = _perkManager.UpdateViewParamsStruct();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {

            var perk = AssetDatabase.LoadAssetAtPath<AbstractPerk>("Assets/scripts/PerkSystem/ScriptablePerks/AttackSpeed.asset");
            var inst = Instantiate(perk);
            _perkManager.AddPerk(inst);
            // _viewParams = _perkManager.UpdateViewParamsStruct();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            var perk = AssetDatabase.LoadAssetAtPath<AbstractPerk>("Assets/scripts/PerkSystem/ScriptablePerks/MoveSpeed.asset");
            var inst = Instantiate(perk);
            _perkManager.AddPerk(inst);
            // _viewParams = _perkManager.UpdateViewParamsStruct();

        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            // _perkManager.AddPerk(ScriptableObject.CreateInstance<MoveSpeedPerk>());
            var perk = AssetDatabase.LoadAssetAtPath<AbstractPerk>("Assets/scripts/PerkSystem/ScriptablePerks/RicochetPerk.asset");
            var inst = Instantiate(perk);
            _perkManager.AddPerk(inst);

        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            var perk = AssetDatabase.LoadAssetAtPath<AbstractPerk>("Assets/scripts/PerkSystem/ScriptablePerks/ElectronicShield.asset");
            var inst = Instantiate(perk);
            _perkManager.AddPerk(inst);
            // _viewParams = _perkManager.UpdateViewParamsStruct();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            // _perkManager.AddPerk(ScriptableObject.CreateInstance<ProjectileSizePerk>());
            var perk = AssetDatabase.LoadAssetAtPath<AbstractPerk>("Assets/scripts/PerkSystem/ScriptablePerks/ProjectileSize.asset");
            var inst = Instantiate(perk);
            _perkManager.AddPerk(inst);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            // _perkManager.AddPerk(ScriptableObject.CreateInstance<RicochetPerk>());
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            // _perkManager.AddPerk(ScriptableObject.CreateInstance<RepulsiveProjectilesPerk>());
            var perk = AssetDatabase.LoadAssetAtPath<AbstractPerk>("Assets/scripts/PerkSystem/ScriptablePerks/RepulsiveProjectilesPerk.asset");
            var inst = Instantiate(perk);
            _perkManager.AddPerk(inst);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            //_perkManager.AddPerk(ScriptableObject.CreateInstance<CircularProjectilePerk>());
            var perk = AssetDatabase.LoadAssetAtPath<AbstractPerk>("Assets/scripts/PerkSystem/ScriptablePerks/CircularProjectile.asset");
            var inst = Instantiate(perk);
            _perkManager.AddPerk(inst);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            var perk = AssetDatabase.LoadAssetAtPath<AbstractPerk>("Assets/scripts/PerkSystem/ScriptablePerks/RegenHealth.asset");
            var inst = Instantiate(perk);
            _perkManager.AddPerk(inst);
            // _viewParams = _perkManager.UpdateViewParamsStruct();
        }
    }
}