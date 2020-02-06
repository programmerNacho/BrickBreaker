using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LevelSelector : MonoBehaviour
{
    [SerializeField]
    private Transform buttonsParent;
    [SerializeField]
    private LevelButton levelButtonPrefab;

    private List<LevelButton> levelButtons;

    private void Start()
    {
        InitializeButtons();
    }

    private void InitializeButtons()
    {
        LevelManager.Instance.LoadGame();
        LevelList levelList = LevelManager.Instance.LevelList;
        levelButtons = new List<LevelButton>();

        for (int i = 0; i < levelList.levelScenes.Count; i++)
        {
            LevelButton levelButton = Instantiate(levelButtonPrefab, buttonsParent);
            levelButton.Initialize(levelList.levelScenes[i].SceneName);
            if(!levelList.levelScenes[i].InstantlyAccessible && i >= 1  && levelList.levelScenes[i - 1].LevelData.Completed)
            {
                levelButton.Button.interactable = true;
            }
            else
            {
                levelButton.Button.interactable = levelList.levelScenes[i].InstantlyAccessible;
            }
            levelButton.ButtonClicked += LoadLevel;
            levelButtons.Add(levelButton);
        }
    }

    public void LoadLevel(LevelButton levelButton)
    {
        if(levelButtons.Contains(levelButton))
        {
            LevelManager.Instance.LoadLevel(levelButton.LevelName);
        }
    }
}
