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
    Animation closeAnim;
    BoxCollider[] coll;
    bool isOpen;
    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        audio = GetComponent<AudioSource>();
        if (rend == null)
        {
            rend = GetComponentInChildren<Renderer>();
            startColor = rend.material.color;
        }
        anim = GetComponent<Animation>();
        closeAnim = transform.GetChild(0).GetComponent<Animation>();
        coll = GetComponents<BoxCollider>();
        coll[1].enabled = false;
        inv = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).GetChild(0).GetComponent<Inventory>();
    }


    public void Interact()
    {
        if (!anim.isPlaying && !closeAnim.isPlaying)
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
                else //Opens the door
                {
                    if (!isOpen)
                    {
                        audio.clip = open;
                        anim.Play();
                    }
                    else
                    {
                        audio.clip = close;
                        closeAnim.Play();
                    }
                    audio.Play();
                    isOpen = !isOpen;
                    for (int i = 0; i < coll.Length; i++)
                    {
                        coll[i].enabled = !coll[i].enabled;
                    }
                }
            }
        }

    }
    public override bool Highlight(bool active)
    {
        if (anim.isPlaying || closeAnim.isPlaying)
        {
            print("PLAYING");
            rend.material.color = startColor;
            return false;
        }

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
        return true;

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
