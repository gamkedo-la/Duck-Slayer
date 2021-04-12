using UnityEngine;

public class Target : MonoBehaviour
{
  float health = 100f;

  public void TakeDamage(float amount)
  {
    health -= amount;
    if(health <= 0) {
      Die();
    }
  }

  private void Start() {
    // Invoke("Die", 10.0f); 
  }

  void Die() {
    Destroy(gameObject);
  }
}

