using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPerksContainer : MonoBehaviour
{
    [SerializeField, Range (0, 10)] private int LevelHealthPerk;
    public float HealthPerk = 100f;

    [Range (0, 10)] public int LevelArmorPerk;
    public int ArmorPerk = 10;

    [Range (0, 10)] public int LevelAbsorbPerk;

    public float AbsorbPerk = 0f;


    [SerializeField] public List<BasePerkSystem> Perks = new List<BasePerkSystem> ();


    private void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag ("PerkHealth"))
        {
            Perks.Add (new HealthPerk ());
            var qq = (HealthPerk) Perks[0];
            HealthPerk = qq.Health (HealthPerk);
        }
    }

    private void Start ()
    {
        StartCoroutine (Shooting ());
    }

    IEnumerator Shooting ()
    {
        while (true)
        {

            Debug.Log (Perks.Count);

            yield return new WaitForSeconds (2);
        }
    }
}