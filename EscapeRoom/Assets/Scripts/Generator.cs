using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Generator : MonoBehaviour
{
    //Trigger framför som kollar om item finns, lerpar till rätt postiotion
    //Bools för att kolla vilka platser som finns

    [SerializeField] private Transform slot1;
    [SerializeField] private Transform slot2;
    [SerializeField] private Transform slot3;
    [SerializeField] private Transform slot4;

    private bool slot1Taken;
    private bool slot2Taken;
    public bool slot3Taken;
    public bool slot4Taken;



    public List<GameObject> batteries;

    private void Start()
    {
        batteries = new List<GameObject>();
        slot1Taken = false;
        slot2Taken = false;
        slot3Taken = false;
        slot4Taken = false;
    }


    private void Update()
    {
        if (slot1Taken)
        {
            batteries[0].transform.position = slot1.transform.position;
            batteries[0].transform.rotation = slot1.transform.rotation;
            batteries[0].GetComponent<BoxCollider>().enabled = false;
        }
        if (slot2Taken)
        {
            batteries[1].transform.position = slot2.transform.position;
            batteries[1].transform.rotation = slot2.transform.rotation;
            batteries[1].GetComponent<BoxCollider>().enabled = false;
        }
        if(slot3Taken)
        {
            batteries[2].transform.position = slot3.transform.position;
            batteries[2].transform.rotation = slot3.transform.rotation;
            batteries[2].GetComponent<BoxCollider>().enabled = false;
        }
        if (slot4Taken)
        {
            batteries[3].transform.position = slot4.transform.position;
            batteries[3].transform.rotation = slot4.transform.rotation;
            batteries[3].GetComponent<BoxCollider>().enabled = false;
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Grabbable"))
        {
            batteries.Add(other.gameObject);
            Debug.Log("Ye");
            if (slot1Taken == false)
            {
                slot1Taken = true;
                Debug.Log("Slot1");
            }
            else if (slot2Taken == false)
            {
                
                slot2Taken = true;
            }
            else if (slot3Taken == false)
            {

                slot3Taken = true;
            }
            else if (slot4Taken == false)
            {
               
                slot4Taken = true;
            }
            else Debug.Log("Worng");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Grabbable"))
        {
            batteries.Remove(other.gameObject);
            if (slot4Taken == true)
            {
                slot4Taken = false;
            }
            else if (slot3Taken == true)
            {
                slot3Taken = false;
            }
            else if (slot2Taken == true)
            {
                slot2Taken = false;
            }
            else if (slot1Taken == true)
            {
                slot1Taken = false;
            }
            else Debug.Log("wack");
        }
    }
}

