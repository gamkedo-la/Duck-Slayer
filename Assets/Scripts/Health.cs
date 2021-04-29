using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health;
    private float MaxHP;
    public HealthDisplay display;


    private void Start()
    {
        MaxHP = health;
    }

    public void DealDamage(float damage)
    {
        health -= damage;

        display.SetValue(health / MaxHP);

        if (health <= 0)
            Death();
    }

    public void Death()
    {
        Debug.Log(gameObject.name + " has died.");
    }
}
