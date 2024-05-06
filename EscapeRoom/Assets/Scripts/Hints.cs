using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Hints : MonoBehaviour
{
    [SerializeField] private GameObject qHint;
    [SerializeField] GameObject hint1;
    [SerializeField] GameObject hint2;
    [SerializeField] GameObject hint3;
    [SerializeField] GameObject hint4;
    [SerializeField] GameObject hint5;
    bool showQ = false;
    bool showH = false;
    int hintIndex = 1;
    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        qHint.SetActive(false);
        hint1.SetActive(false);
        hint2.SetActive(false);
        hint3.SetActive(false);
        hint4.SetActive(false);
        hint5.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (showQ)
        {
            qHint.SetActive(true);
            if (Input.GetKey(KeyCode.Q))
            {
                showQ = false;
                showH = true;
            }
        }
        else
        {
            qHint.SetActive(false);
        }
        if(Input.GetKey(KeyCode.H)) 
        {
            timer = 4f;
        }
        if (Input.GetKey(KeyCode.H) || timer != 0)
        {
            if(timer > 0)
            {
                timer -= Time.deltaTime;
                Debug.Log(timer);
            }
            if (hintIndex == 1)
            {
                hint1.SetActive(true);
                Debug.Log("HEj");
                if(timer >=0)
                {
                    hint1.SetActive(false);
                    Debug.Log("då");
                }
            }
            else if (hintIndex == 2)
            {
                hint2.SetActive(true);
                if (timer >= 0)
                {
                    hint2.SetActive(false);
                }
            }
            else if (hintIndex == 3)
            {
                hint3.SetActive(true);
                if (timer >= 0)
                {
                    hint3.SetActive(false);
                }
            }
            else if (hintIndex == 4)
            {
                hint4.SetActive(true);
                if (timer >= 0)
                {
                    hint4.SetActive(false);
                }
            }
            else if (hintIndex == 5)
            {
                hint5.SetActive(true);
                if (timer >= 0)
                {
                    hint5.SetActive(false);
                }
            }
        }

    }
    private void OnTriggerEnter(Collider col)
    {
        if (!showH)
        {
            showQ = true;
        }
    }
}
