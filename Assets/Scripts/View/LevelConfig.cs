
using System.Collections.Generic;
using UnityEngine;

public class LevelConfig : MonoBehaviour
{
    [SerializeField] private PersonSpawner _spawner;
    [SerializeField] private Particles _particles;

    public PersonSpawner Spawner => _spawner;
    public Particles Particles => _particles;
}
