using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class LevelButton : MonoBehaviour
{
    private string levelName;

    public string LevelName
    {
        get
        {
            return levelName;
        }

        set
        {
            levelName = value;
        }
    }

    private Button button;

    public Button Button
    {
        get
        {
            return button;
        }

        set
        {
            button = value;
        }
    }

    [HideInInspector]
    public UnityAction<LevelButton> ButtonClicked = delegate { };

    public void Initialize(string levelName)
    {
        this.levelName = levelName;
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        ButtonClicked.Invoke(this);
    }
}
