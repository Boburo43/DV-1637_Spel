using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject mainMenu;

    private void Start()
    {
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
    public void GoToOptions()
    {
        optionsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void BackToMain()
    {
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void Play()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
