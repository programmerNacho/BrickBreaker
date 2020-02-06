using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

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

        DontDestroyOnLoad(gameObject);
    }

    [SerializeField]
    private LevelList levelList;

    public LevelList LevelList
    {
        get
        {
            return levelList;
        }

        set
        {
            levelList = value;
        }
    }

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void LevelCompleted(string sceneName)
    {
        foreach (LevelScene levelScene in levelList.levelScenes)
        {
            if(levelScene.SceneName == sceneName && !levelScene.LevelData.Completed)
            {
                levelScene.LevelData.Completed = true;
                break;
            }
        }

        SaveGame();
    }

    private void SaveGame()
    {
        LevelData[] levelDatas = new LevelData[levelList.levelScenes.Count];

        for (int i = 0; i < levelDatas.Length; i++)
        {
            levelDatas[i] = levelList.levelScenes[i].LevelData;
        }

        SaveLoadManager.Serialize(levelDatas);
    }

    public void LoadGame()
    {
        LevelData[] levelData = SaveLoadManager.DeSerialize();
        if(levelData != null)
        {
            if (levelList.levelScenes.Count >= levelData.Length)
            {
                for (int i = 0; i < levelData.Length; i++)
                {
                    levelList.levelScenes[i].LevelData = levelData[i];
                }
            }
            else
            {
                for (int i = 0; i < levelList.levelScenes.Count; i++)
                {
                    levelList.levelScenes[i].LevelData = levelData[i];
                }
            }
        }
        else
        {
            for (int i = 0; i < levelList.levelScenes.Count; i++)
            {
                levelList.levelScenes[i].LevelData.Completed = false;
            }
        }
    }
}
