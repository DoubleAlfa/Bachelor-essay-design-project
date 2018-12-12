using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable, IInteractable {

    [SerializeField]
    bool locked;
    Inventory inv;
	// Use this for initialization
	void Start ()
    {
        inv = GameObject.FindGameObjectWithTag("Player");	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Interact()
    {

    }
    public override void Highlight(bool active)
    {
        if (active)
        {
            if (!locked)
                rend.material.color = Color.green;
            else if()
            else
            {
                rend.material.color = Color.red;
            }
        }
        else
            rend.material.color = startColor;
    }
}
