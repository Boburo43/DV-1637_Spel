using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Hints : MonoBehaviour
{
    [SerializeField] private GameObject qHint;
    public bool showQ = true;

    // Start is called before the first frame update
    void Start()
    {
        qHint.SetActive(false);
    }
    void OnTriggerStay(Collider col)
    {
        if (showQ)
        {
            qHint.SetActive(true);
            if(Input.GetKey(KeyCode.Q))
            {
                showQ = false;
            }
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
