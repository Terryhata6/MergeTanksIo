
using UnityEngine;

public class SpawnPointView : MonoBehaviour
{
    private void Start()
    {
        FindObjectOfType<MainController>().GetController<LevelController>().AddSpawnPoint(transform);
    }

}
