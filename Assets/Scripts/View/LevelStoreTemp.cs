
using System.Collections.Generic;
using UnityEngine;

public class LevelStoreTemp : MonoBehaviour
{
    [SerializeField] private List<GameObject> _levels;
    void Start()
    {
        FindObjectOfType<MainController>().GetController<LevelController>().SetLevels(_levels);

    }
}
