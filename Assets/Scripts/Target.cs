using UnityEngine;

public class Target : MonoBehaviour
{
  public ParticleSystem onDestroyParticles;
  float health = 100f;
  

  public void TakeDamage(float amount)
  {
    health -= amount;
    if(health <= 0) {
      Die();
    }
  }

  void Die() {
    Destroy(gameObject);
    ParticleSystem particles = Instantiate(onDestroyParticles, transform.position, transform.rotation);
    Color cubeColor = GetComponentInChildren<MeshRenderer>().material.color;
    
    particles.GetComponent<ParticleSystemRenderer>().material.color = cubeColor;
  }
}

