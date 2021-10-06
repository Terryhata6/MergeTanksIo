using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotProjectile : MonoBehaviour
{
    private float _speed = 15;
    public float Speed => _speed;

    [SerializeField] private bool _isShooting;
    [SerializeField] private bool _sequentialShots;
    [SerializeField] private float _delay = 1f;
    
    private ObjectPool<Projectile> _pool;
    private List<Transform> _obj;

    public void SetObjectPools(ObjectPool<Projectile> pool)
    {
        _pool = pool;
    }

    private void Start ()
    {
        StartCoroutine (Shooting ());
    }


    IEnumerator Shooting ()
    {
        while (true)
        {
            if (_isShooting)
            {
                List<Transform> obj = new List<Transform> ();
                obj = GameObject.FindObjectOfType<PlayerView> ().ShotProjectileTransform;
                for (int i = 0; i < obj.Count; i++)
                {

                    Vector3 pos = obj[i].transform.position;
                    Quaternion rot = obj[i].transform.rotation;
                    var tt = _pool.GetObject ();
                    tt.transform.position = pos;
                    tt.transform.rotation = rot;
                }
                yield return new WaitForSeconds (_delay);
            }

            if (_sequentialShots)
            {
                List<Transform> obj = new List<Transform> ();
                obj = GameObject.FindObjectOfType<PlayerView> ().ShotProjectileTransform;
                for (int i = 0; i < obj.Count; i++)
                {

                    Vector3 pos = obj[i].transform.position;
                    Quaternion rot = obj[i].transform.rotation;
                    var tt = _pool.GetObject ();
                    tt.transform.position = pos;
                    tt.transform.rotation = rot;
                    yield return new WaitForSeconds (_delay / obj.Count);
                }
                yield return new WaitForSeconds (_delay);
            }
            yield return new WaitForEndOfFrame ();
        }
    }
}