using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public PowerUp[] powerUpPrefabArray;
    public Transform powerUpSpawnPointsContainer;
    [SerializeField] public int powerUpSpawnerThreshold = 50;
    private Score scoreKeeper;
    private int lastScoreThreshold;

    private void Update()
    {
        if(scoreKeeper!= null && scoreKeeper.CurrentScore > lastScoreThreshold+powerUpSpawnerThreshold)
        {
            lastScoreThreshold = scoreKeeper.CurrentScore;
            SpawnPowerUp();
        }
    }
    private void SpawnPowerUp()
    {
        var spawnPoint = GetSpawnPoint();
        var powerUpPrefab = powerUpPrefabArray[Random.Range(0, powerUpPrefabArray.Length)];
        Instantiate(powerUpPrefab, spawnPoint.position, Quaternion.identity);
    }

    private Transform GetSpawnPoint()
    {
        var childCount = powerUpSpawnPointsContainer.childCount;
        var randomChildIndex = Random.Range(0, childCount);
        return powerUpSpawnPointsContainer.GetChild(randomChildIndex);
    }

    public void SetScoreKeeper(Score value)
    {
        this.scoreKeeper = value;
    }
}
