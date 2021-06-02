using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiveBomber : MonoBehaviour
{
    [SerializeField] float minTimeToDive = 1.5f;
    [SerializeField] float maxTimeToDive = 3f;
    [SerializeField] float minSpeed = 1f;
    [SerializeField] float maxSpeed = 5f;

    private float diveBombTimer;
    [SerializeField] bool shouldDiveBomb = false;

    [SerializeField] Vector3 playerPosition;

    void Start()
    {
        diveBombTimer = Random.Range(minTimeToDive, maxTimeToDive);
    }

    void Update()
    {
        if (!shouldDiveBomb) return;

        CountDown();

        if (diveBombTimer <= 0)
            DiveBomb();
    }

    private void DiveBomb()
    {
        var path = GetComponent<PathFollower>();

        if (path)
            path.StopFollowingPath();

        var speed = Random.Range(minSpeed, maxSpeed) * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, playerPosition, speed);
        transform.LookAt(playerPosition);
    }

    private void CountDown()
    {
        diveBombTimer -= Time.deltaTime;
    }

    public void SetPlayerTarget(Vector3 playerPos)
    {
        playerPosition = playerPos;
    }

    public void RollForDiveBomb(float probability)
    {
        var roll = (Random.value * 100);

        if (roll > probability) return;

        Debug.LogWarning("I'm a divebomber!", gameObject);
        shouldDiveBomb = true;
    }
}
