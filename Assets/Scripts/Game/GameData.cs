using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData")]
public class GameData : ScriptableObject
{
    [SerializeField]
    private int sessionTimeMinutes; // время сессии в МИНУТАХ

    [SerializeField]
    private float timeBetweenEnemySpawn; // КД между спавном врага в СЕКУНДАХ

    [SerializeField]
    private int maxEnemyCount; // максимальное количество врагов на сцене

    [SerializeField]
    private int wavesTimeMinutes; // длительность волны в МИНУТАХ

    [SerializeField] 
    private int maxWaves; // Максимальное количество волн

    [SerializeField]
    private int breakTimeSeconds; // перерыв между волнами в МИНУТАХ

    [SerializeField]
    private float minSpawnOffset;

    [SerializeField]
    private float maxSpawnOffset;

    /// 

    public int SessionTimeMinutes => sessionTimeMinutes; // время сессии в МИНУТАХ

    public int SessionTimeSeconds => sessionTimeMinutes * 60; // время сессии в СЕКУНДАХ

    public float TimeBetweenEnemySpawn => timeBetweenEnemySpawn; // КД между спавном врага

    public int WavesTimeMinutes => wavesTimeMinutes; // длительность волны в МИНУТАХ

    public int WavesTimeSeconds => wavesTimeMinutes * 60; // длительность волны в СЕКУНДАХ

    public int MaxWaves => maxWaves; // Максимальное количество волн

    public int BreakTimeSeconds => breakTimeSeconds; // перерыв между волнами в СЕКУНДАХ

    public int MaxEnemyCount => maxEnemyCount;

    public float MinSpawnOffset => minSpawnOffset;

    public float MaxSpawnOffset => maxSpawnOffset;

}
