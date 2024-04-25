using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurserScrip : MonoBehaviour
{

    public static CurserScrip instance;

    public Texture2D sprite;
    public GameObject croshair;

     public static bool cursurActive;

    // Update is called once per frame
    void Update()
    {
        Debug.Log(cursurActive);
        Cursor.SetCursor(sprite, Vector3.zero, CursorMode.ForceSoftware);
        if(cursurActive)
        {
            Cursor.visible = true;
            croshair.SetActive(false);
        }
        else if (!cursurActive)
        {
            Cursor.visible=false;
            croshair.SetActive(true);
        }
    }


    
    
}
