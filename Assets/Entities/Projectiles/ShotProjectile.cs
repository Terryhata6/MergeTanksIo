using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotProjectile : MonoBehaviour
{
    private float _speed = 15;
    public float Speed => _speed;

    public bool isShoot;

    private PoolObjects _pool;

    // private void Awake ()
    // {
    //    _pool = new PoolObjects();
    // }

    private void Start ()
    {
        _pool = GameObject.FindObjectOfType<PoolObjects> ();

        StartCoroutine (Delay ());

    }


    IEnumerator Delay ()
    {
        while (isShoot)
        {
            // List<Transform> obj = new List<Transform>();
            // obj = GameObject.FindObjectOfType<PlayerView> ().ShotProjectileTransform;
            // for (int i = 0; i < obj.Count; i++)
            // {
            //     Vector3 pos = obj[i].transform.position;
            //     Debug.Log (pos);
            //     Quaternion rot = obj[i].transform.rotation;
            //_pool.GetFreeObject ();
            //Instantiate(Projectile, pos, rot);
            //}

            List<Transform> obj = new List<Transform> ();
            obj = GameObject.FindObjectOfType<PlayerView> ().ShotProjectileTransform;
            for (int i = 0; i < obj.Count; i++)
            {

                Vector3 pos = obj[i].transform.position;
                Debug.Log (pos);
                Quaternion rot = obj[i].transform.rotation;
                var tt = _pool.GetObject ();
                tt.transform.position = pos;
                tt.transform.rotation = rot;

            }
            yield return new WaitForSeconds (2);

        }
    }
}