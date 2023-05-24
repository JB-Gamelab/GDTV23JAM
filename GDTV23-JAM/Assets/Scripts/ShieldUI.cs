using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldUI : MonoBehaviour {

    [SerializeField] private Transform container;
    [SerializeField] private GameObject[] healthList = new GameObject[3];
    [SerializeField] private SecondaryShield shield;
    private float currentHealth;

    private void Start() {
        container.gameObject.SetActive(false);
    }

    private void Update() {
        if (GameObject.Find("SecondaryShield(Clone)")) {
            container.gameObject.SetActive(true);
        } else {
            container.gameObject.SetActive(false);
        }
        
        currentHealth = shield.GetShieldHealth();

        if (currentHealth == 3) {
            healthList[0].SetActive(true);
            healthList[1].SetActive(true);
            healthList[2].SetActive(true);
        }
        if (currentHealth == 2) {
            healthList[0].SetActive(true);
            healthList[1].SetActive(true);
            healthList[2].SetActive(false);
        }
        if (currentHealth == 1) {
            healthList[0].SetActive(true);
            healthList[1].SetActive(false);
            healthList[2].SetActive(false);
        }
        if (currentHealth == 0) {
            healthList[0].SetActive(false);
            healthList[1].SetActive(false);
            healthList[2].SetActive(false);
            gameObject.SetActive(false);
        }

    }
}