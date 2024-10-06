using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public InputField playerNameInput;
    public Text bestScoreText;

    // Start is called before the first frame update
    void Start()
    {
        LoadBestScore();
    }

    public void StartNew()
    {
        PlayerPrefs.SetString("CurrentPlayerName", playerNameInput.text);
        SceneManager.LoadScene(1);
    }

    public void LoadBestScore()
    {
        bestScoreText.text = "Name: " + SaveManager.Instance.playerName + " / High Score: " + SaveManager.Instance.bestScore;
    }

    public void Exit()
    {
        if (EditorApplication.isPlaying)
        {
            EditorApplication.ExitPlaymode();
        }
        else
        {
            Application.Quit();
        }
    }
}
