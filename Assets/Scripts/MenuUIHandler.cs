using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Set the script to be executed later. Best practice for UIs
[DefaultExecutionOrder(1000)]

public class MenuUIHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

public void StartNew()
    {
        SceneManager.LoadScene(1);
    }
}