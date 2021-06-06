using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public enum GameState
    {
        GameRun,
        GamePause
    }
    public GameState currentState;

    public GameObject pauseMenu;

    private void Start()
    {
        currentState = GameState.GameRun;
        pauseMenu.SetActive(false);

        if (instance == null)
            instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape) && currentState == GameState.GameRun)
        {
            PauseGame();
        }

        else if(Input.GetKeyUp(KeyCode.Escape) && currentState == GameState.GamePause)
        {
            ContinueGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0.0f;
        pauseMenu.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        currentState = GameState.GamePause;
    }

    public void ContinueGame()
    {
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        currentState = GameState.GameRun;
    }
}
