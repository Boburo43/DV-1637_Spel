using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CombiantionLock : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject canvas;
    public GameObject Fisch;
    public GameObject Barny;
    [SerializeField] private PlayerSwitching ps;

    public GameObject cam;

    public static bool isActive;
    private bool isRight;

    [SerializeField] GameObject door;
    private Vector3 doorClosedPosition;
    private Vector3 doorOpenPosition;
    private float transitionSpeed = 3f;


    const string numbers = "0123456789";
    public int buttonPressed;
    public string code = "";
    public string atemptedCode = "";
    public TMP_Text codeText;

    public TMP_Text codeHint;
    void Start()
    {
        int charAmount = Random.Range(4, 4);
        for (int i = 0; i < charAmount; i++)
        {
            code += numbers[Random.Range(0, numbers.Length)];
        }

        canvas.SetActive(false);
        doorClosedPosition = door.transform.position;
        doorOpenPosition = doorClosedPosition + new Vector3(-3f, 0, 0);
        buttonPressed = 0;
        isActive = false;
        isRight = false;
    }

    private void Update()
    {
        codeHint.text = code;
        if (isActive)
        {
            cam.GetComponent<Cam>().enabled = false;
            CurserScrip.cursurActive = true;
            if(ps.camFollowFisch)
            {
                Fisch.GetComponent<PlayerMovement>().enabled = false;
            }
            else if(!ps.camFollowFisch)
            {
                Barny.GetComponent<PlayerMovement>().enabled = false;
          
            }
            
        }
        else if(!isActive)
        {
            CurserScrip.cursurActive = false;
            cam.GetComponent<Cam>().enabled = true;
            canvas.SetActive(false);
            if (ps.camFollowFisch)
            {
                Fisch.GetComponent<PlayerMovement>().enabled = true;
            }
            if (!ps.camFollowFisch)
            {
                Barny.GetComponent<PlayerMovement>().enabled = true;
            }
        }
        if(buttonPressed == 4)
        {
            CheckCode();           
        }   
        if(isRight)
        {
            door.transform.position = Vector3.Lerp(door.transform.position, doorOpenPosition, Time.deltaTime * transitionSpeed);
        }
    }

    public void Interact()
    {
        if(isActive == false)
        {
            isActive = true;
            canvas.SetActive(true);
        }
        else if(isActive == true)
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
        FindObjectOfType<AudioManager>().PlaySound("ButtonPressed");
    }
    public void CheckCode()
    {
        if(atemptedCode == code)
        {
            FindObjectOfType<AudioManager>().PlaySound("RightCode");
            isRight = true;
            atemptedCode = "";
            buttonPressed = 4;
            isActive = false;
            
        }
        else if(atemptedCode != code)
        {
            FindObjectOfType<AudioManager>().PlaySound("WrongCode");
            atemptedCode = "";
            buttonPressed = 0;
            
        }
    }
}
