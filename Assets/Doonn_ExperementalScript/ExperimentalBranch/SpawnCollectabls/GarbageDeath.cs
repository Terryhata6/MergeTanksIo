using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageDeath : MonoBehaviour
{
    [SerializeField] private GameObject _example;
    [SerializeField] private float radius = 15f;
    [SerializeField] private float _iterator = 0f;
    [SerializeField] private GameObject _gd;
    public void Init(GameObject go, Transform trans)
    {
        if (go == null) return;

        _gd = go;

        SpawnAround();
    }

    private GameObject[] _ex = new GameObject[10];
    private Vector3[] basePos = new Vector3[10];
    private Vector3[] nextPos = new Vector3[10];
    private Vector3[] parabols = new Vector3[10];
    private float _tempRad;
    private Vector3 _tempVec;

    private void SpawnAround()
    {
        for (int i = 0; i < _ex.Length; i++)
        {
            _ex[i] = Instantiate(_example, _gd.transform.position, Quaternion.identity);
            _ex[i].transform.SetParent(_gd.transform);

            basePos[i] = _ex[i].transform.position;

            _tempRad = Random.Range(0f, 360f) * Mathf.Deg2Rad;

            nextPos[i] = basePos[i];

            nextPos[i] += new Vector3(Mathf.Cos(_tempRad), 0, Mathf.Sin(_tempRad)) * radius;

            parabols[i] = basePos[i];
        }

        StartCoroutine(SpawnCollectabl());
    }

    IEnumerator SpawnCollectabl()
    {
        bool count = true;

        while (count)
        {
            for (int i = 0; i < _ex.Length; i++)
            {
                _tempVec = Vector3.Lerp(basePos[i], nextPos[i], _iterator);

                if (_iterator > 0.5f)
                {
                    _tempVec.y += -5 * ((_iterator - 0.5f) * (_iterator - 0.5f)) - _iterator; // Менять параболу тут
                }
                else
                {
                    _tempVec.y -= 5 * ((_iterator - 0.5f) * (_iterator - 0.5f)) + _iterator; // Менять параболу тут
                    Debug.Log("123131313");
                }

                _ex[i].transform.position = _tempVec;
            }

            _iterator += Time.deltaTime;
            if (_iterator >= 1)
            {
                count = false;
            }
            yield return null;
        }
    }
}

// Transform[] transforms = new Transform[10];
// Vector3[] basePos = new Vector3[transforms.Length];
// Vector3[] nextPos = new Vector3[transforms.Length];

// for (int i = 0; i < 10; i++)
// {
//     //var ex = Instantiate(_example, Vector3.up * 10f, Quaternion.identity);
//     var ex = Instantiate(_example, _gd.transform.position, Quaternion.identity);
//     ex.transform.SetParent(_gd.transform);

//     //ex.transform.position = _gd.transform.position;
//     transforms[i] = ex.transform;

//     // transforms[i] = Instantiate(ex, Vector3.up * 10f, Quaternion.identity).transform;
//     // transforms[i].SetParent(_gd.transform);

//     basePos[i] = transforms[i].position;

//     _tempRad = Random.Range(0f, 360f) * Mathf.Deg2Rad;

//     nextPos[i] = new Vector3(Mathf.Cos(_tempRad), 0, Mathf.Sin(_tempRad)) * radius;
// }

// bool count = true;

// while (count)
// {
//     for (int j = 0; j < transforms.Length; j++)
//     {
//         _tempVec = Vector3.Lerp(basePos[j], nextPos[j], _iterator);
//         _tempVec.y = -(10 / 2) * ((_iterator - 0.5f) * (_iterator - 0.5f)) + _iterator; // Менять параболу тут
//         transforms[j].position = _tempVec;
//         _iterator += Time.deltaTime / 3f;
//         if (_iterator >= 1)
//         {
//             count = false;
//         }
//         yield return null;
//     }

// }