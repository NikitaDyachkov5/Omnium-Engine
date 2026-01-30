using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private GameData gameData;

    [SerializeField]
    private CharacterFactory characterFactory;

    [SerializeField]
    private CharacterSpawn characterSpawn;

    [SerializeField]
    private CameraScript cameraScript;

    [SerializeField]
    private WavesSystem wavesSystem;

    [SerializeField]
    private UIManager uiManager;

    [SerializeField]
    private WindowsService windowsService;

    private ScoreSystem scoreSystem;

    private float gameSessionTime;

    private GameState gameState;

    public WindowsService WindowsService => windowsService;

    public GameState GameState => gameState;

    public static GameManager Instance { get; private set; }

    public CharacterFactory CharacterFactory => characterFactory;

    private float timePreStart = 3;

    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Initialize();
        }
        else
            Destroy(this.gameObject);
    }

    private void Initialize()
    {
        scoreSystem = new ScoreSystem();
        gameState = new GameState();

        characterSpawn.Initialize(characterFactory, scoreSystem, gameData, GameOver);
        wavesSystem.Initialize(gameData, characterSpawn, uiManager);

        gameState.GameStarted += OnGameStarted;
        gameState.GameEnded += OnGameEnded;
        gameState.EndGame();
    }

    public void StartGame()
    {
         gameState.StartGame();
    }

    private void Update()
    {
        if (timePreStart > 0)
        {
            timePreStart -= Time.deltaTime;
            uiManager.ShowCenterMessage($"Start after {timePreStart:F1}");
        }
        else
        {
            if (!gameState.IsGameActive)
            {
                uiManager.ShowCenterMessage($"Let's go", 1.5f);
                StartGame();
            }

            gameSessionTime += Time.deltaTime;

            if (gameSessionTime >= gameData.SessionTimeSeconds)
                GameVictory();

            uiManager.ShowScore(scoreSystem.Score);
        }

        if (!gameState.IsGameActive)
            return;

    }

    private void OnGameStarted()
    {

        characterSpawn.OnPlayerSpawned += OnPlayerSpawned;

        characterSpawn.SpawnPlayer();

        scoreSystem.StartGame();

        gameSessionTime = 0;

        Debug.Log("Game started.");

    }

    private void OnPlayerSpawned(Character player)
    {
        cameraScript.SetTarget(player.transform);
    }

    private void OnGameEnded()
    {
        characterSpawn.OnPlayerSpawned -= OnPlayerSpawned;

        Debug.Log("Game Ended");
        scoreSystem.EndGame();
    }

    private void GameVictory()
    {
        Debug.Log("Victory");
        scoreSystem.EndGame();

        //WindowsService.ShowWindow
    }

    private void GameOver()
    {
        Debug.Log("Defeat");
        scoreSystem.EndGame();
    }
}
