using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{

    [SerializeField] float projectileSpeed = 5f;

    private void Update() {
        transform.position += transform.right * Time.deltaTime * projectileSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Destroy(gameObject);
    }

}
