using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownUI : MonoBehaviour
{

    [SerializeField] private Image lightPrimary;
    [SerializeField] private Image lightSecondary;
    [SerializeField] private Image darkPrimary;
    [SerializeField] private Image darkSecondary;

    [SerializeField] private Player player;

    private float primaryCooldown;
    private float primaryCDMax;
    private float scaledPrimaryCD;
    private float inversePrimaryCD;
    private float secondaryCooldown;
    private float secondaryCDMax;
    private float scaledSecondaryCD;
    private float inverseSecondaryCD;


    private void Update() {
        primaryCooldown = player.GetPrimaryCooldown();
        secondaryCooldown = player.GetSecondaryCooldown();
        primaryCDMax = player.GetPrimaryCDMax();
        secondaryCDMax = player.GetSecondaryCDMax();

        scaledPrimaryCD = primaryCooldown / primaryCDMax;
        inversePrimaryCD = 1.0f - scaledPrimaryCD;
        scaledSecondaryCD = secondaryCooldown / secondaryCDMax;
        inverseSecondaryCD = 1.0f - scaledSecondaryCD;


        if (!player.GetIsDark()) {
            lightPrimary.enabled = true;
            lightPrimary.fillAmount = inversePrimaryCD;
            lightSecondary.enabled = true;
            lightSecondary.fillAmount = inverseSecondaryCD;
            darkPrimary.enabled = false;
            darkSecondary.enabled = false;
            if (!player.GetPrimaryFired()) {
                lightPrimary.fillAmount = 1.0f;
            }
            if (!player.GetSecondaryFired()) {
                lightSecondary.fillAmount = 1.0f;
            }
        } else {
            lightPrimary.enabled = false;
            lightSecondary.enabled = false;
            darkPrimary.enabled = true;
            darkPrimary.fillAmount = inversePrimaryCD;
            darkSecondary.enabled = true;
            darkSecondary.fillAmount = inverseSecondaryCD;
            if (!player.GetPrimaryFired()) {
                darkPrimary.fillAmount = 1.0f;
            }
            if (!player.GetSecondaryFired()) {
                darkSecondary.fillAmount = 1.0f;
            }
        }
    }

}
