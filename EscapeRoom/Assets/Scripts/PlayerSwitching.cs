using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlayerSwitching : MonoBehaviour
{
 
    public int ActiveChar;

    public Transform FischCam;
    public Transform BarnyCam;
    public Transform Maincamera;

    public GameObject Fisch;
    public GameObject Barny;

    public bool camFollowFisch;
    private void Start()
    {
        camFollowFisch = true;
    }

    private void Update()
    {
        if (camFollowFisch == true)
        {
            Maincamera.transform.position = FischCam.transform.position;
            Fisch.GetComponent<PlayerMovement>().enabled = true;
            Barny.GetComponent<PlayerMovement>().enabled = false;
        }
        else if (camFollowFisch == false)
        { 
            Maincamera.position = BarnyCam.transform.position;
            Fisch.GetComponent<PlayerMovement>().enabled = false;
            Barny.GetComponent<PlayerMovement>().enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(ActiveChar == 0)
            {
                ActiveChar += 1;
                camFollowFisch = true;
            }
            else if(ActiveChar == 1)
            { 
                ActiveChar -= 1;
                camFollowFisch = false;
            }
        }
    }
}
