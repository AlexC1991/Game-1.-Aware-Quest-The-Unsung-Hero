using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject startGameButton;
    [SerializeField] private GameObject creditsButton;
    [SerializeField] private GameObject controlsButton;
    [SerializeField] private GameObject controlsScreen;
    [SerializeField] private GameObject creditsScreen;

    private void Start()
    {
        controlsScreen.SetActive(false);
        creditsScreen.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("MainStartScreen");
    }
    
    public void ControlsScreen()
    {
        creditsButton.SetActive(false);
        startGameButton.SetActive(false);
        controlsButton.SetActive(false);
        creditsScreen.SetActive(false);
        controlsScreen.SetActive(true);
    }

    public void BackButton()
    {
        creditsButton.SetActive(true);
        startGameButton.SetActive(true);
        controlsButton.SetActive(true);
        controlsScreen.SetActive(false);
        creditsScreen.SetActive(false);
    }

    public void CreditsScreen()
    {
        creditsButton.SetActive(false);
        startGameButton.SetActive(false);
        controlsButton.SetActive(false);
        controlsScreen.SetActive(false);
        creditsScreen.SetActive(true);
    }
}
