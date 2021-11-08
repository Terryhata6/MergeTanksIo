using UnityEngine;

public struct PersonConf
{
    private IObjectExecuter _controller;
    private GameObject _prefab;

    public IObjectExecuter Controller => _controller;
    public GameObject Prefab => _prefab;

    public PersonConf(IObjectExecuter controller, GameObject prefab)
    {
        _controller = controller;
        _prefab = prefab;
    }
}