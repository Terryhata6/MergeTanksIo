
using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelStoreTemp : MonoBehaviour
{
    public static LevelStoreTemp Current;
    [SerializeField] public List<GameObject> Levels;

    private void Awake()
    {
        Current = this;
    }
}
