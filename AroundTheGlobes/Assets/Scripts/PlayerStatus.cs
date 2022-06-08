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

    private void Start()
    {
        playerHealth = GetComponent<PlayerHealthSystem>();
        isFreezing = true;
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
        coldIcons.SetActive(true);
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
        coldIcons.SetActive(false);
        while (!isFreezing && playerHealth.PlayerHealth <= 100)
        {
            playerHealth.PlayerHealth += healPerLoop;
            yield return new WaitForSeconds(3f);
        }
    }
    
}
