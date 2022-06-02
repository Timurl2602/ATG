using UnityEngine;

public class Fires : MonoBehaviour
{
    [SerializeField] private PlayerStatus playerStatus;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerStatus.IsFreezing = false;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerStatus.IsFreezing = true;
        }
    }
}
