using System;
using System.Collections;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] private bool isFreezing; 
        public bool IsFreezing
    {
        get { return isFreezing; }
        set => isFreezing = value;
    }
    [SerializeField] private bool isTakingDamage;
    [SerializeField] private bool isHealing;
    [SerializeField] private PlayerHealthSystem playerHealth;

    private void Start()
    {
        playerHealth = GetComponent<PlayerHealthSystem>();
    }

    private void Update()
    {
        if (isFreezing && !isTakingDamage)
        {
            StartCoroutine(FreezeDamage(5));
        }
        else if (!isFreezing && isTakingDamage)
        {
            StopCoroutine(FreezeDamage(0));
            isTakingDamage = false;
        }

        if (!isFreezing && !isHealing)
        {
            StartCoroutine(Heal(10));
        } 
        else if (isFreezing && isTakingDamage)
        {
            StopCoroutine(Heal(0));
            isHealing = false;
        }
        
    }

    public IEnumerator FreezeDamage(float damageAmount)
    {
        isTakingDamage = true;
        float damagePerLoop = damageAmount;
        while (isFreezing)
        {
            playerHealth.PlayerHealth -= damagePerLoop;
            yield return new WaitForSeconds(3f);

        }
    }
    
    public IEnumerator Heal(float healAmount)
    {
        isHealing = true;
        float healPerLoop = healAmount;
        while (!isFreezing && playerHealth.PlayerHealth <= 100)
        {
            playerHealth.PlayerHealth += healPerLoop;
            yield return new WaitForSeconds(3f);
        }
    }
    
}
