using System.Collections;
using System.Collections.Generic;
using UnityEngine;


interface IInteractable
{
    public void Interact();
}
public class Interactable : MonoBehaviour
{

    public Transform InteractSource;
    private float range = 2.5f;
    private void Update()
    {
        Debug.DrawLine(InteractSource.position, InteractSource.forward, Color.green);
        if(Input.GetKeyDown(KeyCode.E))
        {
            Ray r = new Ray(InteractSource.position, InteractSource.forward);
            if(Physics.Raycast(r, out RaycastHit hitinfo, range))
            {
                if(hitinfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    interactObj.Interact();
                }
            }
        }
    }
}
