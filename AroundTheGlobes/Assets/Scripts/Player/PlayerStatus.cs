using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] private GameObject coldIcons;
    [SerializeField] private float loopTime;
    [SerializeField] private float damageAmount;
    [SerializeField] private float healAmount;

    private void Start()
    {
        playerHealth = GetComponent<PlayerHealthSystem>();
        isFreezing = true;
    }

    private void Update()
    {
        if (isFreezing && !isTakingDamage)
        {
            StartCoroutine(FreezeDamage());
        }
        else if (!isFreezing && isTakingDamage)
        {
            StopCoroutine(FreezeDamage());
            isTakingDamage = false;
        }

        if (!isFreezing && !isHealing)
        {
            StartCoroutine(Heal());
        }
        else if (isFreezing && isTakingDamage)
        {
            StopCoroutine(Heal());
            isHealing = false;
        }

    }

    public IEnumerator FreezeDamage()
    {
        isTakingDamage = true;
        float damagePerLoop = damageAmount;
        coldIcons.SetActive(true);
        while (isFreezing)
        {
            yield return new WaitForSeconds(loopTime);
            playerHealth.PlayerHealth -= damagePerLoop;

        }
    }
    
    public IEnumerator Heal()
    {
        isHealing = true;
        float healPerLoop = healAmount;
        coldIcons.SetActive(false);
        while (!isFreezing && playerHealth.PlayerHealth <= 100)
        {
            yield return new WaitForSeconds(loopTime);
            playerHealth.PlayerHealth += healPerLoop;
        }
    }
    
}
