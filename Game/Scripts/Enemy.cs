using System;
using UnityEngine;
using UnityEngine.UI;


public class Enemy: MonoBehaviour
{
    public float StartSpeed = 20f;

    [HideInInspector]
    public float Speed;
    public float StartHealth = 100f;
    public int MoneyGain = 50;

    public GameObject DeathEffect;

    private float health;

    [Header("Unity")]
    public Image HealthBar;

    private void Start()
    {
        Speed = StartSpeed;
        health = StartHealth;
    }
    public void TakeDamage(float amount)
    {
        health -= amount;

        HealthBar.fillAmount = health / StartHealth;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        PlayerStats.Money += MoneyGain;

        GameObject effect = (GameObject) Instantiate(DeathEffect, transform.position, Quaternion.identity);

        Destroy(effect, 5f);
        Destroy(gameObject);
    }

    public void Slow(float factor)
    {
        Speed = StartSpeed * (1f - factor);
    }
}
