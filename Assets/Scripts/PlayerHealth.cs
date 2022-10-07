using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerHealth : MonoBehaviour
{
    public int health = 4;
    //[SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private Image damageOverlay;
    [SerializeField] private float damageOveralyDisplayTime;
    private float damageOveralyDisplayTimeReset;
    public bool displayDamageOverlay;

    [SerializeField] private TextMeshProUGUI endText, endSubText;
    [SerializeField] private GameObject endPanel;

    
    void Start()
    {
        damageOveralyDisplayTimeReset = damageOveralyDisplayTime;
        damageOverlay.enabled = false;
        endPanel.SetActive(false);

        gameObject.GetComponent<FirstPersonController>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;

        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (displayDamageOverlay)
        {
            switch (health)
            {
                case > 20:
                    DisplayDamageOverlay(0.15f);
                    break;
                case > 10:
                    DisplayDamageOverlay(0.30f);
                    break;
                case > 5:
                    DisplayDamageOverlay(0.45f);
                    break;
                case 0:
                    DisplayDamageOverlay(6f);
                    LoseGameUI();

                    break;
            }
        }
    }

    void DisplayDamageOverlay(float maxAlpha)
    {
        if (displayDamageOverlay)
        {
            damageOverlay.enabled = true;
            damageOveralyDisplayTime -= Time.deltaTime;

            if (damageOveralyDisplayTime >= damageOveralyDisplayTimeReset - 1f)
            {
                damageOverlay.color = new Color(damageOverlay.color.r, damageOverlay.color.g, damageOverlay.color.b, Mathf.Lerp(0f, maxAlpha, damageOveralyDisplayTimeReset - damageOveralyDisplayTime));

            }

            if (damageOveralyDisplayTime <= 1f)
            {
                damageOverlay.color = new Color(damageOverlay.color.r, damageOverlay.color.g, damageOverlay.color.b, Mathf.Lerp(0f, maxAlpha, damageOveralyDisplayTime));
            }

            if (damageOveralyDisplayTime <= 0f)
            {

                damageOverlay.enabled = false;
                damageOveralyDisplayTime = damageOveralyDisplayTimeReset;
                displayDamageOverlay = false;
            }
        }
    }

    public void LoseGameUI()
    {
        
        endPanel.SetActive(true);
        endText.text = "You were caught!";
        endSubText.text = "...ouch";

        gameObject.GetComponent<FirstPersonController>().enabled = false;
        Cursor.lockState = CursorLockMode.Confined;

        Time.timeScale = 0f;
    }
}
