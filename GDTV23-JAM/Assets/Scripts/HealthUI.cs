using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private GameObject[] healthList = new GameObject[5];
    [SerializeField] private Player player;
    private float currentHealth;

    private void Awake() {
        player.OnDamageReceived += Player_OnDamageReceived;
    }

    private void Player_OnDamageReceived(object sender, System.EventArgs e) {

    }

    private void Update() {
        currentHealth = Player.instance.GetHealth();

        if (currentHealth == 5) {
            healthList[0].SetActive(true);
            healthList[1].SetActive(true);
            healthList[2].SetActive(true);
            healthList[3].SetActive(true);
            healthList[4].SetActive(true);
        }
        if (currentHealth == 4) {
            healthList[0].SetActive(true);
            healthList[1].SetActive(true);
            healthList[2].SetActive(true);
            healthList[3].SetActive(true);
            healthList[4].SetActive(false);
        }
        if (currentHealth == 3) {
            healthList[0].SetActive(true);
            healthList[1].SetActive(true);
            healthList[2].SetActive(true);
            healthList[3].SetActive(false);
            healthList[4].SetActive(false);
        }
        if (currentHealth == 2) {
            healthList[0].SetActive(true);
            healthList[1].SetActive(true);
            healthList[2].SetActive(false);
            healthList[3].SetActive(false);
            healthList[4].SetActive(false);
        }
        if (currentHealth == 1) {
            healthList[0].SetActive(true);
            healthList[1].SetActive(false);
            healthList[2].SetActive(false);
            healthList[3].SetActive(false);
            healthList[4].SetActive(false);
        }
        if (currentHealth == 0) {
            healthList[0].SetActive(false);
            healthList[1].SetActive(false);
            healthList[2].SetActive(false);
            healthList[3].SetActive(false);
            healthList[4].SetActive(false);
        }
    }
}
