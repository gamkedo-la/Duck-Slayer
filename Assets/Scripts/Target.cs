using UnityEngine;

public class Target : MonoBehaviour
{
    public ParticleSystem onDestroyParticles;
    float health = 100f;


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
        Destroy(gameObject);
        ParticleSystem particles = Instantiate(onDestroyParticles, transform.position, transform.rotation);
        Color cubeColor = GetComponentInChildren<MeshRenderer>().material.color;
        particles.GetComponent<ParticleSystemRenderer>().material.color = cubeColor;
    }
}

