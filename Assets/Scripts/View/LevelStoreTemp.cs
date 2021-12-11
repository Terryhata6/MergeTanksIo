
using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelStoreTemp : MonoBehaviour
{
    [SerializeField] public List<GameObject> Levels;

    private void Awake()
    {
        LevelEvents.Current.OnLevelControllerStart += SetLevels;
    }

    private void SetLevels()
    {
        MainController.Current.GetController<LevelController>()?.SetLevels(Levels);
    }
}
