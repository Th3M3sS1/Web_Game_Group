using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public SceneDataSO sceneData;
    public void PlayGame()
    {
        sceneData.newLevel = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    public void LoadGame()
    {
        sceneData.newLevel = false;
        SceneManager.LoadScene(sceneData.sceneToLoad);
    }
}
