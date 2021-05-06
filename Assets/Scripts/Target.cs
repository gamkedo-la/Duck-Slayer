using UnityEngine;

public class Target : MonoBehaviour
{
    public ParticleSystem onDestroyParticles;
    float health = 100f;
    private DetachChildren detacher;

    private void Start()
    {
        detacher = GetComponent<DetachChildren>();
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            GameManagerSingleton.instance.GetScore().IncreaseScore();
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

