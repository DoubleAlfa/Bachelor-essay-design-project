using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    void Interact();
}

public class Interact : MonoBehaviour
{
    RaycastHit hit;
    IInteractable interactObject;
    string objectName = "";
    bool interact;
    GameObject interactIcon;
    Transform Camera;
    // Use this for initialization
    void Start()
    {
        interactIcon = GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(0).gameObject;
        Camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Physics.Raycast(Camera.position, Camera.forward, out hit, int.MaxValue))
        {
            
            if (hit.transform.tag == "Interactable" && objectName != hit.transform.name)
            {
                InteractActive(true);
            }
            else if(hit.transform.tag != "Interactable")
            {
                InteractActive(false);
            }
        }
        if(interact && Input.GetKeyDown(KeyCode.E))
        {
            interactObject.Interact();
        }

    }

    void InteractActive(bool active)
    {
        interact = active;
        if (active)
        {
            interactObject = hit.transform.GetComponent<IInteractable>();
            objectName = hit.transform.name;
        }
        else
        {
            objectName = "";
        }
        interactIcon.SetActive(active);
    }
}
