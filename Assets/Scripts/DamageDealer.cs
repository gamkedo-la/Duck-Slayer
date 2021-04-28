using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] float damage;
    private Target targetComponent;

    private void Start()
    {
        targetComponent = GetComponent<Target>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var player = other.GetComponent<Health>();

            player.DealDamage(damage);

            if (targetComponent != null)
                targetComponent.Die();

            //Destroy(gameObject);
        }
    }
}
