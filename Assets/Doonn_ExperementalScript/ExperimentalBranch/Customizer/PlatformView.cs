using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformView : MonoBehaviour, IExecute
{

    [SerializeField] private InputControllerSO _input;
    [SerializeField] private GameObject _refference;
    [SerializeField] private float _speed;
    private Vector2 _mouseBegan;

    private void OnEnable()
    {
        _input.OnMouseBegan += SetMouseBegan;
        _input.OnMouseMove += ExecuteRotation;
    }

    private void OnDisable()
    {
        _input.OnMouseBegan -= SetMouseBegan;
        _input.OnMouseMove -= ExecuteRotation;
    }

    public void Execute()
    {
        _input.Execute();
    }

    private void SetMouseBegan(Vector2 v2)
    {
        _mouseBegan = v2;
    }

    private void ExecuteRotation(Vector2 v2)
    {
        _refference.transform.Rotate(0f, (_mouseBegan.x - v2.x) * _speed * Time.deltaTime, 0f);
    }
}