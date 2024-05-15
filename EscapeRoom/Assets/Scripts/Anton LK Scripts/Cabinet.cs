using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabinet : MonoBehaviour, IInteractable
{

    [SerializeField] private GameObject door;

    public float open;
    public float close;
    public float speed;

    public bool pressed;



    private void Start()
    {
        pressed = false;
    }
    private void Update()
    {
        Vector3 currentRot = door.transform.localEulerAngles;
        
        if(pressed)
        {
            if(currentRot.y < open)
            {
                door.transform.localEulerAngles = Vector3.Lerp(currentRot, new Vector3(currentRot.x, open, currentRot.z), speed * Time.deltaTime);
            }
        }
        else if(!pressed)
        {
             if(currentRot.y > close)
                {
                door.transform.localEulerAngles = Vector3.Lerp(currentRot, new Vector3(currentRot.x, close, currentRot.z), speed * Time.deltaTime);
                }
        }
    }
    public void Interact()
    {
        if(!pressed)
        {
            pressed = true;
        }
        else if (pressed)
        {
            pressed = false;
        }
    }
}
