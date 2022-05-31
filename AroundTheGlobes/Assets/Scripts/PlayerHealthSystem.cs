using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerHealthSystem : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private float playerHealth;
    public float PlayerHealth
    {
        get { return playerHealth; }
        set => playerHealth = value;
    }

    private void Update()
    {
        if (playerHealth <= 0)
        {
            SceneManager.LoadScene("IceWorldTest_01");
        }

        if (playerHealth > 100)
        {
            playerHealth = 100;
        }

        healthBar.fillAmount = playerHealth / 100;
    }

}
