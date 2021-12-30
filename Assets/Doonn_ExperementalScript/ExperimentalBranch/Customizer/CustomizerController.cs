using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CustomizerController : MonoBehaviour
{
    private ModulTankBuilder _modulTankBuilder;
    [SerializeField] CinemachineVirtualCamera _vCam;
    private CinemachineOrbitalTransposer _orbitTransposer;
    private void Awake()
    {
        _modulTankBuilder = GameObject.FindObjectOfType<ModulTankBuilder>();
        _modulTankBuilder.Init();
        _orbitTransposer = _vCam.GetCinemachineComponent<CinemachineOrbitalTransposer>();

        UICustomizerEvent.Current.OnGetModulTank += GetModulTank;
    }

    private void GetModulTank(ModulTankSO modulTank)
    {
        _modulTankBuilder.Click(modulTank);
    }

    private void Update()
    {
        MoveCameraOrbit();
    }

    private void MoveCameraOrbit()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("Up");
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Debug.Log("Down");
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _orbitTransposer.m_Heading.m_Bias += 0.1f;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _orbitTransposer.m_Heading.m_Bias -= 0.1f;
        }
    }
}