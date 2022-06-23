using System.Collections.Generic;
using UnityEngine;


public class RandomizeBlizzard : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private ParticleSystem snow;
    [SerializeField] private ParticleSystem blizzard;
    [SerializeField] private GameObject[] bonfires;

    [Header("Settings")]
    [Tooltip("Snow Chance value between 0 and 100. Blizzard has the remaining chance")]
    [SerializeField] private int snowChance;
    [Tooltip("Timer length in Seconds. 60 = 1 minute")]
    [SerializeField] private float timerLength;

    [Header("Logic Visualization")]
    [SerializeField] private float timer;
    [SerializeField] private bool isTimerRunning;
    [SerializeField] private int disabledBonfire;

    private void Start()
    {
        isTimerRunning = true;
        timer = timerLength;
    }

    private void Update()
    {
        
        if (isTimerRunning)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }

            if (timer <= 0)
            {
                Roll();
            }
  
        }
    }

    private void Roll()
    {
        var randomNumber = Random.Range(0, 100);
        timer = timerLength;


        if (randomNumber <= snowChance)
        {
            bonfires[disabledBonfire].gameObject.SetActive(true);
            snow.Play();
            blizzard.Stop();
            Debug.Log("Snow");
        }

        if (randomNumber > snowChance )
        {
            blizzard.Play();
            bonfires[disabledBonfire].gameObject.SetActive(true);
            snow.Stop();
            var randomBonfire = Random.Range(0, bonfires.Length);
            disabledBonfire = randomBonfire;
            bonfires[randomBonfire].gameObject.SetActive(false);
            Debug.Log("Blizzard");
            Debug.Log(randomNumber);
            Debug.Log(randomBonfire);
        }
    }
}
