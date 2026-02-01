using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CharacterSpawn : MonoBehaviour
{
    private CharacterFactory characterFactory;

    private GameData gameData;

    private ScoreSystem scoreSystem;

    private System.Action gameOverCallback;

    private int spawnedEnemyCount;

    private int killedEnemyCount;

    public int SpawnedEnemyCount => spawnedEnemyCount;

    public int KilledEnemyCount => killedEnemyCount;

    public event System.Action<Character> OnPlayerSpawned;

    public void Initialize(CharacterFactory factory, ScoreSystem score, GameData data, System.Action onGameOver)
    {
        characterFactory = factory; 
        scoreSystem = score;
        gameData = data;
        gameOverCallback = onGameOver;
    }

    public void SpawnPlayer()
    {
        Character player = characterFactory.GetCharacter(CharacterType.Player);

        player.transform.position = Vector3.zero + new Vector3(0,1.08f,0);
        player.gameObject.SetActive(true);
        player.Initialize();
        player.LiveComponent.OnDeath += CharacterDeathHandler;

        OnPlayerSpawned?.Invoke(player);

    }

    public void SpawnEnemy()
    {
        Character enemy = characterFactory.GetCharacter(CharacterType.DefaultEnemy);

        Vector3 playerPosition = characterFactory.Player.transform.position;

        enemy.transform.position = new Vector3(playerPosition.x + GetOffset(), 0, playerPosition.z + GetOffset());
        enemy.gameObject.SetActive(true);
        enemy.Initialize();
        enemy.LiveComponent.OnDeath += CharacterDeathHandler;

        float GetOffset()
        {
            bool isPlus = Random.Range(0, 10) % 2 == 0;
            float offset = Random.Range(gameData.MinSpawnOffset, gameData.MaxSpawnOffset);

            return isPlus ? offset : -1 * offset;
        }
        spawnedEnemyCount++;
    }

    public void CharacterDeathHandler(Character deathCharacter)
    {
        if(deathCharacter.CharacterType == CharacterType.Player)
        {
            gameOverCallback?.Invoke();
        }
        else
        {
            scoreSystem.AddScore(deathCharacter.CharacterData.ScoreCost);
            killedEnemyCount++;
            Debug.Log($"KilledEnenmyCount:{KilledEnemyCount} | (killedEnemyCount):{killedEnemyCount}");
        }

        deathCharacter.gameObject.SetActive(false);
        characterFactory.ReturnCharacter(deathCharacter);
        deathCharacter.LiveComponent.OnDeath -= CharacterDeathHandler;
    }

}
