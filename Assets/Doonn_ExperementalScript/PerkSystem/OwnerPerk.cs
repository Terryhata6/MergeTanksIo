using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnerPerk : MonoBehaviour
{
    [SerializeField] public AbstractPerk Perk;
    private Shooter shoot;
    public float Health = 100f;
    public int Armor;

    private void Start() {
        shoot = GetComponent<Shooter>();
    }

    private void Update ()
    {
        if (Input.GetKeyDown (KeyCode.Space))
        {
            Perk.Activate(shoot);
        }
        if (Input.GetKeyDown (KeyCode.A))
        {
        }
    }
}