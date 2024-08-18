using DiasGames.Controller;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject optionsMenu;

    CSPlayerController playerController;

    [Header("ReferencesForActivate")]
    [SerializeField] GameObject startMenu;
    [SerializeField] GameObject gameMenu;
    [SerializeField] GameObject dollyTrack;


    private void Awake()
    {
        playerController = FindObjectOfType<CSPlayerController>();

        SetStartMenu();
        
    }
    public void PlayGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void PlayGameNew()
    {
        SetGameMenu();
    }
    public void QuitGameNew()
    {
        SceneManager.LoadScene(0);
    }
    void SetStartMenu()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        startMenu.SetActive(true);
        gameMenu.SetActive(false);

        dollyTrack.SetActive(true);

        playerController.enabled = false;
    }
    void SetGameMenu()
    {
        startMenu.SetActive(false);
        gameMenu.SetActive(true);

        dollyTrack.SetActive(false);

        playerController.enabled = true;
    }
    public void OnApplicationQuit()
    {
        Application.Quit();
    }
    

    
}
