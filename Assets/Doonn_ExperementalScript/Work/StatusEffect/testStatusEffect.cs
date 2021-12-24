using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testStatusEffect : MonoBehaviour
{
    private BasePersonView _enemy;

    //Cashe
    void Awake()
    {
        _enemy = gameObject.GetComponent<BasePersonView>();
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        _enemy.UpdateDebuff();
    }
}