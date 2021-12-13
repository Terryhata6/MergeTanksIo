using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testStatusEffect : MonoBehaviour
{
    private EnemyView _enemy;

    //Cashe
    void Awake()
    {
        _enemy = gameObject.GetComponent<EnemyView>();
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        _enemy.UpdateDebuff();
    }
}