using UnityEngine;
using UnityEngine.UI;

public class Staminabar : MonoBehaviour
{
    [SerializeField] private PlayerController player;

    [SerializeField] private Slider staminaBar;

    private void Update()
    {
        staminaBar.maxValue = player.MaxStamina;

        staminaBar.value = player.Stamina;
    }

}
