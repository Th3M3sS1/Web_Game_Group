using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public GameObject playerHealthBar;

    [SerializeField]
    PlayerController pc;

    

    private void Start()
    {
        currentState = GameState.GameRun;
        pauseMenu.SetActive(false);

        if (instance == null)
            instance = this;

        SavedData data = SaveSystem.LoadGame();

        if (data.levelToLoad == "Level1")
        {
            LoadGame(data);
        }
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

        playerHealthBar.SetActive(false);
    }

    public void ContinueGame()
    {
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        currentState = GameState.GameRun;

        playerHealthBar.SetActive(true);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void SaveGame()
    {
        //save player pos
        SaveSystem.SaveGame(pc, 3);
        //save enemy pos
        //save inventory
    }

    public void LoadGame(SavedData data)
    {
        pc.transform.position = new Vector3(data.playerPos[0], data.playerPos[1], data.playerPos[2]);
    }
}