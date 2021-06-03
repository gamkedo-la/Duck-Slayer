using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] TransformRef PlayerPosition;
    [SerializeField] float minSpeed = 1f;
    [SerializeField] float maxSpeed = 5f;
    [SerializeField] float heightAtWhichWillSelfDestructWhenSpawned = 0.1f;
    private float speed;
    private Vector3 playerPosition;


    void Start()
    {
        SelfDestructIfSpawnedTooLow();

        playerPosition = PlayerPosition.value.position;

        speed = Random.Range(minSpeed, maxSpeed) * Time.deltaTime;

        if (PlayerPosition == null)
        {
            Destroy(this);
            Debug.LogError("No Target, can't shoot", gameObject);
        }
    }

    private void SelfDestructIfSpawnedTooLow()
    {
        if (transform.position.y < heightAtWhichWillSelfDestructWhenSpawned)
            Destroy(this);
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerPosition, speed);
        transform.LookAt(playerPosition);
    }
}
