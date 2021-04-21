using UnityEngine;

public class Target : MonoBehaviour
{
  public ParticleSystem onDestroyParticles;
  float health = 100f;

  private GameObject gameManager;
  private SlowMotion slowMotion;
  private Score score;

	private void Start()
	{
        gameManager = GameObject.FindWithTag("GameManager");
        if(gameManager != null)
		{
            slowMotion = gameManager.GetComponent<SlowMotion>();
            score = gameManager.GetComponent<Score>();
		}
	}


	public void TakeDamage(float amount)
  {
    health -= amount;
    if(health <= 0) {
        if(slowMotion != null)
	    {
            slowMotion.SlowDown();
	    }
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

