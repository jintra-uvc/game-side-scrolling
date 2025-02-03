using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float damage = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            HealthSystemForDummies healthSystem = collision.gameObject.GetComponent<HealthSystemForDummies>();

            if (healthSystem.CurrentHealth > damage) {
                healthSystem.AddToCurrentHealth(Mathf.Abs(damage) * (-1));
            } else
            {
                healthSystem.Kill();
            }
        }
    }
}
