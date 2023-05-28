using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{

    [SerializeField] private Button exitButton;

    private void Awake() {
        exitButton.onClick.AddListener(() => {
            Application.Quit();
        });
    }

    private void Start() {
        Player.instance.OnGameOver += Player_OnGameOver;

        Hide();
    }

    private void Player_OnGameOver(object sender, System.EventArgs e) {
        Show();
    }

    private void Hide() {
        this.gameObject.SetActive(false);
    }

    private void Show() {
        this.gameObject.SetActive(true);
    }
}
