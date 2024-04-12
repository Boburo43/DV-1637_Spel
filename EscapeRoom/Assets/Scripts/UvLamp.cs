using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class UvLamp : MonoBehaviour, IInteractable
{

    public bool lampOn = false;
    public GameObject text;
    public GameObject redLight;

    public PlayerSwitching pS;

    public void Interact()
    {
        if (lampOn == false)
        {
            redLight.SetActive(true);
            lampOn = true;
        }
        else
        {
            redLight.SetActive(false);
            text.SetActive(false);
            lampOn = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (lampOn == true)
        {
            if (pS.camFollowFisch == false)
            {
                text.SetActive(true);
            }
        }
        
    }
}
