using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable, IInteractable
{

    [SerializeField]
    bool locked;
    [SerializeField]
    bool toOtherFloor;
    [SerializeField]
    string code;
    [SerializeField]
    AudioClip notOpen;
    [SerializeField]
    AudioClip open;
    [SerializeField]
    AudioClip unlocked;
    Inventory inv;
    AudioSource audio;


    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        audio = GetComponent<AudioSource>();
        inv = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).GetChild(0).GetComponent<Inventory>();
    }


    public void Interact()
    {
        if (locked) //The door is locked
        {
            if (hasKeyCard(inv.PlayerInventory))
            {
                audio.clip = unlocked;
                locked = false;
            }
            else
                audio.clip = notOpen;
            audio.Play();
        }
        else //What to do if the door is open
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
            if (inventory[0].name.Length >= 7 && inventory[0].name.Substring(0, 7) == "KeyCard")
            {
                if (inventory[0].GetComponent<Keycard>().ToDoor == code)
                    return true;
            }
        }
        return false;
    }
}
