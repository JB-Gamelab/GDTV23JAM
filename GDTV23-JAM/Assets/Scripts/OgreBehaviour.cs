using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OgreBehaviour : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float attackSpeed = 0.05f;
    [SerializeField] private float maxDist = 5f;
    [SerializeField] private float health = 4f;

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private ProjectileBehaviour projectileBehaviour;
    [SerializeField] private Player player;

    private float startX;
    private bool up = true;
    private bool playerDetected = false;


    private void Start() {
        startX = transform.position.x;
    }

    private void Update() {
        if (!playerDetected) {
            float currentX = transform.position.x;

            if (currentX <= startX) {
                up = true;
            }
            if (currentX >= startX + maxDist) {
                up = false;
            }

            if (up) {
                this.transform.position += transform.right * Time.deltaTime * moveSpeed;
                spriteRenderer.flipX = true;
            } else {
                this.transform.position -= transform.right * Time.deltaTime * moveSpeed;
                spriteRenderer.flipX = false;
            }
        } else {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, attackSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Projectile")) {
            health -= projectileBehaviour.getDamage();

            if (health <= 0f) {
                Destroy(gameObject);
            }
        }

        if (collision.gameObject.CompareTag("Player")) {
            playerDetected = true;
        }
    }
}
