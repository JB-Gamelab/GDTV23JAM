using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    public static Diamond Instance { get; private set; }

    public event EventHandler OnDiamondPickup;


    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("Player")) {
            OnDiamondPickup?.Invoke(this, EventArgs.Empty);
            Destroy(this.gameObject);
        }
    }
}
