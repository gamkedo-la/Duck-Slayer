using UnityEngine;
using Events;
public class Target : MonoBehaviour
{
    public ParticleSystem onDestroyParticles;
    [SerializeField] float health = 100f;
    [SerializeField] [Range(2, 10)] float scoreBonusMultiplier = 2f;
    [SerializeField] float distanceWhereBonusNoLongerApplies = 5f;
    [SerializeField] TransformRef PlayerPosition;
    public bool isBoss = false;
    private Vector3 playerPosition;
    private DetachChildren detacher;

    private void Start()
    {
        detacher = GetComponent<DetachChildren>();

        if (PlayerPosition == null)
        {
            playerPosition = Vector3.zero;
            return;
        }

        playerPosition = PlayerPosition.value.position;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            var distanceMultiplier = Vector3.Distance(transform.position, playerPosition);

            var multiplier = distanceMultiplier > distanceWhereBonusNoLongerApplies ? Mathf.RoundToInt(distanceMultiplier) : scoreBonusMultiplier * distanceMultiplier;

            if (isBoss)
            {
                multiplier *= scoreBonusMultiplier;
            }

            GameManagerSingleton.instance.GetScore().IncreaseScore(multiplier);

            Die();
        }
    }

    public void Die()
    {
        if (detacher != null)
            detacher.DetachAndInvoke();

        Destroy(gameObject);
        ParticleSystem particles = Instantiate(onDestroyParticles, transform.position, transform.rotation);
        Color cubeColor = GetComponentInChildren<MeshRenderer>().material.color;
        particles.GetComponent<ParticleSystemRenderer>().material.color = cubeColor;
    }
}

