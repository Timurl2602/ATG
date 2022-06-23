using System;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Transform destination;
    public Rigidbody objectRigidbody;
    public bool isPlayerInRange;
    public bool isPicked;

    private void Start()
    {
        objectRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (isPlayerInRange  && !isPicked )
            {
                isPicked = true;
                
                if(isPicked)
                {
                    this.transform.position = destination.position;
                    this.transform.parent = GameObject.Find("Destination").transform;
                    objectRigidbody.useGravity = false;
                    objectRigidbody.constraints = RigidbodyConstraints.FreezeAll;
                }
            }
            else
            {
                    isPicked = false;
                    this.transform.parent = null;
                    objectRigidbody.useGravity = true;
                    objectRigidbody.constraints = RigidbodyConstraints.None;
            }
        } 
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }
}
