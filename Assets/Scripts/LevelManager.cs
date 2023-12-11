using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverPanel;
    [SerializeField]
    private GameObject winPanel;

    public enum GameState
    {
        None,
        Playing,
        GameOver,
        Win
    }

    public void Start()
    {
        State = GameState.Playing; 
    }

    public GameState State { get; set; }
   
    public void GameOver()
    {
        Time.timeScale = 0.0f;
        gameOverPanel.SetActive(true);
        State = GameState.GameOver;
    }

    public void Win()
    {
        Time.timeScale = 0.0f;
        winPanel.SetActive(true);
        State = GameState.Win;
    }

    public void Restart()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        State = GameState.Playing;
    }
}
