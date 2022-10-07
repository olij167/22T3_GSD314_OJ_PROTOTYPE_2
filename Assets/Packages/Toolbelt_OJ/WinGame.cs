using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityStandardAssets.Characters.FirstPerson;


public class WinGame : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI endText, endSubText;
    [SerializeField] private GameObject endPanel;

    private void Start()
    {
        //endPanel = GameObject.FindGameObjectWithTag("EndPanel");
        //endText = endPanel.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        //endSubText = endPanel.transform.GetChild(2).GetComponent<TextMeshProUGUI>();

        //Camera.main.GetComponent<CamController>().enabled = true;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        gameObject.GetComponent<FirstPersonController>().enabled = true;


        endPanel.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            //gameTimer.enabled = false;
            Time.timeScale = 0;
            endPanel.SetActive(true);
            endText.text = "You Escaped!";
            endSubText.text = "nice.";
            Cursor.lockState = CursorLockMode.Confined;
            gameObject.GetComponent<FirstPersonController>().enabled = false;



        }

    }
}
