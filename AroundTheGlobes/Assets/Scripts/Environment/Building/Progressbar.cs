using UnityEngine;
using UnityEngine.UI;

public class Progressbar : MonoBehaviour
{
    [SerializeField] private Building building;

    [SerializeField] private Slider buildingProgressbar;

    private void Update()
        {

            buildingProgressbar.maxValue = building.maxCubes;

            buildingProgressbar.value = building.cubes;

            if (buildingProgressbar.value == buildingProgressbar.maxValue)
            {
                Destroy(gameObject);
            }

        }

}
