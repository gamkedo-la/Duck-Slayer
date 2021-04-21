using UnityEngine;

public class Target : MonoBehaviour
{
  public ParticleSystem onDestroyParticles;
  float health = 100f;

  SlowMotion slowMotion;

	private void Start()
	{
        slowMotion = GameObject.FindWithTag("SlowDown").GetComponent<SlowMotion>();
	}


	public void TakeDamage(float amount)
  {
    health -= amount;
    if(health <= 0) {
        if(slowMotion != null)
	    {
                slowMotion.SlowDown();
	    }
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

