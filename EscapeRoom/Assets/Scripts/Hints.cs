using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Hints : MonoBehaviour
{
    [SerializeField] private GameObject qHint;
    bool showQ = false;
    bool showH = false;

    // Start is called before the first frame update
    void Start()
    {
        qHint.SetActive(false);
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
    }
    private void OnTriggerEnter(Collider col)
    {
        if (!showH)
        {
            showQ = true;
        }
    }
}
