using Cinemachine;
using Polarith.AI.Move;
using UnityEngine;

public class LevelConfig : MonoBehaviour
{
    [SerializeField] private PersonSpawner _spawner;
    [SerializeField] private CollectablesParam _collectablesParams;
    [SerializeField] private AIMSteeringPerceiver _environment;
    [SerializeField] private AIMComponents _aim;
    [SerializeField] private CinemachineVirtualCamera _virtualCam;
    [SerializeField] private CollectableSpray _spray;
    [SerializeField] private GameObject _mergeObj;

    public PersonSpawner Spawner => _spawner;
    public CollectablesParam CollectableParams => _collectablesParams;
    public AIMComponents Aim => _aim;
    public CinemachineVirtualCamera VirtualCam => _virtualCam;
    public AIMSteeringPerceiver Environment => _environment;
    public CollectableSpray Spray => _spray;
    public GameObject MergeObj => _mergeObj;
}
