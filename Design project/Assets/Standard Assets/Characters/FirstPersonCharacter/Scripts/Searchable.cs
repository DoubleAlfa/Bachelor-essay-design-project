using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Searchable : Interactable, IInteractable
{
    Inventory inv;
    AudioSource audio;
    Hint h;
    [SerializeField] AudioClip failure;
    [SerializeField] GameObject keyCard;
    [SerializeField] int hintNr;

    protected override void Start()
    {
        base.Start();
        h = FindObjectOfType<Hint>();
        inv = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        audio = gameObject.AddComponent<AudioSource>();
    }

    public void Interact()
    {
        if (keyCard != null)
        {
            h.NextHint(hintNr);
            inv.AddItem(keyCard);
            keyCard = null;
        }
        else
        {
            audio.clip = failure;
            audio.Play();
        }


    }


}
