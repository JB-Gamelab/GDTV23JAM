using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryTeleport : MonoBehaviour
{

    private float timer = 0.7f;

    private void Update() {

        transform.position = transform.parent.position;

        timer -= Time.deltaTime;
        if (timer < 0) {
            GameObject.Destroy(gameObject);
        }
    }
}
