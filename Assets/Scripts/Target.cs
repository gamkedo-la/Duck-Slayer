using UnityEngine;

public class Target : MonoBehaviour
{
  public ParticleSystem onDestroyParticles;
  float health = 100f;

  private GameObject gameManager;
  private Score score;

	private void Start()
	{
        gameManager = GameObject.FindWithTag("GameManager");
        if(gameManager != null)
		{
            score = gameManager.GetComponent<Score>();
		}
	}


	public void TakeDamage(float amount)
  {
    health -= amount;
    if(health <= 0) {
      if(score != null)
	    {
        score.IncreaseScore();
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

