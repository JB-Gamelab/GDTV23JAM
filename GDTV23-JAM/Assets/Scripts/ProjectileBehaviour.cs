using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{

    [SerializeField] float projectileSpeed = 5f;
    [SerializeField] GameObject lightProjectile;
    [SerializeField] GameObject darkProjectile;

    private void Awake() {
        if (Player.instance.GetIsDark()) {
            lightProjectile.SetActive(false);
            darkProjectile.SetActive(true);
            projectileSpeed = 20f;
        } else {
            lightProjectile.SetActive(true);
            darkProjectile.SetActive(false);
            projectileSpeed = 1.5f;
        }
    }

    private void Update() {
            transform.position += transform.right * Time.deltaTime * projectileSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Destroy(gameObject);
    }

}
