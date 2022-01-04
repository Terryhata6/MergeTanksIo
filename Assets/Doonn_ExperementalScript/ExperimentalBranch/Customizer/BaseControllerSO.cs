using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseControllerSO : ScriptableObject
{
    public virtual void Initialize(){}
    public virtual void Execute(){}
}
