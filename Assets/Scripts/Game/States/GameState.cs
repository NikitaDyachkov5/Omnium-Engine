using System;

public class GameState
{
    public bool IsGameActive { get; private set; }

    public event Action GameStarted;
    public event Action GameEnded;

    public void StartGame()
    {
        if (IsGameActive) return;

        IsGameActive = true;
        GameStarted?.Invoke();
    }

    public void EndGame()
    {
        if (!IsGameActive) return;

        IsGameActive = false;
        GameEnded?.Invoke();
    }
}
