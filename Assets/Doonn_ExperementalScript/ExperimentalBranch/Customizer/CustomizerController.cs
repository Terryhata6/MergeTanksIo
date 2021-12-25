using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizerController : MonoBehaviour
{
    private ModulTankBuilder _modulTankBuilder;
    
    private void Awake()
    {
        _modulTankBuilder = GameObject.FindObjectOfType<ModulTankBuilder>();
        _modulTankBuilder.Init();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _modulTankBuilder.Click(0);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            _modulTankBuilder.Click(1);
        }

         if (Input.GetKeyDown(KeyCode.E))
        {
            _modulTankBuilder.Click(2);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            _modulTankBuilder.Click(3);
        }
    }
}