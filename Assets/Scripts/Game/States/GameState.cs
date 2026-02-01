using System;

public class GameState
{
    public bool IsGameActive { get; private set; }
    public bool IsGamePaused { get; private set; } 

    public event Action GameStarted;
    public event Action GamePaused;
    public event Action GameEnded;

    public void StartGame()
    {
        if (IsGameActive) return;

        IsGameActive = true;
        IsGamePaused = false;
        GameStarted?.Invoke();
    }

    public void PauseGame()
    {
        if (!IsGameActive) return;

        IsGameActive = false;
        IsGamePaused = true;
        GamePaused?.Invoke();
    }

    public void EndGame()
    {
        if (!IsGameActive) return;

        IsGameActive = false;
        IsGamePaused = false;
        GameEnded?.Invoke();
    }
}
