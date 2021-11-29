using System.IO;
using UnityEditor;
using UnityEngine;

public class EnemyTest : BaseObjectView, ITakeDamage
{
  // public ViewParamsComponent ViewParams = new ViewParamsComponent();
  // [SerializeField] private PerkManager _perkManager;

  // private Shooter _shooter;

  // private void Start()
  // {
  //     // var perk = AssetDatabase.LoadAssetAtPath<AbstractPerk>("Assets/scripts/PerkSystem/ScriptablePerks/AddHealth.asset");
  //     // var inst = Instantiate(perk);
  //     var inst = LoadAssetBundle();
  //     Debug.Log(inst);
  //     _perkManager = new PerkManager(ViewParams);
  //     _perkManager.AddPerk(inst);
  //     //ViewParams = _perkManager.UpdateViewParamsStruct();
  // }

  // private AbstractPerk LoadAssetBundle()
  // {
  //     string Olol = "Assets/scripts/PerkSystem/ScriptablePerks/AddHealth.asset";

  //     var myLoadedAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "perks"));

  //     if (myLoadedAssetBundle == null)
  //     {
  //         Debug.Log("Failed to load AssetBundle!");
  //         return null;
  //     }

  //     var prefab = myLoadedAssetBundle.LoadAsset<AbstractPerk>("AddHealth");
  //     var inst = Instantiate(prefab);
  //     return inst;
  // }
  public void TakeDamage(float damage)
  {
    Debug.Log("АЙАЙАЙАЙАЙАЙАЙАЙА");
  }
}