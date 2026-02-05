using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    [Header("Game State")]
    public GameState CurrentState = GameState.Playing;
    
    // [Header("References")]
    // public PlayerController Player; // Will be uncommented when PlayerController is created
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void PauseGame()
    {
        CurrentState = GameState.Paused;
        Time.timeScale = 0f;
    }
    
    public void ResumeGame()
    {
        CurrentState = GameState.Playing;
        Time.timeScale = 1f;
    }
}

public enum GameState
{
    Playing,
    Paused,
    Dialogue,
    Cutscene,
    Loading
}
