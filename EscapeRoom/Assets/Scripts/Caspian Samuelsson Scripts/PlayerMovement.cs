using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody rb;
    float speed = 10f;
    float horizontalAxis;
    float verticalAxis;

    //public Transform orieniton;

    public Cam Camera;
    public LayerMask collisionMask; // Define which layers should be checked for collision
    public float collisionRadius = 0.5f; // Radius for the SphereCast
    public float checkDistance = 1f; // How far 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }
    
    private void FixedUpdate()
    {   
    
        verticalAxis = Input.GetAxis("Vertical");
        horizontalAxis = Input.GetAxis("Horizontal");

        Vector3 camFor = Camera.transform.forward;
        Vector3 camRight = Camera.transform.right;

        camFor.y = 0;
        camRight.y = 0;

        Vector3 forwardRelative = verticalAxis * camFor;
        Vector3 rightRelative = horizontalAxis * camRight;

        Vector3 moveDir = forwardRelative + rightRelative; 

        Vector3 dir = new Vector3(moveDir.x, rb.velocity.y, moveDir.z);

        Debug.DrawRay(transform.position, dir);
        if (dir.magnitude > 1)
        {
            dir.Normalize();
        } 
        
            transform.position += dir * speed * Time.fixedDeltaTime;
            transform.rotation = Quaternion.Euler(0, Camera.transform.eulerAngles.y, 0); 
    }
}
