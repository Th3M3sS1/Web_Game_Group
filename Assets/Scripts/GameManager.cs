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

    public SceneDataSO sceneData;

    private void Start()
    {
        currentState = GameState.GameRun;
        pauseMenu.SetActive(false);

        if (!sceneData.newLevel)
        {
            pc.transform.position = sceneData.playerPos;
            pc.currentHealth = sceneData.playerHealth;
        }
        else
        {
            pc.transform.position = new Vector3(0.0f, 3.0f, 0.0f);
            pc.currentHealth = pc.maxHealth;
        }

        if (instance == null)
            instance = this;

        ContinueGame();
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
        Debug.Log("Game Savaed");
        sceneData.sceneToLoad = SceneManager.GetActiveScene().name;

        sceneData.playerPos = pc.transform.position;
        sceneData.playerHealth = pc.currentHealth;
    }
}