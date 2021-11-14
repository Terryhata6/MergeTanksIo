using UnityEditor;
using UnityEngine;

public class EnemyTest : BaseObjectView
{
    public ViewParamsStruct ViewParams;
    [SerializeField] private PerkManager _perkManager;

    private Shooter _shooter;

    private void Start()
    {
        //var perk = AssetDatabase.LoadAssetAtPath<AbstractPerk>("Assets/scripts/PerkSystem/ScriptablePerks/AddHealth.asset");
        //var inst = Instantiate(perk);
        //_perkManager = new PerkManager(ViewParams);
        //_perkManager.AddPerk(inst);
        //ViewParams = _perkManager.UpdateViewParamsStruct();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
        }
    }
}