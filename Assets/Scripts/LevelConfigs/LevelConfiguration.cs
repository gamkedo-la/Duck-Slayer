using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Level Config", fileName = "Empty Level Config")]
public class LevelConfiguration : ScriptableObject
{
    public GameObject[] DuckPrefab;
    public int AttackPathIndexLimit;
    public int PassivePathIndexLimit;

    [Header("Edit the probabilties of aggressive or passive duck spawns")]
    public int AttackWeight;
    public int PassiveWeight;

    [Header("Time between ducks")]
    public float minSpawnTime;
    public float maxSpawnTime;

    [Header("Delay before first duck spawns")]
    public float Timer;

    [Header("Time it takes for each duck to complete its path")]
    public float DuckMinFlightTime;
    public float DuckMaxFlightTime;

    [Header("Game Variables")]
    [Range(0, 100)] public float DiveBombProbability;
}
