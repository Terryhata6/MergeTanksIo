using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbsorbPerk : BasePerkSystem
{
    private int _absorb = 5; //<< Absorb Percentage

    private float _resultAbsorb;

    private void Absorb(float currentDamage)
    {
        float getPrecent = currentDamage / (100 - _absorb);  
        _resultAbsorb = getPrecent;
    }

    public int AddAbsorb(int currentAbsorb)
    {
        int newAbsorb = currentAbsorb + _absorb;
        return newAbsorb;
    }
}
