using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonBehaviour : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float attackRange = 5f;
    [SerializeField] private float maxHeight = 5f;

    private float startY;
    private bool up = true;

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
        
    }
}
