using System;
using UnityEngine;

public class Building : MonoBehaviour
{
    public int cubes = 0;
    public int maxCubes = 10;
    public ParticleSystem finished;
    public bool played = false;

    private void Update()
    {
        if (cubes == maxCubes)
        {
            if (!played)
            {
                finished.Play();
                played = true;
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube"))
        {
            Destroy(other.gameObject, 3);
            cubes++;
        }
    }
}
