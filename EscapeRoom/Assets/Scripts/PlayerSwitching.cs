using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitching : MonoBehaviour
{
    public Transform character;
    public List<Transform> characters;
    public int ActiveChar;

    private void Start()
    {
       
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(ActiveChar == 0)
            {
                ActiveChar = characters.Count + 1;
            }
            else if(ActiveChar == 1)
            { 
                ActiveChar = characters.Count - 1;
            }
        }
    }
}
