using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryShield : MonoBehaviour
{

    [SerializeField] private float shieldTimer = 5f;
    [SerializeField] private float shieldHealth = 3f;

    private void Update()
    {
        transform.position = transform.parent.position;

        shieldTimer -= Time.deltaTime;

        if (shieldTimer < 0f) {
            GameObject.Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Enemy")) {
            shieldHealth -= 1;

            if (shieldHealth <= 0) {
                GameObject.Destroy(gameObject);
            }
        }
    }

    public float GetShieldHealth() {
        return shieldHealth;
    }

}
