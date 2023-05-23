using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{

    [SerializeField] private float fireballSpeed = 5f;
    [SerializeField] private float fireballLife = 2f;


    private void Update() {
        transform.position += transform.right * Time.deltaTime * fireballSpeed;

        fireballLife -= Time.deltaTime;
        if (fireballLife < 0) {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {        
        if (collision.collider.CompareTag("Player")) {
            Destroy(gameObject);
        }
    }
}
