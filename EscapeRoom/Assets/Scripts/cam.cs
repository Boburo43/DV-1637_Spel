using UnityEngine;
using System.Collections;

public class Cam : MonoBehaviour
{
    private float x;
    private float y;
    
    private float vertSens = 2f;
    private float horiSens = 2f;

    

    void Update()
    {
        y += vertSens * Input.GetAxis("Mouse X");
        x -= horiSens * Input.GetAxis("Mouse Y");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        x = Mathf.Clamp(x, -65, 65);
        
        transform.eulerAngles = new Vector3(x, y, 0);
    }
}
