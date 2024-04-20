using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CombiantionLock : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject canvas;

    public GameObject cam;

    private bool isActive;

    [SerializeField] GameObject door;
    private Vector3 doorClosedPosition;
    private Vector3 doorOpenPosition;
    private float transitionSpeed = 3f;

    public int buttonPressed;
    public string code = "";
    public string atemptedCode = "";
    public TMP_Text codeText;


    void Start()
    {
        canvas.SetActive(false);
        doorClosedPosition = door.transform.position;
        doorOpenPosition = doorClosedPosition + new Vector3(-5f, 0, 0);
        buttonPressed = 0;
        isActive = false;
    }

    private void Update()
    {
       
        if(isActive)
        {
            cam.GetComponent<Cam>().enabled = false;
            Cursor.visible = true;
        }
        else if(!isActive)
        {
            Cursor.visible = false;
            cam.GetComponent<Cam>().enabled = true;
            canvas.SetActive(false);
        }
        if(buttonPressed == 4)
        {
            CheckCode();           
        }   
    }

    public void Interact()
    {
        if(!isActive)
        {
            isActive = true;
            canvas.SetActive(true);
        }
        else if(isActive)
        {
            isActive = false;
            canvas.SetActive(false);
        }
    }

    public void PressedButton(string buttons)
    {
        buttonPressed += 1;
        atemptedCode = atemptedCode + buttons;
        codeText.text = atemptedCode;
    }
    public void CheckCode()
    {
        if(atemptedCode == code)
        {
            door.transform.position = Vector3.Lerp(door.transform.position, doorOpenPosition, Time.deltaTime * transitionSpeed);
            atemptedCode = "";
            buttonPressed = 0;
            isActive = false;
        }
        else if(atemptedCode != code)
        {
            atemptedCode = "";
            buttonPressed = 0;
        }
    }
}
