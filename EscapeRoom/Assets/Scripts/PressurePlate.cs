using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{

    [SerializeField] GameObject door;
    [SerializeField] GameObject plate;
    bool isOpened = false;
    void Start()
        {

        }

    void OnTriggerEnter(Collider col)
    {
        if (isOpened == false)
        {
            door.transform.position += new Vector3(0, 0, 3f);
            plate.transform.position += new Vector3(0, -0.06f, 0);
            isOpened = true;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (isOpened == true)
        {
            door.transform.position += new Vector3(0, 0, -3f);
            plate.transform.position += new Vector3(0, +0.06f, 0);
            isOpened = false;
        }
    }
    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
