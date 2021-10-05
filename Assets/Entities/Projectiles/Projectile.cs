using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Speed;

    // Update is called once per frame
    void Update()
    {
        float newSpeed = Speed * Time.deltaTime;
        transform.Translate(transform.forward * newSpeed, Space.World);
    }
}
