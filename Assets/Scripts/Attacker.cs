using Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    public GameObject projectile;
    [SerializeField] float minAttackTime = 1f;
    [SerializeField] float maxAttackTime = 5f;
    [SerializeField] TransformRef PlayerPositionRef;
    [SerializeField] AudioSourcePlayer audio;
    private Transform target;
    private float timer;

    void Start()
    {
        ResetTimer();

        if (PlayerPositionRef == null)
        {
            Debug.LogError("Player Position Reference not set", gameObject);
            target = transform;
            return;
        }

        target = PlayerPositionRef.value;

        if (projectile == null)
        {
            projectile = gameObject;
            Debug.LogError("I'm shooting ducks", gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        CountDown();

        if (timer <= 0)
            ShootProjectile();
    }

    private void CountDown()
    {
        timer -= Time.deltaTime;
    }

    private void ShootProjectile()
    {
        GameObject shot = Instantiate(projectile, transform.position, Quaternion.identity);
        shot.transform.LookAt(target);

        if (audio != null)
            audio.PlayAudio();

        ResetTimer();
    }

    private void ResetTimer()
    {
        timer = Random.Range(minAttackTime, maxAttackTime);
    }
}
