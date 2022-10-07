using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private float invincibilityTimer;
    private float invincibilityTimerReset;
    [SerializeField] private bool playerIsInvincible;
    private SphereCollider sphereCollider;

    private void Start()
    {
        invincibilityTimerReset = invincibilityTimer;
        sphereCollider = GetComponent<SphereCollider>();
    }
    private void Update()
    {
        if (playerIsInvincible)
        {
            invincibilityTimer -= Time.deltaTime;

            if (invincibilityTimer <= 0f)
            {
                sphereCollider.enabled = true;
                invincibilityTimer = invincibilityTimerReset;
                playerIsInvincible = false;
            }
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !playerIsInvincible)
        {
            playerHealth.health --;
            playerHealth.displayDamageOverlay = true;
            playerIsInvincible = true;

            sphereCollider.enabled = false;

            gameObject.transform.position = new Vector3(Random.Range(-100, 100), 2, Random.Range(-100, 100));
        }
    }
}
