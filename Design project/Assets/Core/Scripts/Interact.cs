using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IInteractable
{
    void Interact();
    bool Equip
    {
        get;
    }
    GameObject Gameobject
    {
        get;
    }
    Sprite Icon
    {
        get;
    }
}

public class Interact : MonoBehaviour
{
    #region Variables
    string objectName = "";
    bool interact;
    float interactRange = 3;
    IInteractable interactObject;
    RaycastHit hit;
    GameObject interactIcon;
    Transform Camera;
    #endregion
    // Use this for initialization
    void Start()
    {
        interactIcon = GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(0).gameObject;
        Camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
        InteractActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Uses spherecast (wider raycast) to detect if we're looking at something we can interact with
        if (Physics.SphereCast(Camera.position,0.2f,Camera.forward, out hit, interactRange))
        {
            //If its interactable, show that we can interact with it
            if (hit.transform.tag == "Interactable" && objectName != hit.transform.name)
            {
                InteractActive(true);
            }//If we can't interact with it, this makes sure the player knows.
            else if(hit.transform.tag != "Interactable")
            {
                InteractActive(false);
            }
        }
        else //If we don't hit anything, we can't interact.
        {
            if (interact)
                InteractActive(false);
        }
        //If we're looking at something that we can interact with and we press 'E', we interact with it. 
        if(interact && Input.GetKeyDown(KeyCode.E))
        {
            interactObject.Interact();
        }
        
    }

    void InteractActive(bool active) //Toggles if interact-mode is active or not.
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
