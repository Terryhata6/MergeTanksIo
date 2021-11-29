
using Polarith.AI.Move;
using UnityEngine;

public class LevelConfig : MonoBehaviour
{
    [SerializeField] private PersonSpawner _spawner;
    [SerializeField] private CollectablesParam _collectablesParams;
    [SerializeField] private AIMSteeringPerceiver _environment;
    [SerializeField] private GameObject _aim;

    public PersonSpawner Spawner => _spawner;
    public CollectablesParam CollectableParams => _collectablesParams;
    public GameObject Aim => _aim;
    public AIMSteeringPerceiver Environment => _environment;
}
