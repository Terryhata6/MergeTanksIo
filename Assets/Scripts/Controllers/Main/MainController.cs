using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    private List<BaseController> _controllers;


    private void Awake()
    {
        _controllers = new List<BaseController>();
        _controllers.Add(new InputController());
        _controllers.Add(new PlayerController());
    }

    private void Start()
    {
        foreach (var controller in _controllers)
        {
            if (controller is IInitialize)
            {
                (controller as IInitialize).Initialize();
            }
        }
    }


    private void Update()
    {
        foreach (var controller in _controllers)
        {
            if (controller is IExecute)
            {
                (controller as IExecute).Execute();
            }
        }
    }

    public T GetController<T>() where T : BaseController
    {
        foreach (BaseController obj in _controllers)
        {
            if (obj.GetType() == typeof(T))
            {
                return (T) obj;
            }
        }

        return null;
    }

    #region Will Replaced or Deleted

    /// <summary>
    /// don't forget syntaxis
    /// </summary>
    public void stupid()
    {
        GetController<BaseController>();
        InputController a = new InputController();
        a = GetController<InputController>();
    }

    #endregion
}