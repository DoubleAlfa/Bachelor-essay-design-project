using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDoors : Interactable,IInteractable {

    [SerializeField]
    bool locked;
    [SerializeField]
    bool toOtherFloor;
    [SerializeField]
    string code;
    [SerializeField]
    AudioClip close;
    [SerializeField]
    AudioClip open;
    [SerializeField]
    AudioClip notOpen;
    [SerializeField]
    AudioClip unlocked;
    Inventory inv;
    AudioSource audio;
    Animation anim;
    BoxCollider coll;
    Renderer[] rends;
    Color[] startColors;
    bool isOpen;
    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        audio = GetComponent<AudioSource>();
        if (rend == null)
        {
            rends = GetComponentsInChildren<Renderer>();
            startColors = new Color[rends.Length];
            for (int i = 0; i < rends.Length; i++)
            {
                startColors[i] = rends[i].material.color;
            }
        }
        coll = GetComponent<BoxCollider>();
        anim = GetComponent<Animation>();
        inv = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).GetChild(0).GetComponent<Inventory>();
    }


    public void Interact()
    {
        if (!anim.isPlaying)
        {
            if (locked) //The door is locked
            {
                if (hasKeyCard(inv.PlayerInventory))
                {
                    audio.clip = unlocked;
                    locked = false;
                }
                else
                {
                    audio.clip = notOpen;
                }

                audio.Play();
            }
            else //What to do if the door is open
            {
                if (toOtherFloor)
                {

                }
                else //Opens or closes the door 
                {
                    if (!isOpen)
                    {
                        audio.clip = open;
                        anim.Play("DoubleDoorOpen");
                        //coll.enabled = false;
                    }
                    else
                    {
                        audio.clip = close;
                        anim.Play("DoubleDoorClose");
                    }
                    audio.Play();
                    isOpen = !isOpen;
                }
            }
        }

    }
    public override bool Highlight(bool active) //Handles if the door should be highlighted in green, red or not at all.
    {
        if (anim.isPlaying)
        {
            for (int i = 0; i < rends.Length; i++)
            {
                rends[i].material.color = startColors[i];
            }
            return false;
        }

        if (active)
        {
            if (!locked || hasKeyCard(inv.PlayerInventory))
            {
                for (int i = 0; i < rends.Length; i++)
                {
                    rends[i].material.color = Color.green;
                }
            }
                
            else
            {
                for (int i = 0; i < rends.Length; i++)
                {
                    rends[i].material.color = Color.red;
                }
            }
        }
        else
        {
            for (int i = 0; i < rends.Length; i++)
            {
                rends[i].material.color = startColors[i];
            }
        }
        return true;

    }

    bool hasKeyCard(List<GameObject> inventory) //Returns true if the player has a keycard.
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
