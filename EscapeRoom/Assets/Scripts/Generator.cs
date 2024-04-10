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
    private bool slot3Taken;
    private bool slot4Taken;

    public List<GameObject> gameObjects;

    private void Start()
    {
        gameObjects = new List<GameObject>();
        slot1Taken = false;
        slot2Taken = false;
        slot3Taken = false;
        slot4Taken = false;
    }


    private void Update()
    {






        if (slot1Taken)
        {
            gameObjects[0].transform.position = slot1.transform.position;
            gameObjects[0].transform.rotation = slot1.transform.rotation;
            gameObjects[0].GetComponent<BoxCollider>().enabled = false;
        }
        if (slot2Taken)
        {
            gameObjects[1].transform.position = slot2.transform.position;
            gameObjects[1].transform.rotation = slot2.transform.rotation;
            gameObjects[1].GetComponent<BoxCollider>().enabled = false;
        }
        if(slot3Taken)
        {
            gameObjects[2].transform.position = slot3.transform.position;
            gameObjects[2].transform.rotation = slot3.transform.rotation;
            gameObjects[2].GetComponent<BoxCollider>().enabled = false;
        }
        if (slot4Taken)
        {
            gameObjects[3].transform.position = slot4.transform.position;
            gameObjects[3].transform.rotation = slot4.transform.rotation;
            gameObjects[3].GetComponent<BoxCollider>().enabled = false;
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Grabbable"))
        {
            gameObjects.Add(other.gameObject);
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
            gameObjects.Remove(other.gameObject);
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

