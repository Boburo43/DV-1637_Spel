using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform orientation;
    public float sensX = 400f;
    public float sensY = 400f;


    float rotaionX;
    public float rotaionY;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Mouse X") * sensX * Time.deltaTime;
        float inputY = Input.GetAxis("Mouse Y") * sensY * Time.deltaTime;

        rotaionY += inputX;
        rotaionX -= inputY;

        rotaionX = Mathf.Clamp(rotaionX, -90f, 90f);

        transform.rotation = Quaternion.Euler(rotaionX, rotaionY, 0);
        orientation.rotation = Quaternion.Euler(0, rotaionY, 0);
    }
}
