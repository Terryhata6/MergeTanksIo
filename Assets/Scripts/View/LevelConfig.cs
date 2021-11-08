
using Polarith.AI.Move;
using UnityEngine;

public class LevelConfig : MonoBehaviour
{
    [SerializeField] private PersonSpawner _spawner;
    [SerializeField] private Particles _particles;
    [SerializeField] private AIMSteeringPerceiver _environment;
    [SerializeField] private GameObject _aim;

    public PersonSpawner Spawner => _spawner;
    public Particles Particles => _particles;
    public GameObject Aim => _aim;
    public AIMSteeringPerceiver Environment => _environment;
}
