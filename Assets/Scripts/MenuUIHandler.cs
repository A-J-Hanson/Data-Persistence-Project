using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

// Set the script to be executed later. Best practice for UIs
[DefaultExecutionOrder(1000)]

public class MenuUIHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        updateMenuScoreBoard();            

        // Display name of player for currect session when returning to menu
        if (!string.IsNullOrWhiteSpace(MainManager.Instance.playerName))
        {
            GameObject.Find("Player Name").GetComponent<TMP_InputField>().text = MainManager.Instance.playerName;
        }
    }

public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        MainManager.Instance.SaveData();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void StoreName(string sn)
    {
        MainManager.Instance.playerName = sn;
    }
    void updateMenuScoreBoard()
        {
            GameObject.Find("High Score Text").GetComponent<TextMeshProUGUI>().text = "Best Score : " + MainManager.Instance.highScore + " (" + MainManager.Instance.hsName + ")";
        }
}

