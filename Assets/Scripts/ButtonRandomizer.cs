using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonRandomizer : MonoBehaviour
{
    public Button[] buttons;
    public Color workingButtonColor;
    public string playSceneName;
    public GameObject playGamePanel;

    private int playButtonIndex = -1;


    public static bool isPlay = false;

    void Awake()
    {
        isPlay = false;
    }

    void Start()
    {
        playButtonIndex = Random.Range(0, buttons.Length);
        SetPlayButton();
        buttons[playButtonIndex].onClick.AddListener(LoadPlayScene);
    }

    void SetPlayButton()
    {
        foreach (Button button in buttons)
        {
            button.image.color = Color.white;
        }
                
        buttons[playButtonIndex].image.color = workingButtonColor;
        buttons[playButtonIndex].GetComponentInChildren<Text>().text = "PLAY";
    }

    public void LoadPlayScene()
    {
        if (buttons[playButtonIndex].image.color == workingButtonColor && buttons[playButtonIndex].GetComponentInChildren<Text>().text == "PLAY")
        {
            isPlay = true;
            playGamePanel.SetActive(false);
            
        }
    }
}