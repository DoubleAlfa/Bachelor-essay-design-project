using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable, IInteractable {

    [SerializeField]
    bool locked;
    [SerializeField]
    string code;
    [SerializeField]
    AudioClip notOpen;
    [SerializeField]
    AudioClip Open;
    Inventory inv;

    
	// Use this for initialization
	protected override void Start ()
    {
        base.Start();
        inv = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).GetChild(0).GetComponent<Inventory>();
    }
	
	
    public void Interact()
    {
        if(locked)
        {
            
        }
    }
    public override void Highlight(bool active)
    {
        if (active)
        {
            if (!locked || hasKeyCard(inv.PlayerInventory))
                rend.material.color = Color.green;
            else
            {
                rend.material.color = Color.red;
            }
        }
        else
            rend.material.color = startColor;
    }

    bool hasKeyCard(List<GameObject> inventory)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if(inventory[0].name.Length >=7 &&inventory[0].name.Substring(0,7) == "KeyCard")
            {
                if (inventory[0].GetComponent<Keycard>().ToDoor == code)
                    return true;
            }
        }
        return false;
    }
}
