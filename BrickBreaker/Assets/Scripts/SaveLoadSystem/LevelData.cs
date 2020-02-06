using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelData
{
    [SerializeField]
    private string alias;
    [SerializeField]
    private bool completed = false;
    public string Alias
    {
        get { return alias; }
        set { alias = value; }
    }
    public bool Completed
    {
        get { return completed; }
        set { completed = value; }
    }

    public LevelData(string alias, bool completed)
    {
        this.alias = alias;
        this.completed = completed;
    }
}
