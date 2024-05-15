using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Playables;

public class Timer : MonoBehaviour
{
    public static float timeLeft = 900f;
    private float totalTime = 900f;
    public bool timerOn = true;
    [SerializeField] private Cam Camera;
    public static bool lose = false;

    [SerializeField] private GameObject HalfTimeText;
    float warningActive = 5f;

    public TMP_Text TimerTxt;
    // Start is called before the first frame update
    void Start()
    {
        timeLeft = 900f;
        timerOn = true;
        HalfTimeText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(timerOn)
        {
            if(timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                updateTimer(timeLeft);
                lose = false;
                if(timeLeft <= totalTime / 2 & warningActive > 0)
                {
                    //Notifiera spelare
                    HalfTimeText.gameObject.SetActive(true);
                    warningActive -= Time.deltaTime;
                }
                else
                {
                    HalfTimeText.gameObject.SetActive(false);
                }
            }
            else
            {
                timerOn = false;
                lose = true;
            }
            
        }
    }
    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float timeleft = Mathf.FloorToInt((currentTime / totalTime) * 100);

        TimerTxt.text = string.Format("Battery left: {0} %", timeleft);
    }
}
