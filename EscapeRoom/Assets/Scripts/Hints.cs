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
    public int hintIndex = 1;
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
        if (Input.GetKey(KeyCode.H))
        {
            timer = 4f;
        }
        if (Input.GetKey(KeyCode.H) || timer != 0)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            if (hintIndex == 1)
            {
                if (timer < 0)
                {
                    hint1.SetActive(false);
                    timer = 0;
                }
                else
                {
                    hint1.SetActive(true);

                }
            }
            else if (hintIndex == 2)
            {
                if (timer < 0)
                {
                    hint2.SetActive(false);
                    timer = 0;
                }
                else
                {
                    hint2.SetActive(true);

                }
            }
            else if (hintIndex == 3)
            {
                if (timer < 0)
                {
                    hint3.SetActive(false);
                    timer = 0;
                }
                else
                {
                    hint3.SetActive(true);

                }
            }
            else if (hintIndex == 4)
            {
                if (timer < 0)
                {
                    hint4.SetActive(false);
                    timer = 0;
                }
                else
                {
                    hint4.SetActive(true);

                }
            }
            else if (hintIndex == 5)
            {
                if (timer < 0)
                {
                    hint5.SetActive(false);
                    timer = 0;
                }
                else
                {
                    hint5.SetActive(true);

                }
            }
        }

    }
    
    private void OnTriggerEnter(Collider col)
    {

        Debug.Log("Something is triggered");
        Debug.Log("Name: " + col.gameObject.name);
        
        if (col.gameObject.CompareTag("Player"))
        {
            if (!showH)
            {
                showQ = true;
            }
            if (col.gameObject.GetComponent<BoxCollider>())
            {                                
                Debug.Log("Triggered room 1");
                hintIndex = 1;
            }
            else if (col.gameObject.transform.parent)
            {
                Debug.Log("Triggered room 2") ;
                hintIndex = 2;
            }
            else if (col)
            {
                hintIndex = 3;
            }
            else if (col)
            {
                hintIndex = 4;
            }
            else if (col)
            {
                hintIndex = 5;
            }
        }

    }

}
