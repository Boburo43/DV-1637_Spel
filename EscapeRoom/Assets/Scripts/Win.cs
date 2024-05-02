using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{

    public bool win = false;
    [SerializeField] GameObject winScreen;

    [SerializeField] float timeCompleted;

    [SerializeField] public TMP_Text Timertext;

    float minutes;
    float seconds;

    private void Start()
    {
        winScreen.SetActive(false);
    }
    private void Update()
    {
        minutes = Mathf.FloorToInt(timeCompleted / 60);
        seconds = Mathf.FloorToInt(timeCompleted % 60);

        if (win == true)
        {
            Time.timeScale = 0f;


            winScreen.SetActive(true);
            Timertext.text = string.Format("You had: {0:00} : {1:00} left", minutes, seconds);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            win = true;

            timeCompleted = Timer.timeLeft;
        }
    }

    public void Mainmenu()
    {
        SceneManager.LoadScene("MainScene");
    }
}