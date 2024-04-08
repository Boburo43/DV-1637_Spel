using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlayerSwitching : MonoBehaviour
{
 
    private int ActiveChar = 1;

    public Transform FischCam;
    public Transform BarnyCam;
    public Transform Maincamera;

    public GameObject Fisch;
    public GameObject Barny;
    public bool camFollowFisch;

    public Animator CrossFade;
    private void Start()
    {
        camFollowFisch = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(Switch(0.5f));
        }
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

    }

    private IEnumerator Switch(float delay)
    {
        CrossFade.SetTrigger("Switch");

        yield return new WaitForSeconds(delay);
        if (ActiveChar == 0)
        {
            ActiveChar += 1;
            camFollowFisch = true;
        }
        else if (ActiveChar == 1)
        {

            ActiveChar -= 1;
            camFollowFisch = false;
        }

    }
}
