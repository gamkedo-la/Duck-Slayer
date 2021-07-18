using System.Collections;
using System.Collections.Generic;
using Events;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health;
    private float MaxHP;
    public HealthDisplay display;
    [SerializeField] GameEvent onPlayerDeath;

    private void Awake()
    {
        if (display == null)
            display = FindObjectOfType<HealthDisplay>();
    }

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
        onPlayerDeath?.Invoke();
        //Debug.Log(gameObject.name + " has died.");
    }

    public void Heal()
    {
        health = MaxHP;
    }
}
