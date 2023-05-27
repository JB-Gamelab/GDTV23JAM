using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonBehaviour : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float fireballTimer = 0f;
    [SerializeField] private float fireballTimerMax = 1f;
    [SerializeField] private float maxHeight = 5f;
    [SerializeField] private float health = 4f;
    [SerializeField] private ProjectileBehaviour projectileBehaviour;
    [SerializeField] private Fireball fireball;
    [SerializeField] private Transform fireballOffset;

    private float startY;
    private bool up = true;
    private bool playerDetected = false;

    private Quaternion directionQuaternion = new Quaternion(0f, 1f, 0f, 0f);

    private void Start() {
        startY = transform.position.y;
    }

    private void Update() {
            float currentY = transform.position.y;

            if (currentY <= startY) {
                up = true;
            }
            if (currentY >= startY + maxHeight) {
                up = false;
            }

            if (up) {
                this.transform.position += transform.up * Time.deltaTime * moveSpeed;
            } else {
                this.transform.position -= transform.up * Time.deltaTime * moveSpeed;
            }
        
        if (playerDetected) {
            fireballTimer -= Time.deltaTime;
            if (fireballTimer < 0) {
                Instantiate(fireball, fireballOffset.position, directionQuaternion);
                fireballTimer = fireballTimerMax;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Projectile")) {
            health -= projectileBehaviour.getDamage();


            if (health <= 0f) {
                Destroy(gameObject);
            }
        } else if (collision.gameObject.CompareTag("Player")) {
            playerDetected = true;
        }
    }
}
