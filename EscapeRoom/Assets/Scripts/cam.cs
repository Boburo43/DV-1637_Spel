using UnityEngine;
using System.Collections;

public class Cam : MonoBehaviour
{
    public float x;
    public float y;
    
    private float vertSens = 2f;
    private float horiSens = 2f;
    

    void Update()
    {
        y += vertSens * Input.GetAxis("Mouse X");
        x -= horiSens * Input.GetAxis("Mouse Y");
        Cursor.lockState = CursorLockMode.Confined;

        x = Mathf.Clamp(x, -65, 65);
        
        transform.eulerAngles = new Vector3(x, y, 0);
    }
}
