using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject loseMenu;
    public bool isPaused = false;
    public bool isLost = false;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        loseMenu.SetActive(false);
        //winMenu.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer.lose == true)
        {
            isLost = true;
        }
        if (isPaused && Input.GetKeyDown(KeyCode.Escape)) 
        { 
            isPaused = false;    
        }
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = true;  
        }

        // LoseScreen
        if(!isLost)
        {
            Time.timeScale = 1;
            loseMenu.SetActive(false);
            CurserScrip.cursurActive = false;
        }
        else if (isLost)
        {
            Time.timeScale = 0;
            loseMenu.SetActive(true);
            CurserScrip.cursurActive = true;
            Cursor.visible = true;
        }

        if(!isPaused)
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
            CurserScrip.cursurActive = false;
        }
        else if (isPaused)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            Cursor.visible = true;
        }



    }
    public void MainMenu () 
    {
            SceneManager.LoadScene("MainMenu");
    }
    public void Resume()
    {
        isPaused = false;
    }
    public void Restart()
    {
        SceneManager.LoadScene("MainScene");
    }
}
