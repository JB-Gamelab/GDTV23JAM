using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    [SerializeField] private AudioClip lightProjectile;
    [SerializeField] private AudioClip darkProjectile;
    [SerializeField] private AudioClip shield;
    [SerializeField] private AudioClip teleport;
    [SerializeField] private AudioClip death;


    private void Start() {
        Player.instance.OnProjectileFired += Player_OnProjectileFired;
        Player.instance.OnSecondary += Player_OnSecondary;
        Player.instance.OnGameOver += Player_OnGameOver;
    }

    private void Player_OnGameOver(object sender, System.EventArgs e) {
        AudioSource.PlayClipAtPoint(death, this.transform.position);
    }

    private void Player_OnSecondary(object sender, System.EventArgs e) {
        if (Player.instance.GetIsDark()) {
            AudioSource.PlayClipAtPoint(darkProjectile, this.transform.position);
        } else {
            AudioSource.PlayClipAtPoint(lightProjectile, this.transform.position);
        }
    }

    private void Player_OnProjectileFired(object sender, System.EventArgs e) {
        if (Player.instance.GetIsDark()) {
            AudioSource.PlayClipAtPoint(teleport, this.transform.position);
        } else {
            AudioSource.PlayClipAtPoint(shield, this.transform.position);
        }
    }
}
