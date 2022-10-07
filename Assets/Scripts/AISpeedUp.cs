using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AISpeedUp : MonoBehaviour
{
    [SerializeField] private RichAI chaserAI;
    [SerializeField] private GameTimer gameTimer;
    [SerializeField] private DuckCount duckCount;
    [SerializeField] private List<int> ducksCollectedSpeedIncreaseThresholds;
    [SerializeField] private int count = 0;
    [SerializeField] private Inventory inventory;

    private void Start()
    {
        gameTimer = GameObject.FindGameObjectWithTag("GameTimer").GetComponent<GameTimer>();

        chaserAI = GetComponent<RichAI>();
    }

    private void Update()
    {
        if (gameTimer.seconds >= 59)
        {
            IncreaseAISpeed();
        }

        if (duckCount.DucksCollected(duckCount.ducksCollected, inventory) >= ducksCollectedSpeedIncreaseThresholds[count])
        {
            IncreaseAISpeed();
            count++;
        }
    }

    public void IncreaseAISpeed()
    {
        chaserAI.maxSpeed++;
    }
}
