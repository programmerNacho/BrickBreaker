using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Modifier : MonoBehaviour
{
    public abstract void Activate();
    public virtual void DeActivate()
    {
        ModifierSystem.Instance.RemoveModifier(this);
    }
}
