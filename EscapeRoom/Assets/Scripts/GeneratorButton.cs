using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorButton : MonoBehaviour, IInteractable
{

    public Generator gen;

    public GameObject red;
    public GameObject green;
    public GameObject blue;
    public GameObject white;

    public Animator anim;

    public GameObject door;

    private void Update()
    {
        if (gen.slot3Taken || gen.slot4Taken)
        {
            if (gen.batteries[0] = red)
            {
                if (gen.batteries[1] = green)
                {
                    if (gen.batteries[2] = blue)
                    {
                        door.SetActive(false);
                    }
                }
            }
        }
    }

    public void Interact()
    {
        anim.SetTrigger("Press");
        Debug.Log("Press button");
    }
}
