using UnityEngine;
using UnityEngine.Rendering;

public class GeneratorButton : MonoBehaviour, IInteractable
{

    public Generator gen;

    public GameObject red;
    public GameObject green;
    public GameObject blue;
    public GameObject white;

    public Animator anim;

    public GameObject doorF;
    public GameObject doorB;
    public Transform dropPoint;
    public Transform dropPoint2;
    public Transform dropPoint3;
    public Transform dropPoint4;

    private bool right;
    private bool openDoor;

    private Vector3 doorFClosedPosition;
    private Vector3 doorBClosedPosition;
    private Vector3 doorFOpenPosition;
    private Vector3 doorBOpenPosition;
    private float transitionSpeed = 3f;


    private void Start()
    {
        doorFClosedPosition = doorF.transform.position;
        doorBClosedPosition = doorB.transform.position;
        doorFOpenPosition = doorFClosedPosition + new Vector3(-3f, 0, 0);
        doorBOpenPosition = doorBClosedPosition + new Vector3(-3f, 0, 0);
        openDoor = false;
    }

    private void Update()
    {
        if(openDoor)
        {
            doorF.transform.position = Vector3.Lerp(doorF.transform.position, doorFOpenPosition, Time.deltaTime * transitionSpeed);
            doorB.transform.position = Vector3.Lerp(doorB.transform.position, doorBOpenPosition, Time.deltaTime * transitionSpeed);
        }
    }
    public void CheckRight()
    {
        if (gen.slot3Taken)
        {
            if (gen.batteries[0] == red)
            {
                if (gen.batteries[1] == green)
                {
                    if (gen.batteries[2] == blue)
                    {
                        right = true;                    
                    }
                }
            }
        }
    }


    public void Interact()
    {
        CheckRight();
        anim.SetTrigger("Press");
        if(right == true)
        {
            openDoor = true;
        }
        else if(right == false)
        {
            if (gen.batteries.Count == 3)
            {

                red.GetComponent<Rigidbody>().isKinematic = true;
                blue.GetComponent<Rigidbody>().isKinematic = true;
                green.GetComponent<Rigidbody>().isKinematic = true;

                red.transform.position = dropPoint.transform.position;
                green.transform.position = dropPoint2.transform.position;
                blue.transform.position = dropPoint3.transform.position;

                red.GetComponent<BoxCollider>().enabled = true;
                green.GetComponent<BoxCollider>().enabled = true;
                blue.GetComponent<BoxCollider>().enabled = true;

                red.GetComponent<Rigidbody>().isKinematic = false;
                blue.GetComponent<Rigidbody>().isKinematic = false;
                green.GetComponent<Rigidbody>().isKinematic = false;

                gen.batteries.Clear();

                gen.slot1Taken = false;
                gen.slot2Taken = false;
                gen.slot3Taken = false;





                
               
            }
            else if(gen.batteries.Count == 4)
            {
                red.GetComponent<Rigidbody>().isKinematic = true;
                blue.GetComponent<Rigidbody>().isKinematic = true;
                green.GetComponent<Rigidbody>().isKinematic = true;
                white.GetComponent<Rigidbody>().isKinematic= true;


                red.transform.position = dropPoint.transform.position;
                green.transform.position = dropPoint2.transform.position;
                blue.transform.position = dropPoint3.transform.position;
                white.transform.position = dropPoint4.transform.position;

                red.GetComponent<BoxCollider>().enabled = true;
                green.GetComponent<BoxCollider>().enabled = true;
                blue.GetComponent<BoxCollider>().enabled = true;
                white.GetComponent<BoxCollider>().enabled = true;

                red.GetComponent<Rigidbody>().isKinematic = false;
                blue.GetComponent<Rigidbody>().isKinematic = false;
                green.GetComponent<Rigidbody>().isKinematic = false;
                white.GetComponent<Rigidbody>().isKinematic = false;

                gen.batteries.Clear();

                gen.slot1Taken = false;
                gen.slot2Taken = false;
                gen.slot3Taken = false;
                gen.slot4Taken = false;

                
            }
           
        }
    }
}
