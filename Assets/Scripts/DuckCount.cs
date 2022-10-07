using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DuckCount : MonoBehaviour
{
    [SerializeField] public int totalDucks, ducksCollected;
    [SerializeField] private Inventory inventory;
    [SerializeField] private TextMeshProUGUI duckCountText, winTriggerText;
    [SerializeField] private SpawnDucks spawnDucks;
    [SerializeField] private GameObject winTrigger;
    [SerializeField] private bool displayWinTriggerText;
    [SerializeField] private float winTriggerTextTimer = 5f;
    private float winTriggerTextTimerReset;
    void Start()
    {
        totalDucks = spawnDucks.duckPrefabs.Count * spawnDucks.duckNumPerType;
        winTriggerTextTimerReset = winTriggerTextTimer;
        winTriggerText.enabled = false;
        winTrigger.SetActive(false);
    }

    void Update()
    {
        duckCountText.text = DucksCollected(ducksCollected, inventory) + "/" + totalDucks + " Ducks Collected";

        if (DucksCollected(ducksCollected, inventory) >= 15)
        {
            ActivateWinTrigger();
        }

        if (displayWinTriggerText)
        {
            winTriggerText.enabled = true;
            winTriggerTextTimer -= Time.deltaTime;

            if (winTriggerTextTimer >= winTriggerTextTimerReset - 2f)
            {
                winTriggerText.alpha = Mathf.Lerp(0f, 1f, winTriggerTextTimerReset - winTriggerTextTimer);

            }

            if (winTriggerTextTimer <= 2f)
            {
                winTriggerText.alpha = Mathf.Lerp(0f, 1f, winTriggerTextTimer);
            }

            if (winTriggerTextTimer <= 0f)
            {

                winTriggerText.enabled = false;
                winTriggerTextTimer = winTriggerTextTimerReset;
                displayWinTriggerText = false;
            }
        }
    }

    public int DucksCollected(int ducksCollected, Inventory inventory)
    {
        foreach (InventoryItem item in inventory.inventory)
        {
            ducksCollected += item.numCarried;
        }

        return ducksCollected;
    }

    public void ActivateWinTrigger()
    {
        winTrigger.SetActive(true);
        displayWinTriggerText = true;

       
    }
}
