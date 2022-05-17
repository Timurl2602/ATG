using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public TextMeshProUGUI buttonSnow;
    public TextMeshProUGUI buttonBlizzard;
    
    public ParticleSystem snow;
    public ParticleSystem blizzard;

    private void Awake()
    {
        buttonSnow.text = "Disable Snow";
        buttonBlizzard.text = "Enable Blizzard";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Game has been quit!");
            Application.Quit();
        }
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("IceWorldTest_01");
        }
    }

    public void EnableSnow()
    {
        if (!snow.isPlaying)
        {
            blizzard.Stop();
            snow.Play();
            buttonSnow.text = "Disable Snow";
            buttonBlizzard.text = "Enable Blizzard";
        }
        else
        {
            snow.Stop();
            buttonSnow.text = "Enable Snow";
        }
    }
    
    public void EnableBlizzard()
    {
        if (!blizzard.isPlaying)
        {
            snow.Stop();
            blizzard.Play();
            buttonBlizzard.text = "Disable Blizzard";
            buttonSnow.text = "Enable Snow";
        }
        else
        {
            blizzard.Stop();
            buttonBlizzard.text = "Enable Blizzard";
        }
    }
}
