using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class LevelScene
{
    [SerializeField]
    private string sceneName;
    [SerializeField]
    private LevelData levelData;
    [SerializeField]
    private bool instantlyAccessible;

    public string SceneName
    {
        get
        {
            return sceneName;
        }

        set
        {
            sceneName = value;
        }
    }

    public LevelData LevelData
    {
        get
        {
            return levelData;
        }

        set
        {
            levelData = value;
        }
    }

    public bool InstantlyAccessible
    {
        get
        {
            return instantlyAccessible;
        }

        set
        {
            instantlyAccessible = value;
        }
    }
}
