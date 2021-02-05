using UnityEngine;

public class Target : MonoBehaviour
{
  float health = 200f;
  public void TakeDamage(float amount)
  {
    health -= amount;
    if(health <= 0) {
      Die();
    }
  }

  void Die() {
    Destroy(gameObject);
  }
}

