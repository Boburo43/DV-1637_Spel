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

    public GameObject door;
    public Transform dropPoint;
    public Transform dropPoint2;
    public Transform dropPoint3;
    public Transform dropPoint4;

    public bool right;

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
            door.SetActive(false);
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
                red.GetComponent<BoxCollider>().enabled = true;
                green.GetComponent<BoxCollider>().enabled = true;
                blue.GetComponent<BoxCollider>().enabled = true;
                white.GetComponent<BoxCollider>().enabled = true;
                red.transform.position = dropPoint.transform.position;
                green.transform.position = dropPoint2.transform.position;
                blue.transform.position = dropPoint3.transform.position;
                white.transform.position = dropPoint4.transform.position;

                gen.batteries.Clear();

                gen.slot1Taken = false;
                gen.slot2Taken = false;
                gen.slot3Taken = false;
                gen.slot4Taken = false;

                
            }
           
        }
    }
}
