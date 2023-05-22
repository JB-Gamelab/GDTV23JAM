using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OgreBehaviour : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float attackRange = 5f;
    [SerializeField] private float maxDist = 5f;
    
    [SerializeField] private SpriteRenderer spriteRenderer;

    private float startX;
    private bool up = true;


    private void Start() {
        startX = transform.position.x;
    }

    private void Update() {
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
        
    }
}
