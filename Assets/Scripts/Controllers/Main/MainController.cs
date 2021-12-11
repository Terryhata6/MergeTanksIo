using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    public static MainController Current;
    
   private List<BaseController> _controllers;
   [SerializeField] private bool _useMouse;
   private List<BaseController> _updateExecuters;
   private List<BaseController> _fixedUpdateExecuters;
   private int i;

   public bool UseMouse => _useMouse;
    private void Awake()
    {
        Current = this;
        _controllers = new List<BaseController>();
        _fixedUpdateExecuters = new List<BaseController>();
        _updateExecuters = new List<BaseController>();
        AddController(new InputController().SetMainController(this));
        AddController(new PlayerController());
        AddController(new LevelController());
        AddController(new CollectableController());
        AddController(new EnemyController());
        AddController(new ProjectileController()); //<< Doonn
        AddController(new UIController());
    }

    private void Start()
    {
        for (int i = 0; i < _controllers.Count; i++)
        {
            if (_controllers[i] is IInitialize)
            {
                _controllers[i].Initialize();
            }
        }
        LevelEvents.Current.GameLaunched();
    }


    private void Update()
    {
        for (i = 0; i < _updateExecuters.Count; i++)
        {
            _updateExecuters[i].Execute();
        }
    }

    private void FixedUpdate()
    {
        for (i = 0; i < _fixedUpdateExecuters.Count; i++)
        {
            _fixedUpdateExecuters[i].FixedExecute();
        }
    }

    public void AddController(BaseController controller)
    {
        if (!_controllers.Contains(controller))
        {
            if (controller is IExecute)
            {
                _updateExecuters.Add(controller);
            }

            if (controller is IFixedExecute)
            {
                _fixedUpdateExecuters.Add(controller);
            }
            _controllers.Add(controller);
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
        //GetController<BaseController>();
        //InputController a = new InputController();
       // a = GetController<InputController>();
    }

    #endregion
}