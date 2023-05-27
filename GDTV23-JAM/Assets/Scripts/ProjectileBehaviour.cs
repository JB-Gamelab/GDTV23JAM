using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{

    [SerializeField] float lightProjectileSpeed = 2f;
    [SerializeField] float darkProjectileSpeed = 20f;
    [SerializeField] float lightProjectileLife = 6f;
    [SerializeField] float darkProjectileLife = 0.15f;
    [SerializeField] float lightProjectileDamage = 5f;
    [SerializeField] float darkProjectileDamage = 2f;
    [SerializeField] GameObject lightProjectile;
    [SerializeField] GameObject darkProjectile;

    private float projectileSpeed;
    private float projectileLife;
    private float projectileDamage;
   

    private void Awake() {
        if (Player.instance.GetIsDark()) {
            lightProjectile.SetActive(false);
            darkProjectile.SetActive(true);
            projectileSpeed = darkProjectileSpeed;
            projectileLife = darkProjectileLife;
            projectileDamage = darkProjectileDamage;
        } else {
            lightProjectile.SetActive(true);
            darkProjectile.SetActive(false);
            projectileSpeed = lightProjectileSpeed;
            projectileLife = lightProjectileLife;
            projectileDamage = lightProjectileDamage;
        }
    }

    private void Update() {
        transform.position += transform.right * Time.deltaTime * projectileSpeed;

        projectileLife -= Time.deltaTime;
        if (projectileLife < 0) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (!collision.CompareTag("Player")) {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("Environment")) {
            Destroy(gameObject);
        }
    }

    public float getDamage() {
        if (!Player.instance.GetIsDark()) {
            return lightProjectileDamage;
        } else {
            return darkProjectileDamage;
        }
    }

}
