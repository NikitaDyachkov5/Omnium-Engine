using UnityEngine;

public class WavesSystem : MonoBehaviour
{
    private GameData gameData;

    private CharacterSpawn characterSpawn;

    private int enemySpawnCount; // отслеживание количество противника

    private int countWaves = 0; // счёт волн

    private float breakSeconds; // счёт перерыва в секундах

    private float waveTimeSeconds; // счёт 1 волны

    private float timeBetweenEnemySpawn;

    private int breakTimeSeconds;


    private WaveState waveState;

    public void Initialize(GameData data, CharacterSpawn spawn)
    {
        gameData = data;
        characterSpawn = spawn;
        timeBetweenEnemySpawn = data.TimeBetweenEnemySpawn;
        breakTimeSeconds = data.BreakTimeSeconds;

        GameManager.Instance.GameState.GameStarted += OnGameStarted;
        GameManager.Instance.GameState.GameEnded += OnGameEnded;

        waveState = new WaveState();

        waveState.FightChanged += OnFightStarted;
        waveState.BreakChanged += OnBreakStarted;
    }

    private void OnGameStarted()
    {
        waveState.FightTime();
    }

    private void OnGameEnded()
    {
        StopAllCoroutines();
        Debug.Log("Waves stopped");
    }

    private void OnFightStarted()
    {
        StartWave();
    }

    private void OnBreakStarted()
    {

    }

    public void StartWave()
    {
        countWaves++;
        Debug.Log($"Start wave! ({countWaves})");
        enemySpawnCount = 0;
        breakSeconds = gameData.BreakTimeSeconds;
        //waveTimeSeconds = gameData.WavesTimeSeconds;
        waveTimeSeconds = 10;

        if (waveState == null)
            Debug.LogError("WaveState NOT FOUND");

    }

    private void Update()
    {

        if (!GameManager.Instance.GameState.IsGameActive)
            return;
        
        //if (waveTimeSeconds >= gameData.WavesTimeSeconds) !!!
        if (waveTimeSeconds <= 0  && waveState.IsFight && CheckSurvivedWave())
            waveState.BreakTime();


        if (waveState.IsBreak)
        {
            if (gameData.MaxWaves == countWaves)
            {
                GameManager.Instance.GameState.EndGame();
                return;
            }
            breakSeconds -= Time.deltaTime;
            if (breakSeconds <= 0)
            {
                breakTimeSeconds = gameData.BreakTimeSeconds;
                waveState.FightTime();
            }
        }

        if (waveState.IsFight)
            SpawningEnemy();


        waveTimeSeconds -= Time.deltaTime;

    }

    private bool CheckSurvivedWave()
    {
        return enemySpawnCount * countWaves == characterSpawn.KilledEnemyCount;
    }

    private void SpawningEnemy()
    {
        timeBetweenEnemySpawn -= Time.deltaTime;

        if (timeBetweenEnemySpawn <= 0)
        {
            Debug.Log($"enemySpawnCount {enemySpawnCount}");

            if (enemySpawnCount < gameData.MaxEnemyCount)
            {
                if (enemySpawnCount == gameData.MaxEnemyCount)
                    return;

                Debug.Log($"SPAWN ENEMY! count in scene {enemySpawnCount}");
                characterSpawn.SpawnEnemy();

                enemySpawnCount++;
            }
            timeBetweenEnemySpawn = gameData.TimeBetweenEnemySpawn;
        }
    }

}
