using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractTest : Interactable, IInteractable
{
    float counter;
    bool spin;


    public GameObject Gameobject
    {
        get { return gameObject; }
    }
    
    
    void Update()
    {
        if(spin)
        {
            print("EYEYEYE");
            transform.Rotate(Vector3.up * Time.deltaTime * 50);
            counter += Time.deltaTime * 50;
            if(counter >= 90)
            {
                spin = false;
                transform.Rotate(Vector3.down * (counter - 90));
                counter = 0;
                tag = "Interactable";
            }
        }
    }
	public void Interact()
    {
        print("JAHAAA!");
        if(!spin)
        {
            spin = true;
            tag = "Untagged";
        }
    }


}
