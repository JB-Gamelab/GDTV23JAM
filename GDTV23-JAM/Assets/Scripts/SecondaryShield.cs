using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryShield : MonoBehaviour
{

    [SerializeField] private float shieldTimer = 5f;

    private void Update()
    {
        transform.position = transform.parent.position;

        shieldTimer -= Time.deltaTime;

        if (shieldTimer < 0f) {
            GameObject.Destroy(gameObject);
        }
    }
}
