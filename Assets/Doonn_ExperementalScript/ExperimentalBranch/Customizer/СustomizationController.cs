using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class СustomizationController : MonoBehaviour
{
    private ModulTankBuilder _modulTankBuilder;
    //[SerializeField] CinemachineVirtualCamera _vCam;
    //private CinemachineOrbitalTransposer _orbitTransposer;

    [SerializeField] private GameObject _refference;
    private IExecute _execute;
    private void Awake()
    {
        if (_refference.TryGetComponent(out IExecute execute))
        {
            _execute = execute;
        }

        _modulTankBuilder = GameObject.FindObjectOfType<ModulTankBuilder>();
        if (_modulTankBuilder == null) return;
        _modulTankBuilder.Init();
        //_orbitTransposer = _vCam.GetCinemachineComponent<CinemachineOrbitalTransposer>();
    }

    private void Update()
    {
        _execute.Execute();
    }

}