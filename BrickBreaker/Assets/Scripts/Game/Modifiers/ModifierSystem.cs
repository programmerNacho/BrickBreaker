using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierSystem : MonoBehaviour
{
    public static ModifierSystem Instance { get; private set; }

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private List<Modifier> modifiersList;

    private void Start()
    {
        modifiersList = new List<Modifier>();
    }

    public void AddModifier(Modifier modifierPrefab)
    {
        foreach (Modifier m in modifiersList)
        {
            if(m.GetType() == modifierPrefab.GetType())
            {
                return;
            }
        }

        Modifier modifierCreated = Instantiate(modifierPrefab, transform);

        if(modifierCreated.GetCancelModifier() != null)
        {
            List<Modifier> removeModifiers = new List<Modifier>();

            foreach (Modifier m in modifiersList)
            {
                if(m.GetType() == modifierCreated.GetCancelModifier().GetType())
                {
                    removeModifiers.Add(m);
                }
            }

            foreach (Modifier m in removeModifiers)
            {
                m.DeActivate();
            }
        }

        modifiersList.Add(modifierCreated);
        modifierCreated.Activate();
    }

    public void RemoveModifier(Modifier modifier)
    {
        modifiersList.Remove(modifier);
        Destroy(modifier.gameObject);
    }
}
