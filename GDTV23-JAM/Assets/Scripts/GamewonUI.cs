using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamewonUI : MonoBehaviour
{

    [SerializeField] private Button exitButton;
    [SerializeField] private Diamond diamond;

    private void Awake() {
        exitButton.onClick.AddListener(() => {
            Application.Quit();
        });

    }

    private void Start() {
        diamond.OnDiamondPickup += Diamond_OnDiamondPickup;
        Hide();
    }

    private void Diamond_OnDiamondPickup(object sender, System.EventArgs e) {
        Show();
        Time.timeScale = 0f;
    }

    private void Hide() {
        this.gameObject.SetActive(false);
    }

    private void Show() {
        this.gameObject.SetActive(true);
    }
}
