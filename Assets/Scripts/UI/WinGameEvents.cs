using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WinGameEvents : MonoBehaviour
{
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
        // SceneManager.LoadScene(SceneManager.sceneCount + 1, LoadSceneMode.Single);
    }
}
