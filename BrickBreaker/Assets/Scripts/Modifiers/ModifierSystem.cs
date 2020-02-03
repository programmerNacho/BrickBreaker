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
        Modifier modifierCreated = Instantiate(modifierPrefab, transform);
        if(modifierCreated.GetCancelModifier() != null)
        {
            foreach (Modifier m in modifiersList)
            {
                if(m.GetType() == modifierCreated.GetCancelModifier().GetType())
                {
                    m.DeActivate();
                    break;
                }
            }
        }
        modifierCreated.Activate();
        modifiersList.Add(modifierCreated);
    }

    public void RemoveModifier(Modifier modifier)
    {
        modifiersList.Remove(modifier);
        Destroy(modifier.gameObject);
    }
}
